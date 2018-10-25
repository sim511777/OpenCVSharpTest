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
using ShimLib;

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

      public void Log(string text) {
         this.tbxLog.AppendText(text + Environment.NewLine);
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
            var bmpOld = pbx.DrawingImage;
            var bmpSrc = bmp;
            pbx.DrawingImage = bmpSrc;
            pbx.Invalidate();
            if (bmpOld != null)
                bmpOld.Dispose();
        }

        public FormMain() {
            FormMain.form = this;
            InitializeComponent();
            this.cbxExampleImage.SelectedIndex = 0;
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
            if (this.pbxDst.DrawingImage == null || x < 0 || x >= this.pbxDst.DrawingImage.Width || y < 0 || y >= this.pbxDst.DrawingImage.Height)
                col = Color.Black;
            else
                col = this.pbxDst.DrawingImage.GetPixel(x, y);
            int avg = (col.R + col.G + col.B) / 3;
            Brush br = (avg > 128) ? Brushes.Blue : Brushes.Yellow;
            return Tuple.Create(avg.ToString(), br);
        }

        private void btnExample_Click(object sender, EventArgs e) {
            if (this.cap != null) {
                this.StopLive();
            }
            
            var oldTime = DateTime.Now;

            if (this.matSrc != null)
                this.matSrc.Dispose();
            this.matSrc = ((Bitmap)Resources.ResourceManager.GetObject(this.cbxExampleImage.Text)).ToMat();
            this.lblGrabTime.Text = $"grab time: {(DateTime.Now - oldTime).TotalMilliseconds}ms";

            this.ProcessImage();

            this.pbxSrc.ZoomToImage();
            this.pbxDst.ZoomToImage();
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

            this.pbxSrc.ZoomToImage();
            this.pbxDst.ZoomToImage();
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

            this.pbxSrc.ZoomToImage();
            this.pbxDst.ZoomToImage();
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
            this.timer1.Enabled = true;
            this.btnLive.Text = "Live Stop";
            this.pbxSrc.ZoomToRect(0, 0, this.cap.FrameWidth, this.cap.FrameHeight);
            this.pbxDst.ZoomToRect(0, 0, this.cap.FrameWidth, this.cap.FrameHeight);
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
            this.pbxSrc.ZoomReset();
            this.pbxDst.ZoomReset();
        }

        private void btnFitZoom_Click(object sender, EventArgs e) {
            this.pbxSrc.ZoomToImage();
            this.pbxDst.ZoomToImage();
        }

        private void cbxTest_SelectedIndexChanged(object sender, EventArgs e) {
            var mii = this.cbxFunc.SelectedItem as MethodInfoItem;
            var mi = mii.MethodInfo;
            var paramInfos = mi.GetParameters();
            CustomClass cs = new CustomClass();
            foreach (var pi in paramInfos) {
                string itemName = pi.Name;
                object itemValue = pi.HasDefaultValue ? pi.DefaultValue : Activator.CreateInstance(pi.ParameterType);
                Type itemType = pi.ParameterType;
                bool itemReadOnly = false;
                bool itemVisible = true;
                string itemDescription = pi.ParameterType.Name;
                string itemCategory = "Parameter";
                CustomProperty cp = new CustomProperty(itemName, itemValue, itemType, itemReadOnly, itemVisible, itemDescription, itemCategory);
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
