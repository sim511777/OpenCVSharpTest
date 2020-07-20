﻿using System;
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
using System.Diagnostics;
using System.IO;
using System.Drawing.Imaging;
using ShimLib;

namespace OpenCVSharpTest {
    public partial class FormMain : Form {
        public FormMain() {
            InitializeComponent();
            
            var bmpNames = typeof(Properties.Resources).GetProperties(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).Where(pi => pi.PropertyType == typeof(Bitmap)).Select(pi => pi.Name);
            this.cbxExampleImage.Items.AddRange(bmpNames.ToArray());
            if (cbxExampleImage.Items.Count >= 1)
                cbxExampleImage.SelectedIndex = 0;

            Glb.form = this;
            Console.SetOut(new TextBoxWriter(this.tbxConsole));
            this.InitFunctionList();
        }

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

        public void DrawHistogram(Mat mat, Chart cht, bool labelHsv = false) {
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
                if (labelHsv == false) {
                    var histR = GetHistogram(mat, 2);
                    var histG = GetHistogram(mat, 1);
                    var histB = GetHistogram(mat, 0);
                    DrawHistogram(histR, cht.Series[0], "R", Color.Red);
                    DrawHistogram(histG, cht.Series[1], "G", Color.Green);
                    DrawHistogram(histB, cht.Series[2], "B", Color.Blue); 
                } else {
                    var histH = GetHistogram(mat, 0);
                    var histS = GetHistogram(mat, 1);
                    var histV = GetHistogram(mat, 2);
                    DrawHistogram(histH, cht.Series[0], "H", Color.Red);
                    DrawHistogram(histS, cht.Series[1], "S", Color.Green);
                    DrawHistogram(histV, cht.Series[2], "V", Color.Blue); 
                }
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

        // Load Bitmap to buffer
        public unsafe static void MatToImageBuffer(Mat mat, ref IntPtr imgBuf, ref int bw, ref int bh, ref int bytepp, ref bool isFloat) {
            bw = mat.Width;
            bh = mat.Height;
            bytepp = (int)(mat.Step() / bw);

            long bufSize = (long)bw * bh * bytepp;
            imgBuf = Util.AllocBuffer(bufSize);
            Util.Memcpy(imgBuf, mat.Data, bufSize);
            var matType = mat.Type();
            isFloat = (matType == MatType.CV_32FC1 || matType == MatType.CV_64FC1);
        }

        public void DrawMat(Mat mat, ImageBox pbx) {
            if (pbx.ImgBuf != IntPtr.Zero) {
                Marshal.FreeHGlobal(pbx.ImgBuf);
            }

            IntPtr buf = IntPtr.Zero;
            int bw = 0;
            int bh = 0;
            int bytepp = 1;
            bool isFloat = false;
            if (mat != null) {
                MatToImageBuffer(mat, ref buf, ref bw, ref bh, ref bytepp, ref isFloat);
            }
            pbx.SetImageBuffer(buf, bw, bh, bytepp, isFloat);
            pbx.Invalidate();
        }

        private void InitFunctionList() {
            var type = typeof(TestIp);
            MethodInfo[] mis = type.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Static | BindingFlags.Public);
            var list = mis.Select((m, i) => new MethodInfoItem(i, m)).ToArray();
            this.lbxFunc.DisplayMember = "Display";
            this.lbxFunc.ValueMember = "MethodInfo";
            this.lbxFunc.Items.AddRange(list);
            if (this.lbxFunc.Items.Count > 0)
                this.lbxFunc.SelectedIndex = 0;
        }

        private void btnExample_Click(object sender, EventArgs e) {
            if (this.cap != null) {
                this.StopLive();
            }
            
            var oldTime = DateTime.Now;

            if (Glb.matSrc != null)
                Glb.matSrc.Dispose();
            Glb.matSrc = ((Bitmap)Resources.ResourceManager.GetObject(this.cbxExampleImage.Text)).ToMat();
            Console.WriteLine($"Image From Resource: {this.cbxExampleImage.Text} ({Glb.matSrc.Width}x{Glb.matSrc.Height})");

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

            if (Glb.matSrc != null)
                Glb.matSrc.Dispose();
            Bitmap bmp = new Bitmap(img);
            Glb.matSrc = bmp.ToMat();
            Console.WriteLine($"Image From Clipboard: ({Glb.matSrc.Width}x{Glb.matSrc.Height})");

            bmp.Dispose();

            this.ProcessImage();
        }

        private void btnLoad_Click(object sender, EventArgs e) {
            if (this.dlgOpen.ShowDialog() != DialogResult.OK)
                return;

            if (this.cap != null) {
                this.StopLive();
            }

            var oldTime = DateTime.Now;

            if (Glb.matSrc != null)
                Glb.matSrc.Dispose();
            Glb.matSrc = new Mat(this.dlgOpen.FileName);
            Console.WriteLine($"Image From File: {Path.GetFileName(dlgOpen.FileName)} ({Glb.matSrc.Width}x{Glb.matSrc.Height})");

            this.ProcessImage();
        }

