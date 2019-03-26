using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace OpenCVSharpTest {
    public enum ParallelMode {
        Serial,
        Parallel,
    }

    class TestErode {
        public static void ErodeOpenCv(int iteration) {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matGray = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matGray);

            Glb.TimerStart();
            var matDst = matGray.Erode(new Mat(), iterations: iteration, borderType: BorderTypes.Replicate);
            Console.WriteLine("=> Method Time: {0}ms", Glb.TimerStop());

            Glb.DrawMatAndHist2(matDst);

            matGray.Dispose();
            matDst.Dispose();
        }

        public static void ErodeUnsafe(int iteration, ParallelMode parallelMode) {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matGray = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matGray);

            Glb.TimerStart();
            var matTemp = matGray.Clone();
            var matDst = new Mat(matGray.Size(), matGray.Type());
            for (int i = 0; i < iteration; i++) {
                IntPtr srcBuf;
                IntPtr dstBuf;
                if (i % 2 == 0) {
                    srcBuf = matTemp.Data;
                    dstBuf = matDst.Data;
                } else {
                    srcBuf = matDst.Data;
                    dstBuf = matTemp.Data;
                }
                IpUnsafe.Erode(srcBuf, dstBuf, matGray.Width, matGray.Height, (int)matGray.Step(), parallelMode);
            }
            if (iteration % 2 == 0)
                matTemp.CopyTo(matDst);

            Console.WriteLine("=> Method Time: {0}ms", Glb.TimerStop());
            Glb.DrawMatAndHist2(matDst);

            matGray.Dispose();
            matDst.Dispose();
            matDst.Dispose();
        }

        public static void ErodeC(int iteration, ParallelMode parallelMode) {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matGray = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matGray);

            Glb.TimerStart();
            var matTemp = matGray.Clone();
            var matDst = new Mat(matGray.Size(), matGray.Type());
            for (int i = 0; i < iteration; i++) {
                IntPtr srcBuf;
                IntPtr dstBuf;
                if (i % 2 == 0) {
                    srcBuf = matTemp.Data;
                    dstBuf = matDst.Data;
                } else {
                    srcBuf = matDst.Data;
                    dstBuf = matTemp.Data;
                }
                IpDll.ErodeC(srcBuf, dstBuf, matGray.Width, matGray.Height, (int)matGray.Step(), parallelMode);
            }
            if (iteration % 2 == 0)
                matTemp.CopyTo(matDst);

            Console.WriteLine("=> Method Time: {0}ms", Glb.TimerStop());
            Glb.DrawMatAndHist2(matDst);

            matGray.Dispose();
            matDst.Dispose();
            matDst.Dispose();
        }

        public static void ErodeSse(int iteration, ParallelMode parallelMode) {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matGray = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matGray);

            Glb.TimerStart();
            var matTemp = matGray.Clone();
            var matDst = new Mat(matGray.Size(), matGray.Type());
            for (int i = 0; i < iteration; i++) {
                IntPtr srcBuf;
                IntPtr dstBuf;
                if (i % 2 == 0) {
                    srcBuf = matTemp.Data;
                    dstBuf = matDst.Data;
                } else {
                    srcBuf = matDst.Data;
                    dstBuf = matTemp.Data;
                }
                IpDll.ErodeSse(srcBuf, dstBuf, matGray.Width, matGray.Height, (int)matGray.Step(), parallelMode);
            }
            if (iteration % 2 == 0)
                matTemp.CopyTo(matDst);

            Console.WriteLine("=> Method Time: {0}ms", Glb.TimerStop());
            Glb.DrawMatAndHist2(matDst);

            matGray.Dispose();
            matDst.Dispose();
            matDst.Dispose();
        }

        public static void ErodeIpp(int iteration) {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matGray = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matGray);

            var matTemp = new Mat(matGray.Size(), matGray.Type());
            Glb.TimerStart();
            for (int i = 0; i < iteration; i++) {
                IpDll.ErodeIpp(matGray.Data, matTemp.Data, matGray.Width, matGray.Height, (int)matGray.Step());
                matTemp.CopyTo(matGray);
            }
            Console.WriteLine("=> Method Time: {0}ms", Glb.TimerStop());
            Glb.DrawMatAndHist2(matGray);

            matGray.Dispose();
            matTemp.Dispose();
        }
    }
}
