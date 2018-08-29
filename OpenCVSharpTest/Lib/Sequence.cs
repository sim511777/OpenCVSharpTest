using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ShimLib {
   // 시퀀스 Abort 예외
   public class SequenceAbortException : Exception {
      public SequenceAbortException(string message) : base(message) {
      }
   }

   // 시퀀스 상태
   public enum SequenceState { Init, Idle, Executing, Pause, }

   // 시퀀스 결과
   public enum SequenceResult { Success, Fail, Abort, }

   class Sequence {
      // 쓰레드 시작
      public static void ThreadStart() {
         thread = new Thread(ThreadProc);
         thread.Priority = ThreadPriority.BelowNormal;
         thread.Start();
      }

      // 쓰레드 중지
      public static void ThreadStop() {
         Abort();                // 동작중인 시퀀스 취소
         threadReqStop = true;   // 메인 쓰레드 중단
         thread.Join();          // 메인 쓰레드 완료 대기
      }

      // 시퀀스 요청
      public static bool Request(Func<SequenceResult> seqProc, string seqName) {
         if (CurrentState != SequenceState.Idle)
            return false;
         SeqProc = seqProc;
         if (seqName == null)
            seqName = "Noname";
         return true;
      }

      // 시퀀스 취소 (Running,Pause -> loop break -> Idle)
      public static bool Abort() {
         if (CurrentState == SequenceState.Idle) {
            return false;
         }
         AbortRequest = true;
         return true;
      }

      // 시퀀스 일시중지 (Running -> Pause)
      public static bool Pause() {
         if (CurrentState != SequenceState.Executing) {
            return false;
         }
         CurrentState = SequenceState.Pause;
         return true;
      }

      // 시퀀스 계속 (Pause -> Running)
      public static bool Resume() {
         if (CurrentState != SequenceState.Pause) {
            return false;
         }
         CurrentState = SequenceState.Executing;
         return true;
      }

      // 현재 시퀀스 상태
      public static SequenceState CurrentState { get; private set; }

      // 마지막 시퀀스 결과
      public static SequenceResult LastResult { get; private set; }

      // 실행중인 프로시저 이름
      public static string SeqName { get; private set; }

      // 마지막 시퀀스 결과
      public static bool AbortRequest { get; private set; }

      private static Thread thread;       // 쓰레드
      private static bool threadReqStop;  // 쓰레드 중단 요청
      private static Func<SequenceResult> SeqProc = null;   // 요청 시퀀스 

      static Sequence() {
         Sequence.CurrentState = SequenceState.Idle;
         Sequence.LastResult = SequenceResult.Success;
         Sequence.SeqName = string.Empty;
         Sequence.AbortRequest = false;
      }

      // 쓰레도 프로시저
      private static void ThreadProc() {
         threadReqStop = false;
         while (!threadReqStop) {
            // 요청 시퀀스 없음
            if (SeqProc == null) {
               Thread.Sleep(100);
               continue;
            }

            // 상태 셋
            AbortRequest = false;
            CurrentState = SequenceState.Executing;

            // 요청 시퀀스 실행
            LastResult = SeqProc();

            // 요청 시퀀스 리셋
            SeqProc = null;
            SeqName = string.Empty;

            // 상태 리셋
            CurrentState = SequenceState.Idle;
         }
      }
   }
}
