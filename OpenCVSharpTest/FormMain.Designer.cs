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
         System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea9 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
         System.Windows.Forms.DataVisualization.Charting.Legend legend9 = new System.Windows.Forms.DataVisualization.Charting.Legend();
         System.Windows.Forms.DataVisualization.Charting.Series series81 = new System.Windows.Forms.DataVisualization.Charting.Series();
         System.Windows.Forms.DataVisualization.Charting.Series series82 = new System.Windows.Forms.DataVisualization.Charting.Series();
         System.Windows.Forms.DataVisualization.Charting.Series series83 = new System.Windows.Forms.DataVisualization.Charting.Series();
         System.Windows.Forms.DataVisualization.Charting.Series series84 = new System.Windows.Forms.DataVisualization.Charting.Series();
         System.Windows.Forms.DataVisualization.Charting.Series series85 = new System.Windows.Forms.DataVisualization.Charting.Series();
         System.Windows.Forms.DataVisualization.Charting.Series series86 = new System.Windows.Forms.DataVisualization.Charting.Series();
         System.Windows.Forms.DataVisualization.Charting.Series series87 = new System.Windows.Forms.DataVisualization.Charting.Series();
         System.Windows.Forms.DataVisualization.Charting.Series series88 = new System.Windows.Forms.DataVisualization.Charting.Series();
         System.Windows.Forms.DataVisualization.Charting.Series series89 = new System.Windows.Forms.DataVisualization.Charting.Series();
         System.Windows.Forms.DataVisualization.Charting.Series series90 = new System.Windows.Forms.DataVisualization.Charting.Series();
         System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea10 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
         System.Windows.Forms.DataVisualization.Charting.Legend legend10 = new System.Windows.Forms.DataVisualization.Charting.Legend();
         System.Windows.Forms.DataVisualization.Charting.Series series91 = new System.Windows.Forms.DataVisualization.Charting.Series();
         System.Windows.Forms.DataVisualization.Charting.Series series92 = new System.Windows.Forms.DataVisualization.Charting.Series();
         System.Windows.Forms.DataVisualization.Charting.Series series93 = new System.Windows.Forms.DataVisualization.Charting.Series();
         System.Windows.Forms.DataVisualization.Charting.Series series94 = new System.Windows.Forms.DataVisualization.Charting.Series();
         System.Windows.Forms.DataVisualization.Charting.Series series95 = new System.Windows.Forms.DataVisualization.Charting.Series();
         System.Windows.Forms.DataVisualization.Charting.Series series96 = new System.Windows.Forms.DataVisualization.Charting.Series();
         System.Windows.Forms.DataVisualization.Charting.Series series97 = new System.Windows.Forms.DataVisualization.Charting.Series();
         System.Windows.Forms.DataVisualization.Charting.Series series98 = new System.Windows.Forms.DataVisualization.Charting.Series();
         System.Windows.Forms.DataVisualization.Charting.Series series99 = new System.Windows.Forms.DataVisualization.Charting.Series();
         System.Windows.Forms.DataVisualization.Charting.Series series100 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
         this.pbxDst = new OpenCVSharpTest.ZoomPictureBox();
         this.pbxSrc = new OpenCVSharpTest.ZoomPictureBox();
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
         this.btnLive.Size = new System.Drawing.Size(75, 23);
         this.btnLive.TabIndex = 3;
         this.btnLive.Text = "Live";
         this.btnLive.UseVisualStyleBackColor = true;
         this.btnLive.Click += new System.EventHandler(this.btnLive_Click);
         // 
         // btnLenna
         // 
         this.btnLenna.Location = new System.Drawing.Point(12, 12);
         this.btnLenna.Name = "btnLenna";
         this.btnLenna.Size = new System.Drawing.Size(75, 23);
         this.btnLenna.TabIndex = 0;
         this.btnLenna.Text = "Lenna";
         this.btnLenna.UseVisualStyleBackColor = true;
         this.btnLenna.Click += new System.EventHandler(this.btnLenna_Click);
         // 
         // btnClipboard
         // 
         this.btnClipboard.Location = new System.Drawing.Point(12, 41);
         this.btnClipboard.Name = "btnClipboard";
         this.btnClipboard.Size = new System.Drawing.Size(75, 23);
         this.btnClipboard.TabIndex = 1;
         this.btnClipboard.Text = "Clipboard";
         this.btnClipboard.UseVisualStyleBackColor = true;
         this.btnClipboard.Click += new System.EventHandler(this.btnClipboard_Click);
         // 
         // btnLoad
         // 
         this.btnLoad.Location = new System.Drawing.Point(12, 70);
         this.btnLoad.Name = "btnLoad";
         this.btnLoad.Size = new System.Drawing.Size(75, 23);
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
         chartArea9.AxisX.LabelStyle.Interval = 20D;
         chartArea9.AxisX.LabelStyle.IntervalOffset = 1D;
         chartArea9.AxisX.MajorGrid.Enabled = false;
         chartArea9.AxisX.MajorTickMark.Interval = 20D;
         chartArea9.AxisX.MajorTickMark.IntervalOffset = 1D;
         chartArea9.AxisX2.LabelStyle.Enabled = false;
         chartArea9.AxisX2.MajorGrid.Enabled = false;
         chartArea9.AxisX2.MajorTickMark.Enabled = false;
         chartArea9.AxisY.LabelStyle.Enabled = false;
         chartArea9.AxisY.MajorGrid.Enabled = false;
         chartArea9.AxisY.MajorTickMark.Enabled = false;
         chartArea9.AxisY2.LabelStyle.Enabled = false;
         chartArea9.AxisY2.MajorGrid.Enabled = false;
         chartArea9.AxisY2.MajorTickMark.Enabled = false;
         chartArea9.Name = "ChartArea1";
         this.chtDst.ChartAreas.Add(chartArea9);
         this.chtDst.Dock = System.Windows.Forms.DockStyle.Fill;
         legend9.Name = "Legend1";
         this.chtDst.Legends.Add(legend9);
         this.chtDst.Location = new System.Drawing.Point(313, 210);
         this.chtDst.Name = "chtDst";
         series81.ChartArea = "ChartArea1";
         series81.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
         series81.Enabled = false;
         series81.Legend = "Legend1";
         series81.Name = "Series1";
         series82.ChartArea = "ChartArea1";
         series82.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
         series82.Enabled = false;
         series82.Legend = "Legend1";
         series82.Name = "Series2";
         series83.ChartArea = "ChartArea1";
         series83.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
         series83.Enabled = false;
         series83.Legend = "Legend1";
         series83.Name = "Series3";
         series84.ChartArea = "ChartArea1";
         series84.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
         series84.Enabled = false;
         series84.Legend = "Legend1";
         series84.Name = "Series4";
         series85.ChartArea = "ChartArea1";
         series85.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
         series85.Enabled = false;
         series85.Legend = "Legend1";
         series85.Name = "Series5";
         series86.ChartArea = "ChartArea1";
         series86.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
         series86.Enabled = false;
         series86.Legend = "Legend1";
         series86.Name = "Series6";
         series87.ChartArea = "ChartArea1";
         series87.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
         series87.Enabled = false;
         series87.Legend = "Legend1";
         series87.Name = "Series7";
         series88.ChartArea = "ChartArea1";
         series88.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
         series88.Enabled = false;
         series88.Legend = "Legend1";
         series88.Name = "Series8";
         series89.ChartArea = "ChartArea1";
         series89.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
         series89.Enabled = false;
         series89.Legend = "Legend1";
         series89.Name = "Series9";
         series90.ChartArea = "ChartArea1";
         series90.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
         series90.Enabled = false;
         series90.Legend = "Legend1";
         series90.Name = "Series10";
         this.chtDst.Series.Add(series81);
         this.chtDst.Series.Add(series82);
         this.chtDst.Series.Add(series83);
         this.chtDst.Series.Add(series84);
         this.chtDst.Series.Add(series85);
         this.chtDst.Series.Add(series86);
         this.chtDst.Series.Add(series87);
         this.chtDst.Series.Add(series88);
         this.chtDst.Series.Add(series89);
         this.chtDst.Series.Add(series90);
         this.chtDst.Size = new System.Drawing.Size(304, 202);
         this.chtDst.TabIndex = 0;
         this.chtDst.Text = "chart1";
         // 
         // chtSrc
         // 
         chartArea10.AxisX.LabelStyle.Interval = 20D;
         chartArea10.AxisX.LabelStyle.IntervalOffset = 1D;
         chartArea10.AxisX.MajorGrid.Enabled = false;
         chartArea10.AxisX.MajorTickMark.Interval = 20D;
         chartArea10.AxisX.MajorTickMark.IntervalOffset = 1D;
         chartArea10.AxisX2.LabelStyle.Enabled = false;
         chartArea10.AxisX2.MajorGrid.Enabled = false;
         chartArea10.AxisX2.MajorTickMark.Enabled = false;
         chartArea10.AxisY.LabelStyle.Enabled = false;
         chartArea10.AxisY.MajorGrid.Enabled = false;
         chartArea10.AxisY.MajorTickMark.Enabled = false;
         chartArea10.AxisY2.LabelStyle.Enabled = false;
         chartArea10.AxisY2.MajorGrid.Enabled = false;
         chartArea10.AxisY2.MajorTickMark.Enabled = false;
         chartArea10.Name = "ChartArea1";
         this.chtSrc.ChartAreas.Add(chartArea10);
         this.chtSrc.Dock = System.Windows.Forms.DockStyle.Fill;
         legend10.Name = "Legend1";
         this.chtSrc.Legends.Add(legend10);
         this.chtSrc.Location = new System.Drawing.Point(3, 210);
         this.chtSrc.Name = "chtSrc";
         series91.ChartArea = "ChartArea1";
         series91.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
         series91.Enabled = false;
         series91.Legend = "Legend1";
         series91.Name = "Series1";
         series92.ChartArea = "ChartArea1";
         series92.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
         series92.Enabled = false;
         series92.Legend = "Legend1";
         series92.Name = "Series2";
         series93.ChartArea = "ChartArea1";
         series93.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
         series93.Enabled = false;
         series93.Legend = "Legend1";
         series93.Name = "Series3";
         series94.ChartArea = "ChartArea1";
         series94.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
         series94.Enabled = false;
         series94.Legend = "Legend1";
         series94.Name = "Series4";
         series95.ChartArea = "ChartArea1";
         series95.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
         series95.Enabled = false;
         series95.Legend = "Legend1";
         series95.Name = "Series5";
         series96.ChartArea = "ChartArea1";
         series96.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
         series96.Enabled = false;
         series96.Legend = "Legend1";
         series96.Name = "Series6";
         series97.ChartArea = "ChartArea1";
         series97.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
         series97.Enabled = false;
         series97.Legend = "Legend1";
         series97.Name = "Series7";
         series98.ChartArea = "ChartArea1";
         series98.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
         series98.Enabled = false;
         series98.Legend = "Legend1";
         series98.Name = "Series8";
         series99.ChartArea = "ChartArea1";
         series99.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
         series99.Enabled = false;
         series99.Legend = "Legend1";
         series99.Name = "Series9";
         series100.ChartArea = "ChartArea1";
         series100.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
         series100.Enabled = false;
         series100.Legend = "Legend1";
         series100.Name = "Series10";
         this.chtSrc.Series.Add(series91);
         this.chtSrc.Series.Add(series92);
         this.chtSrc.Series.Add(series93);
         this.chtSrc.Series.Add(series94);
         this.chtSrc.Series.Add(series95);
         this.chtSrc.Series.Add(series96);
         this.chtSrc.Series.Add(series97);
         this.chtSrc.Series.Add(series98);
         this.chtSrc.Series.Add(series99);
         this.chtSrc.Series.Add(series100);
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
         this.pbxDst.Size = new System.Drawing.Size(304, 201);
         this.pbxDst.TabIndex = 1;
         this.pbxDst.TabStop = false;
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
         this.pbxSrc.Size = new System.Drawing.Size(304, 201);
         this.pbxSrc.TabIndex = 0;
         this.pbxSrc.TabStop = false;
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
      private ZoomPictureBox pbxDst;
      private ZoomPictureBox pbxSrc;
      private System.Windows.Forms.DataVisualization.Charting.Chart chtSrc;
      private System.Windows.Forms.Button btnClipboard;
      private System.Windows.Forms.DataVisualization.Charting.Chart chtDst;
      private System.Windows.Forms.StatusStrip statusStrip1;
      private System.Windows.Forms.ToolStripStatusLabel lblProcessingTime;
      private System.Windows.Forms.ToolStripStatusLabel lblGrabTime;
      private System.Windows.Forms.Button btnLenna;
   }
}

