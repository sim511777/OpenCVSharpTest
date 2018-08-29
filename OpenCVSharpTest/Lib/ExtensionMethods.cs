using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;


namespace ShimLib {
   // 확장 메서드 클래스
   public static class ExtensionMethods {
      // 프로그레스바 Value 노애니
      public static void SetValueNoAnimation(this ProgressBar pb, int value) {
         // To get around the progressive animation, we need to move the 
         // progress bar backwards.
         if (value == pb.Maximum) {
            // Special case as value can't be set greater than Maximum.
            pb.Maximum = value + 1;     // Temporarily Increase Maximum
            pb.Value = value + 1;       // Move past
            pb.Maximum = value;         // Reset maximum
         } else {
            pb.Value = value + 1;       // Move past
         }
         pb.Value = value;               // Move to correct value
      }

      // SizeF의 실수곱
      public static SizeF Mul(this SizeF size, float value) {
         return new SizeF(size.Width * value, size.Height * value);
      }

      // 프로퍼티그리드 컬럼 사이즈 변경
      public static void SetLabelColumnWidth(this PropertyGrid grid, int width) {
         if (grid == null)
            return;

         FieldInfo fi = grid.GetType().GetField("gridView", BindingFlags.Instance | BindingFlags.NonPublic);
         if (fi == null)
            return;

         Control view = fi.GetValue(grid) as Control;
         if (view == null)
            return;

         MethodInfo mi = view.GetType().GetMethod("MoveSplitterTo", BindingFlags.Instance | BindingFlags.NonPublic);
         if (mi == null)
            return;
         mi.Invoke(view, new object[] { width });
      }

      // 숫자변환 함수
      public static int ToInt(this string text) {
         int val = 0;
         bool r = int.TryParse(text, out val);
         return val;
      }
      public static float ToFloat(this string text) {
         float val = 0;
         bool r = float.TryParse(text, out val);
         return val;
      }
      public static double ToDouble(this string text) {
         double val = 0;
         bool r = double.TryParse(text, out val);
         return val;
      }
      public static bool ToBool(this string text) {
         bool val = false;
         bool r = bool.TryParse(text, out val);
         return val;
      }

      // 포인트 거리
      public static float Distance(this PointF pt, float x, float y) {
         return Util.Hypot(pt.X - x, pt.Y - y);
      }
      public static float Distance(this PointF pt1, PointF pt2) {
         return Util.Hypot(pt1.X - pt2.X, pt1.Y - pt2.Y);
      }

      // 컨트롤 더블버퍼링
      public static void SetDoubleBuffered(this Control control, bool isDoubleBuffered) {
         typeof(Control).InvokeMember("DoubleBuffered",
             BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
             null, control, new object[] { isDoubleBuffered });
      }

      // 값 Range
      public static T Range<T>(this T value, T min, T max) where T : IComparable {
         if (value == null)
            return value;
         if (value.CompareTo(min as IComparable) < 0)
            return min;
         if (value.CompareTo(max as IComparable) > 0)
            return max;
         return value;
      }

      // 리스트뷰에 아이템 추가 (리스트뷰, 태그, 아이템+서브아이템모목록
      public static ListViewItem AddItem(this ListView lvw, object tag, params object[] objs) {
         ListViewItem item = new ListViewItem(objs.Select((obj) => obj.ToString()).ToArray());
         item.Tag = tag;
         lvw.Items.Add(item);
         return item;
      }

      // 컬럼 헤더 소터
      public static ColumnHeader AddSort(this ListView.ColumnHeaderCollection headers, string text, int width, SortOrder sortOrder, SortType sortType) {
         var head = headers.Add(text, width);
         head.Tag = new ListViewColumnSorter { text = text, sortOrder = sortOrder, sortType = sortType };
         return head;
      }
      public static void Sort(this ListView lvw, int column) {
         var selCol = lvw.Columns[column];

         if (selCol.Tag == null) {
            return;
         }

         var selSorter = (ListViewColumnSorter)selCol.Tag;
         selSorter.sortOrder = (selSorter.sortOrder == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.Ascending;
         selCol.Text = selSorter.text + ((selSorter.sortOrder == SortOrder.Ascending) ? " ▲" : " ▼");

         foreach (ColumnHeader col in lvw.Columns) {
            var colSorter = (ListViewColumnSorter)col.Tag;
            if (colSorter != selSorter) {
               col.Text = colSorter.text;
               colSorter.sortOrder = SortOrder.None;
            }
         }

         lvw.ListViewItemSorter = new ListViewItemComparer(column, selSorter.sortOrder, selSorter.sortType);
      }

      // 윈도우 10에서 포커스 없이도 휠이 동작 하므로 필요
      public static void DisableNoFocusWheel(this Control ctrl) {
         ctrl.MouseWheel += (sender, e) => {
            if ((sender as Control).Focused == false)
               ((HandledMouseEventArgs)e).Handled = true;
         };
      }
   }

   public enum SortType { String, Number };
   public class ListViewColumnSorter {
      public string text = string.Empty;
      public SortOrder sortOrder = SortOrder.None;
      public SortType sortType = SortType.String;
   }

}
