using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.InteropServices;

namespace OpenCVSharpTest {
    unsafe class MyBlobs {
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
            while (links[label] != 0) {
                label = links[label];
            }

            return label;
        }

        public static MyBlob[] Label(IntPtr src, int bw, int bh, int stride) {
            byte *psrc = (byte *)src.ToPointer();
            
            // label 버퍼
            int[] labels = Enumerable.Repeat(0, bw*bh).ToArray();

            // link 테이블
            var links = new List<int>();
            links.Add(0);
            
            // 1st stage
            // labeling with scan
            Glb.TimerStart();
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
                        labels[bw * y + x] = newLabel;
                        // link 테이블에 새 루트 라벨 추가
                        links.Add(0);
                    } else {
                        // 주변에 있다면 주변 라벨들의 루트중 최소라벨
                        int minLabel = GetRootLabel(links, nbrs[0]);
                        for (int i=0; i<nbrCount; i++) {
                            var rootLabel = GetRootLabel(links, nbrs[i]);
                            if (rootLabel < minLabel) {
                                minLabel = rootLabel;
                            }
                        }
                        labels[bw * y + x] = minLabel;
                        // link 테이블에서 주변 라벨의 parent 수정
                        for (int i = 0; i < nbrCount; i++) {
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
            Console.WriteLine($"=> 1st labelling time: {Glb.TimerStop()}");

            // 2nd stage
            // links 수정
            Glb.TimerStart();
            for (int i=0; i<links.Count; i++) {
                if (links[i] == 0)
                    continue;
                links[i] = GetRootLabel(links, links[i]);
            }
            Console.WriteLine($"=> link 수정 time: {Glb.TimerStop()}");

            // labels 수정
            Glb.TimerStart();
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
            Console.WriteLine($"=> labels 수정 time: {Glb.TimerStop()}");


            // 3. 후처리
            // link index 수정
            Glb.TimerStart();
            Dictionary<int, int> relabelTable = new Dictionary<int, int>();
            int newIndex = 1;
            for (int i=1; i<links.Count; i++) {
                var link = links[i];
                if (link == 0) {
                    relabelTable.Add(i, newIndex++);
                }
            }
            Console.WriteLine($"=> link index 수정 time: {Glb.TimerStop()}");

            // labels 수정
            Glb.TimerStart();
            for (int y = 0; y < bh; y++) {
                for (int x = 0; x < bw; x++) {
                    var label = labels[bw*y+x];
                    if (label == 0)
                        continue;
                    labels[bw*y+x] = relabelTable[label];
                }
            }
            Console.WriteLine($"=> labels index 수정 time: {Glb.TimerStop()}");


            // 4. 데이터 추출
            MyBlob[] blobs = new MyBlob[relabelTable.Count];
            for (int i=0; i<blobs.Length; i++) {
                blobs[i] = new MyBlob();
            }

            Glb.TimerStart();
            for (int y = 0; y < bh; y++) {
                for (int x = 0; x < bw; x++) {
                    var label = labels[bw*y+x];
                    if (label == 0)
                        continue;
                    int idx = label-1;
                    var blob = blobs[idx];
                    blob.area++;
                    blob.pixels.Add(new Point(x, y));
                    blob.centroidX += x;
                    blob.centroidY += y;
                    if (x < blob.minX) blob.minX = x;
                    if (y < blob.minY) blob.minY = y;
                    if (x > blob.maxX) blob.maxX = x;
                    if (y > blob.maxY) blob.maxY = y;
                }
            }
            Console.WriteLine($"=> blob pixel 추출 time: {Glb.TimerStop()}");

            Glb.TimerStart();
            foreach (var blob in blobs) {
                if (blob.pixels.Count == 0)
                    continue;
                blob.centroidX /= blob.area;
                blob.centroidY /= blob.area;
            }
            Console.WriteLine($"=> centoid 나누기 time: {Glb.TimerStop()}");

            return blobs;
        }
    }

    class MyBlob {
        public int area = 0;
        public List<Point> pixels = new List<Point>();
        public int centroidX = 0;
        public int centroidY = 0;
        public int minX = int.MaxValue-1;
        public int minY = int.MaxValue-1;
        public int maxX = -1;
        public int maxY = -1;
    }
}