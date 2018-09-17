using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;
using OpenCVSharpTest.Properties;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using OpenCvSharp.Blob;
using System.Reflection;
using System.Collections;
using CvSize = OpenCvSharp.Size;
using CvPoint = OpenCvSharp.Point;

namespace OpenCVSharpTest {
    public partial class FormMain : Form {
        public static FormMain form;

        public Mat matSrc = null;

        private void DrawHistogram(float[] histo, Series series, string name, Color color, AxisType yAxisTYpe = AxisType.Primary) {
            series.Name = name;
            series.Color = color;
            series.Points.Clear();
            series.YAxisType = yAxisTYpe;
            for (int i = 0; i < histo.Length; i++) {
                series.Points.AddXY(i, histo[i]);
            }
            series.Enabled = true;
        }

        public void DrawHistogram(Mat mat, Chart cht) {
            if (mat == null) {
                cht.Series[0].Enabled = false;
                cht.Series[1].Enabled = false;
                cht.Series[2].Enabled = false;
                return;
            }

            MatType matType = mat.Type();
            if (matType == MatType.CV_8UC1) {
                var histo = GetHistogram(mat, 0);
                float acc = 0;
                var histoAccum = histo.Select(val => acc += val).ToArray();
                DrawHistogram(histo, cht.Series[0], "Gray", Color.Black);
                DrawHistogram(histoAccum, cht.Series[1], "Accum", Color.Red, AxisType.Secondary);
                cht.Series[0].Enabled = true;
                cht.Series[1].Enabled = true;
                cht.Series[2].Enabled = false;
            } else if (matType == MatType.CV_8UC3 || matType == MatType.CV_8UC4) {
                var histR = GetHistogram(mat, 2);
                var histG = GetHistogram(mat, 1);
                var histB = GetHistogram(mat, 0);
                DrawHistogram(histR, cht.Series[0], "R", Color.Red);
                DrawHistogram(histG, cht.Series[1], "G", Color.Green);
                DrawHistogram(histB, cht.Series[2], "B", Color.Blue);
                cht.Series[0].Enabled = true;
                cht.Series[1].Enabled = true;
                cht.Series[2].Enabled = true;
            }
        }

        public float[] GetHistogram(Mat matSrc, int channel) {
            var images = new Mat[] { matSrc };
            var channels = new int[] { channel };
            InputArray mask = null;
            Mat hist = new Mat();
            int dims = 1;
            int width = matSrc.Cols, height = matSrc.Rows;
            const int histogramSize = 256;
            int[] histSize = { histogramSize };
            Rangef[] ranges = { new Rangef(0, histogramSize) };

            Cv2.CalcHist(images, channels, mask, hist, dims, histSize, ranges);
            var histo = new float[256];
            Marshal.Copy(hist.Data, histo, 0, 256);
            return histo;
        }

        public void DrawMat(Bitmap bmp, ZoomPictureBox pbx) {
            var bmpOld = pbx.Image;
            var bmpSrc = bmp;
            pbx.DrawImage = bmpSrc;
            pbx.Invalidate();
            if (bmpOld != null)
                bmpOld.Dispose();
        }

        public FormMain() {
            FormMain.form = this;
            InitializeComponent();
            this.InitFunctionList();
        }

        private void InitFunctionList() {
            var type = typeof(ImageProcessing);
            MethodInfo[] mis = type.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Static | BindingFlags.Public);
            var list = mis.Select((m, i) => new MethodInfoItem(i, m)).ToArray();
            this.cbxFunc.DisplayMember = "Display";
            this.cbxFunc.ValueMember = "MethodInfo";
            this.cbxFunc.Items.AddRange(list);
            if (this.cbxFunc.Items.Count > 0)
                this.cbxFunc.SelectedIndex = 0;
        }

        private Tuple<string, Brush> GetDstPixelValue(int x, int y) {
            Color col;
            if (this.pbxDst.DrawImage == null || x < 0 || x >= this.pbxDst.DrawImage.Width || y < 0 || y >= this.pbxDst.DrawImage.Height)
                col = Color.Black;
            else
                col = this.pbxDst.DrawImage.GetPixel(x, y);
            int avg = (col.R + col.G + col.B) / 3;
            Brush br = (avg > 128) ? Brushes.Blue : Brushes.Yellow;
            return Tuple.Create(avg.ToString(), br);
        }

        private void btnLenna_Click(object sender, EventArgs e) {
            if (this.cap != null) {
                this.StopLive();
            }

            var oldTime = DateTime.Now;

            if (this.matSrc != null)
                this.matSrc.Dispose();
            this.matSrc = Resources.Lenna.ToMat();
            this.lblGrabTime.Text = $"grab time: {(DateTime.Now - oldTime).TotalMilliseconds}ms";

            this.ProcessImage();
        }

