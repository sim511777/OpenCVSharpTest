using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using Vector = System.Windows.Vector;

namespace OpenCVSharpTest {
   class ZoomPictureBox : PictureBox {
      private Image drawImage = null;
      public Image DrawImage {
         get { return this.drawImage; }
         set { this.drawImage = value; this.Invalidate(); }
      }

      private float zoom= 1;
      public float Zoom {
         get { return this.zoom; }
         set { this.zoom = value; this.Invalidate(); }
      }

      public SizeF pan = new SizeF(0, 0);
      public SizeF Pan {
         get { return this.pan; }
         set { this.pan = value; this.Invalidate(); }
      }

      public float ZoomStep { get; set; } = 1.1f;
      public float ZoomMin { get; set; } = 0.01f;
      public float ZoomMax { get; set; } = 100f;
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
         this.Paint += new PaintEventHandler(this.ZoomPictureBox_Paint);
      }

      private void ZoomPictureBox_Paint(object sender, PaintEventArgs e) {
         if (this.drawImage == null)
            return;
         var g = e.Graphics;
         g.InterpolationMode = InterpolationMode.NearestNeighbor;
         g.DrawImage(this.drawImage, this.pan.Width, this.pan.Height, this.DrawImage.Width*this.zoom, this.DrawImage.Height*this.zoom);
      }

      private void ZoomPictureBox_MouseWheel(object sender, MouseEventArgs e) {
         if (this.EnableWheelZoom == false)
            return;
         float factor = ((e.Delta > 0) ? this.ZoomStep : (1 / this.ZoomStep));
         Vector vM = new Vector(e.Location.X, e.Location.Y);
         Vector vI = new Vector(this.pan.Width, this.pan.Height);
         Vector vI2 = (vI-vM)*factor+vM;
         this.pan.Width = (float)vI2.X;
         this.pan.Height = (float)vI2.Y;
         this.Zoom *= factor;
      }

      private bool mousePan = false;
      private Point ptOld = new Point();
      private void ZoomPictureBox_MouseDown(object sender, MouseEventArgs e) {
         if (this.EnableMousePan == false)
            return;

         if (e.Button != MouseButtons.Left)
            return;
         this.mousePan = true;
         this.ptOld = e.Location;
      }

      private void ZoomPictureBox_MouseUp(object sender, MouseEventArgs e) {
         if (this.EnableMousePan == false)
            return;

         if (e.Button != MouseButtons.Left)
            return;
         this.mousePan = false;
      }

      private void ZoomPictureBox_MouseMove(object sender, MouseEventArgs e) {
         if (this.EnableMousePan == false)
            return;

         if (!this.mousePan)
            return;
         this.Pan += (Size)e.Location - (Size)this.ptOld;
         this.ptOld = e.Location;
      }
   }
}
