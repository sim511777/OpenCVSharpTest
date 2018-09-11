using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace OpenCVSharpTest {
    class IpDll {
        [DllImport("IP.dll")] extern public static void InverseImage(IntPtr buf, int bw, int bh, int stride);
        [DllImport("IP.dll")] extern public static void SseInverseImage(IntPtr buf, int bw, int bh, int stride);
        [DllImport("IP.dll")] extern public static void VecInverseImage(IntPtr buf, int bw, int bh, int stride);
        [DllImport("IP.dll")] extern public static void AvxInverseImage(IntPtr buf, int bw, int bh, int stride);
    }
}
