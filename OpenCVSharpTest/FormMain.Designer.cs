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
         this.groupBox3 = new System.Windows.Forms.GroupBox();
         this.grdParameter = new System.Windows.Forms.PropertyGrid();
         this.label2 = new System.Windows.Forms.Label();
         this.cbxFunc = new System.Windows.Forms.ComboBox();
         this.panel2 = new System.Windows.Forms.Panel();
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this.btnZoomReset = new System.Windows.Forms.Button();
         this.btnFitZoom = new System.Windows.Forms.Button();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.btnLenna = new System.Windows.Forms.Button();
         this.btnLoad = new System.Windows.Forms.Button();
         this.btnClipboard = new System.Windows.Forms.Button();
         this.btnLive = new System.Windows.Forms.Button();
         this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
         this.timer1 = new System.Windows.Forms.Timer(this.components);
         this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
         this.chtDst = new System.Windows.Forms.DataVisualization.Charting.Chart();
         this.chtSrc = new System.Windows.Forms.DataVisualization.Charting.Chart();
         this.statusStrip1 = new System.Windows.Forms.StatusStrip();
         this.lblGrabTime = new System.Windows.Forms.ToolStripStatusLabel();
         this.lblProcessingTime = new System.Windows.Forms.ToolStripStatusLabel();
         this.lblLog = new System.Windows.Forms.ToolStripStatusLabel();
         this.pbxDst = new ZoomPictureBox();
         this.pbxSrc = new ZoomPictureBox();
         this.panel1.SuspendLayout();
         this.groupBox3.SuspendLayout();
         this.panel2.SuspendLayout();
         this.groupBox2.SuspendLayout();
         this.groupBox1.SuspendLayout();
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
         this.panel1.Controls.Add(this.groupBox3);
         this.panel1.Controls.Add(this.panel2);
         this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
         this.panel1.Location = new System.Drawing.Point(0, 0);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(258, 630);
         this.panel1.TabIndex = 0;
         // 
         // groupBox3
         // 
         this.groupBox3.Controls.Add(this.grdParameter);
         this.groupBox3.Controls.Add(this.label2);
         this.groupBox3.Controls.Add(this.cbxFunc);
         this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
         this.groupBox3.Location = new System.Drawing.Point(0, 79);
         this.groupBox3.Name = "groupBox3";
         this.groupBox3.Size = new System.Drawing.Size(258, 551);
         this.groupBox3.TabIndex = 6;
         this.groupBox3.TabStop = false;
         this.groupBox3.Text = "Processing";
         // 
         // grdParameter
         // 
         this.grdParameter.Dock = System.Windows.Forms.DockStyle.Top;
         this.grdParameter.Location = new System.Drawing.Point(3, 49);
         this.grdParameter.Name = "grdParameter";
         this.grdParameter.PropertySort = System.Windows.Forms.PropertySort.Categorized;
         this.grdParameter.Size = new System.Drawing.Size(252, 212);
         this.grdParameter.TabIndex = 3;
         this.grdParameter.ToolbarVisible = false;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Dock = System.Windows.Forms.DockStyle.Top;
         this.label2.Location = new System.Drawing.Point(3, 37);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(70, 12);
         this.label2.TabIndex = 8;
         this.label2.Text = "Parameters";
         // 
         // cbxFunc
         // 
         this.cbxFunc.Dock = System.Windows.Forms.DockStyle.Top;
         this.cbxFunc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cbxFunc.FormattingEnabled = true;
         this.cbxFunc.Location = new System.Drawing.Point(3, 17);
         this.cbxFunc.Name = "cbxFunc";
         this.cbxFunc.Size = new System.Drawing.Size(252, 20);
         this.cbxFunc.TabIndex = 2;
         this.cbxFunc.SelectedIndexChanged += new System.EventHandler(this.cbxTest_SelectedIndexChanged);
         // 
         // panel2
         // 
         this.panel2.Controls.Add(this.groupBox2);
         this.panel2.Controls.Add(this.groupBox1);
         this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
         this.panel2.Location = new System.Drawing.Point(0, 0);
         this.panel2.Name = "panel2";
         this.panel2.Size = new System.Drawing.Size(258, 79);
         this.panel2.TabIndex = 9;
         // 
         // groupBox2
         // 
         this.groupBox2.AutoSize = true;
         this.groupBox2.Controls.Add(this.btnZoomReset);
         this.groupBox2.Controls.Add(this.btnFitZoom);
         this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
         this.groupBox2.Location = new System.Drawing.Point(163, 0);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(95, 79);
         this.groupBox2.TabIndex = 5;
         this.groupBox2.TabStop = false;
         this.groupBox2.Text = "Zoom";
         // 
         // btnZoomReset
         // 
         this.btnZoomReset.Location = new System.Drawing.Point(6, 20);
         this.btnZoomReset.Name = "btnZoomReset";
         this.btnZoomReset.Size = new System.Drawing.Size(75, 23);
         this.btnZoomReset.TabIndex = 3;
         this.btnZoomReset.Text = "Original";
         this.btnZoomReset.UseVisualStyleBackColor = true;
         this.btnZoomReset.Click += new System.EventHandler(this.btnZoomReset_Click);
         // 
         // btnFitZoom
         // 
         this.btnFitZoom.Location = new System.Drawing.Point(6, 49);
         this.btnFitZoom.Name = "btnFitZoom";
         this.btnFitZoom.Size = new System.Drawing.Size(75, 23);
         this.btnFitZoom.TabIndex = 3;
         this.btnFitZoom.Text = "Fit";
         this.btnFitZoom.UseVisualStyleBackColor = true;
         this.btnFitZoom.Click += new System.EventHandler(this.btnFitZoom_Click);
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.btnLenna);
         this.groupBox1.Controls.Add(this.btnLoad);
         this.groupBox1.Controls.Add(this.btnClipboard);
         this.groupBox1.Controls.Add(this.btnLive);
         this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
         this.groupBox1.Location = new System.Drawing.Point(0, 0);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(163, 79);
         this.groupBox1.TabIndex = 4;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Image";
         // 
         // btnLenna
         // 
         this.btnLenna.Location = new System.Drawing.Point(6, 20);
         this.btnLenna.Name = "btnLenna";
         this.btnLenna.Size = new System.Drawing.Size(75, 23);
         this.btnLenna.TabIndex = 0;
         this.btnLenna.Text = "Lenna";
         this.btnLenna.UseVisualStyleBackColor = true;
         this.btnLenna.Click += new System.EventHandler(this.btnLenna_Click);
         // 
         // btnLoad
         // 
         this.btnLoad.Location = new System.Drawing.Point(80, 20);
         this.btnLoad.Name = "btnLoad";
         this.btnLoad.Size = new System.Drawing.Size(75, 23);
         this.btnLoad.TabIndex = 2;
         this.btnLoad.Text = "Load";
         this.btnLoad.UseVisualStyleBackColor = true;
         this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
         // 
         // btnClipboard
         // 
         this.btnClipboard.Location = new System.Drawing.Point(6, 49);
         this.btnClipboard.Name = "btnClipboard";
         this.btnClipboard.Size = new System.Drawing.Size(75, 23);
         this.btnClipboard.TabIndex = 1;
         this.btnClipboard.Text = "Clipboard";
         this.btnClipboard.UseVisualStyleBackColor = true;
         this.btnClipboard.Click += new System.EventHandler(this.btnClipboard_Click);
         // 
         // btnLive
         // 
         this.btnLive.Location = new System.Drawing.Point(80, 49);
         this.btnLive.Name = "btnLive";
         this.btnLive.Size = new System.Drawing.Size(75, 23);
         this.btnLive.TabIndex = 3;
         this.btnLive.Text = "Live";
         this.btnLive.UseVisualStyleBackColor = true;
         this.btnLive.Click += new System.EventHandler(this.btnLive_Click);
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
         this.tableLayoutPanel1.Location = new System.Drawing.Point(258, 0);
         this.tableLayoutPanel1.Name = "tableLayoutPanel1";
         this.tableLayoutPanel1.RowCount = 2;
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this.tableLayoutPanel1.Size = new System.Drawing.Size(918, 630);
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
         this.chtDst.Location = new System.Drawing.Point(462, 318);
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
         this.chtDst.Size = new System.Drawing.Size(453, 309);
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
         this.chtSrc.Location = new System.Drawing.Point(3, 318);
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
         this.chtSrc.Size = new System.Drawing.Size(453, 309);
         this.chtSrc.TabIndex = 1;
         this.chtSrc.Text = "chart1";
         // 
         // statusStrip1
         // 
         this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblGrabTime,
            this.lblProcessingTime,
            this.lblLog});
         this.statusStrip1.Location = new System.Drawing.Point(0, 630);
         this.statusStrip1.Name = "statusStrip1";
         this.statusStrip1.Size = new System.Drawing.Size(1176, 22);
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
         // lblLog
         // 
         this.lblLog.Name = "lblLog";
         this.lblLog.Size = new System.Drawing.Size(27, 17);
         this.lblLog.Text = "log:";
         // 
         // pbxDst
         // 
         this.pbxDst.AxisXInvert = false;
         this.pbxDst.AxisXYFlip = false;
         this.pbxDst.AxisYInvert = false;
         this.pbxDst.CenterLineColor = System.Drawing.Color.Yellow;
         this.pbxDst.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pbxDst.DrawCenterLine = true;
         this.pbxDst.DrawImage = null;
         this.pbxDst.DrawPixelValue = true;
         this.pbxDst.DrawPixelValueZoom = 30F;
         this.pbxDst.EnableMousePan = true;
         this.pbxDst.EnableWheelZoom = true;
         this.pbxDst.Location = new System.Drawing.Point(462, 3);
         this.pbxDst.Name = "pbxDst";
         this.pbxDst.Pan = new System.Drawing.SizeF(0F, 0F);
         this.pbxDst.ShowPixelInfo = true;
         this.pbxDst.Size = new System.Drawing.Size(453, 309);
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
         this.pbxSrc.CenterLineColor = System.Drawing.Color.Yellow;
         this.pbxSrc.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pbxSrc.DrawCenterLine = true;
         this.pbxSrc.DrawImage = null;
         this.pbxSrc.DrawPixelValue = true;
         this.pbxSrc.DrawPixelValueZoom = 30F;
         this.pbxSrc.EnableMousePan = true;
         this.pbxSrc.EnableWheelZoom = true;
         this.pbxSrc.Location = new System.Drawing.Point(3, 3);
         this.pbxSrc.Name = "pbxSrc";
         this.pbxSrc.Pan = new System.Drawing.SizeF(0F, 0F);
         this.pbxSrc.ShowPixelInfo = true;
         this.pbxSrc.Size = new System.Drawing.Size(453, 309);
         this.pbxSrc.TabIndex = 0;
         this.pbxSrc.TabStop = false;
         this.pbxSrc.Zoom = 1F;
         this.pbxSrc.ZoomMax = 100F;
         this.pbxSrc.ZoomMin = 0.1F;
         this.pbxSrc.ZoomStep = 1.2F;
         // 
         // FormMain
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(1176, 652);
         this.Controls.Add(this.tableLayoutPanel1);
         this.Controls.Add(this.panel1);
         this.Controls.Add(this.statusStrip1);
         this.Name = "FormMain";
         this.Text = "OpenCV Test";
         this.panel1.ResumeLayout(false);
         this.groupBox3.ResumeLayout(false);
         this.groupBox3.PerformLayout();
         this.panel2.ResumeLayout(false);
         this.panel2.PerformLayout();
         this.groupBox2.ResumeLayout(false);
         this.groupBox1.ResumeLayout(false);
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
      private System.Windows.Forms.Button btnClipboard;
      private System.Windows.Forms.StatusStrip statusStrip1;
      private System.Windows.Forms.ToolStripStatusLabel lblProcessingTime;
      private System.Windows.Forms.ToolStripStatusLabel lblGrabTime;
      private System.Windows.Forms.Button btnLenna;
      private System.Windows.Forms.Button btnZoomReset;
      private System.Windows.Forms.Button btnFitZoom;
      private System.Windows.Forms.GroupBox groupBox3;
      private System.Windows.Forms.PropertyGrid grdParameter;
      private System.Windows.Forms.ComboBox cbxFunc;
      private System.Windows.Forms.GroupBox groupBox2;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.ToolStripStatusLabel lblLog;
      private System.Windows.Forms.Label label2;
      public System.Windows.Forms.DataVisualization.Charting.Chart chtSrc;
      public System.Windows.Forms.DataVisualization.Charting.Chart chtDst;
      public ZoomPictureBox pbxDst;
      public ZoomPictureBox pbxSrc;
      private System.Windows.Forms.Panel panel2;
   }
}

