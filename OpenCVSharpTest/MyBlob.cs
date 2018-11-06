using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace OpenCVSharpTest {
    class MyBlobs {
        private int[] labels;
        
        public void Label(IntPtr src, int bw, int bh, int stride) {
        }
    }

    class MyBlob {
        public int area;
        public Point[] GetPixels() {
            return null;
        }

        public Point centroid;
        public double cricularity;
        public bool converxity;
        public double inertiaRatio;

        public MyContour GetContour() {
            return null;
        }
    }

    enum ContourDir {
        Rightl, RightDown, Down, LeftDown, Left, LeftUp, Up, RightUp
    }

    class MyContour {
        public Point startPoint;
        public int count;
        public ContourDir[] dirs;

    }
}
