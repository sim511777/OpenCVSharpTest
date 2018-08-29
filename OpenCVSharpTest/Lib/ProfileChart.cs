using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing.Design;
using System.Windows.Forms.Design;

namespace ShimLib {
   public partial class ProfileChart : UserControl {
      public ProfileChart() {
         InitializeComponent();
      }

      // 데이터를 별도로 보관하지 않는다. 관리 포인트를 일관화 하기 위하여 : 시리즈 포인트리스트에 set/get 
      public double[] Profiles {
         set
	      {
		      this.chtProfile.Series[0].Points.Clear();
            List<double> powerList = value.ToList();
            for (int i = 0; i <= powerList.Count + 1; i++) {
               if (i==0 || i == powerList.Count+1) {
                  int idx = this.chtProfile.Series[0].Points.AddXY(i, 0);
                  this.chtProfile.Series[0].Points[i].AxisLabel = " ";
                  this.chtProfile.Series[0].Points[i].Label = " ";
                  this.chtProfile.Series[0].Points[i].MarkerStyle = MarkerStyle.None;
               } else {
                  int idx = this.chtProfile.Series[0].Points.AddXY(i, powerList[i-1]);
                  this.chtProfile.Series[0].Points[i].AxisLabel = i.ToString();
               }
            } 
	      }
         get {
            List<double> powerList = new List<double>();
            foreach (var point in this.chtProfile.Series[0].Points) {
               if ((int)point.XValue == 0 || (int)point.XValue == this.chtProfile.Series[0].Points.Count-1)
                  continue;   // 0번이랑 끝번은 스킵
               powerList.Add(point.YValues[0]);
            }
            return powerList.ToArray();
         }
      }
      
      private bool m_EscapePressed = false;
      protected override bool ProcessDialogKey(Keys key)
      {
	      if (key == Keys.Escape)
	      {
		      m_EscapePressed = true;
	      }
	      return base.ProcessDialogKey(key);
      }

      public bool EscapePressed
      {
	      get { return m_EscapePressed; }
      }

      int selXIdx = 0;
      private void UpdateSelPoint(int xIdx) {
         selXIdx = xIdx;
         var points = this.chtProfile.Series[0].Points;
         for (int i = 1; i < points.Count-1; i++) {
            if (i == selXIdx) {
               points[i].MarkerStyle = MarkerStyle.Cross;
               points[i].MarkerSize = 12;
               points[i].MarkerColor = Color.Green;
            } else {
               points[i].MarkerStyle = this.chtProfile.Series[0].MarkerStyle;
               points[i].MarkerSize = this.chtProfile.Series[0].MarkerSize;
               points[i].MarkerColor = this.chtProfile.Series[0].MarkerColor;
            }
         }
      }

      private void ProfileEqualize(MouseEventArgs e) {
         if (e.Button != System.Windows.Forms.MouseButtons.Left)
            return;
         double xVal;
         double yVal;
         try {
            xVal = chtProfile.ChartAreas[0].AxisX.PixelPositionToValue(e.X);
            yVal = chtProfile.ChartAreas[0].AxisY.PixelPositionToValue(e.Y);
         } catch {
            return;
         }

         var points = this.chtProfile.Series[0].Points;
         int xIdx = (int)Math.Round(xVal);
         if (xIdx < 1 || xIdx > points.Count-2) {
            return;
         }

         this.UpdateSelPoint(xIdx);
         
         bool bShift =  ((Control.ModifierKeys & Keys.Shift) != Keys.None);
         yVal = Math.Round(yVal);
         if (bShift) yVal = ((int)yVal+2) / 5 * 5;
         if (yVal < 0) yVal = 0;
         if (yVal > 100) yVal = 100;
         points[xIdx].SetValueY(yVal);
         this.chtProfile.Invalidate();
      }

      private void chtProfile_MouseMove(object sender, MouseEventArgs e) {
         this.ProfileEqualize(e);
      }

      private void chtProfile_MouseDown(object sender, MouseEventArgs e) {
         this.ProfileEqualize(e);
      }

      private double GetXVal(int posX) {
         return this.chtProfile.ChartAreas[0].AxisX.PixelPositionToValue(posX);
      }

      private double GetYVal(int posY) {
         return chtProfile.ChartAreas[0].AxisY.PixelPositionToValue(posY);
      }

