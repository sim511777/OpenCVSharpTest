using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using OpenCvSharp.Blob;
using System.Diagnostics;

namespace OpenCVSharpTest {
    class Glb {
        public static Mat matSrc = null;
        

        public static FormMain form = null;

        public static void DrawMatAndHist0(Mat mat) {
            form.DrawMat(mat?.ToBitmap(), form.pbx0);
            form.DrawHistogram(mat, form.cht0);
        }

        public static void DrawMatAndHist1(Mat mat) {
            form.DrawMat(mat?.ToBitmap(), form.pbx1);
            form.DrawHistogram(mat, form.cht1);
        }

        public static void DrawMatAndHist2(Mat mat) {
            form.DrawMat(mat?.ToBitmap(), form.pbx2);
            form.DrawHistogram(mat, form.cht2);
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

        public static void RenderBlobs(CvBlobs blobs, Mat matDst) {
            int colorCount = 0;
            foreach (var blob in blobs.Values) {
                double r, g, b;
                Hsv2Rgb((colorCount*77) % 360, 0.5, 1.0, out r, out g, out b);
                colorCount++;
                Vec3b color = new Vec3b((byte)b, (byte)g, (byte)r);
                int label = blob.Label;
                for (int y=blob.MinY; y<=blob.MaxY; y++) {
                    for (int x=blob.MinX; x<=blob.MaxX; x++) {
                        if (blobs.Labels[y, x] == label) {
                            matDst.Set(y, x, color);
                        }
                    }
                }
            }
        }
    }
}
