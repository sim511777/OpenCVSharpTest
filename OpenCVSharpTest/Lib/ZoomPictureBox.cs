﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using ShimLib;
using System.Windows;
using Point = System.Drawing.Point;
using Size = System.Drawing.Size;

namespace ShimLib {
   class ZoomPictureBox : PictureBox {
      private Bitmap drawImage = null;
      public Bitmap DrawImage {
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

      public float ZoomStep { get; set; } = 1.2f;
      public float ZoomMin { get; set; } = 0.1f;
      public float ZoomMax { get; set; } = 10f;
      public bool EnableWheelZoom { get; set; } = true;
      public bool EnableMousePan { get; set; } = true;
      public bool ShowPixelInfo { get; set; } = true;
      public bool DrawPixelValue { get; set; } = true;
      public float DrawPixelValueZoom { get; set; } = 30f;

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
         this.pan = new SizeF(0, 0);
         this.zoom = 1f;
         this.Invalidate();
      }

      public PointF WindowToReal(Point ptWnd) {
         float realX = (ptWnd.X - this.pan.Width )/this.zoom;
         float realY = (ptWnd.Y - this.pan.Height)/this.zoom;
         return new PointF(realX, realY);
      }

      public Point RealToWindow(PointF ptReal) {
         float wndX = ptReal.X * this.zoom + this.pan.Width;
         float wndY = ptReal.Y * this.zoom + this.pan.Height;
         return new Point((int)wndX, (int)wndY);
      }

      private void ZoomPictureBox_Paint(object sender, PaintEventArgs e) {
         var g = e.Graphics;
         g.InterpolationMode = InterpolationMode.NearestNeighbor;
         g.PixelOffsetMode = PixelOffsetMode.Half;
         if (this.drawImage != null) {
            g.DrawImage(this.drawImage, this.pan.Width, this.pan.Height, this.DrawImage.Width*this.zoom, this.DrawImage.Height*this.zoom);
            if (this.DrawPixelValue && this.zoom >= this.DrawPixelValueZoom) {
               PointF ptMin = this.WindowToReal(new Point(0, 0));
               PointF ptMax = this.WindowToReal(new Point(this.ClientSize.Width, this.ClientSize.Height));
               int x1 = ((int)Math.Floor(ptMin.X)).Range(0, this.drawImage.Width - 1);
               int x2 = ((int)Math.Floor(ptMax.X)).Range(0, this.drawImage.Width - 1);
               int y1 = ((int)Math.Floor(ptMin.Y)).Range(0, this.drawImage.Height - 1);
               int y2 = ((int)Math.Floor(ptMax.Y)).Range(0, this.drawImage.Height - 1);
               for (int y = y1; y <= y2; y++) {
                  for (int x = x1; x <= x2; x++) {
                     Color col = this.drawImage.GetPixel(x, y);
                     string colorText = string.Format("{0},{1},{2}", col.R, col.G, col.B);
                     g.DrawString(colorText, SystemFonts.DialogFont, ((col.R + col.G + col.B) / 3 < 128) ? Brushes.Yellow : Brushes.Blue, this.RealToWindow(new Point(x, y)));
                  }
               }
            }
         }
         var drawSize = g.MeasureString(this.pixelInfo, SystemFonts.DefaultFont);
         g.FillRectangle(Brushes.White, 0, 0, drawSize.Width, drawSize.Height);
         g.DrawString(pixelInfo, SystemFonts.DefaultFont, Brushes.Black, 0, 0);
      }

      private void ZoomPictureBox_MouseWheel(object sender, MouseEventArgs e) {
         if (this.EnableWheelZoom == false)
            return;
         float factor = ((e.Delta > 0) ? this.ZoomStep : (1 / this.ZoomStep));
         var zoomTemp = (this.zoom * factor).Range(this.ZoomMin, this.ZoomMax);
         factor = zoomTemp/this.zoom;
         Vector vM = new Vector(e.Location.X, e.Location.Y);
         Vector vI = new Vector(this.pan.Width, this.pan.Height);
         Vector vI2 = (vI-vM)*factor+vM;
         this.pan.Width = (float)vI2.X;
         this.pan.Height = (float)vI2.Y;
         this.zoom *= factor;
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
            this.pan += (Size)e.Location - (Size)this.ptOld;
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
            this.pixelInfo = $"({ptRealInt.X},{ptRealInt.Y})[{col.R},{col.G},{col.B}]";
         }
         this.Invalidate();
      }
   }
}