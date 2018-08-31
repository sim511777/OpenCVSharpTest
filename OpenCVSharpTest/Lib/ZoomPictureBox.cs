using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using ShimLib;
using System.Windows;
using System.Drawing.Imaging;
using Point = System.Drawing.Point;
using Size = System.Drawing.Size;

namespace ShimLib {
   class ZoomPictureBox : PictureBox {
      private Func<int, int, Tuple<string, Brush>> FuncGetPixelValueDisp = null;

      // 이미지
      public Bitmap DrawImage { get; set; } = null;
      public float Zoom { get; set; } = 1;
      public SizeF Pan { get; set; } = new SizeF(0, 0);
      public float ZoomStep { get; set; } = 1.2f;
      public float ZoomMin { get; set; } = 0.1f;
      public float ZoomMax { get; set; } = 10f;
      public bool EnableWheelZoom { get; set; } = true;
      public bool EnableMousePan { get; set; } = true;
      public bool ShowPixelInfo { get; set; } = true;
      public bool DrawPixelValue { get; set; } = true;
      public float DrawPixelValueZoom { get; set; } = 30f;
      public bool DrawCenterLine { get; set; } = true;
      public Color CenterLineColor { get; set; } = Color.Yellow;

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

      public void ResetZoom() {
         this.Pan = new SizeF(0, 0);
         this.Zoom = 1f;
         this.Invalidate();
      }

      public void FitZoom() {
         if (this.DrawImage == null) {
            this.ResetZoom();
            return;
         }
         
         float scale1 = (float)this.ClientRectangle.Height / this.DrawImage.Height;
         float scale2 = (float)this.ClientRectangle.Width / this.DrawImage.Width;
         this.Zoom = Math.Min(scale1, scale2).Range(this.ZoomMin, this.ZoomMax);
         float panX = (this.ClientRectangle.Width - this.DrawImage.Width * this.Zoom) / 2;
         float panY = (this.ClientRectangle.Height - this.DrawImage.Height * this.Zoom) / 2;
         this.Pan = new SizeF(panX, panY);

         this.Invalidate();
      }

      public void SetFuncGetPixelValueDisp(Func<int, int, Tuple<string, Brush>> FuncGetPixelValueDisp) {
         this.FuncGetPixelValueDisp = FuncGetPixelValueDisp;
      }

      public PointF WindowToReal(Point ptWnd) {
         float realX = (ptWnd.X - this.Pan.Width )/this.Zoom;
         float realY = (ptWnd.Y - this.Pan.Height)/this.Zoom;
         return new PointF(realX, realY);
      }

      public Point RealToWindow(PointF ptReal) {
         float wndX = ptReal.X * this.Zoom + this.Pan.Width;
         float wndY = ptReal.Y * this.Zoom + this.Pan.Height;
         return new Point((int)wndX, (int)wndY);
      }

      private Tuple<string, Brush> GetBuiltinDispPixelValue(int x, int y) {
         if (this.DrawImage == null)
            return Tuple.Create("0", Brushes.Black);
         if (x < 0 || x >= this.DrawImage.Width || y < 0 || y >= this.DrawImage.Height) {
            if (this.DrawImage.PixelFormat == PixelFormat.Format8bppIndexed)
               return Tuple.Create("0", Brushes.Black);
            else
               return Tuple.Create("0,0,0", Brushes.Black);
         }

         Color col = this.DrawImage.GetPixel(x, y);
         string text =
            (this.DrawImage.PixelFormat == PixelFormat.Format8bppIndexed)
            ? string.Format("{0}", (col.R + col.G + col.B)/3)
            : string.Format("{0},{1},{2}", col.R, col.G, col.B);
         var br = ((col.R + col.G + col.B) / 3 < 128) ? Brushes.Yellow : Brushes.Blue;
         return Tuple.Create(text, br);
      }

