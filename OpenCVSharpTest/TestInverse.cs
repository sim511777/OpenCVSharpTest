using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using OpenCvSharp;

namespace OpenCVSharpTest {
    class TestInverse {
        public static void InverseOpenCv() {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matGray = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matGray);

            var matDst = new Mat();
            Cv2.BitwiseNot(matGray, matDst);
            Glb.DrawMatAndHist2(matDst);

            matGray.Dispose();
            matDst.Dispose();
        }

        public static void InverseApi() {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matDst = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matDst);

            int bw = matDst.Width;
            int bh = matDst.Height;
            for (int y = 0; y < bh; y++) {
                for (int x = 0; x < bw; x++) {
                    matDst.Set(y, x, (byte)~matDst.Get<byte>(y, x));
                }
            }
            Glb.DrawMatAndHist2(matDst);

            matDst.Dispose();
        }

        public static void InverseMarshal() {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matDst = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matDst);

            IntPtr buf = matDst.Data;
            int bw = matDst.Width;
            int bh = matDst.Height;
            int stride = (int)matDst.Step();
            for (int y = 0; y < bh; y++) {
                IntPtr pp = buf + stride * y;
                for (int x = 0; x < bw; x++, pp = pp + 1) {
                    Marshal.WriteByte(pp, (byte)~Marshal.ReadByte(pp));
                }
            }
            Glb.DrawMatAndHist2(matDst);

            matDst.Dispose();
        }

        public static void InverseUnsafe() {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matDst = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matDst);

            IpUnsafe.Inverse(matDst.Data, matDst.Width, matDst.Height, (int)matDst.Step());
            Glb.DrawMatAndHist2(matDst);

            matDst.Dispose();
        }

        public static void InverseC() {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matDst = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matDst);

            IpDll.InverseC(matDst.Data, matDst.Width, matDst.Height, (int)matDst.Step());
            Glb.DrawMatAndHist2(matDst);

            matDst.Dispose();
        }

        public static void InverseSee() {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matDst = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matDst);

            IpDll.InverseSse(matDst.Data, matDst.Width, matDst.Height, (int)matDst.Step());
            Glb.DrawMatAndHist2(matDst);

            matDst.Dispose();
        }

        public static void InverseVectorClass() {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matDst = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matDst);

            IpDll.InverseVec(matDst.Data, matDst.Width, matDst.Height, (int)matDst.Step());
            Glb.DrawMatAndHist2(matDst);

            matDst.Dispose();
        }

        public static void InverseAvx() {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matDst = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matDst);

            IpDll.InverseAvx(matDst.Data, matDst.Width, matDst.Height, (int)matDst.Step());
            Glb.DrawMatAndHist2(matDst);

            matDst.Dispose();
        }
    }
}