        private void timer1_Tick(object sender, EventArgs e) {
            var oldTime = DateTime.Now;

            if (Glb.matSrc != null)
                Glb.matSrc.Dispose();
            Glb.matSrc = new Mat();
            this.cap.Read(Glb.matSrc);
            Console.WriteLine($"Image From Camera: ({Glb.matSrc.Width}x{Glb.matSrc.Height})");

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
            this.pbx0.Invalidate();
        }

        private void StopLive() {
            this.cap.Dispose();
            this.cap = null;
            this.timer1.Enabled = false;
            this.btnLive.Text = "Live";
        }

        // 이미지 처리
        Stopwatch sw = new Stopwatch();
        private void ProcessImage() {
            Glb.form.pbx0.Tag = null;
            Glb.form.pbx1.Tag = null;
            Glb.form.pbx2.Tag = null;
            try
            {
                Console.WriteLine("==================================");
                var method = (this.lbxFunc.SelectedItem as MethodInfoItem)?.MethodInfo;

                var cs = this.grdParameter.SelectedObject as CustomClass;
                var prmDisps = cs.Cast<CustomProperty>().Select(prm => prm.Name + ":" + prm.Value.ToString()).ToArray();
                var prmDisp = string.Join(", ", prmDisps);
                Console.WriteLine($"{method.Name} ({prmDisp})");
                
                var prmValues = cs.Cast<CustomProperty>().Select(prop => prop.Value).ToArray();
                sw.Restart();
                object r = method.Invoke(this, prmValues);
                sw.Stop();
                Console.WriteLine($"=>  Total Time: {sw.ElapsedMilliseconds}ms");
            } catch (TargetInvocationException ex) {
                DrawMat(null, this.pbx1);
                DrawHistogram(null, this.cht1);
                DrawMat(null, this.pbx2);
                DrawHistogram(null, this.cht2);
                Console.WriteLine($"=> Error: {ex.InnerException.Message}");
            } catch (Exception ex) {
                DrawMat(null, this.pbx1);
                DrawHistogram(null, this.cht1);
                DrawMat(null, this.pbx2);
                DrawHistogram(null, this.cht2);
                Console.WriteLine($"=> Error: {ex.Message}");
            }
            Console.WriteLine();
        }

        private void btnZoomReset_Click(object sender, EventArgs e) {
            this.pbx0.ResetZoom();
            this.pbx0.Invalidate();
            this.pbx1.ResetZoom();
            this.pbx1.Invalidate();
            this.pbx2.ResetZoom();
            this.pbx2.Invalidate();

        }

        private void btnFitZoom_Click(object sender, EventArgs e) {
        }

        private void lbxTest_SelectedIndexChanged(object sender, EventArgs e) {
            var mii = this.lbxFunc.SelectedItem as MethodInfoItem;
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
            grdParameter.ExpandAllGridItems();
            grdParameter.Refresh();

            this.ProcessImage();
        }

        private void grdParameter_PropertyValueChanged(object s, PropertyValueChangedEventArgs e) {
            this.ProcessImage();
        }

        private void pbx_Paint(object sender, PaintEventArgs e) {
            ImageGraphics ig = new ImageGraphics(sender as ImageBox, e.Graphics);
            if ((sender as ImageBox).Tag is Action<ImageGraphics> drawing) {
                drawing(ig);
            }
        }

        static string[] extList = { ".bmp", ".jpg", ".gif", ".png", };
        private string GetDragDataImageFile(IDataObject data) {
            string[] files = (string[])data.GetData(DataFormats.FileDrop);
            if (files.Length != 1)
                return null;

            string file = files[0];
            FileAttributes attr = File.GetAttributes(file);
            if (attr.HasFlag(FileAttributes.Directory))
                return null;

            string ext = Path.GetExtension(file).ToLower();
            if (extList.Contains(ext) == false)
                return null;

            return file;
        }

        private void pbx0_DragEnter(object sender, DragEventArgs e) {
            string imageFile = GetDragDataImageFile(e.Data);
            if (imageFile == null) {
                e.Effect = DragDropEffects.None;
                return;
            }
            e.Effect = DragDropEffects.Copy;
        }

        private void pbx0_DragDrop(object sender, DragEventArgs e) {
            string filePath = GetDragDataImageFile(e.Data);
            if (filePath == null)
                return;

            if (this.cap != null) {
                this.StopLive();
            }

            var oldTime = DateTime.Now;

            if (Glb.matSrc != null)
                Glb.matSrc.Dispose();
            Glb.matSrc = new Mat(filePath);
            Console.WriteLine($"Image From File: {Path.GetFileName(dlgOpen.FileName)} ({Glb.matSrc.Width}x{Glb.matSrc.Height})");

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
