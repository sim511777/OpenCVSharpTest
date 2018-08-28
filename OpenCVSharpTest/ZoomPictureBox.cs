using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace OpenCVSharpTest {
   class ZoomPictureBox : PictureBox {
      public float Zoom { get; set; } = 1;
      public Point Pan = new Point(0, 0);

      public float ZoomScale { get; set; } = 1.2f;
      public bool EnableWheelZoom { get; set; } = true;
      public bool EnableMousePan { get; set; } = true;

      public bool AxisXInvert { get; set; } = false;
      public bool AxisYInvert { get; set; } = false;
      public bool AxisXYFlip { get; set; } = false;
      public Point AxisOrigin = new Point(0, 0);

      public ZoomPictureBox() {
         this.MouseWheel += new MouseEventHandler(this.ZoomPictureBox_MouseWheel);
         this.MouseDown += new MouseEventHandler(this.ZoomPictureBox_MouseDown);
         this.MouseUp += new MouseEventHandler(this.ZoomPictureBox_MouseUp);
         this.MouseMove += new MouseEventHandler(this.ZoomPictureBox_MouseMove);
      }

      private void ZoomPictureBox_MouseWheel(object sender, MouseEventArgs e) {
         this.Zoom *= (e.Delta > 0) ? this.ZoomScale : 1 / this.ZoomScale;
         this.Invalidate();
      }

      private bool mousePan = false;
      private Point ptOld = new Point();
      private void ZoomPictureBox_MouseDown(object sender, MouseEventArgs e) {
         if (e.Button != MouseButtons.Left)
            return;
         this.mousePan = true;
         this.ptOld = e.Location;
      }

      private void ZoomPictureBox_MouseUp(object sender, MouseEventArgs e) {
         if (e.Button != MouseButtons.Left)
            return;
         this.mousePan = false;
      }

      private void ZoomPictureBox_MouseMove(object sender, MouseEventArgs e) {
         if (!this.mousePan)
            return;
         var delta = Point.Subtract(e.Location, (Size)this.ptOld);
         this.Pan.Offset(delta);
         this.ptOld = e.Location;
         this.Invalidate();
      }
   }
}
