using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

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

        public static void Blob(IntPtr src, IntPtr tmp, IntPtr dst, int bw, int bh, int stride) {
            byte *psrc = (byte *)src.ToPointer();
            byte *ptmp = (byte *)tmp.ToPointer();
            byte *pdst = (byte *)dst.ToPointer();
            // 라벨버퍼
            IntPtr labelBuf = Marshal.AllocHGlobal(bw * bh * sizeof(int));
            int *plabel = (int *)labelBuf.ToPointer();
            for (int i=0; i<bw*bh; i++) {
                plabel[i] = -1;
            }

            // disjoint set
            var link = new int[bw*bh];
            
            // 1 pass
            int NextLabel = 0;
            for (int y = 0; y < bh; y++) {
                byte *ppsrc = psrc + stride * y;
                int *pplabel = plabel + bw * y;
                for (int x = 0; x < bw; x++, ppsrc = ppsrc + 1, pplabel = pplabel + 1) {
                    if (*ppsrc == 0)
                        continue;

                    int[] neighborLabels = new int[4];
                    int neighborCount = 0;

                    if (x != 0) {
                        int labelLeft = *(pplabel - 1);
                        if (labelLeft != -1) {
                            neighborLabels[neighborCount++] = labelLeft;
                        }
                    }
                    if (y != 0) {
                        int labelTop = *(pplabel - stride);
                        if (labelTop != -1) {
                            neighborLabels[neighborCount++] = labelTop;
                        }

                        if (x != 0) {
                            int labelLeftTop = *(pplabel - stride - 1);
                            if (labelLeftTop != -1) {
                                neighborLabels[neighborCount++] = labelLeftTop;
                            }
                        }
                        if (x != bw-1) {
                            int labelRightTop = *(pplabel - stride + 1);
                            if (labelRightTop != -1) {
                                neighborLabels[neighborCount++] = labelRightTop;
                            }
                        }
                    }

                    if (neighborCount == 0) {
                        link[NextLabel] = -1;
                        *pplabel = NextLabel;
                        NextLabel++;
                    } else {
                        int neighborMin = neighborLabels[0];
                        for (int i=1; i<neighborCount; i++) {
                            if (neighborLabels[i] < neighborMin)
                                neighborMin = neighborLabels[i];
                        }
                        *pplabel = neighborMin;
                        for (int i=0; i<neighborCount; i++) {
                            // disjoint-set union
                            if (neighborLabels[i] != neighborMin)
                                link[neighborLabels[i]] = neighborMin;
                        }
                    }
                }
            }

            // display
            for (int y = 0; y < bh; y++) {
                int* pplabel = plabel + bw * y;
                byte* pptmp = ptmp + stride * y;
                for (int x = 0; x < bw; x++, pplabel++, pptmp++) {
                    *pptmp = (byte)((*pplabel+1) * 10); 
                }
            }

            // 2 pass
            for (int y = 0; y < bh; y++) {
                int* pplabel = plabel + bw * y;
                for (int x = 0; x < bw; x++, pplabel++) {
                    if (*pplabel == -1)
                        continue;
                    // disjoint-set find
                    var label = *pplabel;
                    while (link[label] != -1) {
                        label = link[label];
                    }
                    *pplabel = label;
                }
            }

            // display
            for (int y = 0; y < bh; y++) {
                int* pplabel = plabel + bw * y;
                byte* ppdst = pdst + stride * y;
                for (int x = 0; x < bw; x++, pplabel++, ppdst++) {
                    *ppdst = (byte)((*pplabel+1) * 10); 
                }
            }

            Marshal.FreeHGlobal(labelBuf);
        }
    }
}
