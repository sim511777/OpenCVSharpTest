namespace ShimLib {
   partial class FormConfig {
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
         this.components = new System.ComponentModel.Container();
         this.btnSave = new System.Windows.Forms.Button();
         this.btnCancel = new System.Windows.Forms.Button();
         this.dlgFolder = new System.Windows.Forms.FolderBrowserDialog();
         this.dlgColor = new System.Windows.Forms.ColorDialog();
         this.gridConfig = new System.Windows.Forms.PropertyGrid();
         this.mnuPopup = new System.Windows.Forms.ContextMenuStrip(this.components);
         this.모두펼치기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.모두접기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.panel1 = new System.Windows.Forms.Panel();
         this.btnApply = new System.Windows.Forms.Button();
         this.mnuPopup.SuspendLayout();
         this.panel1.SuspendLayout();
         this.SuspendLayout();
         // 
         // btnSave
         // 
         this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.btnSave.Location = new System.Drawing.Point(434, 14);
         this.btnSave.Name = "btnSave";
         this.btnSave.Size = new System.Drawing.Size(75, 37);
         this.btnSave.TabIndex = 32;
         this.btnSave.Text = "Ok";
         this.btnSave.UseVisualStyleBackColor = true;
         // 
         // btnCancel
         // 
         this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnCancel.Location = new System.Drawing.Point(515, 14);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(75, 37);
         this.btnCancel.TabIndex = 33;
         this.btnCancel.Text = "Cancel";
         this.btnCancel.UseVisualStyleBackColor = true;
         // 
         // dlgColor
         // 
         this.dlgColor.FullOpen = true;
         // 
         // gridConfig
         // 
         this.gridConfig.ContextMenuStrip = this.mnuPopup;
         this.gridConfig.Dock = System.Windows.Forms.DockStyle.Fill;
         this.gridConfig.Location = new System.Drawing.Point(0, 0);
         this.gridConfig.Name = "gridConfig";
         this.gridConfig.PropertySort = System.Windows.Forms.PropertySort.Categorized;
         this.gridConfig.Size = new System.Drawing.Size(602, 767);
         this.gridConfig.TabIndex = 35;
         this.gridConfig.ToolbarVisible = false;
         // 
         // mnuPopup
         // 
         this.mnuPopup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.모두펼치기ToolStripMenuItem,
            this.모두접기ToolStripMenuItem});
         this.mnuPopup.Name = "mnuPopup";
         this.mnuPopup.Size = new System.Drawing.Size(139, 48);
         // 
         // 모두펼치기ToolStripMenuItem
         // 
         this.모두펼치기ToolStripMenuItem.Name = "모두펼치기ToolStripMenuItem";
         this.모두펼치기ToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
         this.모두펼치기ToolStripMenuItem.Text = "모두 펼치기";
         this.모두펼치기ToolStripMenuItem.Click += new System.EventHandler(this.모두펼치기ToolStripMenuItem_Click);
         // 
         // 모두접기ToolStripMenuItem
         // 
         this.모두접기ToolStripMenuItem.Name = "모두접기ToolStripMenuItem";
         this.모두접기ToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
         this.모두접기ToolStripMenuItem.Text = "모두 접기";
         this.모두접기ToolStripMenuItem.Click += new System.EventHandler(this.모두접기ToolStripMenuItem_Click);
         // 
         // panel1
         // 
         this.panel1.Controls.Add(this.btnApply);
         this.panel1.Controls.Add(this.btnSave);
         this.panel1.Controls.Add(this.btnCancel);
         this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.panel1.Location = new System.Drawing.Point(0, 767);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(602, 63);
         this.panel1.TabIndex = 36;
         // 
         // btnApply
         // 
         this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.btnApply.Location = new System.Drawing.Point(353, 14);
         this.btnApply.Name = "btnApply";
         this.btnApply.Size = new System.Drawing.Size(75, 37);
         this.btnApply.TabIndex = 32;
         this.btnApply.Text = "Apply";
         this.btnApply.UseVisualStyleBackColor = true;
         this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
         // 
         // FormConfig
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(602, 830);
         this.Controls.Add(this.gridConfig);
         this.Controls.Add(this.panel1);
         this.MinimizeBox = false;
         this.Name = "FormConfig";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Config";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormConfig_FormClosing);
         this.Load += new System.EventHandler(this.FormConfig_Load);
         this.mnuPopup.ResumeLayout(false);
         this.panel1.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button btnSave;
      private System.Windows.Forms.Button btnCancel;
      private System.Windows.Forms.FolderBrowserDialog dlgFolder;
      private System.Windows.Forms.ColorDialog dlgColor;
      private System.Windows.Forms.PropertyGrid gridConfig;
      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.Button btnApply;
      private System.Windows.Forms.ContextMenuStrip mnuPopup;
      private System.Windows.Forms.ToolStripMenuItem 모두펼치기ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem 모두접기ToolStripMenuItem;
   }
}