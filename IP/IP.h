// 다음 ifdef 블록은 DLL에서 내보내기하는 작업을 쉽게 해 주는 매크로를 만드는 
// 표준 방식입니다. 이 DLL에 들어 있는 파일은 모두 명령줄에 정의된 IP_EXPORTS 기호로
// 컴파일되며, 이 DLL을 사용하는 모든 프로젝트에서는 이 기호를 정의할 수 없습니다.
// 이렇게 하면 소스 파일에 이 파일이 들어 있는 다른 모든 프로젝트에서는 
// IP_API 함수를 DLL에서 가져오는 것으로 보지만, 이 DLL은
// 이 매크로로 정의된 기호가 내보내지는 것으로 봅니다.
#ifdef IP_EXPORTS
#define IP_API extern "C" __declspec(dllexport)
#else
#define IP_API extern "C" __declspec(dllimport)
#endif

IP_API void InverseImageC(BYTE *buf, int bw, int bh, int stride);
IP_API void InverseImageSse(BYTE *buf, int bw, int bh, int stride);
IP_API void InverseImageVec(BYTE *buf, int bw, int bh, int stride);
IP_API void InverseImageAvx(BYTE *buf, int bw, int bh, int stride);
IP_API void Erode(BYTE* srcPtr, BYTE* dstPtr, int bw, int bh, int step);
IP_API void BlobC(BYTE *psrc, BYTE *pdst, int bw, int bh, int stride);
