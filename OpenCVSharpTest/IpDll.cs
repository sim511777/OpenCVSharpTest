using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace OpenCVSharpTest {
    class IpDll {
        [DllImport("IP.dll")] public static extern void InverseC(IntPtr buf, int bw, int bh, int stride);
        [DllImport("IP.dll")] public static extern void InverseSse(IntPtr buf, int bw, int bh, int stride, bool useParallel);
        [DllImport("IP.dll")] public static extern void InverseVec(IntPtr buf, int bw, int bh, int stride);
        [DllImport("IP.dll")] public static extern void InverseAvx(IntPtr buf, int bw, int bh, int stride);
        [DllImport("IP.dll")] public static extern void ErodeC(IntPtr srcBuf, IntPtr dstBuf, int bw, int bh, int step, bool useSse, bool useParallel);
        [DllImport("IP.dll")] public static extern void ErodeIpp(IntPtr srcPtr, IntPtr dstPtr, int bw, int bh, int step);
        [DllImport("IP.dll")] public static extern void DummyFunction(IntPtr srcPtr, IntPtr dstPtr, int bw, int bh, int step, int sleepMs);
        [DllImport("IP.dll")] public static extern void ErodeIppRoi(IntPtr srcPtr, IntPtr dstPtr, int bw, int bh, int step, int roiX, int roiY, int roiW, int roiH);
        [DllImport("IP.dll")] public static extern void GetString([MarshalAs(UnmanagedType.LPWStr)] StringBuilder sb);
        [DllImport("IP.dll")] public static extern void SetString([MarshalAs(UnmanagedType.LPWStr)] string str);
        [DllImport("IP.dll")] public static extern unsafe void Devernay(double** x, double** y, int* N, int** curve_limits, int* M, double* image, int X, int Y, double sigma, double th_h, double th_l);
        [DllImport("IP.dll")] public static extern unsafe void FreeBuffer(void* buffer);
    }
}
