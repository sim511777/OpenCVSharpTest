using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShimLib {
   public partial class FormLog : Form {
      // 생성자
      public FormLog() {
         InitializeComponent();
         this.CreateControl();    // Show하기 전엔 핸들이 만들어 지지 않으므로 Invoke 에러 발생함, 그래서 수동으로 만들어줌
      }

      // 리스트박스 추가
      public ListBox AddListBox(string logName) {
         var lbx = new ListBox();
         lbx.HorizontalScrollbar = true;
         lbx.Dock = DockStyle.Fill;
         lbx.Tag = new object();
         var page = new TabPage(logName);
         page.Controls.Add(lbx);
         this.tabLog.TabPages.Add(page); 
         bool handleCreated = (lbx.Handle != IntPtr.Zero);
         return lbx;
      }

      // 폼쑈~
      new public void Show(IWin32Window owner) {
         if (this.Visible == false) {
            base.Show(owner);
         } else {
            this.BringToFront();
         }
      }

      ///////////////////
      // event handler //
      ///////////////////
      private void btnClear_Click(object sender, EventArgs e) {
         TabPage page = this.tabLog.SelectedTab;
         if (page == null)
            return;
         foreach(var control in page.Controls) {
            var lbx = control as ListBox;
            if (lbx == null)
               continue;
            lbx.Items.Clear();
            break;
         }
      }

      private void FormLog_FormClosing(object sender, FormClosingEventArgs e) {
         // 사용자가 UI에서 Close할때는 창을 닫지 않고 Hide해줌
         if (e.CloseReason == CloseReason.UserClosing) {
            e.Cancel = true;
            this.Hide();
         }
      }

      private void btnClose_Click(object sender, EventArgs e) {
         this.Hide();
      }

      private void chkAutoScroll_CheckedChanged(object sender, EventArgs e) {
         bool useAutoScroll = this.chkAutoScroll.Checked;
         foreach (TabPage page in this.tabLog.TabPages) {
            if (page.Controls.Count == 0)
               continue;
            ListBox lbx = page.Controls[0] as ListBox;
            lbx.Tag = useAutoScroll ? new Object() : null;
         }
      }

      private void tabLog_SelectedIndexChanged(object sender, EventArgs e) {

      }

      private void panel2_Paint(object sender, PaintEventArgs e) {

      }
   }
}
