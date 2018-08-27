using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace OpenCVTestLoadImage {
   class IpDll {
      [DllImport("IP.dll")] extern public static void InverseImage(IntPtr buf, int bw, int bh, int stride);
   }
}
