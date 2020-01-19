using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using OpenCvSharp;
using System.Diagnostics;

namespace OpenCVSharpTest {
    class TestInverse {
        public static double GetTimeMs() {
            return Stopwatch.GetTimestamp() * 1000.0 / Stopwatch.Frequency;
        }
        public static double InverseOpenCv() {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matGray = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matGray);

            var matDst = new Mat();
            
            var st = GetTimeMs();
            Cv2.BitwiseNot(matGray, matDst);
            var dt = GetTimeMs() - st;
            
            Glb.DrawMatAndHist2(matDst);

            matGray.Dispose();
            matDst.Dispose();
            return dt;
        }

        public static double InverseApi() {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matDst = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matDst);

            int bw = matDst.Width;
            int bh = matDst.Height;
            
            var st = GetTimeMs();
            for (int y = 0; y < bh; y++) {
                for (int x = 0; x < bw; x++) {
                    matDst.Set(y, x, (byte)~matDst.Get<byte>(y, x));
                }
            }
            var dt = GetTimeMs() - st;

            Glb.DrawMatAndHist2(matDst);

            matDst.Dispose();
            return dt;
        }

        public static double InverseMarshal() {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matDst = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matDst);

            IntPtr buf = matDst.Data;
            int bw = matDst.Width;
            int bh = matDst.Height;
            int stride = (int)matDst.Step();
            
            var st = GetTimeMs();
            for (int y = 0; y < bh; y++) {
                IntPtr pp = buf + stride * y;
                for (int x = 0; x < bw; x++, pp = pp + 1) {
                    Marshal.WriteByte(pp, (byte)~Marshal.ReadByte(pp));
                }
            }
            var dt = GetTimeMs() - st;

            Glb.DrawMatAndHist2(matDst);

            matDst.Dispose();
            return dt;
        }

        public static double InverseUnsafe() {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matDst = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matDst);

            var st = GetTimeMs();
            IpUnsafe.Inverse(matDst.Data, matDst.Width, matDst.Height, (int)matDst.Step());
            var dt = GetTimeMs() - st;

            Glb.DrawMatAndHist2(matDst);

            matDst.Dispose();
            return dt;
        }

        public static double InverseParallelFor() {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matDst = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matDst);

            var st = GetTimeMs();
            IpUnsafe.InverseParallelFor(matDst.Data, matDst.Width, matDst.Height, (int)matDst.Step());
            var dt = GetTimeMs() - st;

            Glb.DrawMatAndHist2(matDst);

            matDst.Dispose();
            return dt;
        }

        public static double InverseC() {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matDst = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matDst);

            var st = GetTimeMs();
            IpDll.InverseC(matDst.Data, matDst.Width, matDst.Height, (int)matDst.Step());
            var dt = GetTimeMs() - st;

            Glb.DrawMatAndHist2(matDst);

            matDst.Dispose();
            return dt;
        }

        public static double Sse() {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matDst = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matDst);

            var st = GetTimeMs();
            IpDll.InverseSse(matDst.Data, matDst.Width, matDst.Height, (int)matDst.Step());
            var dt = GetTimeMs() - st;

            Glb.DrawMatAndHist2(matDst);

            matDst.Dispose();
            return dt;
        }

        public static double InverseVectorClass() {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matDst = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matDst);

            var st = GetTimeMs();
            IpDll.InverseVec(matDst.Data, matDst.Width, matDst.Height, (int)matDst.Step());
            var dt = GetTimeMs() - st;

            Glb.DrawMatAndHist2(matDst);

            matDst.Dispose();
            return dt;
        }

        public static double InverseAvx() {
            Glb.DrawMatAndHist0(Glb.matSrc);

            var matDst = Glb.matSrc.CvtColor(ColorConversionCodes.BGR2GRAY);
            Glb.DrawMatAndHist1(matDst);

            var st = GetTimeMs();
            IpDll.InverseAvx(matDst.Data, matDst.Width, matDst.Height, (int)matDst.Step());
            var dt = GetTimeMs() - st;

            Glb.DrawMatAndHist2(matDst);

            matDst.Dispose();
            return dt;
        }
    }
}
