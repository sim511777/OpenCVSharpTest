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

        public static byte GetPixelEdgeReplicate(byte* ptr, int bw, int bh, int step, int x, int y) {
            if (x < 0) x = 0;
            else if (x > bw - 1) x = bw - 1;

            if (y < 0) y = 0;
            else if (y > bh - 1) y = bh - 1;

            return *(ptr + step * y + x);
        }

        public static void ErodeEdge(byte* srcPtr, byte* dstPtr, int bw, int bh, int step, int x, int y) {
            byte s0 = GetPixelEdgeReplicate(srcPtr, bw, bh, step, x - 1, y - 1);
            byte s1 = GetPixelEdgeReplicate(srcPtr, bw, bh, step, x, y - 1);
            byte s2 = GetPixelEdgeReplicate(srcPtr, bw, bh, step, x + 1, y - 1);
            byte s3 = GetPixelEdgeReplicate(srcPtr, bw, bh, step, x - 1, y);
            byte s4 = GetPixelEdgeReplicate(srcPtr, bw, bh, step, x, y);
            byte s5 = GetPixelEdgeReplicate(srcPtr, bw, bh, step, x + 1, y);
            byte s6 = GetPixelEdgeReplicate(srcPtr, bw, bh, step, x - 1, y + 1);
            byte s7 = GetPixelEdgeReplicate(srcPtr, bw, bh, step, x, y + 1);
            byte s8 = GetPixelEdgeReplicate(srcPtr, bw, bh, step, x + 1, y + 1);

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

        public static void Erode(IntPtr srcBuf, IntPtr dstBuf, int bw, int bh, int step) {
            byte* srcPtr = (byte*)srcBuf.ToPointer();
            byte* dstPtr = (byte*)dstBuf.ToPointer();
            int x1 = 1, x2 = bw - 2;
            int y1 = 1, y2 = bh - 2;
            for (int y = y1; y <= y2; y++) {
                byte* sp = &srcPtr[y * step + x1];
                byte* dp = &dstPtr[y * step + x1];
                byte* s0 = (sp - step - 1);
                byte* s1 = (sp - step);
                byte* s2 = (sp - step + 1);
                byte* s3 = (sp - 1);
                byte* s5 = (sp + 1);
                byte* s6 = (sp + step - 1);
                byte* s7 = (sp + step);
                byte* s8 = (sp + step + 1);
                for (int x = x1; x <= x2; x++, sp++, dp++, s0++, s1++, s2++, s3++, s5++, s6++, s7++, s8++) {
                    byte min = *s0;
                    if (*s1 < min) min = *s1;
                    if (*s2 < min) min = *s2;
                    if (*s3 < min) min = *s3;
                    if (*sp < min) min = *sp;
                    if (*s5 < min) min = *s5;
                    if (*s6 < min) min = *s6;
                    if (*s7 < min) min = *s7;
                    if (*s8 < min) min = *s8;

                    *(dp) = min;
                }
            }

            // edge pixel process
            for (int x = 0; x < bw; x++) {
                int yTop = 0;
                int yBottom = bh - 1;
                ErodeEdge(srcPtr, dstPtr, bw, bh, step, x, yTop);
                ErodeEdge(srcPtr, dstPtr, bw, bh, step, x, yBottom);
            }
            for (int y = 1; y < bh - 1; y++) {
                int xLeft = 0;
                int xRight = bw - 1;
                ErodeEdge(srcPtr, dstPtr, bw, bh, step, xLeft, y);
                ErodeEdge(srcPtr, dstPtr, bw, bh, step, xRight, y);
            }
        }

        public static void ErodeParallel(IntPtr srcBuf, IntPtr dstBuf, int bw, int bh, int step) {
            byte* srcPtr = (byte*)srcBuf.ToPointer();
            byte* dstPtr = (byte*)dstBuf.ToPointer();
            int x1 = 1, x2 = bw - 2;
            int y1 = 1, y2 = bh - 2;
            Parallel.For(y1, y2, (y) => {
                byte* sp = &srcPtr[y * step + x1];
                byte* dp = &dstPtr[y * step + x1];
                byte* s0 = (sp - step - 1);
                byte* s1 = (sp - step);
                byte* s2 = (sp - step + 1);
                byte* s3 = (sp - 1);
                byte* s5 = (sp + 1);
                byte* s6 = (sp + step - 1);
                byte* s7 = (sp + step);
                byte* s8 = (sp + step + 1);
                for (int x = x1; x <= x2; x++, sp++, dp++, s0++, s1++, s2++, s3++, s5++, s6++, s7++, s8++) {
                    byte min = *s0;
                    if (*s1 < min) min = *s1;
                    if (*s2 < min) min = *s2;
                    if (*s3 < min) min = *s3;
                    if (*sp < min) min = *sp;
                    if (*s5 < min) min = *s5;
                    if (*s6 < min) min = *s6;
                    if (*s7 < min) min = *s7;
                    if (*s8 < min) min = *s8;

                    *(dp) = min;
                }
            });

            // edge pixel process
            for (int x = 0; x < bw; x++) {
                int yTop = 0;
                int yBottom = bh - 1;
                ErodeEdge(srcPtr, dstPtr, bw, bh, step, x, yTop);
                ErodeEdge(srcPtr, dstPtr, bw, bh, step, x, yBottom);
            }
            for (int y = 1; y < bh - 1; y++) {
                int xLeft = 0;
                int xRight = bw - 1;
                ErodeEdge(srcPtr, dstPtr, bw, bh, step, xLeft, y);
                ErodeEdge(srcPtr, dstPtr, bw, bh, step, xRight, y);
            }
        }

        public static void Erode2(IntPtr srcBuf, IntPtr dstBuf, int bw, int bh, int step) {
            byte* srcPtr = (byte*)srcBuf.ToPointer();
            byte* dstPtr = (byte*)dstBuf.ToPointer();
            int x1 = 1, x2 = bw - 2;
            int y1 = 1, y2 = bh - 2;
            int[] ofs = { -step - 1, -step, -step + 1, -1, 0, 1, step - 1, step, step + 1, };
            for (int y = y1; y <= y2; y++) {
                byte* sptr = &srcPtr[y * step];
                byte* dptr = &dstPtr[y * step];
                for (int x = x1; x <= x2; x++) {
                    byte result = sptr[x + ofs[0]];
                    for (int i = 1; i < 9; i++) {
                        byte val = sptr[x + ofs[i]];
                        result = result < val ? result : val;
                    }
                    dptr[x] = result;
                }
            }

            // edge pixel process
            for (int x = 0; x < bw; x++) {
                int yTop = 0;
                int yBottom = bh - 1;
                ErodeEdge(srcPtr, dstPtr, bw, bh, step, x, yTop);
                ErodeEdge(srcPtr, dstPtr, bw, bh, step, x, yBottom);
            }
            for (int y = 1; y < bh - 1; y++) {
                int xLeft = 0;
                int xRight = bw - 1;
                ErodeEdge(srcPtr, dstPtr, bw, bh, step, xLeft, y);
                ErodeEdge(srcPtr, dstPtr, bw, bh, step, xRight, y);
            }
        }

        public static void Erode3(IntPtr srcBuf, IntPtr dstBuf, int bw, int bh, int step) {
            byte* srcPtr = (byte*)srcBuf.ToPointer();
            byte* dstPtr = (byte*)dstBuf.ToPointer();
            int x1 = 1, x2 = bw - 2;
            int y1 = 1, y2 = bh - 2;
            for (int y = y1; y <= y2; y++) {
                byte* sp = &srcPtr[y * step + x1];
                byte* dp = &dstPtr[y * step + x1];
                for (int x = x1; x <= x2; x++, sp++, dp++) {
                    byte *s0 = (sp - step - 1);
                    byte *s1 = (sp - step);
                    byte *s2 = (sp - step + 1);
                    byte *s3 = (sp - 1);
                    byte *s5 = (sp + 1);
                    byte *s6 = (sp + step - 1);
                    byte *s7 = (sp + step);
                    byte *s8 = (sp + step + 1);

                    byte min = *s0;
                    if (*s1 < min) min = *s1;
                    if (*s2 < min) min = *s2;
                    if (*s3 < min) min = *s3;
                    if (*sp < min) min = *sp;
                    if (*s5 < min) min = *s5;
                    if (*s6 < min) min = *s6;
                    if (*s7 < min) min = *s7;
                    if (*s8 < min) min = *s8;

                    *(dp) = min;
                }
            }

            // edge pixel process
            for (int x = 0; x < bw; x++) {
                int yTop = 0;
                int yBottom = bh - 1;
                ErodeEdge(srcPtr, dstPtr, bw, bh, step, x, yTop);
                ErodeEdge(srcPtr, dstPtr, bw, bh, step, x, yBottom);
            }
            for (int y = 1; y < bh - 1; y++) {
                int xLeft = 0;
                int xRight = bw - 1;
                ErodeEdge(srcPtr, dstPtr, bw, bh, step, xLeft, y);
                ErodeEdge(srcPtr, dstPtr, bw, bh, step, xRight, y);
            }
        }

        public static void MemcpyMarshal1(IntPtr dst, IntPtr src, int nbytes) {
            for (int i = 0; i < nbytes; i++) {
                Marshal.WriteByte(dst, i, Marshal.ReadByte(src, i));
            }
        }

        public static void MemcpyMarshal2(IntPtr dst, IntPtr src, int nbytes) {
            byte[] temp = new byte[nbytes];
            Marshal.Copy(src, temp, 0, nbytes);
            Marshal.Copy(temp, 0, dst, nbytes);
        }

        public static void MemcpyUnsafe(IntPtr dst, IntPtr src, int nbytes) {
            byte* pdst = (byte*)dst.ToPointer();
            byte* psrc = (byte*)src.ToPointer();
            for (int i = 0; i < nbytes; i++) {
                pdst[i] = psrc[i];
            }
        }

        [DllImport("msvcrt.dll", EntryPoint = "memcpy", CallingConvention = CallingConvention.Cdecl, SetLastError = false)]
        public static extern IntPtr memcpy(IntPtr dest, IntPtr src, ulong count);
        public static void MemcpyCrt(IntPtr dst, IntPtr src, int nbytes) {
            memcpy(dst, src, (ulong)nbytes);
        }

        public static void MemcpyBufferClass(IntPtr dst, IntPtr src, int nbytes) {
            byte* pdst = (byte*)dst.ToPointer();
            byte* psrc = (byte*)src.ToPointer();
            Buffer.MemoryCopy(psrc, pdst, nbytes, nbytes);
        }
    }
}
