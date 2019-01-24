// IP.cpp: DLL 응용 프로그램을 위해 내보낸 함수를 정의합니다.
//

#include "stdafx.h"
#include "IP.h"
#include <emmIntrin.h>  // SSE
#include <immintrin.h>  // AVX
#include <dvec.h>       // Vector class

IP_API void InverseImageC(BYTE *buf, int bw, int bh, int stride) {
    for (int y = 0; y < bh; y++) {
        BYTE* ppbuf = buf + stride * y;
        for (int x = 0; x < bw; x++, ppbuf++) {
            *ppbuf = ~(*ppbuf);
        }
    }
}

IP_API void InverseImageSse(BYTE *buf, int bw, int bh, int stride) {
    __m128i mfull = _mm_set1_epi8((char)255);
    int nloop = bw / 16; // 한 라인에서  SIMD처리 가능한 횟수
    for (int y = 0; y < bh; y++) {
        // SIMD처리
        __m128i *mpbuf = (__m128i *)(buf + stride * y);
        for (int n = 0; n < nloop; n++, mpbuf++) {
            __m128i mbuf = _mm_loadu_si128(mpbuf);
            mbuf = _mm_xor_si128(mbuf, mfull);
            _mm_storeu_si128(mpbuf, mbuf);
        }

        // C처리
        BYTE *ppbuf = (buf + stride * y + nloop * 16);
        for (int x = nloop * 16; x < bw; x++, ppbuf++) {
            *ppbuf = ~(*ppbuf);
        }
    }
}

IP_API void InverseImageVec(BYTE *buf, int bw, int bh, int stride) {
    I8vec16 vfull(255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255);
    int nloop = bw / 16;
    for (int y = 0; y < bh; y++) {
       // SIMD처리
        __m128i *mpbuf = (__m128i *)(buf + stride * y);
        for (int n = 0; n < nloop; n++, mpbuf++) {
            I8vec16 vbuf = _mm_loadu_si128(mpbuf);
            vbuf ^= vfull;
            _mm_storeu_si128(mpbuf, vbuf);
        }

        // C처리
        BYTE *pp = (buf + stride * y + nloop * 16);
        for (int x = nloop * 16; x < bw; x++, pp++) {
            *pp = ~(*pp);
        }
    }
}

IP_API void InverseImageAvx(BYTE *buf, int bw, int bh, int stride) {
    __m256i mfull = _mm256_set1_epi8((char)255);
    int nloop = bw / 32;
    for (int y = 0; y < bh; y++) {
        // SIMD처리
        __m256i *mpbuf = (__m256i *)(buf + stride * y);
        for (int n = 0; n < nloop; n++, mpbuf++) {
            __m256i mbuf = _mm256_loadu_si256(mpbuf);
            mbuf = _mm256_xor_si256(mbuf, mfull);
            _mm256_storeu_si256(mpbuf, mbuf);
        }

        // C처리
        BYTE *ppbuf = (buf + stride * y + nloop * 32);
        for (int x = nloop * 32; x < bw; x++, ppbuf++) {
            *ppbuf = ~(*ppbuf);
        }
    }
}

IP_API void BlobC(BYTE *psrc, BYTE *pdst, int bw, int bh, int stride) {
}


BYTE GetPixelEdgeReplicate(BYTE* ptr, int bw, int bh, int step, int x, int y) {
    if (x < 0) x = 0;
    else if (x > bw - 1) x = bw - 1;

    if (y < 0) y = 0;
    else if (y > bh - 1) y = bh - 1;

    return *(ptr + step * y + x);
}

