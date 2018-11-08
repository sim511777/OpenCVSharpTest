using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;
using OpenCvSharp;
using OpenCvSharp.Blob;

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

        public static void RenderBlobs(CvBlobs blobs, Mat matDst) {
            byte *pdst = matDst.DataPointer;
            int bw = matDst.Width;
            int bh = matDst.Height;
            int stride = (int)matDst.Step();
            int colorCount = 0;
            foreach (var blob in blobs.Values) {
                double r, g, b;
                Glb.Hsv2Rgb((colorCount*77) % 360, 0.5, 1.0, out r, out g, out b);
                colorCount++;
                byte bb = (byte)b;
                byte bg = (byte)g;
                byte br = (byte)r;
                int label = blob.Label;
                for (int y=blob.MinY; y<=blob.MaxY; y++) {
                    for (int x=blob.MinX; x<=blob.MaxX; x++) {
                        if (blobs.Labels[y, x] == label) {
                            byte *ppdst = pdst + stride*y + x*3;
                            ppdst[0] = bb;
                            ppdst[1] = bg;
                            ppdst[2] = br;
                        }
                    }
                }
            }
        }

        public static void RenderBlobs(MyBlobs blobs, Mat matDst) {
            byte *pdst = matDst.DataPointer;
            int bw = matDst.Width;
            int bh = matDst.Height;
            int stride = (int)matDst.Step();
            int colorCount = 0;
            foreach (var blob in blobs.Blobs.Values) {
                double r, g, b;
                Glb.Hsv2Rgb((colorCount*77) % 360, 0.5, 1.0, out r, out g, out b);
                colorCount++;
                byte bb = (byte)b;
                byte bg = (byte)g;
                byte br = (byte)r;
                int label = blob.label;
                for (int y=blob.MinY; y<=blob.MaxY; y++) {
                    for (int x=blob.MinX; x<=blob.MaxX; x++) {
                        if (blobs.Labels[y*bw+x] == label) {
                            byte *ppdst = pdst + stride*y + x*3;
                            ppdst[0] = bb;
                            ppdst[1] = bg;
                            ppdst[2] = br;
                        }
                    }
                }
            }
        }
    }
}
