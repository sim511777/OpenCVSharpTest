using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using OpenCvSharp;
using OpenCvSharp.Extensions;
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
    }
}
