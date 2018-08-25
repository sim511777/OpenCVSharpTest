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
using OpenCVTestLoadImage.Properties;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using OpenCvSharp.Blob;

namespace OpenCVTestLoadImage {
   public partial class FormMain : Form {
      public FormMain() {
         InitializeComponent();
      }

      private void btnLenna_Click(object sender, EventArgs e) {
         if (this.cap != null) {
            this.StopLive();
         }

         var oldTime = DateTime.Now;
         var matSrc = Resources.Lenna.ToMat();
         this.lblGrabTime.Text = $"grab time: {(DateTime.Now - oldTime).TotalMilliseconds}ms";

         this.ProcessImage(matSrc);
         matSrc.Dispose();
      }

      private void btnClipboard_Click(object sender, EventArgs e) {
         Image img = Clipboard.GetImage();
         if (img == null)
            return;

         if (this.cap != null) {
            this.StopLive();
         }

         var oldTime = DateTime.Now;
         Bitmap bmp = new Bitmap(img);
         var matSrc = bmp.ToMat();
         bmp.Dispose();
         this.lblGrabTime.Text = $"grab time: {(DateTime.Now - oldTime).TotalMilliseconds}ms";

         this.ProcessImage(matSrc);
         matSrc.Dispose();
      }

      private void btnLoad_Click(object sender, EventArgs e) {
         if (this.dlgOpen.ShowDialog() != DialogResult.OK)
            return;


         if (this.cap != null) {
            this.StopLive();
         }

         var oldTime = DateTime.Now;
         var matSrc = new Mat(this.dlgOpen.FileName);
         this.lblGrabTime.Text = $"grab time: {(DateTime.Now - oldTime).TotalMilliseconds}ms";

         this.ProcessImage(matSrc);
         matSrc.Dispose();
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
      }

      private void StopLive() {
            this.cap.Dispose();
            this.cap = null;
            this.timer1.Enabled = false;
            this.btnLive.Text = "Live";
      }

      private void timer1_Tick(object sender, EventArgs e) {
         var oldTime = DateTime.Now;
         var matSrc = new Mat();
         this.cap.Read(matSrc);
         this.lblGrabTime.Text = $"grab time: {(DateTime.Now - oldTime).TotalMilliseconds}ms";

         this.ProcessImage(matSrc);
         matSrc.Dispose();
      }

      public static void DrawHistogram(Mat mat, Chart cht) {
         MatType matType = mat.Type();
         if (matType == MatType.CV_8UC1) {
            var histo = GetHistogram(mat, 0);
            float acc = 0;
            var histoAccum = histo.Select(val => acc += val).ToArray();
            DrawHistogram(histo, cht.Series[0], "Gray", Color.Black);
            DrawHistogram(histoAccum, cht.Series[1], "Accum", Color.Red, AxisType.Secondary);
         } else if (matType == MatType.CV_8UC3 || matType == MatType.CV_8UC4) {
            var histR = GetHistogram(mat, 2);
            var histG = GetHistogram(mat, 1);
            var histB = GetHistogram(mat, 0);
            DrawHistogram(histR, cht.Series[0], "R", Color.Red);
            DrawHistogram(histG, cht.Series[1], "G", Color.Green);
            DrawHistogram(histB, cht.Series[2], "B", Color.Blue);
         }
      }

      public static void DrawHistogram(float[] histo, Series series, string name, Color color, AxisType yAxisTYpe = AxisType.Primary) {
         series.Name = name;
         series.Color = color;
         series.Points.Clear();
         series.YAxisType = yAxisTYpe;
         for (int i = 0; i < histo.Length; i++) {
            series.Points.AddXY(i, histo[i]);
         }
         series.Enabled = true;
      }