void ErodeEdge(BYTE* srcPtr, BYTE* dstPtr, int bw, int bh, int step, int x, int y) {
    BYTE s0 = GetPixelEdgeReplicate(srcPtr, bw, bh, step, x - 1, y - 1);
    BYTE s1 = GetPixelEdgeReplicate(srcPtr, bw, bh, step, x, y - 1);
    BYTE s2 = GetPixelEdgeReplicate(srcPtr, bw, bh, step, x + 1, y - 1);
    BYTE s3 = GetPixelEdgeReplicate(srcPtr, bw, bh, step, x - 1, y);
    BYTE s4 = GetPixelEdgeReplicate(srcPtr, bw, bh, step, x, y);
    BYTE s5 = GetPixelEdgeReplicate(srcPtr, bw, bh, step, x + 1, y);
    BYTE s6 = GetPixelEdgeReplicate(srcPtr, bw, bh, step, x - 1, y + 1);
    BYTE s7 = GetPixelEdgeReplicate(srcPtr, bw, bh, step, x, y + 1);
    BYTE s8 = GetPixelEdgeReplicate(srcPtr, bw, bh, step, x + 1, y + 1);

    BYTE min = s0;
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

IP_API void Erode(BYTE* srcPtr, BYTE* dstPtr, int bw, int bh, int step) {
    int x1 = 1, x2 = bw - 2;
    int y1 = 1, y2 = bh - 2;
    for (int y = y1; y <= y2; y++) {
        BYTE* psrc = &srcPtr[y * step + x1];
        BYTE* pdst = &dstPtr[y * step + x1];
        BYTE* s0 = (psrc - step - 1);
        BYTE* s1 = (psrc - step);
        BYTE* s2 = (psrc - step + 1);
        BYTE* s3 = (psrc - 1);
        BYTE* s5 = (psrc + 1);
        BYTE* s6 = (psrc + step - 1);
        BYTE* s7 = (psrc + step);
        BYTE* s8 = (psrc + step + 1);
        for (int x = x1; x <= x2; x++, psrc++, pdst++, s0++, s1++, s2++, s3++, s5++, s6++, s7++, s8++) {
            BYTE min = *s0;
            if (*s1 < min) min = *s1;
            if (*s2 < min) min = *s2;
            if (*s3 < min) min = *s3;
            if (*psrc < min) min = *psrc;
            if (*s5 < min) min = *s5;
            if (*s6 < min) min = *s6;
            if (*s7 < min) min = *s7;
            if (*s8 < min) min = *s8;

            *(pdst) = min;
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

IP_API void ErodeMmx(BYTE* srcPtr, BYTE* dstPtr, int bw, int bh, int step) {
    int x1 = 1, x2 = bw - 2;
    int y1 = 1, y2 = bh - 2;
    
    int len = x2 - x1 + 1;
    int nloop = len / 16;
    DWORD d0[4] = { 0, 0, 0, 0 };
    __m128i m0 = _mm_loadu_si128((__m128i*)d0);
    for (int y = y1; y <= y2; y++) {
        // 자투리 처리
        int   xx2 = x1 + nloop * 16;
        BYTE* psrc = &srcPtr[y * step + xx2];
        BYTE* pdst = &dstPtr[y * step + xx2];
        BYTE* s0 = (psrc - step - 1);
        BYTE* s1 = (psrc - step);
        BYTE* s2 = (psrc - step + 1);
        BYTE* s3 = (psrc - 1);
        BYTE* s5 = (psrc + 1);
        BYTE* s6 = (psrc + step - 1);
        BYTE* s7 = (psrc + step);
        BYTE* s8 = (psrc + step + 1);
        for (int x = xx2; x <= x2; x++, psrc++, pdst++, s0++, s1++, s2++, s3++, s5++, s6++, s7++, s8++) {
            BYTE min = *s0;
            if (*s1 < min) min = *s1;
            if (*s2 < min) min = *s2;
            if (*s3 < min) min = *s3;
            if (*psrc < min) min = *psrc;
            if (*s5 < min) min = *s5;
            if (*s6 < min) min = *s6;
            if (*s7 < min) min = *s7;
            if (*s8 < min) min = *s8;

            *(pdst) = min;
        }

        // MMX 시작
        psrc = &srcPtr[y*bw + x1];
        pdst = &dstPtr[y*bw + x1];
        __m128i *mpsrc = (__m128i*)psrc;
        __m128i *mpdst = (__m128i*)pdst;
        __m128i *mp1 = (__m128i*)(psrc - bw - 1), *mp2 = (__m128i*)(psrc - bw), *mp3 = (__m128i*)(psrc - bw + 1);
        __m128i *mp4 = (__m128i*)(psrc - 1), *mp6 = (__m128i*)(psrc + 1);
        __m128i *mp7 = (__m128i*)(psrc + bw - 1), *mp8 = (__m128i*)(psrc + bw), *mp9 = (__m128i*)(psrc + bw + 1);
        for (int x = 0; x < nloop; x++) {
            __m128i m1 = _mm_loadu_si128(mp1);
            __m128i m2 = _mm_loadu_si128(mp2);
            __m128i m3 = _mm_loadu_si128(mp3);
            __m128i m4 = _mm_loadu_si128(mp4);
            __m128i m5 = _mm_loadu_si128(mpsrc);
            __m128i m6 = _mm_loadu_si128(mp6);
            __m128i m7 = _mm_loadu_si128(mp7);
            __m128i m8 = _mm_loadu_si128(mp8);
            __m128i m9 = _mm_loadu_si128(mp9);
            __m128i mind = m1;
            mind = _mm_min_epu8(mind, m2);
            mind = _mm_min_epu8(mind, m3);
            mind = _mm_min_epu8(mind, m4);
            mind = _mm_min_epu8(mind, m5);
            mind = _mm_min_epu8(mind, m6);
            mind = _mm_min_epu8(mind, m7);
            mind = _mm_min_epu8(mind, m8);
            mind = _mm_min_epu8(mind, m9);
            _mm_storeu_si128(mpdst, mind);
            mpdst++, mpsrc++;
            mp1++, mp2++, mp3++, mp4++, mp6++, mp7++, mp8++, mp9++;
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