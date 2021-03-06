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

IP_API void InverseC(BYTE *buf, int bw, int bh, int stride);
IP_API void InverseSse(BYTE *buf, int bw, int bh, int stride, BOOL useParallel);
IP_API void InverseVec(BYTE *buf, int bw, int bh, int stride);
IP_API void InverseAvx(BYTE *buf, int bw, int bh, int stride);

IP_API void ErodeC(BYTE* srcPtr, BYTE* dstPtr, int bw, int bh, int step, bool useSse, bool useParallel);
IP_API void ErodeIpp(BYTE* srcPtr, BYTE* dstPtr, int bw, int bh, int step);
IP_API void DummyFunction(BYTE* srcPtr, BYTE* dstPtr, int bw, int bh, int step, int sleepMs);
IP_API void ErodeIppRoi(BYTE* srcPtr, BYTE* dstPtr, int bw, int bh, int step, int roiX, int roiY, int roiW, int roiH);
IP_API const void GetString(wchar_t* sb);
IP_API const void SetString(wchar_t* str);
IP_API void Devernay(double ** x, double ** y, int * N, int ** curve_limits, int * M,
    double * image, int X, int Y,
    double sigma, double th_h, double th_l);
IP_API void FreeBuffer(void* buffer);
IP_API int LabelMarker(BYTE* srcPtr, int* dstPtr, int bw, int bh);
IP_API void InverseIppRoi(BYTE* src, BYTE* dst, int bw, int bh, int roiX, int roiY, int roiW, int roiH);