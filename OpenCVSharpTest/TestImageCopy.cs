using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace OpenCVSharpTest {
    class TestImageCopy {
        public static void ImageCopyMarshal1() {
            Mat matDst = new Mat(Glb.matSrc.Size(), Glb.matSrc.Type());
            int nbytes = (int)Glb.matSrc.Step() * Glb.matSrc.Height;

            Glb.TimerStart();
            IpUnsafe.MemcpyMarshal1(matDst.Data, Glb.matSrc.Data, nbytes);
            Console.WriteLine("=> Method Time: {0}ms", Glb.TimerStop());

            Glb.DrawMatAndHist0(Glb.matSrc);
            Glb.DrawMatAndHist1(matDst);
            Glb.DrawMatAndHist2(null);
            matDst.Dispose();
        }

        public static void ImageCopyMarshal2() {
            Mat matDst = new Mat(Glb.matSrc.Size(), Glb.matSrc.Type());
            int nbytes = (int)Glb.matSrc.Step() * Glb.matSrc.Height;

            Glb.TimerStart();
            IpUnsafe.MemcpyMarshal2(matDst.Data, Glb.matSrc.Data, nbytes);
            Console.WriteLine("=> Method Time: {0}ms", Glb.TimerStop());

            Glb.DrawMatAndHist0(Glb.matSrc);
            Glb.DrawMatAndHist1(matDst);
            Glb.DrawMatAndHist2(null);
            matDst.Dispose();
        }

        public static void ImageCopyUnsafe() {
            Mat matDst = new Mat(Glb.matSrc.Size(), Glb.matSrc.Type());
            int nbytes = (int)Glb.matSrc.Step() * Glb.matSrc.Height;

            Glb.TimerStart();
            IpUnsafe.MemcpyUnsafe(matDst.Data, Glb.matSrc.Data, nbytes);
            Console.WriteLine("=> Method Time: {0}ms", Glb.TimerStop());

            Glb.DrawMatAndHist0(Glb.matSrc);
            Glb.DrawMatAndHist1(matDst);
            Glb.DrawMatAndHist2(null);
            matDst.Dispose();
        }

        public static void ImageCopyCrt() {
            Mat matDst = new Mat(Glb.matSrc.Size(), Glb.matSrc.Type());
            int nbytes = (int)Glb.matSrc.Step() * Glb.matSrc.Height;

            Glb.TimerStart();
            IpUnsafe.MemcpyCrt(matDst.Data, Glb.matSrc.Data, nbytes);
            Console.WriteLine("=> Method Time: {0}ms", Glb.TimerStop());

            Glb.DrawMatAndHist0(Glb.matSrc);
            Glb.DrawMatAndHist1(matDst);
            Glb.DrawMatAndHist2(null);
            matDst.Dispose();
        }

        public static void ImageCopyBufferClass() {
            Mat matDst = new Mat(Glb.matSrc.Size(), Glb.matSrc.Type());
            int nbytes = (int)Glb.matSrc.Step() * Glb.matSrc.Height;

            Glb.TimerStart();
            IpUnsafe.MemcpyBufferClass(matDst.Data, Glb.matSrc.Data, nbytes);
            Console.WriteLine("=> Method Time: {0}ms", Glb.TimerStop());

            Glb.DrawMatAndHist0(Glb.matSrc);
            Glb.DrawMatAndHist1(matDst);
            Glb.DrawMatAndHist2(null);
            matDst.Dispose();
        }

        public static void ImageCopyOpenCV() {
            Mat matDst = new Mat(Glb.matSrc.Size(), Glb.matSrc.Type());

            Glb.TimerStart();
            Glb.matSrc.CopyTo(matDst);
            Console.WriteLine("=> Method Time: {0}ms", Glb.TimerStop());

            Glb.DrawMatAndHist0(Glb.matSrc);
            Glb.DrawMatAndHist1(matDst);
            Glb.DrawMatAndHist2(null);
            matDst.Dispose();
        }
    }
}
