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
        [DllImport("IP.dll")] extern public static void ErodeC(IntPtr srcPtr, IntPtr dstPtr, int bw, int bh, int step);
        [DllImport("IP.dll")] extern public static void ErodeCParallel(IntPtr srcPtr, IntPtr dstPtr, int bw, int bh, int step);
        [DllImport("IP.dll")] extern public static void ErodeC2(IntPtr srcPtr, IntPtr dstPtr, int bw, int bh, int step);
        [DllImport("IP.dll")] extern public static void ErodeC2Parallel(IntPtr srcPtr, IntPtr dstPtr, int bw, int bh, int step);
        [DllImport("IP.dll")] extern public static void ErodeSse(IntPtr srcPtr, IntPtr dstPtr, int bw, int bh, int step);
        [DllImport("IP.dll")] extern public static void ErodeSse2D(IntPtr srcPtr, IntPtr dstPtr, int bw, int bh, int step);
        [DllImport("IP.dll")] extern public static void ErodeSseParallel(IntPtr srcPtr, IntPtr dstPtr, int bw, int bh, int step);
    }
}
