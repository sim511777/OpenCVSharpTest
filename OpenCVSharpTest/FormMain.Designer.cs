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
         System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
         System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
         System.Windows.Forms.DataVisualization.Charting.Series series21 = new System.Windows.Forms.DataVisualization.Charting.Series();
         System.Windows.Forms.DataVisualization.Charting.Series series22 = new System.Windows.Forms.DataVisualization.Charting.Series();
         System.Windows.Forms.DataVisualization.Charting.Series series23 = new System.Windows.Forms.DataVisualization.Charting.Series();
         System.Windows.Forms.DataVisualization.Charting.Series series24 = new System.Windows.Forms.DataVisualization.Charting.Series();
         System.Windows.Forms.DataVisualization.Charting.Series series25 = new System.Windows.Forms.DataVisualization.Charting.Series();
         System.Windows.Forms.DataVisualization.Charting.Series series26 = new System.Windows.Forms.DataVisualization.Charting.Series();
         System.Windows.Forms.DataVisualization.Charting.Series series27 = new System.Windows.Forms.DataVisualization.Charting.Series();
         System.Windows.Forms.DataVisualization.Charting.Series series28 = new System.Windows.Forms.DataVisualization.Charting.Series();
         System.Windows.Forms.DataVisualization.Charting.Series series29 = new System.Windows.Forms.DataVisualization.Charting.Series();
         System.Windows.Forms.DataVisualization.Charting.Series series30 = new System.Windows.Forms.DataVisualization.Charting.Series();
         System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
         System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
         System.Windows.Forms.DataVisualization.Charting.Series series31 = new System.Windows.Forms.DataVisualization.Charting.Series();
         System.Windows.Forms.DataVisualization.Charting.Series series32 = new System.Windows.Forms.DataVisualization.Charting.Series();
         System.Windows.Forms.DataVisualization.Charting.Series series33 = new System.Windows.Forms.DataVisualization.Charting.Series();
         System.Windows.Forms.DataVisualization.Charting.Series series34 = new System.Windows.Forms.DataVisualization.Charting.Series();
         System.Windows.Forms.DataVisualization.Charting.Series series35 = new System.Windows.Forms.DataVisualization.Charting.Series();
         System.Windows.Forms.DataVisualization.Charting.Series series36 = new System.Windows.Forms.DataVisualization.Charting.Series();
         System.Windows.Forms.DataVisualization.Charting.Series series37 = new System.Windows.Forms.DataVisualization.Charting.Series();
         System.Windows.Forms.DataVisualization.Charting.Series series38 = new System.Windows.Forms.DataVisualization.Charting.Series();
         System.Windows.Forms.DataVisualization.Charting.Series series39 = new System.Windows.Forms.DataVisualization.Charting.Series();
         System.Windows.Forms.DataVisualization.Charting.Series series40 = new System.Windows.Forms.DataVisualization.Charting.Series();
         this.panel1 = new System.Windows.Forms.Panel();
         this.btnLive = new System.Windows.Forms.Button();
         this.btnLenna = new System.Windows.Forms.Button();
         this.btnClipboard = new System.Windows.Forms.Button();
         this.btnLoad = new System.Windows.Forms.Button();
         this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
         this.timer1 = new System.Windows.Forms.Timer(this.components);
         this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
         this.chtDst = new System.Windows.Forms.DataVisualization.Charting.Chart();
         this.pbxDst = new System.Windows.Forms.PictureBox();
         this.pbxSrc = new System.Windows.Forms.PictureBox();
         this.chtSrc = new System.Windows.Forms.DataVisualization.Charting.Chart();
         this.statusStrip1 = new System.Windows.Forms.StatusStrip();
         this.lblGrabTime = new System.Windows.Forms.ToolStripStatusLabel();
         this.lblProcessingTime = new System.Windows.Forms.ToolStripStatusLabel();
         this.panel1.SuspendLayout();
         this.tableLayoutPanel1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.chtDst)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.pbxDst)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.pbxSrc)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.chtSrc)).BeginInit();
         this.statusStrip1.SuspendLayout();
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
         chartArea3.AxisX.LabelStyle.Interval = 20D;
         chartArea3.AxisX.LabelStyle.IntervalOffset = 1D;
         chartArea3.AxisX.MajorGrid.Enabled = false;
         chartArea3.AxisX.MajorTickMark.Interval = 20D;
         chartArea3.AxisX.MajorTickMark.IntervalOffset = 1D;
         chartArea3.AxisX2.LabelStyle.Enabled = false;
         chartArea3.AxisX2.MajorGrid.Enabled = false;
         chartArea3.AxisX2.MajorTickMark.Enabled = false;
         chartArea3.AxisY.LabelStyle.Enabled = false;
         chartArea3.AxisY.MajorGrid.Enabled = false;
         chartArea3.AxisY.MajorTickMark.Enabled = false;
         chartArea3.AxisY2.LabelStyle.Enabled = false;
         chartArea3.AxisY2.MajorGrid.Enabled = false;
         chartArea3.AxisY2.MajorTickMark.Enabled = false;
         chartArea3.Name = "ChartArea1";
         this.chtDst.ChartAreas.Add(chartArea3);
         this.chtDst.Dock = System.Windows.Forms.DockStyle.Fill;
         legend3.Name = "Legend1";
         this.chtDst.Legends.Add(legend3);
         this.chtDst.Location = new System.Drawing.Point(313, 210);
         this.chtDst.Name = "chtDst";
         series21.ChartArea = "ChartArea1";
         series21.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
         series21.Enabled = false;
         series21.Legend = "Legend1";
         series21.Name = "Series1";
         series22.ChartArea = "ChartArea1";
         series22.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
         series22.Enabled = false;
         series22.Legend = "Legend1";
         series22.Name = "Series2";
         series23.ChartArea = "ChartArea1";
         series23.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
         series23.Enabled = false;
         series23.Legend = "Legend1";
         series23.Name = "Series3";
         series24.ChartArea = "ChartArea1";
         series24.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
         series24.Enabled = false;
         series24.Legend = "Legend1";
         series24.Name = "Series4";
         series25.ChartArea = "ChartArea1";
         series25.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
         series25.Enabled = false;
         series25.Legend = "Legend1";
         series25.Name = "Series5";
         series26.ChartArea = "ChartArea1";
         series26.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
         series26.Enabled = false;
         series26.Legend = "Legend1";
         series26.Name = "Series6";
         series27.ChartArea = "ChartArea1";
         series27.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
         series27.Enabled = false;
         series27.Legend = "Legend1";
         series27.Name = "Series7";
         series28.ChartArea = "ChartArea1";
         series28.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
         series28.Enabled = false;
         series28.Legend = "Legend1";
         series28.Name = "Series8";
         series29.ChartArea = "ChartArea1";
         series29.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
         series29.Enabled = false;
         series29.Legend = "Legend1";
         series29.Name = "Series9";
         series30.ChartArea = "ChartArea1";
         series30.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
         series30.Enabled = false;
         series30.Legend = "Legend1";
         series30.Name = "Series10";
         this.chtDst.Series.Add(series21);
         this.chtDst.Series.Add(series22);
         this.chtDst.Series.Add(series23);
         this.chtDst.Series.Add(series24);
         this.chtDst.Series.Add(series25);
         this.chtDst.Series.Add(series26);
         this.chtDst.Series.Add(series27);
         this.chtDst.Series.Add(series28);
         this.chtDst.Series.Add(series29);
         this.chtDst.Series.Add(series30);
         this.chtDst.Size = new System.Drawing.Size(304, 202);
         this.chtDst.TabIndex = 0;
         this.chtDst.Text = "chart1";
         // 
         // pbxDst
         // 
         this.pbxDst.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pbxDst.Location = new System.Drawing.Point(313, 3);
         this.pbxDst.Name = "pbxDst";
         this.pbxDst.Size = new System.Drawing.Size(304, 201);
         this.pbxDst.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
         this.pbxDst.TabIndex = 1;
         this.pbxDst.TabStop = false;
         // 
         // pbxSrc
         // 
         this.pbxSrc.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pbxSrc.Location = new System.Drawing.Point(3, 3);
         this.pbxSrc.Name = "pbxSrc";
         this.pbxSrc.Size = new System.Drawing.Size(304, 201);
         this.pbxSrc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
         this.pbxSrc.TabIndex = 0;
         this.pbxSrc.TabStop = false;
         // 
         // chtSrc
         // 
         chartArea4.AxisX.LabelStyle.Interval = 20D;
         chartArea4.AxisX.LabelStyle.IntervalOffset = 1D;
         chartArea4.AxisX.MajorGrid.Enabled = false;
         chartArea4.AxisX.MajorTickMark.Interval = 20D;
         chartArea4.AxisX.MajorTickMark.IntervalOffset = 1D;
         chartArea4.AxisX2.LabelStyle.Enabled = false;
         chartArea4.AxisX2.MajorGrid.Enabled = false;
         chartArea4.AxisX2.MajorTickMark.Enabled = false;
         chartArea4.AxisY.LabelStyle.Enabled = false;
         chartArea4.AxisY.MajorGrid.Enabled = false;
         chartArea4.AxisY.MajorTickMark.Enabled = false;
         chartArea4.AxisY2.LabelStyle.Enabled = false;
         chartArea4.AxisY2.MajorGrid.Enabled = false;
         chartArea4.AxisY2.MajorTickMark.Enabled = false;
         chartArea4.Name = "ChartArea1";
         this.chtSrc.ChartAreas.Add(chartArea4);
         this.chtSrc.Dock = System.Windows.Forms.DockStyle.Fill;
         legend4.Name = "Legend1";
         this.chtSrc.Legends.Add(legend4);
         this.chtSrc.Location = new System.Drawing.Point(3, 210);
         this.chtSrc.Name = "chtSrc";
         series31.ChartArea = "ChartArea1";
         series31.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
         series31.Enabled = false;
         series31.Legend = "Legend1";
         series31.Name = "Series1";
         series32.ChartArea = "ChartArea1";
         series32.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
         series32.Enabled = false;
         series32.Legend = "Legend1";
         series32.Name = "Series2";
         series33.ChartArea = "ChartArea1";
         series33.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
         series33.Enabled = false;
         series33.Legend = "Legend1";
         series33.Name = "Series3";
         series34.ChartArea = "ChartArea1";
         series34.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
         series34.Enabled = false;
         series34.Legend = "Legend1";
         series34.Name = "Series4";
         series35.ChartArea = "ChartArea1";
         series35.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
         series35.Enabled = false;
         series35.Legend = "Legend1";
         series35.Name = "Series5";
         series36.ChartArea = "ChartArea1";
         series36.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
         series36.Enabled = false;
         series36.Legend = "Legend1";
         series36.Name = "Series6";
         series37.ChartArea = "ChartArea1";
         series37.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
         series37.Enabled = false;
         series37.Legend = "Legend1";
         series37.Name = "Series7";
         series38.ChartArea = "ChartArea1";
         series38.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
         series38.Enabled = false;
         series38.Legend = "Legend1";
         series38.Name = "Series8";
         series39.ChartArea = "ChartArea1";
         series39.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
         series39.Enabled = false;
         series39.Legend = "Legend1";
         series39.Name = "Series9";
         series40.ChartArea = "ChartArea1";
         series40.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
         series40.Enabled = false;
         series40.Legend = "Legend1";
         series40.Name = "Series10";
         this.chtSrc.Series.Add(series31);
         this.chtSrc.Series.Add(series32);
         this.chtSrc.Series.Add(series33);
         this.chtSrc.Series.Add(series34);
         this.chtSrc.Series.Add(series35);
         this.chtSrc.Series.Add(series36);
         this.chtSrc.Series.Add(series37);
         this.chtSrc.Series.Add(series38);
         this.chtSrc.Series.Add(series39);
         this.chtSrc.Series.Add(series40);
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
         ((System.ComponentModel.ISupportInitialize)(this.pbxDst)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.pbxSrc)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.chtSrc)).EndInit();
         this.statusStrip1.ResumeLayout(false);
         this.statusStrip1.PerformLayout();
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
      private System.Windows.Forms.PictureBox pbxDst;
      private System.Windows.Forms.PictureBox pbxSrc;
      private System.Windows.Forms.DataVisualization.Charting.Chart chtSrc;
      private System.Windows.Forms.Button btnClipboard;
      private System.Windows.Forms.DataVisualization.Charting.Chart chtDst;
      private System.Windows.Forms.StatusStrip statusStrip1;
      private System.Windows.Forms.ToolStripStatusLabel lblProcessingTime;
      private System.Windows.Forms.ToolStripStatusLabel lblGrabTime;
      private System.Windows.Forms.Button btnLenna;
   }
}

