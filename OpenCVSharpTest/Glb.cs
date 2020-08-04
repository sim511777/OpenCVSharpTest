using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using OpenCvSharp.Blob;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;

namespace OpenCVSharpTest {
    class Glb {
        public static Mat matSrc = null;
        

        public static FormMain form = null;
        public static IntPtr imgBuf0 = IntPtr.Zero;
        public static IntPtr imgBuf1 = IntPtr.Zero;
        public static IntPtr imgBuf2 = IntPtr.Zero;

        public static void DrawMatAndHist0(Mat mat) {
            form.DrawMat(mat, form.pbx0, ref Glb.imgBuf0);
            form.DrawHistogram(mat, form.cht0);
        }

        public static void DrawMatAndHist1(Mat mat) {
            form.DrawMat(mat, form.pbx1, ref Glb.imgBuf1);
            form.DrawHistogram(mat, form.cht1);
        }

        public static void DrawMatAndHist2(Mat mat) {
            form.DrawMat(mat, form.pbx2, ref Glb.imgBuf2);
            form.DrawHistogram(mat, form.cht2);
        }

        public static void DrawMat0(Mat mat) {
            form.DrawMat(mat, form.pbx0, ref Glb.imgBuf0);
        }

        public static void DrawMat1(Mat mat) {
            form.DrawMat(mat, form.pbx1, ref Glb.imgBuf1);
        }

        public static void DrawMat2(Mat mat) {
            form.DrawMat(mat, form.pbx2, ref Glb.imgBuf2);
        }

        public static void DrawHist0(Mat mat, bool labelHsv = false) {
            form.DrawHistogram(mat, form.cht0, labelHsv);
        }

        public static void DrawHist1(Mat mat, bool hsv = false) {
            form.DrawHistogram(mat, form.cht1, hsv);
        }

        public static void DrawHist2(Mat mat, bool hsv = false) {
            form.DrawHistogram(mat, form.cht2, hsv);
        }

        private static Stopwatch sw = new Stopwatch();

        public static void TimerStart() {
            sw.Restart();
        }

        public static long TimerStop() {
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

        public static void Hsv2Rgb(double h, double s, double v, out double r, out double g, out double b) {
            double d = h / 60.0;
            int num1 = (int)Math.Floor(d);
            int num2 = (int)d % 6;
            double num3 = d - (double)num1;
            double num4 = v * (1.0 - s);
            double num5 = v * (1.0 - num3 * s);
            double num6 = v * (1.0 - (1.0 - num3) * s);
            switch (num2) {
                case 0:
                    r = (double)byte.MaxValue * v;
                    g = (double)byte.MaxValue * num6;
                    b = (double)byte.MaxValue * num4;
                    break;
                case 1:
                    r = (double)byte.MaxValue * num5;
                    g = (double)byte.MaxValue * v;
                    b = (double)byte.MaxValue * num4;
                    break;
                case 2:
                    r = (double)byte.MaxValue * num4;
                    g = (double)byte.MaxValue * v;
                    b = (double)byte.MaxValue * num6;
                    break;
                case 3:
                    r = (double)byte.MaxValue * num4;
                    g = (double)byte.MaxValue * num5;
                    b = (double)byte.MaxValue * v;
                    break;
                case 4:
                    r = (double)byte.MaxValue * num6;
                    g = (double)byte.MaxValue * num4;
                    b = (double)byte.MaxValue * v;
                    break;
                case 5:
                    r = (double)byte.MaxValue * v;
                    g = (double)byte.MaxValue * num4;
                    b = (double)byte.MaxValue * num5;
                    break;
                default:
                    throw new Exception();
            }
        }

        public static ImageCodecInfo GetImageCodecInfo(ImageFormat format) {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs) {
                if (codec.FormatID == format.Guid) {
                    return codec;
                }
            }
            return null;
        }
    }
}
