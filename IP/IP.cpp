// IP.cpp: DLL 응용 프로그램을 위해 내보낸 함수를 정의합니다.
//

#include "stdafx.h"
#include "IP.h"


// 내보낸 변수의 예제입니다.
IP_API int nIP=0;

// 내보낸 함수의 예제입니다.
IP_API int fnIP(void)
{
    return 42;
}

// 내보낸 클래스의 생성자입니다.
// 클래스 정의를 보려면 IP.h를 참조하세요.
CIP::CIP()
{
    return;
}

IP_API void InverseImage(BYTE *buf, int bw, int bh, int stride) {
   for (int y = 0; y < bh; y++) {
      BYTE* pp = buf + stride * y;
      for (int x = 0; x < bw; x++, pp++) {
         *pp = ~(*pp);
      }
   }
}