      private void addPointToolStripMenuItem_Click(object sender, EventArgs e) {
         int xIdx = 0;
         try {
            double XVal = GetXVal(ptPopup.X);
            xIdx = ((int)XVal).Range(0, this.Profiles.Length);
         } catch {
            xIdx = this.Profiles.Length;  // 뒤로 추가 하니깐
         }

         double YVal = 0;
         try {
            YVal = GetYVal(ptPopup.Y).Range(0, 100);
         } catch {
            YVal = 0;
         }

         var list = this.Profiles.ToList();
         list.Insert(xIdx, YVal);
         this.Profiles = list.ToArray();
         this.UpdateSelPoint(xIdx+1);
      }

      private void add10PointToolStripMenuItem_Click(object sender, EventArgs e) {
         var list = this.Profiles.ToList();
         list.AddRange(new double[10]);
         this.Profiles = list.ToArray();
         this.UpdateSelPoint(0);
      }

      private void deletePointToolStripMenuItem_Click(object sender, EventArgs e) {
         if (this.Profiles.Length == 0)
            return;

         int xIdx = 0;
         try {
            double XVal = GetXVal(ptPopup.X);
            xIdx = ((int)Math.Round(XVal)-1).Range(0, this.Profiles.Length-1);
         } catch {
            xIdx = this.Profiles.Length-1;  // 뒤로 추가 하니깐
         }

         var list = this.Profiles.ToList();
         list.RemoveAt(xIdx);
         this.Profiles = list.ToArray();
         this.UpdateSelPoint(0);
      }

      private void deleteAllPointToolStripMenuItem_Click(object sender, EventArgs e) {
         this.Profiles = new double[0];
         this.UpdateSelPoint(0);
      }

      private void resetAllValueZeroToolStripMenuItem_Click(object sender, EventArgs e) {
         this.Profiles = new double[this.Profiles.Length];
      }

      Point ptPopup = new Point();
      private void chtProfile_MouseClick(object sender, MouseEventArgs e) {
         if (e.Button == MouseButtons.Right) {
            ptPopup = e.Location;
            this.menuProfile.Show(PointToScreen(e.Location));
         };
      }

      private void chtProfile_KeyDown(object sender, KeyEventArgs e) {
         var points = this.chtProfile.Series[0].Points;
         if (e.KeyCode == Keys.Right) {
            int xIdx  = (selXIdx+1).Range(1, points.Count-2);
            this.UpdateSelPoint(xIdx);
            return;
         }
         if (e.KeyCode == Keys.Left) {
            int xIdx  = (selXIdx-1).Range(1, points.Count-2);
            this.UpdateSelPoint(xIdx);
            return;
         }

         if (this.selXIdx == 0)
            return;
         if (this.selXIdx <= 0 || this.selXIdx >= points.Count-1)
            return;

         int addValue = ((Control.ModifierKeys & Keys.Shift) != Keys.None) ? 5 : 1;
         if (e.KeyCode == Keys.Up) {
            points[this.selXIdx].YValues[0] = (((int)(points[this.selXIdx].YValues[0]+addValue))/addValue*addValue).Range(0, 100);
            this.chtProfile.Refresh();
         }
         if (e.KeyCode == Keys.Down) {
            points[this.selXIdx].YValues[0] = (((int)(points[this.selXIdx].YValues[0]-1))/addValue*addValue).Range(0, 100);
            this.chtProfile.Refresh();
         }
      }

      private void chtProfile_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e) {
         switch (e.KeyCode) {
            case Keys.Down:
            case Keys.Up:
            case Keys.Left:
            case Keys.Right:
               e.IsInputKey = true;
               break;
         }
      }
   }

   class PropertyProfileEditor : UITypeEditor {
      public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) {
         return UITypeEditorEditStyle.DropDown;
      }
      public override bool IsDropDownResizable { get { return true; } }
      public override object EditValue(ITypeDescriptorContext context, System.IServiceProvider provider, object value) {
         IWindowsFormsEditorService svc = provider.GetService(typeof(IWindowsFormsEditorService)) as IWindowsFormsEditorService;
         ProfileChart ctrl = new ProfileChart();
         double[] values = value as double[];
         ctrl.Profiles = values;
         svc.DropDownControl(ctrl);
         if (!ctrl.EscapePressed)
            value = ctrl.Profiles;

         return value;
      }
   }
}
