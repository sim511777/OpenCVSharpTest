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

        public unsafe static void Inverse(IntPtr buf, int bw, int bh, int stride) {
            byte *pbuf = (byte *)buf.ToPointer();
            for (int y = 0; y < bh; y++) {
                byte *ppbuf = pbuf + stride * y;
                for (int x = 0; x < bw; x++, ppbuf = ppbuf + 1) {
                   *ppbuf = (byte)~*ppbuf;
                }
            }
        }

        public unsafe static void MyBlob(IntPtr thr, IntPtr dst, int bw, int bh, int stride) {
            byte *pthr = (byte *)thr.ToPointer();
            byte *pdst = (byte *)dst.ToPointer();
            for (int y = 0; y < bh; y++) {
                byte *ppthr = pthr + stride * y;
                byte *ppdst = pdst + stride * y;
                for (int x = 0; x < bw; x++, ppthr = ppthr + 1, ppdst = ppdst + 1) {
                   *ppdst = (byte)~*ppthr;
                }
            }
        }
    }
}
