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


IP_API int IntRange(int val, int min, int max) {
    if (val < min)
        return min;
    if (val > max)
        return max;
    return val;
}

IP_API void ErodeEdge(BYTE* srcPtr, BYTE* dstPtr, int bw, int bh, int step, int x, int y) {
    BYTE s0 = *(srcPtr + step * IntRange(y - 1, 0, bh - 1) + IntRange(x - 1, 0, bw - 1));
    BYTE s1 = *(srcPtr + step * IntRange(y - 1, 0, bh - 1) + IntRange(x, 0, bw - 1));
    BYTE s2 = *(srcPtr + step * IntRange(y - 1, 0, bh - 1) + IntRange(x + 1, 0, bw - 1));
    BYTE s3 = *(srcPtr + step * IntRange(y, 0, bh - 1) + IntRange(x - 1, 0, bw - 1));
    BYTE s4 = *(srcPtr + step * IntRange(y, 0, bh - 1) + IntRange(x, 0, bw - 1));
    BYTE s5 = *(srcPtr + step * IntRange(y, 0, bh - 1) + IntRange(x + 1, 0, bw - 1));
    BYTE s6 = *(srcPtr + step * IntRange(y + 1, 0, bh - 1) + IntRange(x - 1, 0, bw - 1));
    BYTE s7 = *(srcPtr + step * IntRange(y + 1, 0, bh - 1) + IntRange(x, 0, bw - 1));
    BYTE s8 = *(srcPtr + step * IntRange(y + 1, 0, bh - 1) + IntRange(x + 1, 0, bw - 1));
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
    for (int y = 1; y < bh - 1; y++) {
        for (int x = 1; x < bw - 1; x++) {
            BYTE* sp = srcPtr + y * step + x;
            BYTE* dp = dstPtr + y * step + x;
            BYTE s0 = *(sp - step - 1);
            BYTE s1 = *(sp - step);
            BYTE s2 = *(sp - step + 1);
            BYTE s3 = *(sp - 1);
            BYTE s4 = *(sp);
            BYTE s5 = *(sp + 1);
            BYTE s6 = *(sp + step - 1);
            BYTE s7 = *(sp + step);
            BYTE s8 = *(sp + step + 1);
            BYTE min = s0;
            if (s1 < min) min = s1;
            if (s2 < min) min = s2;
            if (s3 < min) min = s3;
            if (s4 < min) min = s4;
            if (s5 < min) min = s5;
            if (s6 < min) min = s6;
            if (s7 < min) min = s7;
            if (s8 < min) min = s8;
            *dp = min;
        }
    }

    // edge pixel process
    for (int x = 0; x < bw; x++) {
        ErodeEdge(srcPtr, dstPtr, bw, bh, step, x, 0);
        ErodeEdge(srcPtr, dstPtr, bw, bh, step, x, bh - 1);
    }
    for (int y = 1; y < bh - 1; y++) {
        ErodeEdge(srcPtr, dstPtr, bw, bh, step, 0, y);
        ErodeEdge(srcPtr, dstPtr, bw, bh, step, bw - 1, y);
    }
}