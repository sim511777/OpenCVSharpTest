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

        public static void Erode(IntPtr srcBuf, IntPtr dstBuf, int bw, int bh, int step) {
            byte* srcPtr = (byte*)srcBuf.ToPointer();
            byte* dstPtr = (byte*)dstBuf.ToPointer();
            for (int y=1; y<bh-1; y++) {
                for (int x=1; x<bw-1; x++) {
                    byte* sp = srcPtr + y*step+x;
                    byte* dp = dstPtr + y*step+x;
                    byte s0 = *(sp - step - 1);
                    byte s1 = *(sp - step);
                    byte s2 = *(sp - step + 1);
                    byte s3 = *(sp - 1);
                    byte s4 = *(sp);
                    byte s5 = *(sp + 1);
                    byte s6 = *(sp + step - 1);
                    byte s7 = *(sp + step);
                    byte s8 = *(sp + step + 1);
                    byte min = s0;
                    if (s1 < min) min = s1;
                    if (s2 < min) min = s2;
                    if (s3 < min) min = s3;
                    if (s4 < min) min = s4;
                    if (s5 < min) min = s5;
                    if (s6 < min) min = s6;
                    if (s7 < min) min = s7;
                    if (s8 < min) min = s8;
                    *dp = min;
                }
            }

            // edge pixel process
            for (int x = 0; x < bw; x++) {
                ErodeEdge(srcPtr, dstPtr, bw, bh, step, x, 0);
                ErodeEdge(srcPtr, dstPtr, bw, bh, step, x, bh - 1);
            }
            for (int y = 1; y < bh - 1; y++) {
                ErodeEdge(srcPtr, dstPtr, bw, bh, step, 0, y);
                ErodeEdge(srcPtr, dstPtr, bw, bh, step, bw - 1, y);
            }
        }

        public static void ErodeEdge(byte* srcPtr, byte* dstPtr, int bw, int bh, int step, int x, int y) {
            byte s0 = *(srcPtr + step * IntRange(y - 1, 0, bh-1) + IntRange(x - 1, 0, bw-1));
            byte s1 = *(srcPtr + step * IntRange(y - 1, 0, bh-1) + IntRange(x    , 0, bw-1));
            byte s2 = *(srcPtr + step * IntRange(y - 1, 0, bh-1) + IntRange(x + 1, 0, bw-1));
            byte s3 = *(srcPtr + step * IntRange(y    , 0, bh-1) + IntRange(x - 1, 0, bw-1));
            byte s4 = *(srcPtr + step * IntRange(y    , 0, bh-1) + IntRange(x    , 0, bw-1));
            byte s5 = *(srcPtr + step * IntRange(y    , 0, bh-1) + IntRange(x + 1, 0, bw-1));
            byte s6 = *(srcPtr + step * IntRange(y + 1, 0, bh-1) + IntRange(x - 1, 0, bw-1));
            byte s7 = *(srcPtr + step * IntRange(y + 1, 0, bh-1) + IntRange(x    , 0, bw-1));
            byte s8 = *(srcPtr + step * IntRange(y + 1, 0, bh-1) + IntRange(x + 1, 0, bw-1));
            byte min = s0;
            if (s1 < min) min = s1;
            if (s2 < min) min = s2;
            if (s3 < min) min = s3;
            if (s4 < min) min = s4;
            if (s5 < min) min = s5;
            if (s6 < min) min = s6;
            if (s7 < min) min = s7;
            if (s8 < min) min = s8;
            *(dstPtr + step * y + x) = min;
        }

        public static int IntRange(int val, int min, int max) {
            if (val < min)
                return min;
            if (val > max)
                return max;
            return val;
        }
    }
}
