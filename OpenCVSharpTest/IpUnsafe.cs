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
        public static void BlobPass(byte *data, int *labels, int bw, int bh, int stride, byte*tmp, byte*dst) {
            // 1 pass
            for (int i=0; i<bw*bh; i++) {
                labels[i] = 0;
            }
            int NextLabel = 1;

            HashSet<int> neighborsLabels = new HashSet<int>();
            //Dictionary<int, HashSet<int>> linked = new Dictionary<int, HashSet<int>>();
            var link = new Dictionary<int,int>();

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
                        link.Add(NextLabel, -1);
                        *plabel = NextLabel;
                        NextLabel += 1;
                    } else {
                        var L = neighborsLabels;
                        *plabel = L.Min();
                        foreach (var label in L) {
                            if (*plabel != label)
                                link[label] = *plabel;
                        }
                    }
                }
            }

            // display
            for (int y = 0; y < bh; y++) {
                int* plabel = labels + bw * y;
                byte* ptmp = tmp + stride * y;
                byte* pdst = dst + stride * y;
                for (int x = 0; x < bw; x++, plabel++, ptmp++, pdst++) {
                    *ptmp = (byte)(*plabel * 10); 
                }
            }

            // 2 pass
            for (int y = 0; y < bh; y++) {
                int* plabel = labels + bw * y;
                for (int x = 0; x < bw; x++, plabel = plabel + 1) {
                    if (*plabel == 0)
                        continue;
                    var label = *plabel;
                    while (link[label] != -1) {
                        label = link[label];
                    }
                    *plabel = label;
                }
            }

            // display
            for (int y = 0; y < bh; y++) {
                int* plabel = labels + bw * y;
                byte* ptmp = tmp + stride * y;
                byte* pdst = dst + stride * y;
                for (int x = 0; x < bw; x++, plabel++, ptmp++, pdst++) {
                    *pdst = (byte)(*plabel * 10); 
                }
            }
        }

        public static void Blob(IntPtr src, IntPtr tmp, IntPtr dst, int bw, int bh, int stride) {
            byte *psrc = (byte *)src.ToPointer();
            byte *pdst = (byte *)dst.ToPointer();
            
            IntPtr lblBuf = Marshal.AllocHGlobal(bw * bh * sizeof(int));
            int *plbl = (int *)lblBuf.ToPointer();
            
            BlobPass(psrc, plbl, bw, bh, stride, (byte *)tmp.ToPointer(), (byte *)dst.ToPointer());
                        
            Marshal.FreeHGlobal(lblBuf);
        }
    }
}
