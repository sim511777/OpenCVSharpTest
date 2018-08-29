using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace ShimLib {
   // 로그를 사용하기 위한 클래스
   public class Logger {
      private string name;
      private string rootDir;
      private Control ctlDisp;
      private int maxLine;

      private Object locker = new object();
      private string currFilePath = null;
      private StreamWriter currStream = null;

      // 생성자
      public Logger(string name, string rootDir, ListBox listBox, int maxLine) {
         this.name = name;                      // name.txt로 저장됨
         this.rootDir = rootDir;                // null이면 파일 저장 안함
         this.ctlDisp = listBox;                // null이면 리스트박스 표시 안함
         this.maxLine = maxLine;                // listBox null이면 무시됨
      }
      public Logger(string name, string rootDir, TextBox textBox, int maxLine) {
         this.name = name;                      // name.txt로 저장됨
         this.rootDir = rootDir;                // null이면 파일 저장 안함
         this.ctlDisp = textBox;                // null이면 리스트박스 표시 안함
         this.maxLine = maxLine;                // listBox null이면 무시됨
      }
      // 로그 기록
      public void Log(string message) {
         DateTime now = DateTime.Now;
         string textLine = string.Format(@"[{0:00}.{1:00}-{2:00}:{3:00}:{4:00}.{5:000}] {6}", 
            now.Month, now.Day, now.Hour, now.Minute, now.Second, now.Millisecond, message);

         if (this.rootDir != null) {
            string filePath = string.Format(@"{0}\Year_{1:0000}\Mon_{2:00}\Day_{3:00}\{4}.txt",
               this.rootDir, now.Year, now.Month, now.Day, this.name);
            this.LogToFile(filePath, textLine);
         }

         if (this.ctlDisp is ListBox) {
            this.LogToListBox(textLine, this.ctlDisp as ListBox);
         } else if (this.ctlDisp is TextBox) {
            this.LogToTextBox(textLine, this.ctlDisp as TextBox);
         }
      }

      // 파일 기록
      private void LogToFile(string filePath, string textLine) {
         lock (locker) {
            if (filePath != this.currFilePath || this.currStream == null) {
               string logDir = Path.GetDirectoryName(filePath);
               if (Directory.Exists(logDir) == false) {
                  Directory.CreateDirectory(logDir);
               }
               if (this.currStream != null)
                  this.currStream.Dispose();
               this.currStream = File.AppendText(filePath); // create file
               this.currFilePath = filePath;
            }
            this.currStream.WriteLine(textLine);
            this.currStream.Flush();
         }
      }

      // 텍스트박스 표시
      private void LogToListBox(string textLine, ListBox lbx) {
         Action action = delegate () {
            if (lbx.Items.Count >= this.maxLine) {
               lbx.Items.Clear();
            }
            lbx.Items.Add(textLine);
            if (lbx.Tag != null) {
               lbx.TopIndex = lbx.Items.Count - 1;
            }
         };
         if (lbx.Created)
            lbx.BeginInvoke(action);
      }
      
      // 텍스트박스 표시
      private void LogToTextBox(string textLine, TextBox tbx) {
         Action action = delegate () {
            if (tbx.Lines.Length >= this.maxLine) {
               tbx.Clear();
            }
            string text = ((tbx.TextLength != 0) ? "\r\n" : string.Empty) + textLine;
            tbx.AppendText(text);
         };
         if (tbx.Created)
            tbx.BeginInvoke(action);
      }
   }
}