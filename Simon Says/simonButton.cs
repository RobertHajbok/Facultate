using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Simon_Says
{
    public partial class simonButton : Button
    {
        GraphicsPath path;
        GraphicsPath innerPath;

        private bool _clicked = false;
        public bool Clicked
        {
            get { return _clicked; }
            set
            {
                _clicked = value;
                Invalidate();
            }
        }

        private int _rotation = 0;
        public int Rotation
        {
            get { return _rotation; }
            set { _rotation = value; }
        }

        public simonButton()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            Graphics g = pevent.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Create painting objects
            Brush b = new SolidBrush(this.ForeColor);

            // Create Rectangle To Limit brush area.
            Rectangle rect = new Rectangle(0, 0, 150, 150);

            LinearGradientBrush linearBrush =
              new LinearGradientBrush(rect,
              Color.FromArgb(20, 20, 20),
              this.ForeColor,
              225);

            path = new GraphicsPath();
            innerPath = new GraphicsPath();

            switch (Rotation)
            {
                case 0:
                    {
                        path.AddArc(0, 0, 270, 270, 180, 90);
                        path.AddArc(120, 0, 30, 30, 270, 90);
                        path.AddLine(150, 0, 150, 85);
                        path.AddArc(100, 100, 100, 100, -90, -90);
                        path.AddLine(100, 150, 0, 150);
                        path.AddArc(0, 120, 30, 30, 90, 90);

                        innerPath.AddArc(10, 10, 250, 250, 180, 90);
                        innerPath.AddArc(130, 10, 10, 10, 270, 90);
                        innerPath.AddLine(140, 0, 140, 90);
                        innerPath.AddArc(90, 90, 100, 100, -90, -90);
                        innerPath.AddLine(90, 140, 10, 140);
                        innerPath.AddArc(10, 130, 10, 10, 90, 90);
                    }
                    break;

                case 90:
                    {
                        path.AddArc(-120, 0, 270, 270, 270, 90);
                        path.AddArc(120, 120, 30, 30, 0, 90);
                        path.AddLine(135, 150, 50, 150);
                        path.AddArc(-50, 100, 100, 100, 0, -90);
                        path.AddLine(0, 100, 0, 15);
                        path.AddArc(0, 0, 30, 30, 180, 90);

                        innerPath.AddArc(-110, 10, 250, 250, 270, 90);
                        innerPath.AddArc(130, 130, 10, 10, 0, 90);
                        innerPath.AddLine(130, 140, 60, 140);
                        innerPath.AddArc(-40, 90, 100, 100, 0, -90);
                        innerPath.AddLine(10, 90, 10, 10);
                        innerPath.AddArc(10, 10, 10, 10, 180, 90);
                    }
                    break;

                case 180:
                    {
                        path.AddArc(-120, -120, 270, 270, 0, 90);
                        path.AddArc(0, 120, 30, 30, 90, 90);
                        path.AddLine(0, 135, 0, 50);
                        path.AddArc(-50, -50, 100, 100, 90, -90);
                        path.AddLine(50, 0, 135, 0);
                        path.AddArc(120, 0, 30, 30, 270, 90);

                        innerPath.AddArc(-110, -110, 250, 250, 0, 90);
                        innerPath.AddArc(10, 130, 10, 10, 90, 90);
                        innerPath.AddLine(10, 125, 10, 60);
                        innerPath.AddArc(-40, -40, 100, 100, 90, -90);
                        innerPath.AddLine(60, 10, 135, 10);
                        innerPath.AddArc(130, 10, 10, 10, 270, 90);
                    }
                    break;

                case 270:
                    {
                        path.AddArc(0, -120, 270, 270, 90, 90);
                        path.AddArc(0, 0, 30, 30, 180, 90);
                        path.AddLine(15, 0, 100, 0);
                        path.AddArc(100, -50, 100, 100, 180, -90);
                        path.AddLine(150, 50, 150, 135);
                        path.AddArc(120, 120, 30, 30, 0, 90);

                        innerPath.AddArc(10, -110, 250, 250, 90, 90);
                        innerPath.AddArc(10, 10, 10, 10, 180, 90);
                        innerPath.AddLine(5, 10, 60, 10);
                        innerPath.AddArc(90, -40, 100, 100, 180, -90);
                        innerPath.AddLine(140, 60, 140, 135);
                        innerPath.AddArc(130, 130, 10, 10, 0, 90);
                    }
                    break;
            }

            this.Region = new Region(path);

            PathGradientBrush pgbrush = new PathGradientBrush(innerPath);
            pgbrush.CenterPoint = new Point(75, 75);
            pgbrush.CenterColor = Color.White;
            pgbrush.SurroundColors = new Color[] { Color.FromArgb(250, this.ForeColor) };

            if (_clicked == false)
            {
                g.FillPath(linearBrush, path);
                g.FillPath(b, innerPath);
            }
            else
            {
                g.FillPath(linearBrush, path);
                g.FillPath(pgbrush, innerPath);
            }

            // Dispose of painting objects
            b.Dispose();
            pgbrush.Dispose();
            linearBrush.Dispose();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            _clicked = true;
            base.OnMouseDown(mevent);
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            _clicked = false;
            base.OnMouseUp(mevent);
        }
    }
}
