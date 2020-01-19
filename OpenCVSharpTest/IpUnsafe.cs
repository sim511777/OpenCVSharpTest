using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace OpenCVSharpTest {
    unsafe class IpUnsafe {
        private static byte GetBorderPixelReplicate(byte* ptr, int bw, int bh, int step, int x, int y) {
            if (x < 0) x = 0;
            else if (x > bw - 1) x = bw - 1;

            if (y < 0) y = 0;
            else if (y > bh - 1) y = bh - 1;

            return *(ptr + step * y + x);
        }

        private static void ErodeBorderPixel(byte* srcPtr, byte* dstPtr, int bw, int bh, int step, int x, int y) {
            byte s0 = GetBorderPixelReplicate(srcPtr, bw, bh, step, x - 1, y - 1);
            byte s1 = GetBorderPixelReplicate(srcPtr, bw, bh, step, x, y - 1);
            byte s2 = GetBorderPixelReplicate(srcPtr, bw, bh, step, x + 1, y - 1);
            byte s3 = GetBorderPixelReplicate(srcPtr, bw, bh, step, x - 1, y);
            byte s4 = GetBorderPixelReplicate(srcPtr, bw, bh, step, x, y);
            byte s5 = GetBorderPixelReplicate(srcPtr, bw, bh, step, x + 1, y);
            byte s6 = GetBorderPixelReplicate(srcPtr, bw, bh, step, x - 1, y + 1);
            byte s7 = GetBorderPixelReplicate(srcPtr, bw, bh, step, x, y + 1);
            byte s8 = GetBorderPixelReplicate(srcPtr, bw, bh, step, x + 1, y + 1);

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

        private static void ErodeBorder(byte* srcPtr, byte* dstPtr, int bw, int bh, int step) {
            for (int x = 0; x < bw; x++) {
                int yTop = 0;
                int yBottom = bh - 1;
                ErodeBorderPixel(srcPtr, dstPtr, bw, bh, step, x, yTop);
                ErodeBorderPixel(srcPtr, dstPtr, bw, bh, step, x, yBottom);
            }
            for (int y = 1; y < bh - 1; y++) {
                int xLeft = 0;
                int xRight = bw - 1;
                ErodeBorderPixel(srcPtr, dstPtr, bw, bh, step, xLeft, y);
                ErodeBorderPixel(srcPtr, dstPtr, bw, bh, step, xRight, y);
            }
        }

        private static void Erode1Line(byte* sp, byte* dp, int step, int len) {
            int[] ofs = { -step - 1, -step, -step + 1, -1, 0, 1, step - 1, step, step + 1, };
            byte* s0 = sp + ofs[0];
            byte* s1 = sp + ofs[1];
            byte* s2 = sp + ofs[2];
            byte* s3 = sp + ofs[3];
            byte* s4 = sp + ofs[4];
            byte* s5 = sp + ofs[5];
            byte* s6 = sp + ofs[6];
            byte* s7 = sp + ofs[7];
            byte* s8 = sp + ofs[8];
            for (int x = 0; x < len; x++, dp++, s0++, s1++, s2++, s3++, s4++, s5++, s6++, s7++, s8++) {
                byte min = *s0;
                if (*s1 < min) min = *s1;
                if (*s2 < min) min = *s2;
                if (*s3 < min) min = *s3;
                if (*s4 < min) min = *s4;
                if (*s5 < min) min = *s5;
                if (*s6 < min) min = *s6;
                if (*s7 < min) min = *s7;
                if (*s8 < min) min = *s8;
                *(dp) = min;
            }
        }

        public static void Erode(IntPtr srcBuf, IntPtr dstBuf, int bw, int bh, int step, bool useParallel) {
            byte* srcPtr = (byte*)srcBuf.ToPointer();
            byte* dstPtr = (byte*)dstBuf.ToPointer();
            ErodeBorder(srcPtr, dstPtr, bw, bh, step);
            
            int x1 = 1, x2 = bw - 1;
            int y1 = 1, y2 = bh - 1;

            Action<int> actionErode1Line = (y) => {
                byte* sp = &srcPtr[y * step + x1];
                byte* dp = &dstPtr[y * step + x1];
                Erode1Line(sp, dp, step, x2 - x1);
            };

            if (useParallel) {
                Parallel.For(y1, y2, actionErode1Line);
            } else {
                for (int y = y1; y < y2; y++) {
                    actionErode1Line(y);
                }
            }
        }

        public static void Inverse(IntPtr buf, int bw, int bh, int stride) {
            byte *pbuf = (byte *)buf.ToPointer();
            for (int y = 0; y < bh; y++) {
                byte *ppbuf = pbuf + stride * y;
                for (int x = 0; x < bw; x++, ppbuf = ppbuf + 1) {
                   *ppbuf = (byte)~*ppbuf;
                }
            }
        }

        public static void InverseParallelFor(IntPtr buf, int bw, int bh, int stride) {
            byte *pbuf = (byte *)buf.ToPointer();
            Action<int> act = (y) => {
                byte *ppbuf = pbuf + stride * y;
                for (int x = 0; x < bw; x++, ppbuf = ppbuf + 1) {
                   *ppbuf = (byte)~*ppbuf;
                }
            };
            Parallel.For(0, bh, act);
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
