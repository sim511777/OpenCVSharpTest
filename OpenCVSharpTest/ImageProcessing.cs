﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCVSharpTest.Properties;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using OpenCvSharp.Blob;
using System.Runtime.InteropServices;

namespace OpenCVSharpTest {
   class ImageProcessing {
      public static void CvtColor(ColorConversionCodes code = ColorConversionCodes.BGR2GRAY) {
         var form = FormMain.form;
         var matDst = form.matSrc.CvtColor(code);
         form.DrawMat(matDst.ToBitmap(), form.pbxDst);
         form.DrawHistogram(matDst, form.chtDst);
         matDst.Dispose();
      }

      public static void EqualizeHist() {
         var form = FormMain.form;
         var matDst = form.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY).EqualizeHist();
         form.DrawMat(matDst.ToBitmap(), form.pbxDst);
         form.DrawHistogram(matDst, form.chtDst);
         matDst.Dispose();
      }

      public static void EqualizeHistHsv() {
         var form = FormMain.form;
         // BGR to HSV변환
         var matHsv = form.matSrc.CvtColor(ColorConversionCodes.BGR2HSV);
         // 채널 분리
         var hsvChannels = matHsv.Split();
         // 변환
         hsvChannels[2] = hsvChannels[2].EqualizeHist();
         // 채널 병합
         var matDst = new Mat();
         Cv2.Merge(hsvChannels, matDst);
         // HSV to BGR변환
         matDst = matDst.CvtColor(ColorConversionCodes.HSV2BGR);
         form.DrawMat(matDst.ToBitmap(), form.pbxDst);
         form.DrawHistogram(matDst, form.chtDst);
         matHsv.Dispose();
         matDst.Dispose();
      }

