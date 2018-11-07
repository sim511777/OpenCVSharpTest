using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace OpenCVSharpTest {
    unsafe class IpUnsafe {
        public static void Inverse(IntPtr buf, int bw, int bh, int stride) {
            byte *pbuf = (byte *)buf.ToPointer();
            for (int y = 0; y < bh; y++) {
                byte *ppbuf = pbuf + stride * y;
                for (int x = 0; x < bw; x++, ppbuf = ppbuf + 1) {
                   *ppbuf = (byte)~*ppbuf;
                }
            }
        }
    }
}
