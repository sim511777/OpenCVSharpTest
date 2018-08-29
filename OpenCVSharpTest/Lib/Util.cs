using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Reflection;
using System.Drawing;
using System.Dynamic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.InteropServices;

namespace ShimLib {
   public class Util {
      // 디렉토리 클린업
      public static void CleanUpDirectory(string dir, bool dirAlso = false) {
         if (Directory.Exists(dir) == false)
            return;
         DirectoryInfo dirInfo = new DirectoryInfo(dir);
         FileInfo[] fileInfos = dirInfo.GetFiles("*", SearchOption.AllDirectories);
         Array.ForEach(fileInfos, file => file.Delete());
         if (dirAlso)
            dirInfo.Delete();
      }

      // 타입이 Array<>타입인지 조사
      public static bool IsListType(Type type) {
         if (type.IsArray == false)
            return false;
         return true;
      }

      // hypot : prevent double buffer overflow of sqrt(x^2, y^2);
      public static double Hypot(double x, double y) {
         if (x == 0.0 && y == 0.0)
            return 0.0;

         double t;
         x = Math.Abs(x);
         y = Math.Abs(y);
         t = Math.Min(x, y);
         x = Math.Max(x, y);
         t = t / x;
         return x * Math.Sqrt(1 + t * t);
      }      
      public static float Hypot(float x, float y) {
         if (x == 0.0f && y == 0.0f)
            return 0.0f;

         float t;
         x = Math.Abs(x);
         y = Math.Abs(y);
         t = Math.Min(x, y);
         x = Math.Max(x, y);
         t = t / x;
         return x * (float)Math.Sqrt(1 + t * t);
      }
      // 빈파일 생성
      public static void CreateEmptyFile(string filePath) {
         string dir = Path.GetDirectoryName(filePath);
         Directory.CreateDirectory(dir);
         File.Create(filePath).Close();
      }

      // 이미 실행중?
      public static bool IsFirstRun() {
         bool createNew;
         var mutex = new Mutex(true, Application.ProductName, out createNew);
         GC.KeepAlive(mutex); // 프로그램 실행중 계속 살아있게 하기 위해서
         return createNew;
      }

      // 노포커스 휠 윈도우 10에서는 필요없음. 자동으로 됨
      public static void EnableNoFocusWheel() {
         MessageFilter mf = new MessageFilter();
         Application.AddMessageFilter(mf);
         GC.KeepAlive(mf); // 프로그램 실행중 계속 살아있게 하기 위해서
      }

      //Convert object to byte array
      public static byte[] ObjectToByteArray(object obj) {
         BinaryFormatter bf = new BinaryFormatter();     // 포메터 준비
         MemoryStream ms = new MemoryStream();           // 쓸 메모리 스트림 생성
         bf.Serialize(ms, obj);                          // 포메터로 오브젝트를 스트림에 시리얼라이즈 
         return ms.ToArray();
      }

      //Convert byte array to object
      public static object ByteArrayToObject(byte[] arr) {
         BinaryFormatter bf = new BinaryFormatter();     // 포메터 준비
         MemoryStream memStream = new MemoryStream(arr); // 메모리로부터 스트림생성
         return bf.Deserialize(memStream);               // 포메터로 스트림에서 오브젝트로 디시리얼라이즈
      }

      // GC 방지
      public static T GcLock<T>(T obj)  {
         GCHandle.Alloc(obj);
         return obj;
      }

      // bit 조회
      public static bool BitGet(int data, int bit) {
         return (data & (1 << bit)) != 0;
      }

      // bit 셋
      public static int BitSet(int data, int bit, bool flag) {
         if (flag)
            return data | (1 << bit);
         else
            return data & ~(1 << bit);
      }
   }

   // 메시지 필터
   public class MessageFilter : IMessageFilter {
      private const int WM_MOUSEWHEEL = 0x020A;
      private const int WM_MOUSEHWHEEL = 0x020E;

      [DllImport("user32.dll")]
      static extern IntPtr WindowFromPoint(Point p);
      [DllImport("user32.dll", CharSet = CharSet.Auto)]
      static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

      public bool PreFilterMessage(ref Message m) {
         switch (m.Msg) {
            case WM_MOUSEWHEEL:
            case WM_MOUSEHWHEEL:
               IntPtr hControlUnderMouse = WindowFromPoint(new Point((int)m.LParam));
               if (hControlUnderMouse == m.HWnd) {
                  //Do nothing because it's already headed for the right control
                  return false;
               } else {
                  //Send the scroll message to the control under the mouse
                  uint u = Convert.ToUInt32(m.Msg);
                  SendMessage(hControlUnderMouse, u, m.WParam, m.LParam);
                  return true;
               }
            default:
               return false;
         }
      }
   }
}
