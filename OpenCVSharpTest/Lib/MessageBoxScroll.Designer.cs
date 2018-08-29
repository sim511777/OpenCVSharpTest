namespace ShimLib {
   partial class MessageBoxScroll {
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
         this.btnOk = new System.Windows.Forms.Button();
         this.tbxContents = new System.Windows.Forms.TextBox();
         this.panel1 = new System.Windows.Forms.Panel();
         this.panel1.SuspendLayout();
         this.SuspendLayout();
         // 
         // btnOk
         // 
         this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.btnOk.Location = new System.Drawing.Point(356, 15);
         this.btnOk.Name = "btnOk";
         this.btnOk.Size = new System.Drawing.Size(75, 23);
         this.btnOk.TabIndex = 0;
         this.btnOk.Text = "Ok";
         this.btnOk.UseVisualStyleBackColor = true;
         // 
         // tbxContents
         // 
         this.tbxContents.BackColor = System.Drawing.SystemColors.Window;
         this.tbxContents.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.tbxContents.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tbxContents.Location = new System.Drawing.Point(0, 0);
         this.tbxContents.Multiline = true;
         this.tbxContents.Name = "tbxContents";
         this.tbxContents.ReadOnly = true;
         this.tbxContents.ScrollBars = System.Windows.Forms.ScrollBars.Both;
         this.tbxContents.Size = new System.Drawing.Size(443, 372);
         this.tbxContents.TabIndex = 1;
         this.tbxContents.WordWrap = false;
         // 
         // panel1
         // 
         this.panel1.Controls.Add(this.btnOk);
         this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.panel1.Location = new System.Drawing.Point(0, 372);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(443, 50);
         this.panel1.TabIndex = 2;
         // 
         // MessageBoxScroll
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(443, 422);
         this.Controls.Add(this.tbxContents);
         this.Controls.Add(this.panel1);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "MessageBoxScroll";
         this.ShowIcon = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "MessageBoxScroll";
         this.panel1.ResumeLayout(false);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button btnOk;
      private System.Windows.Forms.TextBox tbxContents;
      private System.Windows.Forms.Panel panel1;
   }
}