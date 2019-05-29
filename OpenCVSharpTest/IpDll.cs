using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace OpenCVSharpTest {
    class IpDll {
        [DllImport("IP.dll")] public static extern void InverseC(IntPtr buf, int bw, int bh, int stride);
        [DllImport("IP.dll")] extern public static void InverseSse(IntPtr buf, int bw, int bh, int stride);
        [DllImport("IP.dll")] extern public static void InverseVec(IntPtr buf, int bw, int bh, int stride);
        [DllImport("IP.dll")] extern public static void InverseAvx(IntPtr buf, int bw, int bh, int stride);
        [DllImport("IP.dll")] extern public static void ErodeC(IntPtr srcBuf, IntPtr dstBuf, int bw, int bh, int step, bool useSse, bool useParallel);
        [DllImport("IP.dll")] extern public static void ErodeIpp(IntPtr srcPtr, IntPtr dstPtr, int bw, int bh, int step);
        [DllImport("IP.dll")] extern public static void DummyFunction(IntPtr srcPtr, IntPtr dstPtr, int bw, int bh, int step, int sleepMs);
        [DllImport("IP.dll")] extern public static void ErodeIppRoi(IntPtr srcPtr, IntPtr dstPtr, int bw, int bh, int step, int roiX, int roiY, int roiW, int roiH);
        [DllImport("IP.dll")] extern public static void GetString([MarshalAs(UnmanagedType.LPWStr)] StringBuilder sb);
        [DllImport("IP.dll")] extern public static void SetString([MarshalAs(UnmanagedType.LPWStr)] string str);
    }
}
