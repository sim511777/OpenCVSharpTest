using System;
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
            Glb.DrawMatAndHist1(matGray);

            var matDst = matGray.EqualizeHist();
            Glb.DrawMatAndHist2(matDst);

            matGray.Dispose();
            matDst.Dispose();
        }

        public static void EqualizeHistHsv() {
            Glb.DrawMatAndHist0(Glb.matSrc);
            
            // BGR to HSV변환
            var matHsv = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2HSV);
            // 채널 분리
            var hsvChannels = matHsv.Split();
            // 변환
            hsvChannels[2] = hsvChannels[2].EqualizeHist();
            Glb.DrawMatAndHist1(hsvChannels[2]);
            // 채널 병합
            var matDst = new Mat();
            Cv2.Merge(hsvChannels, matDst);
            // HSV to BGR변환
            matDst = matDst.CvtColor(ColorConversionCodes.HSV2BGR);
            Glb.DrawMatAndHist2(matDst);

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

        public static void Blur(double ksize = 5, BorderTypes borderType = BorderTypes.Reflect101) {
            Glb.DrawMatAndHist0(Glb.matSrc);
            
            var matGray = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matGray);
            
            var matDst = matGray.Blur(new Size(ksize, ksize), borderType:borderType);
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
            
            var matGray = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matGray);

            var matDst = matGray.MedianBlur(ksize);
            Glb.DrawMatAndHist2(matDst);

            matGray.Dispose();
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

        public static void Blob() {
            Glb.DrawMatAndHist0(Glb.matSrc);
            
            var matThr = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY).Threshold(128, 255, ThresholdTypes.Otsu);
            Glb.DrawMatAndHist1(matThr);

            var blobs = new CvBlobs();
            blobs.Label(matThr);
            Glb.Log("==== Blob List ====");
            var pairList = blobs.OrderBy(blob => blob.Key);
            foreach (var pair in pairList) {
                CvBlob blob = pair.Value;
                string msg = $"{blob.Label} {blob.Area}";
                Glb.Log(msg);
            }
            var matDsp = new Mat(Glb.matSrc.Rows, Glb.matSrc.Cols, MatType.CV_8UC3);
            blobs.RenderBlobs(matDsp, matDsp);
            Glb.DrawMatAndHist2(matDsp);

            matThr.Dispose();
            matDsp.Dispose();
        }

        public static void ContrastBrightness(double x1 = 64, double y1 = 0, double x2 = 192, double y2 = 255) {
            Glb.DrawMatAndHist0(Glb.matSrc);
            
            // BGR to HSV변환
            var matHsv = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2HSV);
            // 채널 분리
            var hsvChannels = matHsv.Split();
            // 변환
            double scale = (y2 - y1) / (x2 - x1);
            double offset = (x2 * y1 - x1 * y2) / (x2 - x1);
            hsvChannels[2].ConvertTo(hsvChannels[2], MatType.CV_8UC1, scale, offset);
            Glb.DrawMatAndHist1(hsvChannels[2]);
            // 채널 병합
            var matDst = new Mat();
            Cv2.Merge(hsvChannels, matDst);
            // HSV to BGR변환
            matDst = matDst.CvtColor(ColorConversionCodes.HSV2BGR);
            Glb.DrawMatAndHist2(matDst);

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
            Glb.DrawMatAndHist2(null);

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

        public static void Blob_Unsafe() {
            Glb.DrawMatAndHist0(Glb.matSrc);
            
            var matThr = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY).Threshold(128, 255, ThresholdTypes.Otsu);
            Glb.DrawMatAndHist1(matThr);

            var matDst = new Mat(Glb.matSrc.Rows, Glb.matSrc.Cols, MatType.CV_8UC1);
            matDst.SetTo(0);

            IpUnsafe.Blob(matThr.Data, matDst.Data, matThr.Width, matThr.Height, (int)matThr.Step());
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
    }
}
