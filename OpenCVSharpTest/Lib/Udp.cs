using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ShimLib {
   public class Udp {
      private UdpClient client;
      private int localPort;
      private string hostIp;
      private int hostPort;
      private bool connected = false;

      // 수신 이벤트
      public event Action<object, byte[]> Recv = null;

      // 수신 예외 이벤트
      public event Action<object, Exception> RecvException = null;

      // 연결상태
      public bool Connected { get { return this.connected; } }

      // 연결
      public void Connect(int localPort, string hostIp, int hostPort) {
         this.localPort = localPort;
         this.hostIp = hostIp;
         this.hostPort = hostPort;

         this.client = new UdpClient(this.localPort);
         this.client.Connect(this.hostIp, this.hostPort);
         this.thread = new Thread(this.ThreadFunc);
         this.thread.Start();
         this.connected = true;
      }

      // 연결 끊기
      public void Close() {
         this.client.Close();
         this.stopRequest = true;
         this.thread.Join();
         this.connected = false;
      }

      // 송신
      public void Send(byte[] buff) {
         this.client.Send(buff, buff.Length);
      }

      private Thread thread = null;
      private bool stopRequest = false;
      private void ThreadFunc() {
         this.stopRequest = false;
         while (!this.stopRequest) {
            IPEndPoint remoteEp = new IPEndPoint(IPAddress.Any, 0);
            try {
               byte[] buff = this.client.Receive(ref remoteEp);
               if (remoteEp.Address.ToString() != this.hostIp || remoteEp.Port != this.hostPort)
                  continue;
               if (this.Recv != null)
                  Recv(this, buff);
            } catch (Exception ex) {
               if (this.RecvException != null)
                  this.RecvException(this, ex);
            }
         }
      }
   }
}
