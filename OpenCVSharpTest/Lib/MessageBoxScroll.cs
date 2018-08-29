using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShimLib {
   public partial class MessageBoxScroll : Form {
      private MessageBoxScroll() {
         InitializeComponent();
      }

      public static DialogResult Show(IWin32Window owner, string text, string caption) {
         MessageBoxScroll form = new MessageBoxScroll();
         form.Text = caption;
         form.tbxContents.Text = text;
         form.tbxContents.SelectionStart = form.tbxContents.TextLength;
         form.tbxContents.SelectionLength = 0;
         return form.ShowDialog(owner);
      }
   }
}
