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

    public enum MorphologyLogic {
        Outer,
        Inner,
        InnerValue,
    }

    class TestErode {
        public static void ErodeOpenCv(int iteration = 20) {
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

        public static void ErodeUnsafe(int iteration, ParallelMode parallelMode, MorphologyLogic morphologyLogic) {
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
                IpUnsafe.Erode(srcBuf, dstBuf, matGray.Width, matGray.Height, (int)matGray.Step(), parallelMode, morphologyLogic);
            }
            if (iteration % 2 == 0)
                matTemp.CopyTo(matDst);

            Console.WriteLine("=> Method Time: {0}ms", Glb.TimerStop());
            Glb.DrawMatAndHist2(matDst);

            matGray.Dispose();
            matDst.Dispose();
            matDst.Dispose();
        }

        public static void ErodeC(int iteration = 20) {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matGray = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matGray);

            var matTemp = new Mat(matGray.Size(), matGray.Type());
            Glb.TimerStart();
            for (int i = 0; i < iteration; i++) {
                IpDll.ErodeC(matGray.Data, matTemp.Data, matGray.Width, matGray.Height, (int)matGray.Step());
                matTemp.CopyTo(matGray);
            }
            Console.WriteLine("=> Method Time: {0}ms", Glb.TimerStop());
            Glb.DrawMatAndHist2(matGray);

            matGray.Dispose();
            matTemp.Dispose();
        }

        public static void ErodeCNoCopy(int iteration = 20) {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matGray = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matGray);

            var matTemp = new Mat(matGray.Size(), matGray.Type());
            Glb.TimerStart();
            for (int i = 0; i < iteration; i++) {
                if (i % 2 == 0)
                    IpDll.ErodeC(matGray.Data, matTemp.Data, matGray.Width, matGray.Height, (int)matGray.Step());
                else
                    IpDll.ErodeC(matTemp.Data, matGray.Data, matGray.Width, matGray.Height, (int)matGray.Step());
            }
            if (iteration > 0 && iteration % 2 == 1)
                IpUnsafe.MemcpyCrt(matTemp.Data, matGray.Data, (int)matGray.Step() * matGray.Height);
            Console.WriteLine("=> Method Time: {0}ms", Glb.TimerStop());
            Glb.DrawMatAndHist2(matGray);

            matGray.Dispose();
            matTemp.Dispose();
        }

        public static void ErodeCStl(int iteration = 20) {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matGray = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matGray);

            var matTemp = new Mat(matGray.Size(), matGray.Type());
            Glb.TimerStart();
            for (int i = 0; i < iteration; i++) {
                IpDll.ErodeCStl(matGray.Data, matTemp.Data, matGray.Width, matGray.Height, (int)matGray.Step());
                matTemp.CopyTo(matGray);
            }
            Console.WriteLine("=> Method Time: {0}ms", Glb.TimerStop());
            Glb.DrawMatAndHist2(matGray);

            matGray.Dispose();
            matTemp.Dispose();
        }

        public static void ErodeCParallel(int iteration = 20) {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matGray = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matGray);

            var matTemp = new Mat(matGray.Size(), matGray.Type());
            Glb.TimerStart();
            for (int i = 0; i < iteration; i++) {
                IpDll.ErodeCParallel(matGray.Data, matTemp.Data, matGray.Width, matGray.Height, (int)matGray.Step());
                matTemp.CopyTo(matGray);
            }
            Console.WriteLine("=> Method Time: {0}ms", Glb.TimerStop());
            Glb.DrawMatAndHist2(matGray);

            matGray.Dispose();
            matTemp.Dispose();
        }

        public static void ErodeC2(int iteration = 20) {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matGray = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matGray);

            var matTemp = new Mat(matGray.Size(), matGray.Type());
            Glb.TimerStart();
            for (int i = 0; i < iteration; i++) {
                IpDll.ErodeC2(matGray.Data, matTemp.Data, matGray.Width, matGray.Height, (int)matGray.Step());
                matTemp.CopyTo(matGray);
            }
            Console.WriteLine("=> Method Time: {0}ms", Glb.TimerStop());
            Glb.DrawMatAndHist2(matGray);

            matGray.Dispose();
            matTemp.Dispose();
        }

        public static void ErodeC2Parallel(int iteration = 20) {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matGray = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matGray);

            var matTemp = new Mat(matGray.Size(), matGray.Type());
            Glb.TimerStart();
            for (int i = 0; i < iteration; i++) {
                IpDll.ErodeC2Parallel(matGray.Data, matTemp.Data, matGray.Width, matGray.Height, (int)matGray.Step());
                matTemp.CopyTo(matGray);
            }
            Console.WriteLine("=> Method Time: {0}ms", Glb.TimerStop());
            Glb.DrawMatAndHist2(matGray);

            matGray.Dispose();
            matTemp.Dispose();
        }

        public static void ErodeSse(int iteration = 20) {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matGray = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matGray);

            var matTemp = new Mat(matGray.Size(), matGray.Type());
            Glb.TimerStart();
            for (int i = 0; i < iteration; i++) {
                IpDll.ErodeSse(matGray.Data, matTemp.Data, matGray.Width, matGray.Height, (int)matGray.Step());
                matTemp.CopyTo(matGray);
            }
            Console.WriteLine("=> Method Time: {0}ms", Glb.TimerStop());
            Glb.DrawMatAndHist2(matGray);

            matGray.Dispose();
            matTemp.Dispose();
        }

        public static void ErodeSseParallel(int iteration = 20) {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matGray = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matGray);

            var matTemp = new Mat(matGray.Size(), matGray.Type());
            Glb.TimerStart();
            for (int i = 0; i < iteration; i++) {
                IpDll.ErodeSseParallel(matGray.Data, matTemp.Data, matGray.Width, matGray.Height, (int)matGray.Step());
                matTemp.CopyTo(matGray);
            }
            Console.WriteLine("=> Method Time: {0}ms", Glb.TimerStop());
            Glb.DrawMatAndHist2(matGray);

            matGray.Dispose();
            matTemp.Dispose();
        }

        public static void ErodeSseParallelNoCopy(int iteration = 20) {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matGray = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matGray);

            var matTemp = new Mat(matGray.Size(), matGray.Type());
            Glb.TimerStart();
            for (int i = 0; i < iteration; i++) {
                if (i % 2 == 0)
                    IpDll.ErodeSseParallel(matGray.Data, matTemp.Data, matGray.Width, matGray.Height, (int)matGray.Step());
                else
                    IpDll.ErodeSseParallel(matTemp.Data, matGray.Data, matGray.Width, matGray.Height, (int)matGray.Step());
            }
            if (iteration > 0 && iteration % 2 == 1)
                IpUnsafe.MemcpyCrt(matTemp.Data, matGray.Data, (int)matGray.Step() * matGray.Height);
            Console.WriteLine("=> Method Time: {0}ms", Glb.TimerStop());
            Glb.DrawMatAndHist2(matGray);

            matGray.Dispose();
            matTemp.Dispose();
        }

        public static void ErodeIpp(int iteration = 20) {
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
