using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace OpenCVSharpTest {
    class Glb {
        public static FormMain form = null;
        public static Mat matSrc = null;

        public static void Log(string msg) {
            form.Log(msg);
        }

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

        public static void MyBlob(IntPtr thr, IntPtr dst, int bw, int bh, int stride) {
            for (int y = 0; y < bh; y++) {
                IntPtr pthr = thr + stride * y;
                IntPtr pdst = dst + stride * y;
                for (int x = 0; x < bw; x++, pthr = pthr + 1, pdst = pdst + 1) {
                   Marshal.WriteByte(pthr, (byte)~Marshal.ReadByte(pthr));
                }
            }
        }
    }
}