        private void btnClipboard_Click(object sender, EventArgs e) {
            Image img = Clipboard.GetImage();
            if (img == null)
                return;

            if (this.cap != null) {
                this.StopLive();
            }

            var oldTime = DateTime.Now;

            if (this.matSrc != null)
                this.matSrc.Dispose();
            Bitmap bmp = new Bitmap(img);
            this.matSrc = bmp.ToMat();
            bmp.Dispose();
            this.lblGrabTime.Text = $"grab time: {(DateTime.Now - oldTime).TotalMilliseconds}ms";

            this.ProcessImage();
        }

        private void btnLoad_Click(object sender, EventArgs e) {
            if (this.dlgOpen.ShowDialog() != DialogResult.OK)
                return;

            if (this.cap != null) {
                this.StopLive();
            }

            var oldTime = DateTime.Now;

            if (this.matSrc != null)
                this.matSrc.Dispose();
            this.matSrc = new Mat(this.dlgOpen.FileName);
            this.lblGrabTime.Text = $"grab time: {(DateTime.Now - oldTime).TotalMilliseconds}ms";

            this.ProcessImage();
        }

        private void timer1_Tick(object sender, EventArgs e) {
            var oldTime = DateTime.Now;

            if (this.matSrc != null)
                this.matSrc.Dispose();
            this.matSrc = new Mat();
            this.cap.Read(matSrc);
            this.lblGrabTime.Text = $"grab time: {(DateTime.Now - oldTime).TotalMilliseconds}ms";

            this.ProcessImage();
        }

        private VideoCapture cap;

        private void btnLive_Click(object sender, EventArgs e) {
            if (this.cap == null) {
                this.StartLive();
            } else {
                this.StopLive();
            }
        }

        private void StartLive() {
            this.cap = new VideoCapture(0);
            //this.cap.FrameWidth = 1913;
            //this.cap.FrameHeight = 1080;
            this.timer1.Enabled = true;
            this.btnLive.Text = "Live Stop";
        }

        private void StopLive() {
            this.cap.Dispose();
            this.cap = null;
            this.timer1.Enabled = false;
            this.btnLive.Text = "Live";
        }

        // 이미지 처리
        private void ProcessImage() {
            if (this.matSrc == null)
                return;

            var oldTime = DateTime.Now;

            DrawMat(matSrc.ToBitmap(), this.pbxSrc);
            DrawHistogram(matSrc, this.chtSrc);

            var method = (this.cbxFunc.SelectedItem as MethodInfoItem)?.MethodInfo;
            var prmNameList = method.GetParameters().Select(prm => prm.Name);
            if (method != null) {
                try {
                    var cs = this.grdParameter.SelectedObject as CustomClass;
                    var prms = cs.Cast<CustomProperty>().Select(prop => prop.Value).ToArray();
                    object r = method.Invoke(this, prms);
                    this.lblLog.Text = $"{method.Name} Succeed:";
                } catch (TargetInvocationException ex) {
                    DrawMat(null, this.pbxDst);
                    DrawHistogram(null, this.chtDst);
                    this.lblLog.Text = $"{method.Name} Fail: {ex.InnerException.Message}";
                } catch (Exception ex) {
                    DrawMat(null, this.pbxDst);
                    DrawHistogram(null, this.chtDst);
                    this.lblLog.Text = $"{method.Name} Fail: {ex.Message}";
                }
            }

            this.lblProcessingTime.Text = $"IP time: {(DateTime.Now - oldTime).TotalMilliseconds}ms";
        }

        private void btnZoomReset_Click(object sender, EventArgs e) {
            this.pbxSrc.ResetZoom();
            this.pbxDst.ResetZoom();
        }

        private void btnFitZoom_Click(object sender, EventArgs e) {
            this.pbxSrc.FitZoom();
            this.pbxDst.FitZoom();
        }

        private void cbxTest_SelectedIndexChanged(object sender, EventArgs e) {
            var mii = this.cbxFunc.SelectedItem as MethodInfoItem;
            var mi = mii.MethodInfo;
            var paramInfos = mi.GetParameters();
            CustomClass cs = new CustomClass();
            foreach (var pi in paramInfos) {
                CustomProperty cp = new CustomProperty($"{pi.Name} : {pi.ParameterType.Name}", pi.HasDefaultValue ? pi.DefaultValue : Activator.CreateInstance(pi.ParameterType), pi.ParameterType, false, true);
                cs.Add(cp);
            }
            grdParameter.SelectedObject = cs;
            grdParameter.Refresh();

            this.ProcessImage();
        }

        private void grdParameter_PropertyValueChanged(object s, PropertyValueChangedEventArgs e) {
            this.ProcessImage();
        }
    }

    class MethodInfoItem {
        public string Display { get; set; }
        public MethodInfo MethodInfo { get; set; }
        public MethodInfoItem(int index, MethodInfo mi) {
            this.Display = $"{index+1}. {mi.Name}";
            this.MethodInfo = mi;
        }
    }
}
