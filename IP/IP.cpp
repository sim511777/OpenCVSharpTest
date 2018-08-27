// IP.cpp: DLL 응용 프로그램을 위해 내보낸 함수를 정의합니다.
//

#include "stdafx.h"
#include "IP.h"
#include <emmIntrin.h>

IP_API void InverseImage(BYTE *buf, int bw, int bh, int stride) {
   for (int y = 0; y < bh; y++) {
      BYTE* pp = buf + stride * y;
      for (int x = 0; x < bw; x++, pp++) {
         *pp = ~(*pp);
      }
   }
}

/*
__m128i _mm_add_epi8  (__m128i a , __m128i b);   // add 16 8bit  unsigned int
__m128i _mm_add_epi16 (__m128i a , __m128i b);   // add 8  16bit unsigned int
__m128i _mm_add_epi32 (__m128i a , __m128i b);   // add 4  32bit unsigned int
__m128i _mm_add_epi64 (__m128i a , __m128i b);   // add 2  64bit unsigned int

__m128  _mm_add_ps    (__m128 a , __m128 b);     // add 4  32bit float
__m128  _mm_add_pd    (__m128 a , __m128 b);     // add 2  64bit double

__m64   _mm_add_pi8   (__m64 m1 , __m64 m2);     // add 8  8bit  singned/unsigned int
__m64   _mm_add_pi8   (__m64 m1 , __m64 m2);     // add 4  16bit singned/unsigned int
__m64   _mm_add_pi8   (__m64 m1 , __m64 m2);     // add 2  32bit singned/unsigned int
*/
IP_API void MmxInverseImage(BYTE *buf, int bw, int bh, int stride) {
   int nloop = bw / 16;
   for (int y = 0; y < bh; y++) {
      BYTE* pp = buf + stride * y;
      __m128i mfull = _mm_set1_epi8(0x4a);
      for (int n = 0; n < nloop; n++, pp+=16) {
         __m128i mbuf = _mm_loadu_si128((const __m128i *)pp);
         mbuf = _mm_add_epi8(mbuf, mfull);
         _mm_storeu_si128((__m128i *)pp, mbuf);
      }
   }
}
