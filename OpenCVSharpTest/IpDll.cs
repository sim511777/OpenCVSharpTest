using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace OpenCVSharpTest {
    class IpDll {
        const string dll = "IP.dll";
        [DllImport(dll)] public static extern void InverseC(IntPtr buf, int bw, int bh, int stride);
        [DllImport(dll)] public static extern void InverseSse(IntPtr buf, int bw, int bh, int stride, bool useParallel);
        [DllImport(dll)] public static extern void InverseVec(IntPtr buf, int bw, int bh, int stride);
        [DllImport(dll)] public static extern void InverseAvx(IntPtr buf, int bw, int bh, int stride);
        [DllImport(dll)] public static extern void ErodeC(IntPtr srcBuf, IntPtr dstBuf, int bw, int bh, int step, bool useSse, bool useParallel);
        [DllImport(dll)] public static extern void ErodeIpp(IntPtr srcPtr, IntPtr dstPtr, int bw, int bh, int step);
        [DllImport(dll)] public static extern void DummyFunction(IntPtr srcPtr, IntPtr dstPtr, int bw, int bh, int step, int sleepMs);
        [DllImport(dll)] public static extern void ErodeIppRoi(IntPtr srcPtr, IntPtr dstPtr, int bw, int bh, int step, int roiX, int roiY, int roiW, int roiH);
        [DllImport(dll)] public static extern void GetString([MarshalAs(UnmanagedType.LPWStr)] StringBuilder sb);
        [DllImport(dll)] public static extern void SetString([MarshalAs(UnmanagedType.LPWStr)] string str);
        [DllImport(dll)] public static extern unsafe void Devernay(ref IntPtr x, ref IntPtr y, ref int N, ref IntPtr curve_limits, ref int M, 
            IntPtr image, int X, int Y, 
            double sigma, double th_h, double th_l);
        [DllImport(dll)] public static extern unsafe void FreeBuffer(IntPtr buffer);
    }

    class Crt {
        const string dll = "msvcrt.dll";
        [DllImport(dll)] public static extern IntPtr memcpy(IntPtr dest, IntPtr src, long count);
    }
}
