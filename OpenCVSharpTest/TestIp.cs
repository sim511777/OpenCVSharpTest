﻿using System;
using System.Collections.Generic;
using System.Linq;
//using System.Text;
using System.Threading.Tasks;
using OpenCVSharpTest.Properties;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using OpenCvSharp.Blob;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace OpenCVSharpTest {
    class TestIp {
        public static void CvtColor(ColorConversionCodes code = ColorConversionCodes.BGR2GRAY) {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matDst = Glb.matSrc.CvtColor(code);

            Glb.DrawMatAndHist1(matDst);
            Glb.DrawMatAndHist2(null);

            matDst.Dispose();
        }

        public static void EqualizeHist() {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matGray = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            var matDst = matGray.EqualizeHist();

            Glb.DrawMatAndHist1(matGray);
            Glb.DrawMatAndHist2(matDst);

            matGray.Dispose();
            matDst.Dispose();
        }

        public static void EqualizeHistHsv() {
            Glb.DrawMatAndHist0(Glb.matSrc);
            Glb.DrawMat0(Glb.matSrc);

            // BGR to HSV변환
            var matHsv = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2HSV);
            Glb.DrawHist0(matHsv, true);

            // 채널 분리
            var hsvChannels = matHsv.Split();
            // 변환
            hsvChannels[2] = hsvChannels[2].EqualizeHist();
            // 채널 병합
            var matDst = new Mat();
            Cv2.Merge(hsvChannels, matDst);
            Glb.DrawHist1(matDst, true);

            // HSV to BGR변환
            matDst = matDst.CvtColor(ColorConversionCodes.HSV2BGR);

            Glb.DrawMat1(matDst);

            Glb.DrawMatAndHist2(null);

            matHsv.Dispose();
            matDst.Dispose();
        }

        public static void Threshold(double thresh = 128, double maxvalue = 255, ThresholdTypes type = ThresholdTypes.Binary) {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matGray = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matGray);

            var matDst = matGray.Threshold(thresh, maxvalue, type);
            Glb.DrawMatAndHist2(matDst);

            matGray.Dispose();
            matDst.Dispose();
        }

        public static void Canny(double threshold1 = 50, double threshold2 = 200, int apertureSize = 3, bool L2gradient = false) {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matGray = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matGray);

            var matDst = matGray.Canny(threshold1, threshold2, apertureSize, L2gradient);
            Glb.DrawMatAndHist2(matDst);

            matGray.Dispose();
            matDst.Dispose();
        }

        public static void Sobel(int xorder = 1, int yorder = 1, int ksize = 3, double scale = 1, double delta = 0, BorderTypes borderType = BorderTypes.Default) {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matGray = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matGray);

            var matDst = matGray.Sobel(matGray.Type(), xorder, yorder, ksize, scale, delta, borderType);
            Glb.DrawMatAndHist2(matDst);

            matGray.Dispose();
            matDst.Dispose();
        }

        public static void Laplacian(int ksize = 1, double scale = 1, double delta = 0, BorderTypes borderType = BorderTypes.Default) {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matGray = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matGray);

            var matDst = matGray.Laplacian(matGray.Type(), ksize, scale, delta, borderType);
            Glb.DrawMatAndHist2(matDst);

            matGray.Dispose();
            matDst.Dispose();
        }

        public static void Blur(double ksize = 5, BorderTypes borderType = BorderTypes.Reflect101) {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matGray = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matGray);

            var matDst = matGray.Blur(new Size(ksize, ksize), borderType: borderType);
            Glb.DrawMatAndHist2(matDst);

            matGray.Dispose();
            matDst.Dispose();
        }

        public static void GaussianBlur(double ksize = 5, double sigmaX = 5, double sigmaY = 5, BorderTypes borderType = BorderTypes.Reflect101) {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matGray = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matGray);

            var matDst = matGray.GaussianBlur(new Size(ksize, ksize), sigmaX, sigmaY, borderType);
            Glb.DrawMatAndHist2(matDst);

            matGray.Dispose();
            matDst.Dispose();
        }

        public static void MedianBlur(int ksize = 3) {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matDst = Glb.matSrc.MedianBlur(ksize);
            Glb.DrawMatAndHist1(matDst);
            Glb.DrawMatAndHist2(null);

            matDst.Dispose();
        }

        public static void Erode(int iterations = 1) {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matThr = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY).Threshold(128, 255, ThresholdTypes.Otsu);
            Glb.DrawMatAndHist1(matThr);

            var matDst = matThr.Erode(new Mat(), iterations: iterations);
            Glb.DrawMatAndHist2(matDst);

            matThr.Dispose();
            matDst.Dispose();
        }

        public static void Dilate(int iterations = 1) {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matThr = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY).Threshold(128, 255, ThresholdTypes.Otsu);
            Glb.DrawMatAndHist1(matThr);

            var matDst = matThr.Dilate(new Mat(), iterations: iterations);
            Glb.DrawMatAndHist2(matDst);

            matThr.Dispose();
            matDst.Dispose();
        }

        public static void ContrastBrightness(double x1 = 64, double y1 = 0, double x2 = 192, double y2 = 255) {
            Glb.DrawMat0(Glb.matSrc);

            // BGR to HSV변환
            var matHsv = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2HSV);
            Glb.DrawHist0(matHsv, true);

            // 채널 분리
            var hsvChannels = matHsv.Split();
            // 변환
            double scale = (y2 - y1) / (x2 - x1);
            double offset = (x2 * y1 - x1 * y2) / (x2 - x1);
            hsvChannels[2].ConvertTo(hsvChannels[2], MatType.CV_8UC1, scale, offset);

            // 채널 병합
            var matDst = new Mat();
            Cv2.Merge(hsvChannels, matDst);
            Glb.DrawHist1(matDst, true);

            // HSV to BGR변환
            matDst = matDst.CvtColor(ColorConversionCodes.HSV2BGR);
            Glb.DrawMat1(matDst);

            Glb.DrawMatAndHist2(null);

            matHsv.Dispose();
            matDst.Dispose();
        }

        public static void PixelBuffer_By_Api_Rgb() {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matDst = Glb.matSrc.Clone();
            Glb.DrawMatAndHist1(matDst);

            for (int row = 0; row < matDst.Rows; row++) {
                for (int col = 0; col < matDst.Cols; col++) {
                    Vec3b color = matDst.Get<Vec3b>(row, col);
                    color.Item0 = (byte)(255 - color.Item0);
                    color.Item1 = (byte)(255 - color.Item1);
                    color.Item2 = (byte)(255 - color.Item2);
                    matDst.Set(row, col, color);
                }
            }
            Glb.DrawMatAndHist2(matDst);

            matDst.Dispose();
        }

        public static void PixelBuffer_By_Api() {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matDst = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matDst);

            int bw = matDst.Width;
            int bh = matDst.Height;
            for (int y = 0; y < bh; y++) {
                for (int x = 0; x < bw; x++) {
                    matDst.Set(y, x, (byte)~matDst.Get<byte>(y, x));
                }
            }
            Glb.DrawMatAndHist2(matDst);

            matDst.Dispose();
        }

        public static void PixelBuffer_By_Marshalling() {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matDst = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matDst);

            IntPtr buf = matDst.Data;
            int bw = matDst.Width;
            int bh = matDst.Height;
            int stride = (int)matDst.Step();
            for (int y = 0; y < bh; y++) {
                IntPtr pp = buf + stride * y;
                for (int x = 0; x < bw; x++, pp = pp + 1) {
                    Marshal.WriteByte(pp, (byte)~Marshal.ReadByte(pp));
                }
            }
            Glb.DrawMatAndHist2(matDst);

            matDst.Dispose();
        }

        public static void PixelBuffer_By_Unsafe_Pointer() {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matDst = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matDst);

            IpUnsafe.Inverse(matDst.Data, matDst.Width, matDst.Height, (int)matDst.Step());
            Glb.DrawMatAndHist2(matDst);

            matDst.Dispose();
        }

        public static void PixelBuffer_By_Dll_C() {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matDst = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matDst);

            IpDll.InverseImageC(matDst.Data, matDst.Width, matDst.Height, (int)matDst.Step());
            Glb.DrawMatAndHist2(matDst);

            matDst.Dispose();
        }

        public static void PixelBuffer_By_Dll_Sse() {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matDst = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matDst);

            IpDll.InverseImageSse(matDst.Data, matDst.Width, matDst.Height, (int)matDst.Step());
            Glb.DrawMatAndHist2(matDst);

            matDst.Dispose();
        }

        public static void PixelBuffer_By_Dll_VectorClass() {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matDst = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matDst);

            IpDll.InverseImageVec(matDst.Data, matDst.Width, matDst.Height, (int)matDst.Step());
            Glb.DrawMatAndHist2(matDst);

            matDst.Dispose();
        }

        public static void PixelBuffer_By_Dll_Avx() {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matDst = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matDst);

            IpDll.InverseImageAvx(matDst.Data, matDst.Width, matDst.Height, (int)matDst.Step());
            Glb.DrawMatAndHist2(matDst);

            matDst.Dispose();
        }

        public static void Crop(int x = 10, int y = 10, int width = 100, int height = 100) {
            Glb.DrawMatAndHist0(Glb.matSrc);

            Rect roi = new Rect(x, y, width, height);
            Mat matDst = new Mat(Glb.matSrc, roi);
            Glb.DrawMatAndHist1(matDst);

            Glb.DrawMatAndHist2(null);

            matDst.Dispose();
        }

        public static void CropAndCopy(int x = 100, int y = 100, int width = 100, int height = 100) {
            Glb.DrawMatAndHist0(Glb.matSrc);

            Rect roi = new Rect(x, y, width, height);
            Mat matCrop = new Mat(Glb.matSrc, roi)  // 크롭 이미지 생성 하여 수정
               .CvtColor(ColorConversionCodes.BGR2GRAY)
               .Threshold(128, 255, ThresholdTypes.Binary)
               .CvtColor(ColorConversionCodes.GRAY2BGR);
            Glb.DrawMatAndHist1(matCrop);

            Mat matDst = Glb.matSrc.Clone();
            Mat matRoi = new Mat(matDst, roi);  // 부분 참조 이미지 생성
            matCrop.CopyTo(matRoi);             // 수정된 이미지를 참조 버퍼에 복사

            Glb.DrawMatAndHist2(matDst);

            matCrop.Dispose();
            matDst.Dispose();
        }

        public static void Kernel(
            float w00 = 1, float w01 = 1, float w02 = 1,
            float w10 = 1, float w11 = 1, float w12 = 1,
            float w20 = 1, float w21 = 1, float w22 = 1,
            bool normalize = true) {

            Glb.DrawMatAndHist0(Glb.matSrc);

            float[] data = new float[] {
                w00, w01, w02,
                w10, w11, w12,
                w20, w21, w22
            };
            var kernel = new Mat(3, 3, MatType.CV_32FC1, data);
            if (normalize) {
                kernel = kernel.Normalize(normType: NormTypes.L1);
            }

            var matGray = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matGray);

            var matDst = matGray.Filter2D(MatType.CV_8UC1, kernel, borderType: BorderTypes.Default);
            kernel.Dispose();
            Glb.DrawMatAndHist2(matDst);

            matGray.Dispose();
            matDst.Dispose();
        }

        public static void Flip(FlipMode flipCode = FlipMode.X) {
            Glb.DrawMatAndHist0(Glb.matSrc);

            Mat matDst = Glb.matSrc.Flip(flipCode);
            Glb.DrawMatAndHist1(matDst);

            Glb.DrawMatAndHist2(null);

            matDst.Dispose();
        }

        public static void Negative() {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matDst = new Mat();
            Cv2.BitwiseNot(Glb.matSrc.CvtColor(ColorConversionCodes.BGRA2BGR), matDst);
            Glb.DrawMatAndHist1(matDst);

            Glb.DrawMatAndHist2(null);

            matDst.Dispose();
        }

        public static void SetColor(System.Drawing.Color color) {
            Glb.DrawMatAndHist0(Glb.matSrc);


            var matDst = Glb.matSrc.Clone();

            var col = Scalar.FromRgb(color.R, color.G, color.B);
            matDst.SetTo(col);
            Glb.DrawMatAndHist1(matDst);

            Glb.DrawMatAndHist2(null);

            matDst.Dispose();
        }

        public static void SetGray(byte gray = 128) {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matGray = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matGray);

            var matDst = matGray.Clone();
            matDst.SetTo(gray);
            Glb.DrawMatAndHist2(matDst);

            matGray.Dispose();
            matDst.Dispose();
        }

        public static void FaceDetect() {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matGray = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            string xmlPath = Application.StartupPath + "\\..\\haarcascades\\haarcascade_frontalface_alt2.xml";
            var haarCascade = new CascadeClassifier(xmlPath);
            Glb.TimerStart();
            Rect[] faces = haarCascade.DetectMultiScale(matGray);
            Console.WriteLine($"=> Detect Time: {Glb.TimerStop()}ms");
            Console.WriteLine($"=> Face Count: {faces.Length}");

            var matDsp = Glb.matSrc.Clone();
            foreach (var face in faces) {
                matDsp.Rectangle(face.TopLeft, face.BottomRight, Scalar.Lime, 4);
            }

            Glb.DrawMatAndHist1(matDsp);
            Glb.DrawMatAndHist2(null);

            matDsp.Dispose();
            matGray.Dispose();
        }

        public static void JpegCompress(int quality = 50) {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var bmp = Glb.matSrc.ToBitmap();
            var jpg = Glb.BitmapToJpg(bmp, quality);
            var bmpNew = new System.Drawing.Bitmap(jpg);
            var matDsp = bmpNew.ToMat();

            Glb.DrawMatAndHist1(matDsp);
            Glb.DrawMatAndHist2(null);

            matDsp.Dispose();
        }

        public static void Blob_CvBlobs(bool drawWithMyRenderer = true) {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matThr = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY).Threshold(128, 255, ThresholdTypes.Otsu);

            var blobs = new CvBlobs();

            Glb.TimerStart();
            int cnt = blobs.Label(matThr);
            Console.WriteLine($"=> Label Time: {Glb.TimerStop()}ms");

            var matDsp = new Mat(Glb.matSrc.Rows, Glb.matSrc.Cols, MatType.CV_8UC3);
            matDsp.SetTo(Scalar.Black);

            Glb.TimerStart();
            if (drawWithMyRenderer)
                IpUnsafe.RenderBlobs(blobs, matDsp);
            else
                blobs.RenderBlobs(matDsp, matDsp, RenderBlobsMode.Color);
            Console.WriteLine($"=> Render Time: {Glb.TimerStop()}ms");

            Console.WriteLine($"=> Blob Count: {blobs.Count}");

            Glb.DrawMatAndHist1(matThr);
            Glb.DrawMatAndHist2(matDsp);

            matThr.Dispose();
            matDsp.Dispose();
        }

        public static void Blob_Unsafe() {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matThr = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY).Threshold(128, 255, ThresholdTypes.Otsu);

            MyBlobs blobs = new MyBlobs();

            Stopwatch sw = Stopwatch.StartNew();
            blobs.Label(matThr.Data, matThr.Width, matThr.Height, (int)matThr.Step());
            sw.Stop();
            Console.WriteLine($"=> Label Time: {sw.ElapsedMilliseconds}ms");

            var matDst = new Mat(Glb.matSrc.Rows, Glb.matSrc.Cols, MatType.CV_8UC3);
            matDst.SetTo(Scalar.Black);
            Glb.TimerStart();
            IpUnsafe.RenderBlobs(blobs, matDst);
            Console.WriteLine($"=> Render Time: {Glb.TimerStop()}ms");

            Console.WriteLine($"=> Blob Count: {blobs.Blobs.Count}");

            Glb.DrawMatAndHist1(matThr);
            Glb.DrawMatAndHist2(matDst);

            matThr.Dispose();
            matDst.Dispose();
        }

        public static void Blob_DllC() {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matThr = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY).Threshold(128, 255, ThresholdTypes.Otsu);
            Glb.DrawMatAndHist1(matThr);

            var matDst = new Mat(Glb.matSrc.Rows, Glb.matSrc.Cols, MatType.CV_8UC1);
            matDst.SetTo(0);

            IpDll.BlobC(matThr.Data, matDst.Data, matThr.Width, matThr.Height, (int)matThr.Step());
            Glb.DrawMatAndHist2(matDst);

            matThr.Dispose();
            matDst.Dispose();
        }

        public static void AddSaltAndPepperNoise(int percent = 10, int medianK = 5) {
            var matGray = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist0(matGray);

            var matNoise = matGray.Clone();

            Random rnd = new Random();
            IntPtr buf = matNoise.Data;
            int bw = matNoise.Width;
            int bh = matNoise.Height;
            int stride = (int)matNoise.Step();
            for (int y = 0; y < bh; y++) {
                IntPtr pp = buf + stride * y;
                for (int x = 0; x < bw; x++, pp = pp + 1) {
                    var val = rnd.Next() % (100 / percent);
                    if (val == 0)
                        Marshal.WriteByte(pp, 255);
                    else if (val == 1)
                        Marshal.WriteByte(pp, 0);
                }
            }

            Glb.DrawMatAndHist1(matNoise);

            var matMedian = matNoise.MedianBlur(medianK);
            Glb.DrawMatAndHist2(matMedian);

            matGray.Dispose();
            matNoise.Dispose();
            matMedian.Dispose();
        }

        public static void DistanceTransform(DistanceTypes distanceType = DistanceTypes.L2, DistanceMaskSize distanceMaskSize = DistanceMaskSize.Mask3) {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matThr = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY).Threshold(128, 255, ThresholdTypes.Otsu);
            Glb.DrawMatAndHist1(matThr);

            var matDist = matThr.DistanceTransform(distanceType, distanceMaskSize);
            var matDistColor = new Mat();
            matDist.ConvertTo(matDistColor, MatType.CV_8UC1);
            Glb.DrawMatAndHist2(matDistColor);

            matThr.Dispose();
            matDist.Dispose();
            matDistColor.Dispose();
        }

        public static void Morpology(MorphTypes morphTypes = MorphTypes.Erode, int iterations = 1) {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matGray = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            
            var matMorpology = matGray.MorphologyEx(morphTypes, new Mat(), iterations: iterations);
            Glb.DrawMatAndHist1(matMorpology);

            Glb.DrawMatAndHist2(null);
            
            matGray.Dispose();
            matMorpology.Dispose();
        }
    }
}
