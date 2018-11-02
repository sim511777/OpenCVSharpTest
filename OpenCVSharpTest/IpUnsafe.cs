﻿using System;
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

        // 현재 값이 255일때 라벨 버퍼의 주변 4개 조회
        // 모두 0이면 새 label을 지정하고 lable table에 추가
        // 하나라도 0이 아니면 그중 가장 작은 값을 label 로 지정 하고
        // 큰 값들은 label tale에서 대응 값이 지정된 label 보다 크면 갱신
/*
algorithm TwoPass(data)
   linked = []
   labels = structure with dimensions of data, initialized with the value of Background

   First pass

   for row in data:
       for column in row:
           if data[row][column] is not Background

               neighbors = connected elements with the current element's value

               if neighbors is empty
                   linked[NextLabel] = set containing NextLabel
                   labels[row][column] = NextLabel
                   NextLabel += 1

               else

                   Find the smallest label

                   L = neighbors labels
                   labels[row][column] = min(L)
                   for label in L
                       linked[label] = union(linked[label], L)

   Second pass

   for row in data
       for column in row
           if data[row][column] is not Background
               labels[row][column] = find(labels[row][column])

   return labels
*/
        public static void BlobPass(byte *data, int *labels, int bw, int bh, int stride) {
            // 1 pass
            for (int i=0; i<bw*bh; i++) {
                labels[i] = 0;
            }
            int NextLabel = 1;

            SortedSet<int> neighborsLabels = new SortedSet<int>();
            Dictionary<int, SortedSet<int>> linked = new Dictionary<int, SortedSet<int>>();

            for (int y = 0; y < bh; y++) {
                byte *pdata = data + stride * y;
                int *plabel = labels + bw * y;
                for (int x = 0; x < bw; x++, pdata = pdata + 1, plabel = plabel + 1) {
                    if (*pdata == 0)
                        continue;

                    neighborsLabels.Clear();
                    int neighbor = 0;
                    if (x != 0) {
                        neighbor = *(plabel - 1);
                        if (neighbor != 0)
                            neighborsLabels.Add(neighbor);
                    }
                    if (y != 0) {
                        neighbor = *(plabel - stride);
                        if (neighbor != 0)
                            neighborsLabels.Add(neighbor);

                        if (x != 0) {
                            neighbor = *(plabel - stride - 1);
                            if (neighbor != 0)
                                neighborsLabels.Add(neighbor);
                        }
                        if (x != bw-1) {
                            neighbor = *(plabel - stride + 1);
                            if (neighbor != 0)
                                neighborsLabels.Add(neighbor);
                        }
                    }

                    if (neighborsLabels.Count == 0) {
                        SortedSet<int> set = new SortedSet<int>();
                        set.Add(NextLabel);
                        linked[NextLabel] = set;
                        *plabel = NextLabel;
                        NextLabel += 1;
                    } else {
                        var L = neighborsLabels;
                        *plabel = L.Min;
                        foreach (var label in L) {
                            linked[label].UnionWith(L);
                        }
                    }
                }
            }

            // 2 pass
            for (int y = 0; y < bh; y++) {
                byte* pdata = data + stride * y;
                int* plabel = labels + bw * y;
                for (int x = 0; x < bw; x++, pdata = pdata + 1, plabel = plabel + 1) {
                    if (*pdata == 0)
                        continue;
                    var label = *plabel;
                    var parent = linked[label].Min;
                    var last = label;
                    while (last != parent) {
                        last = parent;
                        parent = linked[parent].Min;
                    }
                    *plabel = parent;
                }
            }
        }

        public static void Blob(IntPtr src, IntPtr dst, int bw, int bh, int stride) {
            byte *psrc = (byte *)src.ToPointer();
            byte *pdst = (byte *)dst.ToPointer();
            
            IntPtr lblBuf = Marshal.AllocHGlobal(bw * bh * sizeof(int));
            int *plbl = (int *)lblBuf.ToPointer();
            
            BlobPass(psrc, plbl, bw, bh, stride);
            for (int y = 0; y < bh; y++) {
                byte *ppdst = pdst + stride * y;
                int *pplbl = plbl + bw * y;
                for (int x = 0; x < bw; x++, ppdst = ppdst + 1, pplbl = pplbl + 1) {
                    *ppdst = (byte)(*pplbl * 10);                   
                }
            }
            
            Marshal.FreeHGlobal(lblBuf);

        }
    }
}
