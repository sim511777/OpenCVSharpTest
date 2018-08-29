namespace ShimLib {
   partial class FormProfileEditor {
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
         System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
         System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
         System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint12 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
         System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint13 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
         System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint14 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
         System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint15 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
         System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint16 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
         System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint17 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
         System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint18 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
         System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint19 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
         System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint20 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
         System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint21 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
         System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint22 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
         System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
         this.chtProfile = new System.Windows.Forms.DataVisualization.Charting.Chart();
         this.menuProfile = new System.Windows.Forms.ContextMenuStrip(this.components);
         this.addPointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.add10PointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.deletePointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.deleteAllPointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.resetAllValueZeroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.panel1 = new System.Windows.Forms.Panel();
         this.btnCancel = new System.Windows.Forms.Button();
         this.btnOk = new System.Windows.Forms.Button();
         ((System.ComponentModel.ISupportInitialize)(this.chtProfile)).BeginInit();
         this.menuProfile.SuspendLayout();
         this.panel1.SuspendLayout();
         this.SuspendLayout();
         // 
         // chtProfile
         // 
         this.chtProfile.BorderlineColor = System.Drawing.Color.Black;
         this.chtProfile.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
         chartArea2.AxisX.Interval = 1D;
         chartArea2.AxisX.IsLabelAutoFit = false;
         chartArea2.AxisX.IsMarginVisible = false;
         chartArea2.AxisX.LabelStyle.IsEndLabelVisible = false;
         chartArea2.AxisX.MajorGrid.Enabled = false;
         chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
         chartArea2.AxisY.Interval = 10D;
         chartArea2.AxisY.IsLabelAutoFit = false;
         chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
         chartArea2.AxisY.Maximum = 100D;
         chartArea2.AxisY.Minimum = 0D;
         chartArea2.AxisY.Title = "Laser Power (%)";
         chartArea2.BorderWidth = 10;
         chartArea2.Name = "ChartArea1";
         this.chtProfile.ChartAreas.Add(chartArea2);
         this.chtProfile.Dock = System.Windows.Forms.DockStyle.Fill;
         this.chtProfile.Location = new System.Drawing.Point(0, 0);
         this.chtProfile.Name = "chtProfile";
         series2.BorderWidth = 2;
         series2.ChartArea = "ChartArea1";
         series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
         series2.IsValueShownAsLabel = true;
         series2.LabelFormat = "0.";
         series2.MarkerBorderWidth = 0;
         series2.MarkerColor = System.Drawing.Color.Red;
         series2.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
         series2.Name = "Series1";
         series2.Points.Add(dataPoint12);
         series2.Points.Add(dataPoint13);
         series2.Points.Add(dataPoint14);
         series2.Points.Add(dataPoint15);
         series2.Points.Add(dataPoint16);
         series2.Points.Add(dataPoint17);
         series2.Points.Add(dataPoint18);
         series2.Points.Add(dataPoint19);
         series2.Points.Add(dataPoint20);
         series2.Points.Add(dataPoint21);
         series2.Points.Add(dataPoint22);
         this.chtProfile.Series.Add(series2);
         this.chtProfile.Size = new System.Drawing.Size(820, 644);
         this.chtProfile.TabIndex = 10;
         this.chtProfile.Text = "chart1";
         title2.Name = "Title1";
         title2.Text = "Point Profile";
         this.chtProfile.Titles.Add(title2);
         this.chtProfile.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chtProfile_KeyDown);
         this.chtProfile.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chtProfile_MouseClick);
         this.chtProfile.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chtProfile_MouseDown);
         this.chtProfile.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chtProfile_MouseMove);
         this.chtProfile.MouseUp += new System.Windows.Forms.MouseEventHandler(this.chtProfile_MouseUp);
         this.chtProfile.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.chtProfile_PreviewKeyDown);
         // 
         // menuProfile
         // 
         this.menuProfile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addPointToolStripMenuItem,
            this.add10PointToolStripMenuItem,
            this.deletePointToolStripMenuItem,
            this.deleteAllPointToolStripMenuItem,
            this.resetAllValueZeroToolStripMenuItem});
         this.menuProfile.Name = "menuProfile";
         this.menuProfile.Size = new System.Drawing.Size(183, 114);
         // 
         // addPointToolStripMenuItem
         // 
         this.addPointToolStripMenuItem.Name = "addPointToolStripMenuItem";
         this.addPointToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
         this.addPointToolStripMenuItem.Text = "Add Point";
         this.addPointToolStripMenuItem.Click += new System.EventHandler(this.addPointToolStripMenuItem_Click);
         // 
         // add10PointToolStripMenuItem
         // 
         this.add10PointToolStripMenuItem.Name = "add10PointToolStripMenuItem";
         this.add10PointToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
         this.add10PointToolStripMenuItem.Text = "Add 10 Point";
         this.add10PointToolStripMenuItem.Click += new System.EventHandler(this.add10PointToolStripMenuItem_Click);
         // 
         // deletePointToolStripMenuItem
         // 
         this.deletePointToolStripMenuItem.Name = "deletePointToolStripMenuItem";
         this.deletePointToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
         this.deletePointToolStripMenuItem.Text = "Delete Point";
         this.deletePointToolStripMenuItem.Click += new System.EventHandler(this.deletePointToolStripMenuItem_Click);
         // 
         // deleteAllPointToolStripMenuItem
         // 
         this.deleteAllPointToolStripMenuItem.Name = "deleteAllPointToolStripMenuItem";
         this.deleteAllPointToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
         this.deleteAllPointToolStripMenuItem.Text = "Delete All Point";
         this.deleteAllPointToolStripMenuItem.Click += new System.EventHandler(this.deleteAllPointToolStripMenuItem_Click);
         // 
         // resetAllValueZeroToolStripMenuItem
         // 
         this.resetAllValueZeroToolStripMenuItem.Name = "resetAllValueZeroToolStripMenuItem";
         this.resetAllValueZeroToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
         this.resetAllValueZeroToolStripMenuItem.Text = "Reset All Value Zero";
         this.resetAllValueZeroToolStripMenuItem.Click += new System.EventHandler(this.resetAllValueZeroToolStripMenuItem_Click);
         // 
         // panel1
         // 
         this.panel1.Controls.Add(this.btnCancel);
         this.panel1.Controls.Add(this.btnOk);
         this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.panel1.Location = new System.Drawing.Point(0, 644);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(820, 36);
         this.panel1.TabIndex = 11;
         // 
         // btnCancel
         // 
         this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnCancel.Location = new System.Drawing.Point(733, 7);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(75, 23);
         this.btnCancel.TabIndex = 1;
         this.btnCancel.Text = "Cancel";
         this.btnCancel.UseVisualStyleBackColor = true;
         // 
         // btnOk
         // 
         this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.btnOk.Location = new System.Drawing.Point(652, 7);
         this.btnOk.Name = "btnOk";
         this.btnOk.Size = new System.Drawing.Size(75, 23);
         this.btnOk.TabIndex = 0;
         this.btnOk.Text = "OK";
         this.btnOk.UseVisualStyleBackColor = true;
         // 
         // FormProfileEditor
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(820, 680);
         this.Controls.Add(this.chtProfile);
         this.Controls.Add(this.panel1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
         this.Name = "FormProfileEditor";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Profile Editor";
         ((System.ComponentModel.ISupportInitialize)(this.chtProfile)).EndInit();
         this.menuProfile.ResumeLayout(false);
         this.panel1.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.DataVisualization.Charting.Chart chtProfile;
      private System.Windows.Forms.ContextMenuStrip menuProfile;
      private System.Windows.Forms.ToolStripMenuItem addPointToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem add10PointToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem deletePointToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem deleteAllPointToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem resetAllValueZeroToolStripMenuItem;
      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.Button btnCancel;
      private System.Windows.Forms.Button btnOk;
   }
}