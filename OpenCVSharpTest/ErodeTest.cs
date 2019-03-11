using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace OpenCVSharpTest {
    class ErodeTest {
        public static void ErodeOpenCv(int iteration = 20) {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matThr = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matThr);

            Glb.TimerStart();
            var matDst = matThr.Erode(new Mat(), iterations: iteration, borderType: BorderTypes.Replicate);
            Console.WriteLine("=> Method Time: {0}ms", Glb.TimerStop());

            Glb.DrawMatAndHist2(matDst);

            matThr.Dispose();
            matDst.Dispose();
        }

        public static void ErodeUnsafe(int iteration = 20) {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matGray = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matGray);

            var matTemp = new Mat(matGray.Size(), matGray.Type());
            Glb.TimerStart();
            for (int i = 0; i < iteration; i++) {
                IpUnsafe.Erode(matGray.Data, matTemp.Data, matGray.Width, matGray.Height, (int)matGray.Step());
                matTemp.CopyTo(matGray);
            }
            Console.WriteLine("=> Method Time: {0}ms", Glb.TimerStop());
            Glb.DrawMatAndHist2(matGray);

            matGray.Dispose();
            matTemp.Dispose();
        }

        public static void ErodeUnsafeParallel(int iteration = 20) {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matGray = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matGray);

            var matTemp = new Mat(matGray.Size(), matGray.Type());
            Glb.TimerStart();
            for (int i = 0; i < iteration; i++) {
                IpUnsafe.ErodeParallel(matGray.Data, matTemp.Data, matGray.Width, matGray.Height, (int)matGray.Step());
                matTemp.CopyTo(matGray);
            }
            Console.WriteLine("=> Method Time: {0}ms", Glb.TimerStop());
            Glb.DrawMatAndHist2(matGray);

            matGray.Dispose();
            matTemp.Dispose();
        }

        public static void ErodeUnsafe2(int iteration = 20) {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matGray = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matGray);

            var matTemp = new Mat(matGray.Size(), matGray.Type());
            Glb.TimerStart();
            for (int i = 0; i < iteration; i++) {
                IpUnsafe.Erode2(matGray.Data, matTemp.Data, matGray.Width, matGray.Height, (int)matGray.Step());
                matTemp.CopyTo(matGray);
            }
            Console.WriteLine("=> Method Time: {0}ms", Glb.TimerStop());
            Glb.DrawMatAndHist2(matGray);

            matGray.Dispose();
            matTemp.Dispose();
        }

        public static void ErodeUnsafe3(int iteration = 20) {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matGray = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matGray);

            var matTemp = new Mat(matGray.Size(), matGray.Type());
            Glb.TimerStart();
            for (int i = 0; i < iteration; i++) {
                IpUnsafe.Erode3(matGray.Data, matTemp.Data, matGray.Width, matGray.Height, (int)matGray.Step());
                matTemp.CopyTo(matGray);
            }
            Console.WriteLine("=> Method Time: {0}ms", Glb.TimerStop());
            Glb.DrawMatAndHist2(matGray);

            matGray.Dispose();
            matTemp.Dispose();
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

        public static void ErodeSse2D(int iteration = 20) {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matGray = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matGray);

            var matTemp = new Mat(matGray.Size(), matGray.Type());
            Glb.TimerStart();
            for (int i = 0; i < iteration; i++) {
                IpDll.ErodeSse2D(matGray.Data, matTemp.Data, matGray.Width, matGray.Height, (int)matGray.Step());
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

        public static void ErodeSseOpenMP(int iteration = 20) {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matGray = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matGray);

            var matTemp = new Mat(matGray.Size(), matGray.Type());
            Glb.TimerStart();
            for (int i = 0; i < iteration; i++) {
                IpDll.ErodeSseOpenMP(matGray.Data, matTemp.Data, matGray.Width, matGray.Height, (int)matGray.Step());
                matTemp.CopyTo(matGray);
            }
            Console.WriteLine("=> Method Time: {0}ms", Glb.TimerStop());
            Glb.DrawMatAndHist2(matGray);

            matGray.Dispose();
            matTemp.Dispose();
        }

        public static void ErodeSseOpenMPNoCopy(int iteration = 20) {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matGray = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matGray);

            var matTemp = new Mat(matGray.Size(), matGray.Type());
            Glb.TimerStart();
            for (int i = 0; i < iteration; i++) {
                if (i % 2 == 0)
                    IpDll.ErodeSseOpenMP(matGray.Data, matTemp.Data, matGray.Width, matGray.Height, (int)matGray.Step());
                else
                    IpDll.ErodeSseOpenMP(matTemp.Data, matGray.Data, matGray.Width, matGray.Height, (int)matGray.Step());
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
            var matWork = new Mat(matGray.Size(), matGray.Type());
            Glb.TimerStart();
            for (int i = 0; i < iteration; i++) {
                IpDll.ErodeIpp(matGray.Data, matTemp.Data, matWork.Data, matGray.Width, matGray.Height, (int)matGray.Step());
                matTemp.CopyTo(matGray);
            }
            Console.WriteLine("=> Method Time: {0}ms", Glb.TimerStop());
            Glb.DrawMatAndHist2(matGray);

            matGray.Dispose();
            matTemp.Dispose();
            matWork.Dispose();
        }
    }
}
