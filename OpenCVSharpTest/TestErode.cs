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
            var matDst = new Mat(matGray.Size(), matGray.Type());
            for (int i = 0; i < iteration; i++) {
                if (i % 2 == 0)
                    IpUnsafe.Erode(matGray.Data, matDst.Data, matGray.Width, matGray.Height, (int)matGray.Step(), parallelMode);
                else
                    IpUnsafe.Erode(matDst.Data, matGray.Data, matGray.Width, matGray.Height, (int)matGray.Step(), parallelMode);
            }
            if (iteration != 0 && iteration % 2 == 0)
                matGray.CopyTo(matDst);

            Console.WriteLine("=> Method Time: {0}ms", Glb.TimerStop());
            Glb.DrawMatAndHist2(matDst);

            matGray.Dispose();
            matDst.Dispose();
        }

        public static void ErodeC(int iteration, ParallelMode parallelMode) {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matGray = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matGray);

            Glb.TimerStart();
            var matDst = new Mat(matGray.Size(), matGray.Type());
            for (int i = 0; i < iteration; i++) {
                if (i % 2 == 0)
                    IpDll.ErodeC(matGray.Data, matDst.Data, matGray.Width, matGray.Height, (int)matGray.Step(), parallelMode);
                else
                    IpDll.ErodeC(matDst.Data, matGray.Data, matGray.Width, matGray.Height, (int)matGray.Step(), parallelMode);
            }
            if (iteration != 0 && iteration % 2 == 0)
                matGray.CopyTo(matDst);

            Console.WriteLine("=> Method Time: {0}ms", Glb.TimerStop());
            Glb.DrawMatAndHist2(matDst);

            matGray.Dispose();
            matDst.Dispose();
        }

        public static void ErodeSse(int iteration, ParallelMode parallelMode) {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matGray = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matGray);

            Glb.TimerStart();
            var matDst = new Mat(matGray.Size(), matGray.Type());
            for (int i = 0; i < iteration; i++) {
                if (i % 2 == 0)
                    IpDll.ErodeSse(matGray.Data, matDst.Data, matGray.Width, matGray.Height, (int)matGray.Step(), parallelMode);
                else
                    IpDll.ErodeSse(matDst.Data, matGray.Data, matGray.Width, matGray.Height, (int)matGray.Step(), parallelMode);
            }
            if (iteration != 0 && iteration % 2 == 0)
                matGray.CopyTo(matDst);

            Console.WriteLine("=> Method Time: {0}ms", Glb.TimerStop());
            Glb.DrawMatAndHist2(matDst);

            matGray.Dispose();
            matDst.Dispose();
        }

        public static void ErodeIpp(int iteration) {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matGray = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matGray);

            Glb.TimerStart();
            var matDst = new Mat(matGray.Size(), matGray.Type());
            for (int i = 0; i < iteration; i++) {
                if (i % 2 == 0)
                    IpDll.ErodeIpp(matGray.Data, matDst.Data, matGray.Width, matGray.Height, (int)matGray.Step());
                else
                    IpDll.ErodeIpp(matDst.Data, matGray.Data, matGray.Width, matGray.Height, (int)matGray.Step());
            }
            if (iteration != 0 && iteration % 2 == 0)
                matGray.CopyTo(matDst);

            Console.WriteLine("=> Method Time: {0}ms", Glb.TimerStop());
            Glb.DrawMatAndHist2(matDst);

            matGray.Dispose();
            matDst.Dispose();
        }
    }
}
