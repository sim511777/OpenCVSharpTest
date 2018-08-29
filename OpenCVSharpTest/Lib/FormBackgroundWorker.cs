using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace ShimLib {
   public partial class FormBackgroundWorker : Form {
      private string workName;
      private List<object> itemList;
      private Action<object> workAction;
      private Func<object, string> itemToTextFunc;
      private Action<Exception, object> exceptionAction;

      bool bStop = false;

      // 생성자
      private FormBackgroundWorker() {
         InitializeComponent();
      }

      public static DialogResult Work(string workName, List<object> itemList, IWin32Window ownerWindow, Action<object> workAction, Func<object, string> itemToTextFunc, Action<Exception, object> exceptionAction) {
         FormBackgroundWorker form = new FormBackgroundWorker();

         form.workName = workName;
         form.itemList = itemList;
         form.workAction = workAction;
         form.itemToTextFunc = itemToTextFunc;
         form.exceptionAction = exceptionAction;
         
         return form.ShowDialog(ownerWindow);
      }

      // 작업시작
      private void StartWork() {
         new Thread(this.DoWork).Start();
      }

      // 작업 쓰레드
      private void DoWork() {
         for (int i = 0; i < this.itemList.Count; i++ ) {
            if (bStop == true)
               break;
            object item = itemList[i];

            // 상태 표시
            this.Invoke((MethodInvoker)delegate() {
               this.lblItemCounter.Text = string.Format("({0}/{1})", i+1, this.itemList.Count);
               float percent = (float)(i+1) * 100 / this.itemList.Count;
               this.lblPercent.Text = string.Format("{0:0.00}%", percent);
               this.Text = string.Format("{0:0.00}% " + this.workName + " 중...", percent);
               int iPercent = (int)percent;
               if (iPercent < 0)
                  iPercent = 0;
               if (iPercent > 100)
                  iPercent = 100;
               if (iPercent < this.prbPercent.Maximum)
                  this.prbPercent.Value = iPercent+1;
               this.prbPercent.Value = iPercent;

               this.lblItemName.Text = item == null ? string.Empty : itemToTextFunc(item);
            });
               
            try {
               this.workAction(item);
            } catch (Exception ex) {
               if (exceptionAction != null)
                  this.exceptionAction(ex, item);
            }
         }
         
         this.Invoke((MethodInvoker)delegate() {
            if (this.bStop == true) {
               this.DialogResult = DialogResult.Cancel;
            } else {
               this.DialogResult = DialogResult.OK;
            }
            //this.Close();
         });
      }

      private void RequestStop() {
         //if (MessageBox.Show(this.workName + "을(를) 중단 하시겠습니까?", "작업 중지", MessageBoxButtons.YesNo) != DialogResult.Yes) {
         //   return;
         //}

         this.bStop = true;
      }


      // event handler
      private void FormBackgroundWorker_Load(object sender, EventArgs e) {
         this.StartWork();
      }

      private void btnStop_Click(object sender, EventArgs e) {
         this.RequestStop();
      }
   }
}
