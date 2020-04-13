using System;
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
using ShimLib;
using PointD = System.Windows.Point;

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

        public static void Sobel(int xorder = 1, int yorder = 1, int ksize = 3, double scale = 1, double delta = 0, BorderTypes borderType = BorderTypes.Replicate) {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matGray = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matGray);

            var matDst = matGray.Sobel(matGray.Type(), xorder, yorder, ksize, scale, delta, borderType);
            Glb.DrawMatAndHist2(matDst);

            matGray.Dispose();
            matDst.Dispose();
        }

        public static void Laplacian(int ksize = 1, double scale = 1, double delta = 0, BorderTypes borderType = BorderTypes.Replicate) {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matGray = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matGray);

            var matDst = matGray.Laplacian(matGray.Type(), ksize, scale, delta, borderType);
            Glb.DrawMatAndHist2(matDst);

            matGray.Dispose();
            matDst.Dispose();
        }

        public static void Blur(double ksize = 3, BorderTypes borderType = BorderTypes.Replicate) {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matGray = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matGray);

            var matDst = matGray.Blur(new Size(ksize, ksize), borderType: borderType);
            Glb.DrawMatAndHist2(matDst);

            matGray.Dispose();
            matDst.Dispose();
        }

        public static void GaussianBlur(double ksize = 5, double sigmaX = 5, double sigmaY = 5, BorderTypes borderType = BorderTypes.Replicate) {
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
            Mat matCrop = new Mat(Glb.matSrc, roi).Clone();  // 크롭 이미지 생성 하여 수정
            Cv2.BitwiseNot(matCrop, matCrop);
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

            var matDst = matGray.Filter2D(MatType.CV_8UC1, kernel, borderType: BorderTypes.Replicate);
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
            Console.WriteLine("=> Face Count: {0}", faces.Length);

            var matDsp = Glb.matSrc.Clone();
            foreach (var face in faces) {
                matDsp.Rectangle(face.TopLeft, face.BottomRight, Scalar.Lime, 4);
            }

            Glb.DrawMatAndHist1(matDsp);
            Glb.DrawMatAndHist2(null);

            matDsp.Dispose();
            matGray.Dispose();
        }

        public enum ImageFormatType { Bmp, Gif, Jpeg, Png, Tiff, }
        public static void ImageCompress(ImageFormatType format = ImageFormatType.Jpeg, int quality = 50) {
            var formatTable = new Dictionary<ImageFormatType, ImageFormat>() {
                { ImageFormatType.Bmp, ImageFormat.Bmp },
                { ImageFormatType.Gif, ImageFormat.Gif },
                { ImageFormatType.Jpeg, ImageFormat.Jpeg },
                { ImageFormatType.Png, ImageFormat.Png },
                { ImageFormatType.Tiff, ImageFormat.Tiff },
                };

            Glb.DrawMatAndHist0(Glb.matSrc);

            var bmpBufferSize = Glb.matSrc.Step() * Glb.matSrc.Height;
            
            var bmp = Glb.matSrc.ToBitmap();
            
            // 인코더 준비
            var imageFormat = formatTable[format];
            var enc = ImageCodecInfo.GetImageEncoders().FirstOrDefault(codecInfo => codecInfo.FormatID == imageFormat.Guid);
            var encPrms = new EncoderParameters(1);
            encPrms.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);

            // 메모리 스트림으로 저장
            var ms = new MemoryStream();
            bmp.Save(ms, enc, encPrms);
            
            var compressedBufferSize = ms.Length;

            // 메모리 스트림에서 로드
            var compressedImage = System.Drawing.Image.FromStream(ms);

            var bmpNew = new System.Drawing.Bitmap(compressedImage);
            var matDsp = bmpNew.ToMat();

            Console.WriteLine("bmp : {0}KB => {1}({2}%) : {3}KB", bmpBufferSize / 1000, imageFormat, quality, compressedBufferSize / 1000);

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
            MyBlobRenderer.RenderBlobs(blobs, matDsp);
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
            MyBlobRenderer.RenderBlobs(matLabels, matStats, matCentroids, matDsp);
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
            MyBlobRenderer.RenderBlobs(blobs, matDst);
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

        public static void DistanceTransformMy(bool negative = false)
        {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matThr = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY).Threshold(128, 255, ThresholdTypes.Otsu);
            if (negative)
                Cv2.BitwiseNot(matThr, matThr);
            Glb.DrawMatAndHist1(matThr);

            var matDist = new Mat<float>(matThr.Size());
            IpUnsafe.DistanceTransform(matThr.Data, matThr.Width, matThr.Height, matDist.Data);
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

        public static void Morpology(MorphTypes morphTypes = MorphTypes.Erode, MorphShapes shape = MorphShapes.Rect, int kernelSize = 3, int iteration = 1) {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matGray = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matGray);

            var element = Cv2.GetStructuringElement(shape, new Size(kernelSize, kernelSize));
            var matMorpology = matGray.MorphologyEx(morphTypes, element, iterations: iteration);
            Glb.DrawMatAndHist2(matMorpology);

            matGray.Dispose();
            matMorpology.Dispose();
        }

        public static void MorpologyChamfer(int kernelSize = 31, int iteration = 1) {
            var matGray = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist0(matGray);

            var element = new Mat(kernelSize, kernelSize, MatType.CV_8UC1);
            int r = kernelSize / 2;
            int cx = r;
            int cy = r;
            int rsq = r * r;

            for (int y = 0; y < kernelSize; y++) {
                for (int x = 0; x < kernelSize; x++) {
                    int dx = x - cx;
                    int dy = y - cy;
                    bool inCircle = dx * dx + dy * dy <= rsq;
                    element.Set(y, x, inCircle);
                }
            }
            
            var matMorpology1 = matGray.MorphologyEx(MorphTypes.Open, element, iterations: iteration);
            Glb.DrawMatAndHist1(matMorpology1);

            var matMorpology2 = matMorpology1.MorphologyEx(MorphTypes.Close, element, iterations: iteration);
            Glb.DrawMatAndHist2(matMorpology2);

            matGray.Dispose();
            matMorpology1.Dispose();
            matMorpology2.Dispose();
        }

        public static void MorpologyUserKernal(MorphTypes morphTypes = MorphTypes.Erode, int iteration = 1,
            byte m00 = 1, byte m01 = 1, byte m02 = 1,
            byte m10 = 1, byte m11 = 1, byte m12 = 1,
            byte m20 = 1, byte m21 = 1, byte m22 = 1) {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matGray = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matGray);
            byte[] arr = {
                m00, m01, m02,
                m10, m11, m12,
                m20, m21, m22,
            };
            var element = new Mat(3, 3, MatType.CV_8UC1, arr);
            var matMorpology = matGray.MorphologyEx(morphTypes, element, iterations: iteration);
            Glb.DrawMatAndHist2(matMorpology);

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

        public enum ImageCopyUseAlgorithm {
            Marshal1,
            Marshal2,
            Unsafe,
            Crt,
            BufferClass,
            OpenCV,
        }


        public static void ImageCopyAlgorithm(ImageCopyUseAlgorithm useAlgorithm = ImageCopyUseAlgorithm.OpenCV) {
            switch (useAlgorithm) {
                case ImageCopyUseAlgorithm.Marshal1    : TestImageCopy.ImageCopyMarshal1(); break;
                case ImageCopyUseAlgorithm.Marshal2    : TestImageCopy.ImageCopyMarshal2(); break;
                case ImageCopyUseAlgorithm.Unsafe      : TestImageCopy.ImageCopyUnsafe(); break;
                case ImageCopyUseAlgorithm.Crt         : TestImageCopy.ImageCopyCrt(); break;
                case ImageCopyUseAlgorithm.BufferClass : TestImageCopy.ImageCopyBufferClass(); break;
                case ImageCopyUseAlgorithm.OpenCV      : TestImageCopy.ImageCopyOpenCV(); break;
                default: break;
            }
        }

        public enum InverseUseAlgorithm {
            OpenCv,
            Api,
            Marshal,
            Unsafe,
            ParallelFor,
            C,
            Sse,
            SseParallel,
            VectorClass,
            Avx,
        }

        public static void InverseAlgorithm(InverseUseAlgorithm useAlgorithm = InverseUseAlgorithm.OpenCv) {
            double dtMs = 0;
            switch (useAlgorithm) {
                case InverseUseAlgorithm.OpenCv      : dtMs = TestInverse.InverseOpenCv(); break;
                case InverseUseAlgorithm.Api         : dtMs = TestInverse.InverseApi(); break;
                case InverseUseAlgorithm.Marshal     : dtMs = TestInverse.InverseMarshal(); break;
                case InverseUseAlgorithm.Unsafe      : dtMs = TestInverse.InverseUnsafe(); break;
                case InverseUseAlgorithm.ParallelFor : dtMs = TestInverse.InverseParallelFor(); break;
                case InverseUseAlgorithm.C           : dtMs = TestInverse.InverseC(); break;
                case InverseUseAlgorithm.Sse         : dtMs = TestInverse.Sse(false); break;
                case InverseUseAlgorithm.SseParallel : dtMs = TestInverse.Sse(true); break;
                case InverseUseAlgorithm.VectorClass : dtMs = TestInverse.InverseVectorClass(); break;
                case InverseUseAlgorithm.Avx         : dtMs = TestInverse.InverseAvx(); break;
                default: break;
            }
            Console.WriteLine($"Inverse Time = {dtMs:0.000}ms");
        }

        public enum ErodeUseAlgorithm {
            OpenCv,
            Unsafe,
            C,
            Sse,
            Ipp,
        }

        public static void ErodeAlgorithm(ErodeUseAlgorithm useAlgorithm = ErodeUseAlgorithm.OpenCv, int iteration = 20, bool useParallel = true) {
            switch (useAlgorithm) {
                case ErodeUseAlgorithm.OpenCv            : TestErode.ErodeOpenCv(iteration); break;
                case ErodeUseAlgorithm.Unsafe            : TestErode.ErodeUnsafe(iteration, useParallel); break;
                case ErodeUseAlgorithm.C                 : TestErode.ErodeC(iteration, useParallel); break;
                case ErodeUseAlgorithm.Sse               : TestErode.ErodeSse(iteration, useParallel); break;
                case ErodeUseAlgorithm.Ipp               : TestErode.ErodeIpp(iteration); break;
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

        public static void DummyFunction(int callCount = 20, int sleepMs = 20) {
            var matGray = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            var matDst = new Mat(matGray.Size(), matGray.Type());
            Glb.TimerStart();
            for (int i=0; i<callCount; i++)
                IpDll.DummyFunction(matGray.Data, matDst.Data, matGray.Width, matGray.Height, (int)matGray.Step(), sleepMs);
            Console.WriteLine("=> DummyFunction Time: {0}ms", Glb.TimerStop());
        }

        public static void ErodeIppRoi(int iteration = 20, int roiX = 50, int roiY = 50, int roiW = 50, int roiH = 50) {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matGray = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matGray);

            Glb.TimerStart();
            var matDst = matGray.Clone();
            for (int i = 0; i < iteration; i++) {
                if (i % 2 == 0)
                    IpDll.ErodeIppRoi(matGray.Data, matDst.Data, matGray.Width, matGray.Height, (int)matGray.Step(), roiX, roiY, roiW, roiH);
                else
                    IpDll.ErodeIppRoi(matDst.Data, matGray.Data, matGray.Width, matGray.Height, (int)matGray.Step(), roiX, roiY, roiW, roiH);
            }
            if (iteration != 0 && iteration % 2 == 0)
                matGray.CopyTo(matDst);

            Console.WriteLine("=> Method Time: {0}ms", Glb.TimerStop());
            Glb.DrawMatAndHist2(matDst);

            matGray.Dispose();
            matDst.Dispose();
        }

        public static void Skeleton() {
            Glb.DrawMatAndHist0(Glb.matSrc);
            var size = Glb.matSrc.Size();
            var matSkel = new Mat(Glb.matSrc.Size(), MatType.CV_8UC1, 0);
        }

        public static void GetStringTest() {
            StringBuilder sb = new StringBuilder(512);
            IpDll.GetString(sb);
            Console.WriteLine(sb.ToString());
        }

        public static void SetStringTest(string str = "0123456789") {
            IpDll.SetString(str);
        }

        //public static void GenerateHoleTest(
        //        int bufWidth = 1000, int bufHeight = 1000, byte bufColor = 35,
        //        int circleX = 500, int circleY = 500, int circleRadius = 30, byte circleColor = 255,
        //        double blurKsize = 61, double blurSigma = 0,
        //        int resizeX = 100, int resizeY = 100) {
        //    var matImage = new Mat(bufHeight, bufWidth, MatType.CV_8UC1);
        //    matImage.FloodFill(new Point(0, 0), bufColor);
        //    matImage.Circle(circleX, circleY, circleRadius, circleColor);
        //    matImage.FloodFill(new Point(circleX, circleY), circleColor);
        //    Glb.DrawMatAndHist0(matImage);

        //    var matBlur = matImage.GaussianBlur(new Size(blurKsize, blurKsize), blurSigma, blurSigma, BorderTypes.Replicate);
        //    Glb.DrawMatAndHist1(matBlur);

        //    var matResize = matBlur.Resize(new Size(resizeX, resizeY));
        //    Glb.DrawMatAndHist2(matResize);

        //    matResize.Dispose();
        //    matBlur.Dispose();
        //    matImage.Dispose();
        //}

        //public static void GenerateHoleLocationSaveTest(
        //        int bufWidth = 1000, int bufHeight = 1000, byte bufColor = 35,
        //        int circleX = 500, int circleY = 500, int circleRadius = 30, byte circleColor = 255,
        //        double blurKsize = 61, double blurSigma = 0,
        //        int resizeX = 100, int resizeY = 100) {
        //    for (int y = circleY; y < circleY + 10; y++) {
        //        for (int x = circleX; x < circleX + 10; x++) {
        //            var matImage = new Mat(bufHeight, bufWidth, MatType.CV_8UC1);
        //            matImage.FloodFill(new Point(0, 0), bufColor);
        //            matImage.Circle(x, y, circleRadius, circleColor);
        //            matImage.FloodFill(new Point(x, y), circleColor);
        //            Glb.DrawMatAndHist0(matImage);

        //            var matBlur = matImage.GaussianBlur(new Size(blurKsize, blurKsize), blurSigma, blurSigma, BorderTypes.Replicate);
        //            Glb.DrawMatAndHist1(matBlur);

        //            var matResize = matBlur.Resize(new Size(resizeX, resizeY));
        //            Glb.DrawMatAndHist2(matResize);
        //            string imageFilePath = $@"C:\test\ContactHole_Location\HolePos_({x},{y}).bmp";
        //            bool r = matResize.SaveImage(imageFilePath);
        //            Console.WriteLine($"Save Image File : {imageFilePath} => {r}");
        //            matResize.Dispose();
        //            matBlur.Dispose();
        //            matImage.Dispose();
        //        }
        //    }
        //}

        //public static void GenerateHoleSizeSaveTest(
        //        int bufWidth = 1000, int bufHeight = 1000, byte bufColor = 35,
        //        int circleX = 500, int circleY = 500, int circleRadius = 30, byte circleColor = 255,
        //        double blurKsize = 61, double blurSigma = 0,
        //        int resize = 100) {
        //    for (int i = - 20; i <= 20; i += 4) {
        //        var matImage = new Mat(bufHeight, bufWidth, MatType.CV_8UC1);
        //        matImage.FloodFill(new Point(0, 0), bufColor);
        //        matImage.Circle(circleX, circleY, circleRadius, circleColor);
        //        matImage.FloodFill(new Point(circleX, circleY), circleColor);
        //        Glb.DrawMatAndHist0(matImage);

        //        var matBlur = matImage.GaussianBlur(new Size(blurKsize, blurKsize), blurSigma, blurSigma, BorderTypes.Replicate);
        //        Glb.DrawMatAndHist1(matBlur);

        //        int roiSize = 60;
        //        int resize2 = resize + i;
        //        var matResizeHole = matBlur.Resize(new Size(resize2, resize2));
        //        var matResizeHoleRoi = new Mat(matResizeHole, new Rect((resize2-roiSize)/2, (resize2-roiSize)/2, roiSize, roiSize));

        //        var matResizeOri = matImage.Resize(new Size(resize, resize));
        //        var matResizeOriRoi = new Mat(matResizeOri, new Rect((resize-roiSize)/2, (resize-roiSize)/2, roiSize, roiSize));

        //        matResizeHoleRoi.CopyTo(matResizeOriRoi);
        //        string imageFilePath = $@"C:\test\ContactHole_Size\HoleSize_({resize2:000}).bmp";
        //        bool r = matResizeOri.SaveImage(imageFilePath);
        //        Console.WriteLine($"Save Image File : {imageFilePath} => {r}");

        //        matResizeHole.Dispose();
        //        matBlur.Dispose();
        //        matImage.Dispose();
        //    }
        //}

        public static void HSVControl(double hscale = 1.0, double hoffset = 0.0, double sscale = 1.0, double soffset = 0.0, double vscale = 1.0, double voffset = 0.0) {
            Glb.DrawMat0(Glb.matSrc);

            // BGR to HSV변환
            var matHsv = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2HSV);
            Glb.DrawHist0(matHsv, true);

            // 채널 분리
            var hsvChannels = matHsv.Split();
            // 변환
            hsvChannels[0].ConvertTo(hsvChannels[0], MatType.CV_8UC1, hscale, hoffset);
            hsvChannels[1].ConvertTo(hsvChannels[1], MatType.CV_8UC1, sscale, soffset);
            hsvChannels[2].ConvertTo(hsvChannels[2], MatType.CV_8UC1, vscale, voffset);

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

        public static void Resize(double magnify = 64, InterpolationFlags interpolation = InterpolationFlags.Linear) {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var sizeSrc = Glb.matSrc.Size();
            var sizeDst = new Size(sizeSrc.Width * magnify, sizeSrc.Height * magnify);
            var matResize = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY).Resize(sizeDst, interpolation: interpolation);
            Glb.DrawMatAndHist1(matResize);
            
            Glb.DrawMatAndHist2(null);

            matResize.Dispose();
        }

        public static unsafe void DevernayTest(double sigma = 0, double th_h = 128, double th_l = 50) {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matGray = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matGray);
            Glb.DrawMatAndHist2(null);

            IntPtr image = Marshal.AllocHGlobal(matGray.Width * matGray.Height * sizeof(double));
            for (int iy = 0; iy < matGray.Height; iy++)
            {
                byte* sptr = (byte*)matGray.Ptr(iy);
                double* dptr = (double*)image + matGray.Width * iy;
                for (int ix = 0; ix < matGray.Width; ix++, sptr++, dptr++)
                {
                    *dptr = *sptr;
                }
            }
            IntPtr x = IntPtr.Zero;
            IntPtr y = IntPtr.Zero;
            int numXY = 0;
            IntPtr curve_limits= IntPtr.Zero;
            int numCurve = 0;
            IpDll.Devernay(ref x, ref y, ref numXY, ref curve_limits, ref numCurve, image, matGray.Width, matGray.Height, sigma, th_h, th_l);
            Console.WriteLine($"numXY={numXY}, numCurve={numCurve}");

            double* xList = (double*)x;
            double* yList = (double*)y;
            int* curveLimitList = (int*)curve_limits;

            List<List<PointD>> curveList = new List<List<PointD>>();
            for (int i = 0; i < numCurve; i++) {
                List<PointD> curve = new List<PointD>();
                curveList.Add(curve);
                int stIdx = curveLimitList[i];
                int edIdx = i < numCurve - 1 ? curveLimitList[i + 1] : numXY;
                for (int j = stIdx; j < edIdx; j++) {
                    curve.Add(new PointD(xList[j], yList[j]));
                }
            }

            Action<ImageGraphics> drawing = delegate(ImageGraphics ig) {
                foreach (var curve in curveList) {
                    var polyline = curve
                    .Select(ptd => new PointD(ptd.X + 0.5, ptd.Y + 0.5)).ToArray();
                    for (int i = 0; i < polyline.Length - 1; i++) {
                        var pt1 = polyline[i];
                        var pt2 = polyline[i + 1];
                        ig.DrawLine(pt1, pt2, System.Drawing.Pens.Lime);
                    }
                }
            };
            Glb.form.pbx1.Tag = drawing;

            IpDll.FreeBuffer(x);
            IpDll.FreeBuffer(y);
            IpDll.FreeBuffer(curve_limits);
            Marshal.FreeHGlobal(image);
            
            matGray.Dispose();
        }

        //public static void MakeImage(int bw = 1000, int bh = 1000, int seed = 0, int holeSize = 22, int gaussainSize = 31, int distortSize = 20, int imgNum = 256) {
        //    void DrawCircle(System.Drawing.Graphics g, int x, int y, int r, System.Drawing.Brush br) {
        //        g.FillEllipse(br, x - r, y - r, r + r, r + r);
        //    }

        //    Random rndg = new Random(seed);

        //    using (System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(bw, bh)) {
        //        Console.WriteLine($"Make Iamge by code: ({bmp.Width}x{bmp.Height})");

        //        for (int imgIdx = 0; imgIdx < imgNum; imgIdx++) {
        //            using (var g = System.Drawing.Graphics.FromImage(bmp)) {
        //                System.Drawing.Rectangle rect = new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height);
        //                System.Drawing.Brush br = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(35, 35, 35));
        //                g.FillRectangle(br, rect);
        //                br.Dispose();
        //                g.FillRectangle(System.Drawing.Brushes.White, 100, 100, 50, 150);
        //                g.FillRectangle(System.Drawing.Brushes.White, 100, 100, 150, 50);

        //                Random rnd = new Random(seed);
        //                for (int i = 0; i < 7; i++) {
        //                    bool xdistort = rndg.Next() % 32 == 0;
        //                    bool ydistort = rndg.Next() % 32 == 0;
        //                    int x;
        //                    int y;
        //                    if (xdistort)
        //                        x = rnd.Next(1, 10) * 100 + rndg.Next(-distortSize, distortSize);
        //                    else
        //                        x = rnd.Next(1, 10) * 100;
        //                    if (ydistort)
        //                        y = rnd.Next(1, 10) * 100 + rndg.Next(-distortSize, distortSize);
        //                    else
        //                        y = rnd.Next(1, 10) * 100;

        //                    DrawCircle(g, x, y, holeSize, System.Drawing.Brushes.White);
        //                }
        //            }

        //            var matGray = bmp.ToMat().CvtColor(ColorConversionCodes.BGR2GRAY);
        //            var matBlur = matGray.GaussianBlur(new Size(gaussainSize, gaussainSize), gaussainSize, gaussainSize, BorderTypes.Replicate);
        //            var matResult = matBlur.Resize(new Size(bw / 10, bh / 10), 0, 0, InterpolationFlags.Linear);

        //            string filePath = $"c:\\test\\chole\\img_{imgIdx:00}.bmp";
        //            matResult.SaveImage(filePath);
        //            Console.WriteLine($"SaveImge: ({filePath})");

        //            //Glb.DrawMatAndHist0(matGray);
        //            //Glb.DrawMatAndHist1(matBlur);
        //            //Glb.DrawMatAndHist2(matResult);

        //            matGray.Dispose();
        //            matBlur.Dispose();
        //            matResult.Dispose();
        //        }
        //    }
        //}

        public static void RoateImage(double rotDegree = 90, InterpolationFlags ipf = InterpolationFlags.Linear) {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matGray = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matGray);

            Size size = matGray.Size();
            Mat matRot = Cv2.GetRotationMatrix2D(new Point2f(size.Width / 2, size.Height / 2), rotDegree, 1);
            Mat matDst = matGray.WarpAffine(matRot, size, ipf);
            
            Glb.DrawMatAndHist2(matDst);

            matRot.Dispose();
            matDst.Dispose();
        }

        public static void BatchConvert(string fileDir = @"C:\Users\shshim\Desktop\output") {
            return;
            var files = Directory.GetFiles(fileDir);
            Rect roi = new Rect(4, 2, 6, 8);
            foreach (var file in files) {
                Console.WriteLine(file);
                var ext = Path.GetExtension(file);
                if (ext != ".bmp") {
                    Console.WriteLine("  skip");
                    continue;
                }
                Mat mSrc = new Mat(file);
                Mat mCrop = new Mat(mSrc, roi);
                Mat mGray = mCrop.CvtColor(ColorConversionCodes.BGR2GRAY);
                mGray.SaveImage(file);
                Console.WriteLine($"  Save");
            }
        }
    }
}
