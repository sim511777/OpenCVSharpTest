﻿using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Text;

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
            Console.WriteLine("=> Detect Time: {0}ms", Glb.TimerStop());
            Console.WriteLine("=> Face Count: {}", faces.Length);

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

        public static void Blob_CvBlobs(int filterArea = 0) {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matThr = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY).Threshold(128, 255, ThresholdTypes.Otsu);

            var blobs = new CvBlobs();

            Glb.TimerStart();
            int cnt = blobs.Label(matThr);
            Console.WriteLine("=> Label Time: {0}ms", Glb.TimerStop());

            blobs.FilterByArea(filterArea, int.MaxValue);

            var matDsp = new Mat(Glb.matSrc.Rows, Glb.matSrc.Cols, MatType.CV_8UC3);
            matDsp.SetTo(Scalar.Black);

            Glb.TimerStart();
            IpUnsafe.RenderBlobs(blobs, matDsp);
            Console.WriteLine("=> Render Time: {0}ms", Glb.TimerStop());

            Console.WriteLine("=> Blob Count: {0}", blobs.Count);

            Glb.DrawMatAndHist1(matThr);
            Glb.DrawMatAndHist2(matDsp);

            matThr.Dispose();
            matDsp.Dispose();
        }

        public static void Blob_CvConnectedComponent() {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matThr = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY).Threshold(128, 255, ThresholdTypes.Otsu);
            
            var matLabels = new Mat();
            var matStats = new Mat();
            var matCentroids = new Mat();

            Glb.TimerStart();
            int num = matThr.ConnectedComponentsWithStats(matLabels, matStats, matCentroids) - 1;   // 배경까지 블럽으로 계산된다.
            Console.WriteLine("=> Label Time: {0}ms", Glb.TimerStop());

            var matDsp = new Mat(Glb.matSrc.Rows, Glb.matSrc.Cols, MatType.CV_8UC3);
            matDsp.SetTo(Scalar.Black);

            Glb.TimerStart();
            IpUnsafe.RenderBlobs(matLabels, matStats, matCentroids, matDsp);
            Console.WriteLine("=> Render Time: {0}ms", Glb.TimerStop());

            Console.WriteLine("=> Blob Count: {0}", num);

            Glb.DrawMatAndHist1(matThr);
            Glb.DrawMatAndHist2(matDsp);

            matThr.Dispose();
            matLabels.Dispose();
            matStats.Dispose();
            matCentroids.Dispose();
            matDsp.Dispose();
        }

        public static void Blob_Unsafe() {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matThr = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY).Threshold(128, 255, ThresholdTypes.Otsu);

            MyBlobs blobs = new MyBlobs();

            Stopwatch sw = Stopwatch.StartNew();
            blobs.Label(matThr.Data, matThr.Width, matThr.Height, (int)matThr.Step());
            sw.Stop();
            Console.WriteLine("=> Label Time: {0}ms", sw.ElapsedMilliseconds);

            var matDst = new Mat(Glb.matSrc.Rows, Glb.matSrc.Cols, MatType.CV_8UC3);
            matDst.SetTo(Scalar.Black);
            Glb.TimerStart();
            IpUnsafe.RenderBlobs(blobs, matDst);
            Console.WriteLine("=> Render Time: {0}ms", Glb.TimerStop());

            Console.WriteLine("=> Blob Count: {0}", blobs.Blobs.Count);

            Glb.DrawMatAndHist1(matThr);
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

        public static void DistanceTransform(bool negative = false, DistanceTypes distanceType = DistanceTypes.L2, DistanceMaskSize distanceMaskSize = DistanceMaskSize.Mask3) {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matThr = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY).Threshold(128, 255, ThresholdTypes.Otsu);
            if (negative)
                Cv2.BitwiseNot(matThr, matThr);
            Glb.DrawMatAndHist1(matThr);

            var matDist = matThr.DistanceTransform(distanceType, distanceMaskSize);
            var x1 = matDist.Min();
            var x2 = matDist.Max();
            float y1 = 0;
            float y2 = 255;
            double scale = (y2 - y1) / (x2 - x1);
            double offset = (x2 * y1 - x1 * y2) / (x2 - x1);
            var matDistColor = new Mat();
            matDist.ConvertTo(matDistColor, MatType.CV_8UC1, scale, offset);
            Glb.DrawMatAndHist2(matDistColor);

            matThr.Dispose();
            matDist.Dispose();
            matDistColor.Dispose();
        }

        public static void Morpology(MorphTypes morphTypes = MorphTypes.Erode, int iteration = 1) {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matGray = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);

            var matMorpology = matGray.MorphologyEx(morphTypes, new Mat(), iterations: iteration);
            Glb.DrawMatAndHist1(matMorpology);

            Glb.DrawMatAndHist2(null);

            matGray.Dispose();
            matMorpology.Dispose();
        }

        public static void LabColorSpace(int channel1 = 0, int channel2 = 1) {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matLab = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2Lab);
            var hsvChannels = matLab.Split();
            Glb.DrawMatAndHist1(hsvChannels[channel1]);
            Glb.DrawMatAndHist2(hsvChannels[channel2]);
            matLab.Dispose();
        }

        public static void CarbonPaper(int x1 = 100, int y1 = 300, int x2 = 1100, int y2 = 1600, ThresholdTypes thrType = ThresholdTypes.Binary, int thr = 128, int filterArea = 30) {
            // 1. convert to grayscale
            var matGray = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);

            // 2. roi crop
            Rect roi = new Rect(x1, y1, x2 - x1 + 1, y2 - y1 + 1);
            var matGrayDrawRoi = Glb.matSrc.Clone();
            matGrayDrawRoi.Rectangle(roi, Scalar.Yellow);
            Glb.DrawMat0(matGrayDrawRoi);

            var matRoi = new Mat(matGray, roi);
            Glb.DrawHist0(matRoi);

            // 3. threshold
            var matThr = matRoi.Threshold(thr, 255, thrType);
            Glb.DrawMatAndHist1(matThr);

            // 4. blob with area filter
            CvBlobs blobs = new CvBlobs();
            blobs.Label(matThr);
            blobs.FilterByArea(filterArea, int.MaxValue);

            // 5. display blob
            var matDsp = new Mat(matRoi.Rows, matRoi.Cols, MatType.CV_8UC3);
            matDsp.SetTo(Scalar.Black);
            blobs.RenderBlobs(matDsp, matDsp, RenderBlobsMode.Color);
            Glb.DrawMatAndHist2(matDsp);

            Console.WriteLine("blobs.cnt = {0}", blobs.Count);

            matGray.Dispose();
            matGrayDrawRoi.Dispose();
            matRoi.Dispose();
            matThr.Dispose();
            matDsp.Dispose();
        }

        public static void ImageCopyMarshal1() {
            Mat matDst = new Mat(Glb.matSrc.Size(), Glb.matSrc.Type());
            int nbytes = (int)Glb.matSrc.Step() * Glb.matSrc.Height;

            Glb.TimerStart();
            IpUnsafe.MemcpyMarshal1(matDst.Data, Glb.matSrc.Data, nbytes);
            Console.WriteLine("=> Method Time: {0}ms", Glb.TimerStop());

            Glb.DrawMatAndHist0(Glb.matSrc);
            Glb.DrawMatAndHist1(matDst);
            Glb.DrawMatAndHist2(null);
            matDst.Dispose();
        }

        public static void ImageCopyMarshal2() {
            Mat matDst = new Mat(Glb.matSrc.Size(), Glb.matSrc.Type());
            int nbytes = (int)Glb.matSrc.Step() * Glb.matSrc.Height;

            Glb.TimerStart();
            IpUnsafe.MemcpyMarshal2(matDst.Data, Glb.matSrc.Data, nbytes);
            Console.WriteLine("=> Method Time: {0}ms", Glb.TimerStop());

            Glb.DrawMatAndHist0(Glb.matSrc);
            Glb.DrawMatAndHist1(matDst);
            Glb.DrawMatAndHist2(null);
            matDst.Dispose();
        }

        public static void ImageCopyUnsafe() {
            Mat matDst = new Mat(Glb.matSrc.Size(), Glb.matSrc.Type());
            int nbytes = (int)Glb.matSrc.Step() * Glb.matSrc.Height;

            Glb.TimerStart();
            IpUnsafe.MemcpyUnsafe(matDst.Data, Glb.matSrc.Data, nbytes);
            Console.WriteLine("=> Method Time: {0}ms", Glb.TimerStop());

            Glb.DrawMatAndHist0(Glb.matSrc);
            Glb.DrawMatAndHist1(matDst);
            Glb.DrawMatAndHist2(null);
            matDst.Dispose();
        }

        public static void ImageCopyCrt() {
            Mat matDst = new Mat(Glb.matSrc.Size(), Glb.matSrc.Type());
            int nbytes = (int)Glb.matSrc.Step() * Glb.matSrc.Height;

            Glb.TimerStart();
            IpUnsafe.MemcpyCrt(matDst.Data, Glb.matSrc.Data, nbytes);
            Console.WriteLine("=> Method Time: {0}ms", Glb.TimerStop());

            Glb.DrawMatAndHist0(Glb.matSrc);
            Glb.DrawMatAndHist1(matDst);
            Glb.DrawMatAndHist2(null);
            matDst.Dispose();
        }

        public static void ImageCopyBufferClass() {
            Mat matDst = new Mat(Glb.matSrc.Size(), Glb.matSrc.Type());
            int nbytes = (int)Glb.matSrc.Step() * Glb.matSrc.Height;

            Glb.TimerStart();
            IpUnsafe.MemcpyBufferClass(matDst.Data, Glb.matSrc.Data, nbytes);
            Console.WriteLine("=> Method Time: {0}ms", Glb.TimerStop());

            Glb.DrawMatAndHist0(Glb.matSrc);
            Glb.DrawMatAndHist1(matDst);
            Glb.DrawMatAndHist2(null);
            matDst.Dispose();
        }

        public static void ImageCopyOpenCV() {
            Mat matDst = new Mat(Glb.matSrc.Size(), Glb.matSrc.Type());

            Glb.TimerStart();
            Glb.matSrc.CopyTo(matDst);
            Console.WriteLine("=> Method Time: {0}ms", Glb.TimerStop());

            Glb.DrawMatAndHist0(Glb.matSrc);
            Glb.DrawMatAndHist1(matDst);
            Glb.DrawMatAndHist2(null);
            matDst.Dispose();
        }

        public static void InverseApi_RGB() {
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

        public static void InverseOpenCv() {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matGray = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matGray);

            var matDst = new Mat();
            Cv2.BitwiseNot(matGray, matDst);
            Glb.DrawMatAndHist2(matDst);

            matGray.Dispose();
            matDst.Dispose();
        }

        public static void InverseApi() {
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

        public static void InverseMarshal() {
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

        public static void InverseUnsafe() {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matDst = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matDst);

            IpUnsafe.Inverse(matDst.Data, matDst.Width, matDst.Height, (int)matDst.Step());
            Glb.DrawMatAndHist2(matDst);

            matDst.Dispose();
        }

        public static void InverseC() {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matDst = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matDst);

            IpDll.InverseC(matDst.Data, matDst.Width, matDst.Height, (int)matDst.Step());
            Glb.DrawMatAndHist2(matDst);

            matDst.Dispose();
        }

        public static void InverseSee() {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matDst = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matDst);

            IpDll.InverseSse(matDst.Data, matDst.Width, matDst.Height, (int)matDst.Step());
            Glb.DrawMatAndHist2(matDst);

            matDst.Dispose();
        }

        public static void InverseVectorClass() {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matDst = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matDst);

            IpDll.InverseVec(matDst.Data, matDst.Width, matDst.Height, (int)matDst.Step());
            Glb.DrawMatAndHist2(matDst);

            matDst.Dispose();
        }

        public static void InverseAvx() {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matDst = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matDst);

            IpDll.InverseAvx(matDst.Data, matDst.Width, matDst.Height, (int)matDst.Step());
            Glb.DrawMatAndHist2(matDst);

            matDst.Dispose();
        }

        public enum ErodeUseAlgorithm {
            OpenCv,
            Unsafe,
            UnsafeParallel,
            Unsafe2,
            Unsafe3,
            C,
            CNoCopy,
            CStl,
            CParallel,
            C2,
            C2Parallel,
            Sse,
            Sse2D,
            SseParallel,
            SseParallelNoCopy,
            SseOpenMP,
            SseOpenMPNoCopy,
            Ipp,
        }

        public static void Erode(ErodeUseAlgorithm useAlgorithm = ErodeUseAlgorithm.OpenCv, int iteration = 20) {
            switch (useAlgorithm) {
                case ErodeUseAlgorithm.OpenCv: ErodeTest.ErodeOpenCv(iteration); break;
                case ErodeUseAlgorithm.Unsafe: ErodeTest.ErodeUnsafe(iteration); break;
                case ErodeUseAlgorithm.UnsafeParallel: ErodeTest.ErodeUnsafeParallel(iteration); break;
                case ErodeUseAlgorithm.Unsafe2: ErodeTest.ErodeUnsafe2(iteration); break;
                case ErodeUseAlgorithm.Unsafe3: ErodeTest.ErodeUnsafe3(iteration); break;
                case ErodeUseAlgorithm.C: ErodeTest.ErodeC(iteration); break;
                case ErodeUseAlgorithm.CNoCopy: ErodeTest.ErodeCNoCopy(iteration); break;
                case ErodeUseAlgorithm.CStl: ErodeTest.ErodeCStl(iteration); break;
                case ErodeUseAlgorithm.CParallel: ErodeTest.ErodeCParallel(iteration); break;
                case ErodeUseAlgorithm.C2: ErodeTest.ErodeC2(iteration); break;
                case ErodeUseAlgorithm.C2Parallel: ErodeTest.ErodeC2Parallel(iteration); break;
                case ErodeUseAlgorithm.Sse: ErodeTest.ErodeSse(iteration); break;
                case ErodeUseAlgorithm.Sse2D: ErodeTest.ErodeSse2D(iteration); break;
                case ErodeUseAlgorithm.SseParallel: ErodeTest.ErodeSseParallel(iteration); break;
                case ErodeUseAlgorithm.SseParallelNoCopy: ErodeTest.ErodeSseParallelNoCopy(iteration); break;
                case ErodeUseAlgorithm.SseOpenMP: ErodeTest.ErodeSseOpenMP(iteration); break;
                case ErodeUseAlgorithm.SseOpenMPNoCopy: ErodeTest.ErodeSseOpenMPNoCopy(iteration); break;
                case ErodeUseAlgorithm.Ipp: ErodeTest.ErodeIpp(iteration); break;
                default: break;
            }
        }

        public static void MatrixTest(FormatType formatType = FormatType.Default) {
            Glb.DrawMatAndHist0(null);
            Glb.DrawMatAndHist1(null);
            Glb.DrawMatAndHist2(null);

            void PrintMat(Mat mat) {
                Console.WriteLine(mat.Dump(formatType).Replace("\n","\r\n"));
            }

            Mat a = new Mat(1, 3, MatType.CV_64FC1);
            a.Set(0, 0, 1.0);
            a.Set(0, 1, 2.0);
            a.Set(0, 2, 3.0);
            PrintMat(a);
            PrintMat(a.Transpose());
        }
    }
}
