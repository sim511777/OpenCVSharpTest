namespace ShimLib {
   partial class ProfileChart {
      /// <summary> 
      /// 필수 디자이너 변수입니다.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary> 
      /// 사용 중인 모든 리소스를 정리합니다.
      /// </summary>
      /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
      protected override void Dispose(bool disposing) {
         if (disposing && (components != null)) {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region 구성 요소 디자이너에서 생성한 코드

      /// <summary> 
      /// 디자이너 지원에 필요한 메서드입니다. 
      /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
      /// </summary>
      private void InitializeComponent() {
         this.components = new System.ComponentModel.Container();
         System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
         System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
         System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
         System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
         System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint3 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
         System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint4 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
         System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint5 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
         System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint6 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
         System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint7 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
         System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint8 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
         System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint9 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
         System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint10 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
         System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint11 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
         System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
         this.chtProfile = new System.Windows.Forms.DataVisualization.Charting.Chart();
         this.menuProfile = new System.Windows.Forms.ContextMenuStrip(this.components);
         this.addPointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.deletePointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.deleteAllPointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.resetAllValueZeroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.add10PointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         ((System.ComponentModel.ISupportInitialize)(this.chtProfile)).BeginInit();
         this.menuProfile.SuspendLayout();
         this.SuspendLayout();
         // 
         // chtProfile
         // 
         this.chtProfile.BorderlineColor = System.Drawing.Color.Black;
         this.chtProfile.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
         chartArea1.AxisX.Interval = 1D;
         chartArea1.AxisX.IsLabelAutoFit = false;
         chartArea1.AxisX.IsMarginVisible = false;
         chartArea1.AxisX.LabelStyle.IsEndLabelVisible = false;
         chartArea1.AxisX.MajorGrid.Enabled = false;
         chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
         chartArea1.AxisY.Interval = 10D;
         chartArea1.AxisY.IsLabelAutoFit = false;
         chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
         chartArea1.AxisY.Maximum = 100D;
         chartArea1.AxisY.Minimum = 0D;
         chartArea1.AxisY.Title = "Laser Power (%)";
         chartArea1.BorderWidth = 10;
         chartArea1.Name = "ChartArea1";
         this.chtProfile.ChartAreas.Add(chartArea1);
         this.chtProfile.Dock = System.Windows.Forms.DockStyle.Fill;
         this.chtProfile.Location = new System.Drawing.Point(0, 0);
         this.chtProfile.Name = "chtProfile";
         series1.BorderWidth = 2;
         series1.ChartArea = "ChartArea1";
         series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
         series1.IsValueShownAsLabel = true;
         series1.LabelFormat = "0.";
         series1.MarkerBorderWidth = 0;
         series1.MarkerColor = System.Drawing.Color.Red;
         series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
         series1.Name = "Series1";
         series1.Points.Add(dataPoint1);
         series1.Points.Add(dataPoint2);
         series1.Points.Add(dataPoint3);
         series1.Points.Add(dataPoint4);
         series1.Points.Add(dataPoint5);
         series1.Points.Add(dataPoint6);
         series1.Points.Add(dataPoint7);
         series1.Points.Add(dataPoint8);
         series1.Points.Add(dataPoint9);
         series1.Points.Add(dataPoint10);
         series1.Points.Add(dataPoint11);
         this.chtProfile.Series.Add(series1);
         this.chtProfile.Size = new System.Drawing.Size(586, 488);
         this.chtProfile.TabIndex = 9;
         this.chtProfile.Text = "chart1";
         title1.Name = "Title1";
         title1.Text = "Point Profile";
         this.chtProfile.Titles.Add(title1);
         this.chtProfile.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chtProfile_KeyDown);
         this.chtProfile.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chtProfile_MouseClick);
         this.chtProfile.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chtProfile_MouseDown);
         this.chtProfile.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chtProfile_MouseMove);
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
         // add10PointToolStripMenuItem
         // 
         this.add10PointToolStripMenuItem.Name = "add10PointToolStripMenuItem";
         this.add10PointToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
         this.add10PointToolStripMenuItem.Text = "Add 10 Point";
         this.add10PointToolStripMenuItem.Click += new System.EventHandler(this.add10PointToolStripMenuItem_Click);
         // 
         // ProfileEditor
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.chtProfile);
         this.Name = "ProfileEditor";
         this.Size = new System.Drawing.Size(586, 488);
         ((System.ComponentModel.ISupportInitialize)(this.chtProfile)).EndInit();
         this.menuProfile.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.DataVisualization.Charting.Chart chtProfile;
      private System.Windows.Forms.ContextMenuStrip menuProfile;
      private System.Windows.Forms.ToolStripMenuItem addPointToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem deletePointToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem deleteAllPointToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem add10PointToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem resetAllValueZeroToolStripMenuItem;

   }
}
