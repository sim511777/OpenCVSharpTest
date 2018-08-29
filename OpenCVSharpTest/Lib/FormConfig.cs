using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace ShimLib {
   public partial class FormConfig : Form {
      private object srcConfig = null;
      private Action applyAction = null;

      // 비공개 생성자 (컨픽 오리지널, 적용 동작)
      private FormConfig(string title, object config, Action applyAction) {
         InitializeComponent();

         this.Text = title;
         this.applyAction = applyAction;                             // 적용동작
         this.btnApply.Visible = (applyAction != null);              // null이면 적용버튼 비활성화

         this.srcConfig = config;                                    // 원본 참조 보관
         object temp = Activator.CreateInstance(config.GetType());   // 임시객체 생성
         FormConfig.CopyProperties(config, temp);                    // 속성카피
         this.gridConfig.SelectedObject = temp;                      // 프로퍼티그리드에 달아줌
      }

      // 설정 함수
      public static DialogResult DoConfig(string title, IWin32Window owner, object config, Action applyAction) {
         return new FormConfig(title, config, applyAction).ShowDialog(owner);
      }

      private void btnApply_Click(object sender, EventArgs e) {
         FormConfig.CopyProperties(this.gridConfig.SelectedObject, this.srcConfig);
         if (applyAction != null)
            this.applyAction();
      }

      private void FormConfig_FormClosing(object sender, FormClosingEventArgs e) {
         if (this.DialogResult != DialogResult.OK)
            return;

         FormConfig.CopyProperties(this.gridConfig.SelectedObject, this.srcConfig);
         if (applyAction != null)
            this.applyAction();
      }

      // 멤버 프로퍼티 복사
      private static void CopyProperties(object src, object dest) {
         Type type = src.GetType();
         var props = type.GetProperties();
         foreach (var prop in props) {
            try {
               prop.SetValue(dest, prop.GetValue(src, null), null);
            } catch { }
         }
      }

      private void FormConfig_Load(object sender, EventArgs e) {
         //this.gridConfig.SetLabelColumnWidth(200);
      }

      private void 모두펼치기ToolStripMenuItem_Click(object sender, EventArgs e) {
         this.gridConfig.ExpandAllGridItems();
      }

      private void 모두접기ToolStripMenuItem_Click(object sender, EventArgs e) {
         this.gridConfig.CollapseAllGridItems();
      }
   }
}
