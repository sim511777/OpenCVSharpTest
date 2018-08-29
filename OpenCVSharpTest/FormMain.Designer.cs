namespace OpenCVSharpTest {
   partial class FormMain {
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
         System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
         System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
         System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
         System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
         System.Windows.Forms.DataVisualization.Charting.Series series13 = new System.Windows.Forms.DataVisualization.Charting.Series();
         System.Windows.Forms.DataVisualization.Charting.Series series14 = new System.Windows.Forms.DataVisualization.Charting.Series();
         System.Windows.Forms.DataVisualization.Charting.Series series15 = new System.Windows.Forms.DataVisualization.Charting.Series();
         System.Windows.Forms.DataVisualization.Charting.Series series16 = new System.Windows.Forms.DataVisualization.Charting.Series();
         System.Windows.Forms.DataVisualization.Charting.Series series17 = new System.Windows.Forms.DataVisualization.Charting.Series();
         System.Windows.Forms.DataVisualization.Charting.Series series18 = new System.Windows.Forms.DataVisualization.Charting.Series();
         System.Windows.Forms.DataVisualization.Charting.Series series19 = new System.Windows.Forms.DataVisualization.Charting.Series();
         System.Windows.Forms.DataVisualization.Charting.Series series20 = new System.Windows.Forms.DataVisualization.Charting.Series();
         this.panel1 = new System.Windows.Forms.Panel();
         this.btnLive = new System.Windows.Forms.Button();
         this.btnLenna = new System.Windows.Forms.Button();
         this.btnClipboard = new System.Windows.Forms.Button();
         this.btnLoad = new System.Windows.Forms.Button();
         this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
         this.timer1 = new System.Windows.Forms.Timer(this.components);
         this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
         this.chtDst = new System.Windows.Forms.DataVisualization.Charting.Chart();
         this.chtSrc = new System.Windows.Forms.DataVisualization.Charting.Chart();
         this.statusStrip1 = new System.Windows.Forms.StatusStrip();
         this.lblGrabTime = new System.Windows.Forms.ToolStripStatusLabel();
         this.lblProcessingTime = new System.Windows.Forms.ToolStripStatusLabel();
         this.pbxDst = new ShimLib.ZoomPictureBox();
         this.pbxSrc = new ShimLib.ZoomPictureBox();
         this.btnZoomReset = new System.Windows.Forms.Button();
         this.panel1.SuspendLayout();
         this.tableLayoutPanel1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.chtDst)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.chtSrc)).BeginInit();
         this.statusStrip1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pbxDst)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.pbxSrc)).BeginInit();
         this.SuspendLayout();
         // 
         // panel1
         // 
         this.panel1.Controls.Add(this.btnZoomReset);
         this.panel1.Controls.Add(this.btnLive);
         this.panel1.Controls.Add(this.btnLenna);
         this.panel1.Controls.Add(this.btnClipboard);
         this.panel1.Controls.Add(this.btnLoad);
         this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
         this.panel1.Location = new System.Drawing.Point(0, 0);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(145, 415);
         this.panel1.TabIndex = 0;
         // 
         // btnLive
         // 
         this.btnLive.Location = new System.Drawing.Point(12, 99);
         this.btnLive.Name = "btnLive";
         this.btnLive.Size = new System.Drawing.Size(90, 23);
         this.btnLive.TabIndex = 3;
         this.btnLive.Text = "Live";
         this.btnLive.UseVisualStyleBackColor = true;
         this.btnLive.Click += new System.EventHandler(this.btnLive_Click);
         // 
         // btnLenna
         // 
         this.btnLenna.Location = new System.Drawing.Point(12, 12);
         this.btnLenna.Name = "btnLenna";
         this.btnLenna.Size = new System.Drawing.Size(90, 23);
         this.btnLenna.TabIndex = 0;
         this.btnLenna.Text = "Lenna";
         this.btnLenna.UseVisualStyleBackColor = true;
         this.btnLenna.Click += new System.EventHandler(this.btnLenna_Click);
         // 
         // btnClipboard
         // 
         this.btnClipboard.Location = new System.Drawing.Point(12, 41);
         this.btnClipboard.Name = "btnClipboard";
         this.btnClipboard.Size = new System.Drawing.Size(90, 23);
         this.btnClipboard.TabIndex = 1;
         this.btnClipboard.Text = "Clipboard";
         this.btnClipboard.UseVisualStyleBackColor = true;
         this.btnClipboard.Click += new System.EventHandler(this.btnClipboard_Click);
         // 
         // btnLoad
         // 
         this.btnLoad.Location = new System.Drawing.Point(12, 70);
         this.btnLoad.Name = "btnLoad";
         this.btnLoad.Size = new System.Drawing.Size(90, 23);
         this.btnLoad.TabIndex = 2;
         this.btnLoad.Text = "Load";
         this.btnLoad.UseVisualStyleBackColor = true;
         this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
         // 
         // dlgOpen
         // 
         this.dlgOpen.FileName = "openFileDialog1";
         this.dlgOpen.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG";
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
         this.tableLayoutPanel1.Controls.Add(this.chtDst, 0, 1);
         this.tableLayoutPanel1.Controls.Add(this.pbxDst, 1, 0);
         this.tableLayoutPanel1.Controls.Add(this.pbxSrc, 0, 0);
         this.tableLayoutPanel1.Controls.Add(this.chtSrc, 0, 1);
         this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tableLayoutPanel1.Location = new System.Drawing.Point(145, 0);
         this.tableLayoutPanel1.Name = "tableLayoutPanel1";
         this.tableLayoutPanel1.RowCount = 2;
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this.tableLayoutPanel1.Size = new System.Drawing.Size(620, 415);
         this.tableLayoutPanel1.TabIndex = 1;
         // 
         // chtDst
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
         this.chtDst.ChartAreas.Add(chartArea1);
         this.chtDst.Dock = System.Windows.Forms.DockStyle.Fill;
         legend1.Name = "Legend1";
         this.chtDst.Legends.Add(legend1);
         this.chtDst.Location = new System.Drawing.Point(313, 210);
         this.chtDst.Name = "chtDst";
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
         this.chtDst.Series.Add(series1);
         this.chtDst.Series.Add(series2);
         this.chtDst.Series.Add(series3);
         this.chtDst.Series.Add(series4);
         this.chtDst.Series.Add(series5);
         this.chtDst.Series.Add(series6);
         this.chtDst.Series.Add(series7);
         this.chtDst.Series.Add(series8);
         this.chtDst.Series.Add(series9);
         this.chtDst.Series.Add(series10);
         this.chtDst.Size = new System.Drawing.Size(304, 202);
         this.chtDst.TabIndex = 0;
         this.chtDst.Text = "chart1";
         // 
         // chtSrc
         // 
         chartArea2.AxisX.LabelStyle.Interval = 20D;
         chartArea2.AxisX.LabelStyle.IntervalOffset = 1D;
         chartArea2.AxisX.MajorGrid.Enabled = false;
         chartArea2.AxisX.MajorTickMark.Interval = 20D;
         chartArea2.AxisX.MajorTickMark.IntervalOffset = 1D;
         chartArea2.AxisX2.LabelStyle.Enabled = false;
         chartArea2.AxisX2.MajorGrid.Enabled = false;
         chartArea2.AxisX2.MajorTickMark.Enabled = false;
         chartArea2.AxisY.LabelStyle.Enabled = false;
         chartArea2.AxisY.MajorGrid.Enabled = false;
         chartArea2.AxisY.MajorTickMark.Enabled = false;
         chartArea2.AxisY2.LabelStyle.Enabled = false;
         chartArea2.AxisY2.MajorGrid.Enabled = false;
         chartArea2.AxisY2.MajorTickMark.Enabled = false;
         chartArea2.Name = "ChartArea1";
         this.chtSrc.ChartAreas.Add(chartArea2);
         this.chtSrc.Dock = System.Windows.Forms.DockStyle.Fill;
         legend2.Name = "Legend1";
         this.chtSrc.Legends.Add(legend2);
         this.chtSrc.Location = new System.Drawing.Point(3, 210);
         this.chtSrc.Name = "chtSrc";
         series11.ChartArea = "ChartArea1";
         series11.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
         series11.Enabled = false;
         series11.Legend = "Legend1";
         series11.Name = "Series1";
         series12.ChartArea = "ChartArea1";
         series12.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
         series12.Enabled = false;
         series12.Legend = "Legend1";
         series12.Name = "Series2";
         series13.ChartArea = "ChartArea1";
         series13.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
         series13.Enabled = false;
         series13.Legend = "Legend1";
         series13.Name = "Series3";
         series14.ChartArea = "ChartArea1";
         series14.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
         series14.Enabled = false;
         series14.Legend = "Legend1";
         series14.Name = "Series4";
         series15.ChartArea = "ChartArea1";
         series15.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
         series15.Enabled = false;
         series15.Legend = "Legend1";
         series15.Name = "Series5";
         series16.ChartArea = "ChartArea1";
         series16.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
         series16.Enabled = false;
         series16.Legend = "Legend1";
         series16.Name = "Series6";
         series17.ChartArea = "ChartArea1";
         series17.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
         series17.Enabled = false;
         series17.Legend = "Legend1";
         series17.Name = "Series7";
         series18.ChartArea = "ChartArea1";
         series18.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
         series18.Enabled = false;
         series18.Legend = "Legend1";
         series18.Name = "Series8";
         series19.ChartArea = "ChartArea1";
         series19.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
         series19.Enabled = false;
         series19.Legend = "Legend1";
         series19.Name = "Series9";
         series20.ChartArea = "ChartArea1";
         series20.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
         series20.Enabled = false;
         series20.Legend = "Legend1";
         series20.Name = "Series10";
         this.chtSrc.Series.Add(series11);
         this.chtSrc.Series.Add(series12);
         this.chtSrc.Series.Add(series13);
         this.chtSrc.Series.Add(series14);
         this.chtSrc.Series.Add(series15);
         this.chtSrc.Series.Add(series16);
         this.chtSrc.Series.Add(series17);
         this.chtSrc.Series.Add(series18);
         this.chtSrc.Series.Add(series19);
         this.chtSrc.Series.Add(series20);
         this.chtSrc.Size = new System.Drawing.Size(304, 202);
         this.chtSrc.TabIndex = 1;
         this.chtSrc.Text = "chart1";
         // 
         // statusStrip1
         // 
         this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblGrabTime,
            this.lblProcessingTime});
         this.statusStrip1.Location = new System.Drawing.Point(0, 415);
         this.statusStrip1.Name = "statusStrip1";
         this.statusStrip1.Size = new System.Drawing.Size(765, 22);
         this.statusStrip1.TabIndex = 0;
         this.statusStrip1.Text = "statusStrip1";
         // 
         // lblGrabTime
         // 
         this.lblGrabTime.AutoSize = false;
         this.lblGrabTime.Name = "lblGrabTime";
         this.lblGrabTime.Size = new System.Drawing.Size(150, 17);
         this.lblGrabTime.Text = "grab time:";
         this.lblGrabTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // lblProcessingTime
         // 
         this.lblProcessingTime.AutoSize = false;
         this.lblProcessingTime.Name = "lblProcessingTime";
         this.lblProcessingTime.Size = new System.Drawing.Size(150, 17);
         this.lblProcessingTime.Text = "proc time:";
         this.lblProcessingTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // pbxDst
         // 
         this.pbxDst.AxisXInvert = false;
         this.pbxDst.AxisXYFlip = false;
         this.pbxDst.AxisYInvert = false;
         this.pbxDst.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pbxDst.DrawImage = null;
         this.pbxDst.EnableMousePan = true;
         this.pbxDst.EnableWheelZoom = true;
         this.pbxDst.Location = new System.Drawing.Point(313, 3);
         this.pbxDst.Name = "pbxDst";
         this.pbxDst.Pan = new System.Drawing.SizeF(0F, 0F);
         this.pbxDst.ShowPixelInfo = true;
         this.pbxDst.Size = new System.Drawing.Size(304, 201);
         this.pbxDst.TabIndex = 1;
         this.pbxDst.TabStop = false;
         this.pbxDst.Zoom = 1F;
         this.pbxDst.ZoomMax = 100F;
         this.pbxDst.ZoomMin = 0.1F;
         this.pbxDst.ZoomStep = 1.2F;
         // 
         // pbxSrc
         // 
         this.pbxSrc.AxisXInvert = false;
         this.pbxSrc.AxisXYFlip = false;
         this.pbxSrc.AxisYInvert = false;
         this.pbxSrc.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pbxSrc.DrawImage = null;
         this.pbxSrc.EnableMousePan = true;
         this.pbxSrc.EnableWheelZoom = true;
         this.pbxSrc.Location = new System.Drawing.Point(3, 3);
         this.pbxSrc.Name = "pbxSrc";
         this.pbxSrc.Pan = new System.Drawing.SizeF(0F, 0F);
         this.pbxSrc.ShowPixelInfo = true;
         this.pbxSrc.Size = new System.Drawing.Size(304, 201);
         this.pbxSrc.TabIndex = 0;
         this.pbxSrc.TabStop = false;
         this.pbxSrc.Zoom = 1F;
         this.pbxSrc.ZoomMax = 100F;
         this.pbxSrc.ZoomMin = 0.1F;
         this.pbxSrc.ZoomStep = 1.2F;
         // 
         // btnZoomReset
         // 
         this.btnZoomReset.Location = new System.Drawing.Point(12, 128);
         this.btnZoomReset.Name = "btnZoomReset";
         this.btnZoomReset.Size = new System.Drawing.Size(90, 23);
         this.btnZoomReset.TabIndex = 3;
         this.btnZoomReset.Text = "Reset Zoom";
         this.btnZoomReset.UseVisualStyleBackColor = true;
         this.btnZoomReset.Click += new System.EventHandler(this.btnZoomReset_Click);
         // 
         // FormMain
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(765, 437);
         this.Controls.Add(this.tableLayoutPanel1);
         this.Controls.Add(this.panel1);
         this.Controls.Add(this.statusStrip1);
         this.Name = "FormMain";
         this.Text = "Form1";
         this.panel1.ResumeLayout(false);
         this.tableLayoutPanel1.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.chtDst)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.chtSrc)).EndInit();
         this.statusStrip1.ResumeLayout(false);
         this.statusStrip1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pbxDst)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.pbxSrc)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion
      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.Button btnLoad;
      private System.Windows.Forms.OpenFileDialog dlgOpen;
      private System.Windows.Forms.Button btnLive;
      private System.Windows.Forms.Timer timer1;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private ShimLib.ZoomPictureBox pbxDst;
      private ShimLib.ZoomPictureBox pbxSrc;
      private System.Windows.Forms.DataVisualization.Charting.Chart chtSrc;
      private System.Windows.Forms.Button btnClipboard;
      private System.Windows.Forms.DataVisualization.Charting.Chart chtDst;
      private System.Windows.Forms.StatusStrip statusStrip1;
      private System.Windows.Forms.ToolStripStatusLabel lblProcessingTime;
      private System.Windows.Forms.ToolStripStatusLabel lblGrabTime;
      private System.Windows.Forms.Button btnLenna;
      private System.Windows.Forms.Button btnZoomReset;
   }
}

