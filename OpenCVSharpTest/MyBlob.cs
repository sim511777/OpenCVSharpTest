using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace OpenCVSharpTest {
    unsafe class MyBlobs {
        public void Label(IntPtr src, int bw, int bh, int stride) {
        }
        public MyBlobs[] blobs;
    }

    class MyBlob {
        public int area;
        public Point[] pixels;
        public Point centroid;
        public int minX;
        public int minY;
        public int maxX;
        public int maxY;
    }
}