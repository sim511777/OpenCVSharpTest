namespace ShimLib {
   partial class FormBackgroundWorker {
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
         this.lblItemName = new System.Windows.Forms.Label();
         this.lblItemCounter = new System.Windows.Forms.Label();
         this.prbPercent = new System.Windows.Forms.ProgressBar();
         this.btnStop = new System.Windows.Forms.Button();
         this.lblPercent = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // lblItemName
         // 
         this.lblItemName.AutoSize = true;
         this.lblItemName.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
         this.lblItemName.Location = new System.Drawing.Point(14, 47);
         this.lblItemName.Name = "lblItemName";
         this.lblItemName.Size = new System.Drawing.Size(371, 13);
         this.lblItemName.TabIndex = 0;
         this.lblItemName.Text = "Def_DGE1L40BLU100621_217_20140805135420_7.jpg";
         // 
         // lblItemCounter
         // 
         this.lblItemCounter.AutoSize = true;
         this.lblItemCounter.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
         this.lblItemCounter.Location = new System.Drawing.Point(82, 19);
         this.lblItemCounter.Name = "lblItemCounter";
         this.lblItemCounter.Size = new System.Drawing.Size(58, 13);
         this.lblItemCounter.TabIndex = 0;
         this.lblItemCounter.Text = "(7/100)";
         // 
         // prbPercent
         // 
         this.prbPercent.Location = new System.Drawing.Point(14, 81);
         this.prbPercent.Name = "prbPercent";
         this.prbPercent.Size = new System.Drawing.Size(732, 54);
         this.prbPercent.TabIndex = 1;
         // 
         // btnStop
         // 
         this.btnStop.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
         this.btnStop.Location = new System.Drawing.Point(576, 151);
         this.btnStop.Name = "btnStop";
         this.btnStop.Size = new System.Drawing.Size(170, 49);
         this.btnStop.TabIndex = 2;
         this.btnStop.Text = "중지";
         this.btnStop.UseVisualStyleBackColor = true;
         this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
         // 
         // lblPercent
         // 
         this.lblPercent.AutoSize = true;
         this.lblPercent.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
         this.lblPercent.Location = new System.Drawing.Point(14, 19);
         this.lblPercent.Name = "lblPercent";
         this.lblPercent.Size = new System.Drawing.Size(49, 13);
         this.lblPercent.TabIndex = 0;
         this.lblPercent.Text = "12.1%";
         this.lblPercent.TextAlign = System.Drawing.ContentAlignment.TopRight;
         // 
         // FormBackgroundWorker
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(758, 215);
         this.ControlBox = false;
         this.Controls.Add(this.btnStop);
         this.Controls.Add(this.prbPercent);
         this.Controls.Add(this.lblPercent);
         this.Controls.Add(this.lblItemCounter);
         this.Controls.Add(this.lblItemName);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "FormBackgroundWorker";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "파일 다운로드 중...";
         this.Load += new System.EventHandler(this.FormBackgroundWorker_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label lblItemName;
      private System.Windows.Forms.Label lblItemCounter;
      private System.Windows.Forms.ProgressBar prbPercent;
      private System.Windows.Forms.Button btnStop;
      private System.Windows.Forms.Label lblPercent;
   }
}