      public static float[] GetHistogram(Mat matSrc, int channel) {
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

      private static void DrawMat(Mat mat, PictureBox pbx) {
         var bmpOld = pbx.Image;
         var bmpSrc = mat.ToBitmap();
         pbx.Image = bmpSrc;
         if (bmpOld != null)
            bmpOld.Dispose();
      }

      // 이미지 처리
      unsafe private void ProcessImage(Mat matSrc) {
         var oldTime = DateTime.Now;

         DrawMat(matSrc, this.pbxSrc);
         DrawHistogram(matSrc, this.chtSrc);


         // 1. GrayScale 
         //var matDst = matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
         //DrawMat(matDst, this.pbxDst);
         //DrawHistogram(matDst, this.chtDst);
         //matDst.Dispose();


         // 2. Histogram Equalize
         //var matDst = matSrc.CvtColor(ColorConversionCodes.BGR2GRAY).EqualizeHist();
         //DrawMat(matDst, this.pbxDst);
         //DrawHistogram(matDst, this.chtDst);
         //matDst.Dispose();


         // 3. Threshhold (absolute)
         //var matDst = matSrc.CvtColor(ColorConversionCodes.BGR2GRAY).Threshold(128, 255, ThresholdTypes.Binary);
         //DrawMat(matDst, this.pbxDst);
         //DrawHistogram(matDst, this.chtDst);
         //matDst.Dispose();


         // 4. Edge (Canny)
         //var matDst = matSrc.CvtColor(ColorConversionCodes.BGR2GRAY).Canny(5, 200);
         //DrawMat(matDst, this.pbxDst);
         //DrawHistogram(matDst, this.chtDst);
         //matDst.Dispose();


         // 5. Blur (Gaussian)
         //var matDst = matSrc.CvtColor(ColorConversionCodes.BGR2GRAY).GaussianBlur(new OpenCvSharp.Size(5, 5), 5);
         //DrawMat(matDst, this.pbxDst);
         //DrawHistogram(matDst, this.chtDst);
         //matDst.Dispose();


         // 6. Erode
         //var matDst = matSrc.CvtColor(ColorConversionCodes.BGR2GRAY).Threshold(128, 255, ThresholdTypes.Otsu).Erode(new Mat(), iterations:2);
         //DrawMat(matDst, this.pbxDst);
         //DrawHistogram(matDst, this.chtDst);
         //matDst.Dispose();


         // 7. Blob
         //var matDst = matSrc.CvtColor(ColorConversionCodes.BGR2GRAY).Threshold(128, 255, ThresholdTypes.Otsu);
         //var blobs = new CvBlobs();
         //blobs.Label(matDst);
         //var matDsp = new Mat(matSrc.Rows, matSrc.Cols, MatType.CV_8UC3);
         //blobs.RenderBlobs(matDsp, matDsp);

         //DrawMat(matDsp, this.pbxDst);
         //DrawHistogram(matDst, this.chtDst);

         //matDsp.Dispose();
         //matDst.Dispose();


         // 8. 명암/밝기 변환
         //// BGR to HSV변환
         //matSrc = matSrc.CvtColor(ColorConversionCodes.BGR2HSV);
         //// 채널 분리
         //var hsvChannels = matSrc.Split();
         //// 변환
         //double x1 = 60;
         //double y1 = 0;
         //double x2 = 255;
         //double y2 = 255;
         //double scale = (y2-y1)/(x2-x1);
         //double offset = (x2*y1-x1*y2)/(x2-x1);
         //hsvChannels[2].ConvertTo(hsvChannels[2], MatType.CV_8UC1, scale, offset);
         //// 채널 병합
         //var matDst = new Mat();
         //Cv2.Merge(hsvChannels, matDst);
         //// HSV to BGR변환
         //matDst = matDst.CvtColor(ColorConversionCodes.HSV2BGR);

         //DrawMat(matDst, this.pbxDst);
         //DrawHistogram(matDst, this.chtDst);
         //matDst.Dispose();


         // 9. 픽셀 버퍼 제어 RGB
         //var matDst = new Mat(matSrc.Rows, matSrc.Cols, MatType.CV_8UC3);
         //for (int row=0; row<matDst.Rows; row++) {
         //   for (int col=0; col<matDst.Cols; col++) {
         //      Vec3b color = matSrc.Get<Vec3b>(row, col);
         //      color.Item0 = (byte)(255-color.Item0);
         //      color.Item1 = (byte)(255-color.Item1);
         //      color.Item2 = (byte)(255-color.Item2);
         //      matDst.Set(row, col, color);
         //   }
         //}

         //DrawMat(matDst, this.pbxDst);
         //DrawHistogram(matDst, this.chtDst);
         //matDst.Dispose();


         // 10. 픽셀 버퍼 제어 Gray by API
         var matDst = matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
         for (int row = 0; row < matDst.Rows; row++) {
            for (int col = 0; col < matDst.Cols; col++) {
               byte color = matDst.Get<byte>(row, col);
               color = (byte)(~color);
               matDst.Set(row, col, color);
            }
         }

         DrawMat(matDst, this.pbxDst);
         DrawHistogram(matDst, this.chtDst);
         matDst.Dispose();


         // 11. 픽셀 버퍼 제어 Gray by IntPtr
         //var matDst = matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
         //for (int row = 0; row < matDst.Rows; row++) {
         //   IntPtr pp = matDst.Data + (int)matDst.Step();
         //   for (int col = 0; col < matDst.Cols; col++, pp += 1) {
         //      byte color = Marshal.ReadByte(pp);
         //      color = (byte)~color;
         //      Marshal.WriteByte(pp, color);
         //   }
         //}

         //DrawMat(matDst, this.pbxDst);
         //DrawHistogram(matDst, this.chtDst);
         //matDst.Dispose();


         // 12. 픽셀 버퍼 제어 Gray by pointer
         //var matDst = matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
         //byte* ptr = (byte*)matDst.Data;
         //var stride = matDst.Step();
         //for (int row = 0; row < matDst.Rows; row++) {
         //   byte* pp = ptr + stride;
         //   for (int col = 0; col < matDst.Cols; col++, pp++) {
         //      *pp = (byte)~(*pp);
         //   }
         //}

         //DrawMat(matDst, this.pbxDst);
         //DrawHistogram(matDst, this.chtDst);
         //matDst.Dispose();

         this.lblProcessingTime.Text = $"IP time: {(DateTime.Now - oldTime).TotalMilliseconds}ms";
      }
   }
}
