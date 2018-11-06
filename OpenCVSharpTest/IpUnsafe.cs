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

        private static int GetNeighborLabels(int[] labels, int bw, int bh, int x, int y, int[] nbrs) {
            int nbrCount = 0;
            int label;
            if (x != 0) {
                // check left
                label = labels[bw*y+x-1];
                if (label != 0) {
                    nbrs[nbrCount++] = label;
                }
            }
            if (y != 0) {
                // check top
                label = labels[bw*(y-1)+x];
                if (label != 0) {
                    nbrs[nbrCount++] = label;
                }
                if (x != 0) {
                    // check lt
                    label = labels[bw*(y-1)+x-1];
                    if (label != 0) {
                        nbrs[nbrCount++] = label;
                    }
                }
                if (x != bw - 1) {
                    // check rt
                    label = labels[bw*(y-1)+x+1];
                    if (label != 0) {
                        nbrs[nbrCount++] = label;
                    }
                }
            }

            return nbrCount;
        }

        private static int GetRootLabel(List<int> links, int label) {
            int root = label;
            while (links[root] != 0) {
                root = links[root];
            }

            return root;
        }

        private static int GetMinRootLabel(List<int> links, int[] nbrs, int nbrCount) {
            int minLabel = GetRootLabel(links, nbrs[0]);
            for (int i=0; i<nbrCount; i++) {
                var rootLabel = GetRootLabel(links, nbrs[i]);
                if (rootLabel < minLabel) {
                    minLabel = rootLabel;
                }
            }
            return minLabel;
        }

        private static void DrawLabels(int[] labels, IntPtr draw, int bw, int bh, int stride) {
            for (int y = 0; y < bh; y++) {
                for (int x = 0; x < bw; x++) {
                    int label = labels[bw*y+x];
                    int color = (label);
                    Marshal.WriteByte(draw+stride*y+x, (byte)color); 
                }
            }
        }

        public static int Blob(IntPtr src, IntPtr tmp, IntPtr dst, int bw, int bh, int stride) {
            byte *psrc = (byte *)src.ToPointer();
            
            // label 버퍼
            int[] labels = Enumerable.Repeat(0, bw*bh).ToArray();

            // link 테이블
            var links = new List<int>();
            links.Add(0);
            
            // 1st stage
            int[] nbrs = new int[4];
            for (int y = 0; y < bh; y++) {
                for (int x = 0; x < bw; x++) {
                    // 배경이면 skip
                    if (psrc[stride*y+x] == 0)
                        continue;
                    
                    // 주변 4개의 label버퍼 조사 (l, tl, t, tr)
                    int nbrCount = GetNeighborLabels(labels, bw, bh, x, y, nbrs);
                    if (nbrCount == 0) {
                        // 주변에 없다면 새번호 생성하고 라벨링
                        int newLabel = links.Count;
                        labels[bw*y+x] = newLabel;
                        // link 테이블에 새 루트 라벨 추가
                        links.Add(0);
                    } else {
                        // 주변에 있다면 주변 라벨들의 루트중 최소라벨
                        int minLabel = GetMinRootLabel(links, nbrs, nbrCount);
                        labels[bw*y+x] = minLabel;
                        // link 테이블에서 주변 라벨의 parent 수정
                        for (int i=0; i<nbrCount; i++) {
                            int label = nbrs[i];
                            // 라벨이 min라벨이 아니라면 라벨의 link를 minlabel로 바꿈
                            // 이전 link가 0이 아니라면 이전 link의 link도 minlabel로 바꿈
                            while (label != minLabel) {
                                var oldLink = links[label];
                                links[label] = minLabel;
                                if (oldLink == 0)
                                    break;
                                label = oldLink;
                            }
                        }
                    }
                }
            }

            // display
            DrawLabels(labels, tmp, bw, bh, stride);

            // 2nd stage
            // links 수정
            for (int i=0; i<links.Count; i++) {
                if (links[i] == 0)
                    continue;
                links[i] = GetRootLabel(links, links[i]);
            }

            // labels 수정
            for (int y = 0; y < bh; y++) {
                for (int x = 0; x < bw; x++) {
                    int label = labels[bw*y+x];
                    if (label == 0)
                        continue;
                    var link = links[label];
                    if (link == 0)
                        continue;
                    labels[bw*y+x] = link;
                }
            }


            // display
            DrawLabels(labels, dst, bw, bh, stride);

            return links.Count(link => link == 0)-1;
        }
    }
}
