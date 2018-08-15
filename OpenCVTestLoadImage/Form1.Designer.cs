namespace OpenCVTestLoadImage {
   partial class Form1 {
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

      #region Windows Form 디자이너에서 생성한 코드

      /// <summary>
      /// 디자이너 지원에 필요한 메서드입니다. 
      /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
      /// </summary>
      private void InitializeComponent() {
         this.components = new System.ComponentModel.Container();
         System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
         System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
         System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
         System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
         System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
         System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
         System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
         System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
         System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
         System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
         System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
         System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
         this.panel1 = new System.Windows.Forms.Panel();
         this.btnLive = new System.Windows.Forms.Button();
         this.btnLoad = new System.Windows.Forms.Button();
         this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
         this.timer1 = new System.Windows.Forms.Timer(this.components);
         this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
         this.pbxDst = new System.Windows.Forms.PictureBox();
         this.pbxSrc = new System.Windows.Forms.PictureBox();
         this.chtSrc = new System.Windows.Forms.DataVisualization.Charting.Chart();
         this.btnClipboard = new System.Windows.Forms.Button();
         this.panel1.SuspendLayout();
         this.tableLayoutPanel1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pbxDst)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.pbxSrc)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.chtSrc)).BeginInit();
         this.SuspendLayout();
         // 
         // panel1
         // 
         this.panel1.Controls.Add(this.btnLive);
         this.panel1.Controls.Add(this.btnClipboard);
         this.panel1.Controls.Add(this.btnLoad);
         this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
         this.panel1.Location = new System.Drawing.Point(0, 0);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(145, 437);
         this.panel1.TabIndex = 1;
         // 
         // btnLive
         // 
         this.btnLive.Location = new System.Drawing.Point(12, 70);
         this.btnLive.Name = "btnLive";
         this.btnLive.Size = new System.Drawing.Size(75, 23);
         this.btnLive.TabIndex = 0;
         this.btnLive.Text = "Live";
         this.btnLive.UseVisualStyleBackColor = true;
         this.btnLive.Click += new System.EventHandler(this.btnLive_Click);
         // 
         // btnLoad
         // 
         this.btnLoad.Location = new System.Drawing.Point(12, 41);
         this.btnLoad.Name = "btnLoad";
         this.btnLoad.Size = new System.Drawing.Size(75, 23);
         this.btnLoad.TabIndex = 0;
         this.btnLoad.Text = "Load";
         this.btnLoad.UseVisualStyleBackColor = true;
         this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
         // 
         // dlgOpen
         // 
         this.dlgOpen.FileName = "openFileDialog1";
         // 
         // timer1
         // 
         this.timer1.Interval = 33;
         this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
         // 
         // tableLayoutPanel1
         // 
         this.tableLayoutPanel1.ColumnCount = 2;
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tableLayoutPanel1.Controls.Add(this.pbxDst, 1, 0);
         this.tableLayoutPanel1.Controls.Add(this.pbxSrc, 0, 0);
         this.tableLayoutPanel1.Controls.Add(this.chtSrc, 0, 1);
         this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tableLayoutPanel1.Location = new System.Drawing.Point(145, 0);
         this.tableLayoutPanel1.Name = "tableLayoutPanel1";
         this.tableLayoutPanel1.RowCount = 2;
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tableLayoutPanel1.Size = new System.Drawing.Size(620, 437);
         this.tableLayoutPanel1.TabIndex = 2;
         // 
         // pbxDst
         // 
         this.pbxDst.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pbxDst.Location = new System.Drawing.Point(313, 3);
         this.pbxDst.Name = "pbxDst";
         this.pbxDst.Size = new System.Drawing.Size(304, 212);
         this.pbxDst.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
         this.pbxDst.TabIndex = 1;
         this.pbxDst.TabStop = false;
         // 
         // pbxSrc
         // 
         this.pbxSrc.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pbxSrc.Location = new System.Drawing.Point(3, 3);
         this.pbxSrc.Name = "pbxSrc";
         this.pbxSrc.Size = new System.Drawing.Size(304, 212);
         this.pbxSrc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
         this.pbxSrc.TabIndex = 0;
         this.pbxSrc.TabStop = false;
         // 
         // chtSrc
         // 
         chartArea1.AxisX.LabelStyle.Interval = 20D;
         chartArea1.AxisX.LabelStyle.IntervalOffset = 1D;
         chartArea1.AxisX.MajorGrid.Enabled = false;
         chartArea1.AxisX.MajorTickMark.Interval = 20D;
         chartArea1.AxisX.MajorTickMark.IntervalOffset = 1D;
         chartArea1.AxisX2.LabelStyle.Enabled = false;
         chartArea1.AxisX2.MajorGrid.Enabled = false;
         chartArea1.AxisX2.MajorTickMark.Enabled = false;
         chartArea1.AxisY.LabelStyle.Enabled = false;
         chartArea1.AxisY.MajorGrid.Enabled = false;
         chartArea1.AxisY.MajorTickMark.Enabled = false;
         chartArea1.AxisY2.LabelStyle.Enabled = false;
         chartArea1.AxisY2.MajorGrid.Enabled = false;
         chartArea1.AxisY2.MajorTickMark.Enabled = false;
         chartArea1.Name = "ChartArea1";
         this.chtSrc.ChartAreas.Add(chartArea1);
         this.chtSrc.Dock = System.Windows.Forms.DockStyle.Fill;
         legend1.Name = "Legend1";
         this.chtSrc.Legends.Add(legend1);
         this.chtSrc.Location = new System.Drawing.Point(3, 221);
         this.chtSrc.Name = "chtSrc";
         series1.ChartArea = "ChartArea1";
         series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
         series1.Enabled = false;
         series1.Legend = "Legend1";
         series1.Name = "Series1";
         series2.ChartArea = "ChartArea1";
         series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
         series2.Enabled = false;
         series2.Legend = "Legend1";
         series2.Name = "Series2";
         series3.ChartArea = "ChartArea1";
         series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
         series3.Enabled = false;
         series3.Legend = "Legend1";
         series3.Name = "Series3";
         series4.ChartArea = "ChartArea1";
         series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
         series4.Enabled = false;
         series4.Legend = "Legend1";
         series4.Name = "Series4";
         series5.ChartArea = "ChartArea1";
         series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
         series5.Enabled = false;
         series5.Legend = "Legend1";
         series5.Name = "Series5";
         series6.ChartArea = "ChartArea1";
         series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
         series6.Enabled = false;
         series6.Legend = "Legend1";
         series6.Name = "Series6";
         series7.ChartArea = "ChartArea1";
         series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
         series7.Enabled = false;
         series7.Legend = "Legend1";
         series7.Name = "Series7";
         series8.ChartArea = "ChartArea1";
         series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
         series8.Enabled = false;
         series8.Legend = "Legend1";
         series8.Name = "Series8";
         series9.ChartArea = "ChartArea1";
         series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
         series9.Enabled = false;
         series9.Legend = "Legend1";
         series9.Name = "Series9";
         series10.ChartArea = "ChartArea1";
         series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
         series10.Enabled = false;
         series10.Legend = "Legend1";
         series10.Name = "Series10";
         this.chtSrc.Series.Add(series1);
         this.chtSrc.Series.Add(series2);
         this.chtSrc.Series.Add(series3);
         this.chtSrc.Series.Add(series4);
         this.chtSrc.Series.Add(series5);
         this.chtSrc.Series.Add(series6);
         this.chtSrc.Series.Add(series7);
         this.chtSrc.Series.Add(series8);
         this.chtSrc.Series.Add(series9);
         this.chtSrc.Series.Add(series10);
         this.chtSrc.Size = new System.Drawing.Size(304, 213);
         this.chtSrc.TabIndex = 2;
         this.chtSrc.Text = "chart1";
         // 
         // btnClipboard
         // 
         this.btnClipboard.Location = new System.Drawing.Point(12, 12);
         this.btnClipboard.Name = "btnClipboard";
         this.btnClipboard.Size = new System.Drawing.Size(75, 23);
         this.btnClipboard.TabIndex = 0;
         this.btnClipboard.Text = "Clipboard";
         this.btnClipboard.UseVisualStyleBackColor = true;
         this.btnClipboard.Click += new System.EventHandler(this.btnClipboard_Click);
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(765, 437);
         this.Controls.Add(this.tableLayoutPanel1);
         this.Controls.Add(this.panel1);
         this.Name = "Form1";
         this.Text = "Form1";
         this.panel1.ResumeLayout(false);
         this.tableLayoutPanel1.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.pbxDst)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.pbxSrc)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.chtSrc)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion
      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.Button btnLoad;
      private System.Windows.Forms.OpenFileDialog dlgOpen;
      private System.Windows.Forms.Button btnLive;
      private System.Windows.Forms.Timer timer1;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private System.Windows.Forms.PictureBox pbxDst;
      private System.Windows.Forms.PictureBox pbxSrc;
      private System.Windows.Forms.DataVisualization.Charting.Chart chtSrc;
      private System.Windows.Forms.Button btnClipboard;
   }
}