      private void ZoomPictureBox_Paint(object sender, PaintEventArgs e) {
         var g = e.Graphics;

         if (this.DrawImage != null) {
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.PixelOffsetMode = PixelOffsetMode.Half;
            
            // 이미지 표시
            g.DrawImage(this.DrawImage, this.Pan.Width, this.Pan.Height, this.DrawImage.Width*this.Zoom, this.DrawImage.Height*this.Zoom);
            
            // 이미지 개별 픽셀 값 표시
            if (this.DrawPixelValue && this.Zoom >= this.DrawPixelValueZoom) {
               PointF ptMin = this.WindowToReal(new Point(0, 0));
               PointF ptMax = this.WindowToReal(new Point(this.ClientSize.Width, this.ClientSize.Height));
               int x1 = ((int)Math.Floor(ptMin.X)).Range(0, this.DrawImage.Width - 1);
               int x2 = ((int)Math.Floor(ptMax.X)).Range(0, this.DrawImage.Width - 1);
               int y1 = ((int)Math.Floor(ptMin.Y)).Range(0, this.DrawImage.Height - 1);
               int y2 = ((int)Math.Floor(ptMax.Y)).Range(0, this.DrawImage.Height - 1);
               for (int y = y1; y <= y2; y++) {
                  for (int x = x1; x <= x2; x++) {
                     Tuple<string, Brush> dispPixel;
                     if (this.FuncGetPixelValueDisp != null) {
                        dispPixel = this.FuncGetPixelValueDisp(x, y);
                     } else {
                        dispPixel = GetBuiltinDispPixelValue(x, y);
                     }
                     var pt = this.RealToWindow(new Point(x, y));
                     g.DrawString(dispPixel.Item1, SystemFonts.DefaultFont, dispPixel.Item2, pt);
                  }
               }
            }

            // 센터라인 표시
            if (this.DrawCenterLine) {
               Pen pen = new Pen(this.CenterLineColor);
               pen.DashStyle = DashStyle.Dot;
               Point ptH1 = new Point(0, this.DrawImage.Height/2);
               Point ptH2 = new Point(this.DrawImage.Width, this.DrawImage.Height/2);
               Point ptV1 = new Point(this.DrawImage.Width/2, 0);
               Point ptV2 = new Point(this.DrawImage.Width/2, this.DrawImage.Height);
               g.DrawLine(pen, RealToWindow(ptH1), RealToWindow(ptH2));
               g.DrawLine(pen, RealToWindow(ptV1), RealToWindow(ptV2));
               pen.Dispose();
            }
         }

         // 상단 픽셀 정보 표시
         var drawSize = g.MeasureString(this.pixelInfo, SystemFonts.DefaultFont);
         g.FillRectangle(Brushes.White, 0, 0, drawSize.Width, drawSize.Height);
         g.DrawString(pixelInfo, SystemFonts.DefaultFont, Brushes.Black, 0, 0);
      }

      private void ZoomPictureBox_MouseWheel(object sender, MouseEventArgs e) {
         if (this.EnableWheelZoom == false)
            return;
         float factor = ((e.Delta > 0) ? this.ZoomStep : (1 / this.ZoomStep));
         var zoomTemp = (this.Zoom * factor).Range(this.ZoomMin, this.ZoomMax);
         factor = zoomTemp/this.Zoom;
         Vector vM = new Vector(e.Location.X, e.Location.Y);
         Vector vI = new Vector(this.Pan.Width, this.Pan.Height);
         Vector vI2 = (vI-vM)*factor+vM;
         this.Pan = new SizeF((float)vI2.X, (float)vI2.Y);
         this.Zoom *= factor;
         this.Invalidate();
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

      private string pixelInfo = string.Empty;
      private void ZoomPictureBox_MouseMove(object sender, MouseEventArgs e) {
         if (this.EnableMousePan && this.mousePan) {
            this.Pan += (Size)e.Location - (Size)this.ptOld;
            this.ptOld = e.Location;
         }

         if (this.ShowPixelInfo) {
            PointF ptReal = this.WindowToReal(e.Location);
            Point ptRealInt = new Point((int)Math.Floor(ptReal.X), (int)Math.Floor(ptReal.Y));
            Color col = Color.Black;
            if (this.DrawImage != null) {
               if (ptRealInt.X >= 0 && ptRealInt.X < this.DrawImage.Width && ptRealInt.Y >= 0 && ptRealInt.Y < this.DrawImage.Height) {
                  col = this.DrawImage.GetPixel(ptRealInt.X, ptRealInt.Y);
               }
            }
            Tuple<string, Brush> dispPixel;
            if (this.FuncGetPixelValueDisp != null) {
               dispPixel = this.FuncGetPixelValueDisp(ptRealInt.X, ptRealInt.Y);
            } else {
               dispPixel = GetBuiltinDispPixelValue(ptRealInt.X, ptRealInt.Y);
            }
            this.pixelInfo = $"({ptRealInt.X},{ptRealInt.Y})[{dispPixel.Item1}]";
         }
         this.Invalidate();
      }
   }
}
