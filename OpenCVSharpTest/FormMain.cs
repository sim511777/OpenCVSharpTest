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
using ShimLib;
using System.Reflection;
using System.Collections;
using CvSize = OpenCvSharp.Size;
using CvPoint = OpenCvSharp.Point;

namespace OpenCVSharpTest {
   public partial class FormMain : Form {
      public FormMain() {
         InitializeComponent();
         this.InitFunctionList();
      }

      private void InitFunctionList() {
         var type = typeof(FormMain);
         MethodInfo[] mis = type.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic);
         var list = mis.Where(m => m.Name.StartsWith("IP_")).Select(m => new MethodInfoItem(m)).ToArray();
         this.cbxFunc.DisplayMember = "Display";
         this.cbxFunc.ValueMember = "MethodInfo";
         this.cbxFunc.Items.AddRange(list);
         if (this.cbxFunc.Items.Count>0)
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

      private void timer1_Tick(object sender, EventArgs e) {
         var oldTime = DateTime.Now;
         var matSrc = new Mat();
         this.cap.Read(matSrc);
         this.lblGrabTime.Text = $"grab time: {(DateTime.Now - oldTime).TotalMilliseconds}ms";

         this.ProcessImage(matSrc);
         matSrc.Dispose();
      }

      public static void DrawHistogram(Mat mat, Chart cht) {
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

      private static void DrawMat(Bitmap bmp, ZoomPictureBox pbx) {
         var bmpOld = pbx.Image;
         var bmpSrc = bmp;
         pbx.DrawImage = bmpSrc;
         pbx.Invalidate();
         if (bmpOld != null)
            bmpOld.Dispose();
      }

      private Mat matSrc = null;
      private void IP_CvtColor(ColorConversionCodes code) {
         var matDst = matSrc.CvtColor(code);
         DrawMat(matDst.ToBitmap(), this.pbxDst);
         DrawHistogram(matDst, this.chtDst);
         matDst.Dispose();
      }

      private void IP_EqualizeHist() {
         var matDst = matSrc.CvtColor(ColorConversionCodes.BGR2GRAY).EqualizeHist();
         DrawMat(matDst.ToBitmap(), this.pbxDst);
         DrawHistogram(matDst, this.chtDst);
         matDst.Dispose();
      }

      private void IP_Threshold(double thresh, double maxvalue, ThresholdTypes type) {
         var matDst = matSrc.CvtColor(ColorConversionCodes.BGR2GRAY).Threshold(thresh, maxvalue, type);
         DrawMat(matDst.ToBitmap(), this.pbxDst);
         DrawHistogram(matDst, this.chtDst);
         matDst.Dispose();
      }

      private void IP_Canny(double threshold1, double threshold2, int apertureSize = 3, bool L2gradient = false) {
         var matDst = matSrc.CvtColor(ColorConversionCodes.BGR2GRAY).Canny(threshold1, threshold2, apertureSize, L2gradient);
         DrawMat(matDst.ToBitmap(), this.pbxDst);
         DrawHistogram(matDst, this.chtDst);
         matDst.Dispose();
      }

      private void IP_GaussianBlur(double ksize = 5, double sigmaX = 5, double sigmaY = 5, BorderTypes borderType = BorderTypes.Reflect101) {
         var matDst = matSrc.CvtColor(ColorConversionCodes.BGR2GRAY).GaussianBlur(new OpenCvSharp.Size(ksize, ksize), sigmaX, sigmaY, borderType);
         DrawMat(matDst.ToBitmap(), this.pbxDst);
         DrawHistogram(matDst, this.chtDst);
         matDst.Dispose();
      }

      private void IP_Erode(int iterations = 1) {
         var matDst = matSrc.CvtColor(ColorConversionCodes.BGR2GRAY).Threshold(128, 255, ThresholdTypes.Otsu).Erode(new Mat(), iterations: iterations);
         DrawMat(matDst.ToBitmap(), this.pbxDst);
         DrawHistogram(matDst, this.chtDst);
         matDst.Dispose();
      }

      private void IP_Blob() {
         var matDst = matSrc.CvtColor(ColorConversionCodes.BGR2GRAY).Threshold(128, 255, ThresholdTypes.Otsu);
         var blobs = new CvBlobs();
         blobs.Label(matDst);
         var matDsp = new Mat(matSrc.Rows, matSrc.Cols, MatType.CV_8UC3);
         blobs.RenderBlobs(matDsp, matDsp);
         DrawMat(matDsp.ToBitmap(), this.pbxDst);
         DrawHistogram(matDst, this.chtDst);
         matDsp.Dispose();
         matDst.Dispose();
      }

      private void IP_ContrastBrightness(double x1 = 0, double y1 = 0, double x2 = 255, double y2 = 255) {
         // BGR to HSV변환
         matSrc = matSrc.CvtColor(ColorConversionCodes.BGR2HSV);
         // 채널 분리
         var hsvChannels = matSrc.Split();
         // 변환
         double scale = (y2 - y1) / (x2 - x1);
         double offset = (x2 * y1 - x1 * y2) / (x2 - x1);
         hsvChannels[2].ConvertTo(hsvChannels[2], MatType.CV_8UC1, scale, offset);
         // 채널 병합
         var matDst = new Mat();
         Cv2.Merge(hsvChannels, matDst);
         // HSV to BGR변환
         matDst = matDst.CvtColor(ColorConversionCodes.HSV2BGR);
         DrawMat(matDst.ToBitmap(), this.pbxDst);
         DrawHistogram(matDst, this.chtDst);
         matDst.Dispose();
      }

      private void IP_PixelBuffer_ByApi_Rgb() {
         var matDst = new Mat(matSrc.Rows, matSrc.Cols, MatType.CV_8UC3);
         for (int row = 0; row < matDst.Rows; row++) {
            for (int col = 0; col < matDst.Cols; col++) {
               Vec3b color = matSrc.Get<Vec3b>(row, col);
               color.Item0 = (byte)(255 - color.Item0);
               color.Item1 = (byte)(255 - color.Item1);
               color.Item2 = (byte)(255 - color.Item2);
               matDst.Set(row, col, color);
            }
         }
         DrawMat(matDst.ToBitmap(), this.pbxDst);
         DrawHistogram(matDst, this.chtDst);
         matDst.Dispose();
      }

      private void IP_PixelBuffer_ByApi() {
         var matDst = matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
         for (int row = 0; row < matDst.Rows; row++) {
            for (int col = 0; col < matDst.Cols; col++) {
               byte color = matDst.Get<byte>(row, col);
               matDst.Set(row, col, (byte)(~color));
            }
         }
         DrawMat(matDst.ToBitmap(), this.pbxDst);
         DrawHistogram(matDst, this.chtDst);
         matDst.Dispose();
      }

      private void IP_PixelBuffer_ByIntPtr() {
         var matDst = matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
         for (int row = 0; row < matDst.Rows; row++) {
            IntPtr pp = matDst.Ptr(row);
            for (int col = 0; col < matDst.Cols; col++, pp += 1) {
               byte color = Marshal.ReadByte(pp);
               Marshal.WriteByte(pp, (byte)~color);
            }
         }
         DrawMat(matDst.ToBitmap(), this.pbxDst);
         DrawHistogram(matDst, this.chtDst);
         matDst.Dispose();
      }

      unsafe private void IP_PixelBuffer_ByPointer() {
         var matDst = matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
         byte* buf = matDst.DataPointer;
         int bw = matDst.Width;
         int bh = matDst.Height;
         int stride = (int)matDst.Step();
         for (int y = 0; y < bh; y++) {
            byte* pp = buf + stride * y;
            for (int x = 0; x < bw; x++, pp++) {
               *pp = (byte)~(*pp);
            }
         }
         DrawMat(matDst.ToBitmap(), this.pbxDst);
         DrawHistogram(matDst, this.chtDst);
         matDst.Dispose();
      }

      private void IP_PixelBuffer_ByDll_C() {
         var matDst = matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
         IpDll.InverseImage(matDst.Data, matDst.Width, matDst.Height, (int)matDst.Step());
         DrawMat(matDst.ToBitmap(), this.pbxDst);
         DrawHistogram(matDst, this.chtDst);
         matDst.Dispose();
      }

      private void IP_PixelBuffer_ByDll_Sse() {
         var matDst = matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
         IpDll.SseInverseImage(matDst.Data, matDst.Width, matDst.Height, (int)matDst.Step());
         DrawMat(matDst.ToBitmap(), this.pbxDst);
         DrawHistogram(matDst, this.chtDst);
         matDst.Dispose();
      }

      private void IP_PixelBuffer_ByDll_Avx() {
         var matDst = matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
         IpDll.AvxInverseImage(matDst.Data, matDst.Width, matDst.Height, (int)matDst.Step());
         DrawMat(matDst.ToBitmap(), this.pbxDst);
         DrawHistogram(matDst, this.chtDst);
         matDst.Dispose();
      }

      private void IP_PixelBuffer_ByDll_VectorClass() {
         var matDst = matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
         IpDll.VecInverseImage(matDst.Data, matDst.Width, matDst.Height, (int)matDst.Step());
         DrawMat(matDst.ToBitmap(), this.pbxDst);
         DrawHistogram(matDst, this.chtDst);
         matDst.Dispose();
      }

      private void IP_Crop(int x=10, int y=10, int width=100, int height=100) {
         Rect roi = new Rect(x, y, width, height);
         Mat matDst = new Mat(matSrc, roi);
         DrawMat(matDst.ToBitmap(), this.pbxDst);
         DrawHistogram(matDst, this.chtDst);
         matDst.Dispose();
      }

      private void IP_CropAndCopy(int x=100, int y=100, int width=100, int height=100) {
         Rect roi = new Rect(x, y, width, height);
         Mat matCrop = new Mat(matSrc, roi)  // 크롭 이미지 생성 하여 수정
            .CvtColor(ColorConversionCodes.BGR2GRAY)
            .Threshold(128, 255, ThresholdTypes.Binary)
            .CvtColor(ColorConversionCodes.GRAY2BGR);
         Mat matDst = matSrc.Clone();
         Mat matRoi = new Mat(matDst, roi);  // 부분 참조 이미지 생성
         matCrop.CopyTo(matRoi);             // 수정된 이미지를 참조 버퍼에 복사
         DrawMat(matDst.ToBitmap(), this.pbxDst);
         DrawHistogram(matDst, this.chtDst);
         matDst.Dispose();
      }

      private void IP_Kernel() {
         float[] data = Enumerable.Repeat(1f, 9).ToArray();
         var kernel = new Mat(3, 3, MatType.CV_32FC1, data);
         kernel = kernel.Normalize(normType: NormTypes.L1);
         var matDst = matSrc
            .CvtColor(ColorConversionCodes.BGR2GRAY)
            .Filter2D(MatType.CV_8UC1, kernel, borderType: BorderTypes.Default);
         kernel.Dispose();
         DrawMat(matDst.ToBitmap(), this.pbxDst);
         DrawHistogram(matDst, this.chtDst);
         matDst.Dispose();
      }


      // 이미지 처리
      private void ProcessImage(Mat matSrc) {
         var oldTime = DateTime.Now;

         DrawMat(matSrc.ToBitmap(), this.pbxSrc);
         DrawHistogram(matSrc, this.chtSrc);
         
         this.matSrc = matSrc;
         var method = (this.cbxFunc.SelectedItem as MethodInfoItem)?.MethodInfo;
         var prmNameList = method.GetParameters().Select(prm => prm.Name);
         if (method != null) {
            try {
               var adapter = this.grdParameter.SelectedObject as DictionaryPropertyGridAdapter;
               var props = adapter.GetProperties(null).Cast<PropertyDescriptor>();
               var prmList = prmNameList.Select(prmName => props.First(prop => prop.Name == prmName).GetValue(null)).ToArray();
               object r = method.Invoke(this, prmList);
               this.lblLog.Text = $"IP Succ";
            } catch (TargetInvocationException ex) {
               DrawMat(null, this.pbxDst);
               DrawHistogram(null, this.chtDst);
               this.lblLog.Text = $"IP Fail: {ex.InnerException.Message}";
            } catch (Exception ex) {
               DrawMat(null, this.pbxDst);
               DrawHistogram(null, this.chtDst);
               this.lblLog.Text = $"IP Fail: {ex.Message}";
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
         var methodInfo = ((MethodInfoItem)this.cbxFunc.SelectedItem).MethodInfo;
         var paramInfos = methodInfo.GetParameters();
         Hashtable dict = new Hashtable();
         foreach (var pi in paramInfos) {
            dict[pi.Name] = pi.HasDefaultValue ? pi.DefaultValue : Activator.CreateInstance(pi.ParameterType);
         }

         grdParameter.SelectedObject = new DictionaryPropertyGridAdapter(dict);
      }
   }

   class MethodInfoItem {
      public string Display { get; set; }
      public MethodInfo MethodInfo { get; set; }
      public MethodInfoItem(MethodInfo mi) {
         var paramDisp = string.Join(", ", mi.GetParameters().Select(prm => $"{prm.ParameterType.Name} {prm.Name}").ToArray());
         this.Display = $"{mi.ReturnType.Name} {mi.Name}({paramDisp})";
         this.MethodInfo = mi;
      }
   }
}
