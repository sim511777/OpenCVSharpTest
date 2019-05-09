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
            Mat matCrop = new Mat(Glb.matSrc, roi);  // 크롭 이미지 생성 하여 수정
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

            MatOfFloat matDist = new MatOfFloat(matThr.Size());
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
            C,
            Sse,
            VectorClass,
            Avx,
        }

        public static void InverseAlgorithm(InverseUseAlgorithm useAlgorithm = InverseUseAlgorithm.OpenCv) {
            switch (useAlgorithm) {
                case InverseUseAlgorithm.OpenCv      : TestInverse.InverseOpenCv(); break;
                case InverseUseAlgorithm.Api         : TestInverse.InverseApi(); break;
                case InverseUseAlgorithm.Marshal     : TestInverse.InverseMarshal(); break;
                case InverseUseAlgorithm.Unsafe      : TestInverse.InverseUnsafe(); break;
                case InverseUseAlgorithm.C           : TestInverse.InverseC(); break;
                case InverseUseAlgorithm.Sse         : TestInverse.Sse(); break;
                case InverseUseAlgorithm.VectorClass : TestInverse.InverseVectorClass(); break;
                case InverseUseAlgorithm.Avx         : TestInverse.InverseAvx(); break;
                default: break;
            }
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
    }
}
