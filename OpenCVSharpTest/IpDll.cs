using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace OpenCVSharpTest {
    class IpDll {
        [DllImport("IP.dll")] extern public static void InverseC(IntPtr buf, int bw, int bh, int stride);
        [DllImport("IP.dll")] extern public static void InverseSse(IntPtr buf, int bw, int bh, int stride);
        [DllImport("IP.dll")] extern public static void InverseVec(IntPtr buf, int bw, int bh, int stride);
        [DllImport("IP.dll")] extern public static void InverseAvx(IntPtr buf, int bw, int bh, int stride);
        [DllImport("IP.dll")] extern public static void ErodeC(IntPtr srcBuf, IntPtr dstBuf, int bw, int bh, int step, ParallelMode parallelMode);
        [DllImport("IP.dll")] extern public static void ErodeSse(IntPtr srcBuf, IntPtr dstBuf, int bw, int bh, int step, ParallelMode parallelMode);
        [DllImport("IP.dll")] extern public static void ErodeIpp(IntPtr srcPtr, IntPtr dstPtr, int bw, int bh, int step);
    }
}
