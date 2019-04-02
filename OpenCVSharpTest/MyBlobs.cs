using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.InteropServices;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using OpenCvSharp.Blob;

namespace OpenCVSharpTest {
    unsafe class MyBlobs {
        public Dictionary<int, MyBlob> Blobs = new Dictionary<int, MyBlob>();
        public int bw = 0;
        public int bh = 0;
        public int[] Labels = null;

        public int Label(IntPtr src, int bw, int bh, int stride) {
            Glb.TimerStart();
            // prepare
            byte *psrc = (byte *)src.ToPointer();
            
            // label 버퍼
            this.Labels = new int[bw*bh];
            this.bw = bw;
            this.bh = bh;

            // link 테이블
            int[] links = new int[bw*bh];
            int linkCount = 1;
            Console.WriteLine($"=> 1. Prepare buffer time: {Glb.TimerStop()}ms");
            
            Glb.TimerStart();
            // 1st stage
            // labeling with scan
            int[] nbrs = new int[4];
            for (int y = 0; y < bh; y++) {
                for (int x = 0; x < bw; x++) {
                    // 배경이면 skip
                    if (psrc[stride*y+x] == 0)
                        continue;

                    // 주변 4개의 label버퍼 조사 (l, tl, t, tr)
                    int nbrCount = 0;
                    int checkLabel;
                    if (x != 0) {
                        // check left
                        checkLabel = Labels[bw*y+x-1];
                        if (checkLabel != 0) {
                            nbrs[nbrCount++] = checkLabel;
                        }
                    }
                    if (y != 0) {
                        // check top
                        checkLabel = Labels[bw*(y-1)+x];
                        if (checkLabel != 0) {
                            nbrs[nbrCount++] = checkLabel;
                        }
                        if (x != 0) {
                            // check lt
                            checkLabel = Labels[bw*(y-1)+x-1];
                            if (checkLabel != 0) {
                                nbrs[nbrCount++] = checkLabel;
                            }
                        }
                        if (x != bw - 1) {
                            // check rt
                            checkLabel = Labels[bw*(y-1)+x+1];
                            if (checkLabel != 0) {
                                nbrs[nbrCount++] = checkLabel;
                            }
                        }
                    }
                    
                    if (nbrCount == 0) {
                        // 주변에 없다면 새번호 생성하고 라벨링
                        int newLabel = linkCount;
                        Labels[bw * y + x] = newLabel;
                        // link 테이블에 새 루트 라벨 추가
                        links[linkCount] = 0;
                        linkCount++;
                    } else {
                        // 주변에 있다면 주변 라벨들의 루트중 최소라벨
                        int minLabel = nbrs[0];
                        while (links[minLabel] != 0) {
                            minLabel = links[minLabel];
                        }
                        for (int i=0; i<nbrCount; i++) {
                            var label = nbrs[i];
                            while (links[label] != 0) {
                                label = links[label];
                            }
                            if (label < minLabel) {
                                minLabel = label;
                            }
                        }
                        Labels[bw * y + x] = minLabel;
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
            Console.WriteLine($"=> 2. 1st labelling time: {Glb.TimerStop()}ms");

            // 2nd stage
            // links 수정
            Glb.TimerStart();
            for (int i=0; i<linkCount; i++) {
                if (links[i] == 0)
                    continue;

                int label = links[i];
                while (links[label] != 0) {
                    label = links[label];
                }
                links[i] = label;
            }
            Console.WriteLine($"=> 3. link 수정 time: {Glb.TimerStop()}ms");

            // labels 수정
            Glb.TimerStart();
            for (int y = 0; y < bh; y++) {
                for (int x = 0; x < bw; x++) {
                    int label = Labels[bw*y+x];
                    if (label == 0)
                        continue;
                    var link = links[label];
                    if (link == 0)
                        continue;
                    Labels[bw*y+x] = link;
                }
            }
            Console.WriteLine($"=> 4. labels 수정 time: {Glb.TimerStop()}ms");


            // 3. 후처리
            // link index 수정
            Glb.TimerStart();
            Dictionary<int, int> relabelTable = new Dictionary<int, int>();
            int newIndex = 1;
            for (int i=1; i<linkCount; i++) {
                var link = links[i];
                if (link == 0) {
                    relabelTable.Add(i, newIndex++);
                }
            }
            Console.WriteLine($"=> 5. link index 수정 time: {Glb.TimerStop()}ms");

            // 4. 데이터 추출
            Glb.TimerStart();
            var blobs = this.Blobs;
            blobs.Clear();
            foreach (var newLable in relabelTable.Values) {
                blobs[newLable]  = new MyBlob(newLable);
            }
            int labeledCount = 0;

            // labels 수정
            for (int y = 0; y < bh; y++) {
                for (int x = 0; x < bw; x++) {
                    var label = Labels[bw*y+x];
                    if (label == 0)
                        continue;

                    labeledCount++;

                    int newLabel = relabelTable[label];
                    Labels[bw*y+x] = newLabel;
                    
                    var blob = blobs[newLabel];
                    blob.area++;
                    blob.centroidX += x;
                    blob.centroidY += y;
                    if (x < blob.MinX) blob.MinX = x;
                    if (y < blob.MinY) blob.MinY = y;
                    if (x > blob.MaxX) blob.MaxX = x;
                    if (y > blob.MaxY) blob.MaxY = y;
                }
            }

            foreach (var blob in this.Blobs.Values) {
                blob.centroidX /= blob.area;
                blob.centroidY /= blob.area;
            }
            Console.WriteLine($"=> 6. 데이터 추출 time: {Glb.TimerStop()}ms");

            return labeledCount;
        }
    }

    class MyBlob {
        public MyBlob(int label) {
            this.label = label;
        }
        public int label = 0;
        public int area = 0;
        public double centroidX = 0;
        public double centroidY = 0;
        public int MinX = int.MaxValue-1;
        public int MinY = int.MaxValue-1;
        public int MaxX = -1;
        public int MaxY = -1;
    }

    unsafe class MyBlobRenderer {
        public static void RenderBlobs(CvBlobs blobs, Mat matDst) {
            byte* pdst = matDst.DataPointer;
            int bw = matDst.Width;
            int bh = matDst.Height;
            int stride = (int)matDst.Step();
            int colorCount = 0;
            foreach (var blob in blobs.Values) {
                double r, g, b;
                Glb.Hsv2Rgb((colorCount * 77) % 360, 0.5, 1.0, out r, out g, out b);
                colorCount++;
                byte bb = (byte)b;
                byte bg = (byte)g;
                byte br = (byte)r;
                int label = blob.Label;
                for (int y = blob.MinY; y <= blob.MaxY; y++) {
                    for (int x = blob.MinX; x <= blob.MaxX; x++) {
                        if (blobs.Labels[y, x] == label) {
                            byte* ppdst = pdst + stride * y + x * 3;
                            ppdst[0] = bb;
                            ppdst[1] = bg;
                            ppdst[2] = br;
                        }
                    }
                }
            }
        }

        public static void RenderBlobs(Mat matLabels, Mat matStats, Mat matCentroids, Mat matDst) {
            byte* pdst = matDst.DataPointer;
            int bw = matDst.Width;
            int bh = matDst.Height;
            int stride = (int)matDst.Step();
            int num = matStats.Rows;
            int* labels = (int*)matLabels.DataPointer;
            int* stats = (int*)matStats.DataPointer;
            for (int label = 1; label < num; label++) {
                double r, g, b;
                Glb.Hsv2Rgb(((label - 1) * 77) % 360, 0.5, 1.0, out r, out g, out b);
                byte bb = (byte)b;
                byte bg = (byte)g;
                byte br = (byte)r;
                int* stat = stats + label * 5;
                int minX = stat[(int)ConnectedComponentsTypes.Left];
                int minY = stat[(int)ConnectedComponentsTypes.Top];
                int maxX = minX + stat[(int)ConnectedComponentsTypes.Width] - 1;
                int maxY = minY + stat[(int)ConnectedComponentsTypes.Height] - 1;
                for (int y = minY; y <= maxY; y++) {
                    for (int x = minX; x <= maxX; x++) {
                        if (labels[y * bw + x] == label) {
                            byte* ppdst = pdst + stride * y + x * 3;
                            ppdst[0] = bb;
                            ppdst[1] = bg;
                            ppdst[2] = br;
                        }
                    }
                }
            }
        }

        public static void RenderBlobs(MyBlobs blobs, Mat matDst) {
            byte* pdst = matDst.DataPointer;
            int bw = matDst.Width;
            int bh = matDst.Height;
            int stride = (int)matDst.Step();
            int colorCount = 0;
            foreach (var blob in blobs.Blobs.Values) {
                double r, g, b;
                Glb.Hsv2Rgb((colorCount * 77) % 360, 0.5, 1.0, out r, out g, out b);
                colorCount++;
                byte bb = (byte)b;
                byte bg = (byte)g;
                byte br = (byte)r;
                int label = blob.label;
                for (int y = blob.MinY; y <= blob.MaxY; y++) {
                    for (int x = blob.MinX; x <= blob.MaxX; x++) {
                        if (blobs.Labels[y * bw + x] == label) {
                            byte* ppdst = pdst + stride * y + x * 3;
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