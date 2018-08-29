namespace ShimLib {
   partial class FormLog {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing) {
         if (disposing && (components != null)) {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent() {
         this.btnClear = new System.Windows.Forms.Button();
         this.panel2 = new System.Windows.Forms.Panel();
         this.chkAutoScroll = new System.Windows.Forms.CheckBox();
         this.btnClose = new System.Windows.Forms.Button();
         this.tabLog = new System.Windows.Forms.TabControl();
         this.panel2.SuspendLayout();
         this.SuspendLayout();
         // 
         // btnClear
         // 
         this.btnClear.Location = new System.Drawing.Point(7, 6);
         this.btnClear.Name = "btnClear";
         this.btnClear.Size = new System.Drawing.Size(108, 23);
         this.btnClear.TabIndex = 0;
         this.btnClear.Text = "Clear";
         this.btnClear.UseVisualStyleBackColor = true;
         this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
         // 
         // panel2
         // 
         this.panel2.Controls.Add(this.chkAutoScroll);
         this.panel2.Controls.Add(this.btnClear);
         this.panel2.Controls.Add(this.btnClose);
         this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.panel2.Location = new System.Drawing.Point(0, 436);
         this.panel2.Name = "panel2";
         this.panel2.Size = new System.Drawing.Size(671, 40);
         this.panel2.TabIndex = 0;
         this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
         // 
         // chkAutoScroll
         // 
         this.chkAutoScroll.AutoSize = true;
         this.chkAutoScroll.Checked = true;
         this.chkAutoScroll.CheckState = System.Windows.Forms.CheckState.Checked;
         this.chkAutoScroll.Location = new System.Drawing.Point(121, 13);
         this.chkAutoScroll.Name = "chkAutoScroll";
         this.chkAutoScroll.Size = new System.Drawing.Size(85, 16);
         this.chkAutoScroll.TabIndex = 1;
         this.chkAutoScroll.Text = "Auto Scroll";
         this.chkAutoScroll.UseVisualStyleBackColor = true;
         this.chkAutoScroll.CheckedChanged += new System.EventHandler(this.chkAutoScroll_CheckedChanged);
         // 
         // btnClose
         // 
         this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.btnClose.Location = new System.Drawing.Point(584, 6);
         this.btnClose.Name = "btnClose";
         this.btnClose.Size = new System.Drawing.Size(75, 23);
         this.btnClose.TabIndex = 0;
         this.btnClose.Text = "Close";
         this.btnClose.UseVisualStyleBackColor = true;
         this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
         // 
         // tabLog
         // 
         this.tabLog.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tabLog.ItemSize = new System.Drawing.Size(120, 18);
         this.tabLog.Location = new System.Drawing.Point(0, 0);
         this.tabLog.Multiline = true;
         this.tabLog.Name = "tabLog";
         this.tabLog.SelectedIndex = 0;
         this.tabLog.Size = new System.Drawing.Size(671, 436);
         this.tabLog.TabIndex = 1;
         this.tabLog.SelectedIndexChanged += new System.EventHandler(this.tabLog_SelectedIndexChanged);
         // 
         // FormLog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(671, 476);
         this.Controls.Add(this.tabLog);
         this.Controls.Add(this.panel2);
         this.Name = "FormLog";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Log";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormLog_FormClosing);
         this.panel2.ResumeLayout(false);
         this.panel2.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Panel panel2;
      private System.Windows.Forms.Button btnClose;
      private System.Windows.Forms.TabControl tabLog;
      private System.Windows.Forms.Button btnClear;
      private System.Windows.Forms.CheckBox chkAutoScroll;
   }
}