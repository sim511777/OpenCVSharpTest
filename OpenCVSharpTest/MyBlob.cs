﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.InteropServices;

namespace OpenCVSharpTest {
    unsafe class MyBlobs {
        public static MyBlob[] Label(IntPtr src, int bw, int bh, int stride) {
            byte *psrc = (byte *)src.ToPointer();
            
            // label 버퍼
            int[] labels = new int[bw*bh];

            // link 테이블
            int[] links = new int[bw*bh];
            int linkCount = 1;
            
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
                        checkLabel = labels[bw*y+x-1];
                        if (checkLabel != 0) {
                            nbrs[nbrCount++] = checkLabel;
                        }
                    }
                    if (y != 0) {
                        // check top
                        checkLabel = labels[bw*(y-1)+x];
                        if (checkLabel != 0) {
                            nbrs[nbrCount++] = checkLabel;
                        }
                        if (x != 0) {
                            // check lt
                            checkLabel = labels[bw*(y-1)+x-1];
                            if (checkLabel != 0) {
                                nbrs[nbrCount++] = checkLabel;
                            }
                        }
                        if (x != bw - 1) {
                            // check rt
                            checkLabel = labels[bw*(y-1)+x+1];
                            if (checkLabel != 0) {
                                nbrs[nbrCount++] = checkLabel;
                            }
                        }
                    }
                    
                    if (nbrCount == 0) {
                        // 주변에 없다면 새번호 생성하고 라벨링
                        int newLabel = linkCount;
                        labels[bw * y + x] = newLabel;
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
            for (int i=0; i<linkCount; i++) {
                if (links[i] == 0)
                    continue;

                int label = links[i];
                while (links[label] != 0) {
                    label = links[label];
                }
                links[i] = label;
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
            int newIndex = 0;
            for (int i=1; i<linkCount; i++) {
                var link = links[i];
                if (link == 0) {
                    relabelTable.Add(i, newIndex++);
                }
            }
            Console.WriteLine($"=> link index 수정 time: {Glb.TimerStop()}");

            // 4. 데이터 추출
            MyBlob[] blobs = new MyBlob[relabelTable.Count];
            for (int i=0; i<blobs.Length; i++) {
                blobs[i] = new MyBlob();
            }

            // labels 수정
            Glb.TimerStart();
            for (int y = 0; y < bh; y++) {
                for (int x = 0; x < bw; x++) {
                    var label = labels[bw*y+x];
                    if (label == 0)
                        continue;
                    int idx = relabelTable[label];
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