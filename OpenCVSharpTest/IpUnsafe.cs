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

        public static void DistanceTransform(IntPtr thrBuff, int bw, int bh, IntPtr distBuff) {
            float sq2 = (float)Math.Sqrt(2);
            float one = 1f;

            // thr을 좌상단에서 우하단으로 스캔한다.
            // thr이 0이면 패스
            // thr이 255이면
            // 주변 4개의 픽셀과 dist값에 거리를 더한 값중 가장 작은 값
            for (int y=1; y<bh-1; y++) {
                byte* thrPtr = (byte*)thrBuff.ToPointer() + bw * y + 1;
                float* distPtr = (float*)distBuff.ToPointer() + bw * y + 1;
                for (int x=1; x<bw-1; x++, thrPtr++, distPtr++) {
                    if (*thrPtr == 0)
                        continue;

                    // LeftTop   / CenterTop / RightTop
                    // LeftCenter
                    float LeftTop = *(distPtr - bw - 1) + sq2;
                    float CenterTop = *(distPtr - bw) + one;
                    float RightTop = *(distPtr - bw + 1) + sq2;
                    float LeftCenter = *(distPtr - 1) + one;
                    float minDist = LeftTop;
                    if (CenterTop < minDist) minDist = CenterTop;
                    if (RightTop < minDist) minDist = RightTop;
                    if (LeftCenter < minDist) minDist = LeftCenter;
                    *distPtr = minDist;
                }
            }

            // thr을 우하단에서 좌상단으로 스캔한다
            // thr이 0이면 패스
            // thr이 255이면
            // 주변 8개의 픽셀과 dist값에 거리를 더한 값중 가장 작은 값
            for (int y=bh-2; y>=1; y--) {
                byte* thrPtr = (byte*)thrBuff.ToPointer() + bw * y + bw - 2;
                float* distPtr = (float*)distBuff.ToPointer() + bw * y + bw - 2;
                for (int x = bw-2; x >= 1; x--, thrPtr--, distPtr--) {
                    if (*thrPtr == 0)
                        continue;

                    // LeftTop   / CenterTop / RightTop
                    // LeftCenter
                    float LeftTop = *(distPtr - bw - 1) + sq2;
                    float CenterTop = *(distPtr - bw) + one;
                    float RightTop = *(distPtr - bw + 1) + sq2;
                    float LeftCenter = *(distPtr - 1) + one;
                    float RightCenter = *(distPtr + 1) + one;
                    float LeftBot = *(distPtr + bw - 1) + sq2;
                    float CenterBot = *(distPtr + bw) + one;
                    float RightBot = *(distPtr + bw + 1) + sq2;
                    float minDist = LeftTop;
                    if (CenterTop < minDist) minDist = CenterTop;
                    if (RightTop < minDist) minDist = RightTop;
                    if (LeftCenter < minDist) minDist = LeftCenter;
                    if (RightCenter < minDist) minDist = RightCenter;
                    if (LeftBot < minDist) minDist = LeftBot;
                    if (CenterBot < minDist) minDist = CenterBot;
                    if (RightBot < minDist) minDist = RightBot;
                    *distPtr = minDist;
                }
            }
        }
    }
}
