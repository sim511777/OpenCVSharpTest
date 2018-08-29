using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;

namespace ShimLib {
   class ListViewItemComparer : IComparer {
      private int col;
      private SortOrder order;
      private SortType sortType;
      public ListViewItemComparer(int column, SortOrder order, SortType sortType) {
         col = column;
         this.order = order;
         this.sortType = sortType;
      }
      public int Compare(object x, object y) {
         int returnVal = -1;
         // 문자인지 숫자인지에 따라 데이터 비교
         if (sortType == SortType.Number) {
            double numX = ((ListViewItem)x).SubItems[col].Text.ToFloat();
            double numY = ((ListViewItem)y).SubItems[col].Text.ToFloat();
            returnVal = (numX==numY) ? 0 : (numX>numY?1:-1);
         } else {
            returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
         }
         // 내림차순이면 부호 반대
         if (order == SortOrder.Descending)
            returnVal *= -1;

         return returnVal;
      }
   }
}