      public static void Threshold(double thresh = 128, double maxvalue = 255, ThresholdTypes type = ThresholdTypes.Binary) {
         var form = FormMain.form;
         var matDst = form.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY).Threshold(thresh, maxvalue, type);
         form.DrawMat(matDst.ToBitmap(), form.pbxDst);
         form.DrawHistogram(matDst, form.chtDst);
         matDst.Dispose();
      }

      public static void Canny(double threshold1 = 50, double threshold2 = 200, int apertureSize = 3, bool L2gradient = false) {
         var form = FormMain.form;
         var matDst = form.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY).Canny(threshold1, threshold2, apertureSize, L2gradient);
         form.DrawMat(matDst.ToBitmap(), form.pbxDst);
         form.DrawHistogram(matDst, form.chtDst);
         matDst.Dispose();
      }

      public static void GaussianBlur(double ksize = 5, double sigmaX = 5, double sigmaY = 5, BorderTypes borderType = BorderTypes.Reflect101) {
         var form = FormMain.form;
         var matDst = form.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY).GaussianBlur(new OpenCvSharp.Size(ksize, ksize), sigmaX, sigmaY, borderType);
         form.DrawMat(matDst.ToBitmap(), form.pbxDst);
         form.DrawHistogram(matDst, form.chtDst);
         matDst.Dispose();
      }

      public static void Erode(int iterations = 1) {
         var form = FormMain.form;
         var matDst = form.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY).Threshold(128, 255, ThresholdTypes.Otsu).Erode(new Mat(), iterations: iterations);
         form.DrawMat(matDst.ToBitmap(), form.pbxDst);
         form.DrawHistogram(matDst, form.chtDst);
         matDst.Dispose();
      }

      public static void Blob() {
         var form = FormMain.form;
         var matDst = form.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY).Threshold(128, 255, ThresholdTypes.Otsu);
         var blobs = new CvBlobs();
         blobs.Label(matDst);
         var matDsp = new Mat(form.matSrc.Rows, form.matSrc.Cols, MatType.CV_8UC3);
         blobs.RenderBlobs(matDsp, matDsp);
         form.DrawMat(matDsp.ToBitmap(), form.pbxDst);
         form.DrawHistogram(matDst, form.chtDst);
         matDsp.Dispose();
         matDst.Dispose();
      }

      public static void ContrastBrightness(double x1 = 64, double y1 = 0, double x2 = 192, double y2 = 255) {
         var form = FormMain.form;
         // BGR to HSV변환
         var matHsv = form.matSrc.CvtColor(ColorConversionCodes.BGR2HSV);
         // 채널 분리
         var hsvChannels = matHsv.Split();
         // 변환
         double scale = (y2 - y1) / (x2 - x1);
         double offset = (x2 * y1 - x1 * y2) / (x2 - x1);
         hsvChannels[2].ConvertTo(hsvChannels[2], MatType.CV_8UC1, scale, offset);
         // 채널 병합
         var matDst = new Mat();
         Cv2.Merge(hsvChannels, matDst);
         // HSV to BGR변환
         matDst = matDst.CvtColor(ColorConversionCodes.HSV2BGR);
         form.DrawMat(matDst.ToBitmap(), form.pbxDst);
         form.DrawHistogram(matDst, form.chtDst);
         matHsv.Dispose();
         matDst.Dispose();
      }

      public static void PixelBuffer_ByApi_Rgb() {
         var form = FormMain.form;
         var matDst = new Mat(form.matSrc.Rows, form.matSrc.Cols, MatType.CV_8UC3);
         for (int row = 0; row < matDst.Rows; row++) {
            for (int col = 0; col < matDst.Cols; col++) {
               Vec3b color = form.matSrc.Get<Vec3b>(row, col);
               color.Item0 = (byte)(255 - color.Item0);
               color.Item1 = (byte)(255 - color.Item1);
               color.Item2 = (byte)(255 - color.Item2);
               matDst.Set(row, col, color);
            }
         }
         form.DrawMat(matDst.ToBitmap(), form.pbxDst);
         form.DrawHistogram(matDst, form.chtDst);
         matDst.Dispose();
      }

      public static void PixelBuffer_ByApi() {
         var form = FormMain.form;
         var matDst = form.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
         for (int row = 0; row < matDst.Rows; row++) {
            for (int col = 0; col < matDst.Cols; col++) {
               byte color = matDst.Get<byte>(row, col);
               matDst.Set(row, col, (byte)(~color));
            }
         }
         form.DrawMat(matDst.ToBitmap(), form.pbxDst);
         form.DrawHistogram(matDst, form.chtDst);
         matDst.Dispose();
      }

      public static void PixelBuffer_ByIntPtr() {
         var form = FormMain.form;
         var matDst = form.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
         for (int row = 0; row < matDst.Rows; row++) {
            IntPtr pp = matDst.Ptr(row);
            for (int col = 0; col < matDst.Cols; col++, pp += 1) {
               byte color = Marshal.ReadByte(pp);
               Marshal.WriteByte(pp, (byte)~color);
            }
         }
         form.DrawMat(matDst.ToBitmap(), form.pbxDst);
         form.DrawHistogram(matDst, form.chtDst);
         matDst.Dispose();
      }

      unsafe public static void PixelBuffer_ByPointer() {
         var form = FormMain.form;
         var matDst = form.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
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
         form.DrawMat(matDst.ToBitmap(), form.pbxDst);
         form.DrawHistogram(matDst, form.chtDst);
         matDst.Dispose();
      }

      public static void PixelBuffer_ByDll_C() {
         var form = FormMain.form;
         var matDst = form.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
         IpDll.InverseImage(matDst.Data, matDst.Width, matDst.Height, (int)matDst.Step());
         form.DrawMat(matDst.ToBitmap(), form.pbxDst);
         form.DrawHistogram(matDst, form.chtDst);
         matDst.Dispose();
      }

      public static void PixelBuffer_ByDll_Sse() {
         var form = FormMain.form;
         var matDst = form.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
         IpDll.SseInverseImage(matDst.Data, matDst.Width, matDst.Height, (int)matDst.Step());
         form.DrawMat(matDst.ToBitmap(), form.pbxDst);
         form.DrawHistogram(matDst, form.chtDst);
         matDst.Dispose();
      }

      public static void PixelBuffer_ByDll_Avx() {
         var form = FormMain.form;
         var matDst = form.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
         IpDll.AvxInverseImage(matDst.Data, matDst.Width, matDst.Height, (int)matDst.Step());
         form.DrawMat(matDst.ToBitmap(), form.pbxDst);
         form.DrawHistogram(matDst, form.chtDst);
         matDst.Dispose();
      }

      public static void PixelBuffer_ByDll_VectorClass() {
         var form = FormMain.form;
         var matDst = form.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
         IpDll.VecInverseImage(matDst.Data, matDst.Width, matDst.Height, (int)matDst.Step());
         form.DrawMat(matDst.ToBitmap(), form.pbxDst);
         form.DrawHistogram(matDst, form.chtDst);
         matDst.Dispose();
      }

      public static void Crop(int x=10, int y=10, int width=100, int height=100) {
         var form = FormMain.form;
         Rect roi = new Rect(x, y, width, height);
         Mat matDst = new Mat(form.matSrc, roi);
         form.DrawMat(matDst.ToBitmap(), form.pbxDst);
         form.DrawHistogram(matDst, form.chtDst);
         matDst.Dispose();
      }

      public static void CropAndCopy(int x=100, int y=100, int width=100, int height=100) {
         var form = FormMain.form;
         Rect roi = new Rect(x, y, width, height);
         Mat matCrop = new Mat(form.matSrc, roi)  // 크롭 이미지 생성 하여 수정
            .CvtColor(ColorConversionCodes.BGR2GRAY)
            .Threshold(128, 255, ThresholdTypes.Binary)
            .CvtColor(ColorConversionCodes.GRAY2BGR);
         Mat matDst = form.matSrc.Clone();
         Mat matRoi = new Mat(matDst, roi);  // 부분 참조 이미지 생성
         matCrop.CopyTo(matRoi);             // 수정된 이미지를 참조 버퍼에 복사
         form.DrawMat(matDst.ToBitmap(), form.pbxDst);
         form.DrawHistogram(matDst, form.chtDst);
         matDst.Dispose();
      }

      public static void Kernel() {
         var form = FormMain.form;
         float[] data = Enumerable.Repeat(1f, 9).ToArray();
         var kernel = new Mat(3, 3, MatType.CV_32FC1, data);
         kernel = kernel.Normalize(normType: NormTypes.L1);
         var matDst = form.matSrc
            .CvtColor(ColorConversionCodes.BGR2GRAY)
            .Filter2D(MatType.CV_8UC1, kernel, borderType: BorderTypes.Default);
         kernel.Dispose();
         form.DrawMat(matDst.ToBitmap(), form.pbxDst);
         form.DrawHistogram(matDst, form.chtDst);
         matDst.Dispose();
      }
   }
}