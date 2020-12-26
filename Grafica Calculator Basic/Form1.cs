using System;
using System.Drawing;
using System.Windows.Forms;

namespace Grafica_Calculator_Basic
{
    public partial class Form1 : Form
    {
        Graphics _g;
        Bitmap _b;
        private readonly Random _r = new Random();


        public Form1()
        {
            InitializeComponent();
        }

        //public void Window(Pen toDraw, int x, int y, int dx, int dy)
        //{
        //    g.DrawLine(toDraw, x - dx/2, y - dy/2, x + dx/2, y - dy/2);
        //    g.DrawLine(toDraw, x + dx / 2, y - dy / 2, x + dx / 2, y + dy / 2);
        //    g.DrawLine(toDraw, x + dx / 2, y + dy / 2, x - dx / 2, y + dy / 2);
        //    g.DrawLine(toDraw, x - dx / 2, y + dy / 2, x - dx / 2, y - dy / 2);
        //}

        public void Window(SolidBrush toFill, Pen toDraw, int x, int y, int dx, int dy)
        {
            _g.FillRectangle(toFill, x - dx / 2, y - dy / 2, dx, dy);
            _g.DrawRectangle(toDraw, x - dx / 2, y - dy / 2, dx, dy);
        }

        public void Cross(Pen toDraw, int x, int y, int dx, int dy)
        {
            _g.DrawLine(toDraw, x, y - dy / 2, x, y + dy / 2);
            _g.DrawLine(toDraw, x - dx / 2, y, x + dx / 2, y);
        }

        public void T1(SolidBrush toFill, Pen toDraw, int x, int y, int dx, int dy, int n, int ux, int uy)
        {
            Window(toFill, toDraw, x, y, dx, dy);
            for (var i = 0; i < n; i++)
            {
                var cx = x - dx / 2 + ux / 2 + _r.Next(dx - ux);
                var cy = y - dy / 2 + uy / 2 + _r.Next(dy - uy);
                var fillColor = Color.FromArgb(_r.Next(256), _r.Next(256),
                    _r.Next(256));
                var fill = new SolidBrush(fillColor);
                Window(fill, toDraw, cx, cy, _r.Next(ux), _r.Next(uy));
            }
        }

        public void Poly(SolidBrush toFill, Pen toDraw, int x, int y, int n, int r1, int r2, float rotate)
        {
            var points = new PointF[n];
            var ua = (2 * (float)Math.PI) / n;
            for (var i = 0; i < n; i++)
            {
                points[i].X = x + r1 * (float)Math.Cos(i * ua + rotate);
                points[i].Y = y + r2 * (float)Math.Sin(i * ua + rotate);
            }

            _g.FillPolygon(toFill, points);
            _g.DrawPolygon(toDraw, points);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            _g = Graphics.FromImage(_b);

            var p01 = new Pen(Color.Black, 2);
            var p02 = new Pen(Color.Firebrick, 1);
            var sb01 = new SolidBrush(Color.DarkOrange);
            var sb02 = new SolidBrush(Color.DarkRed);
            var sb03 = new SolidBrush(Color.Brown);
            var sb04 = new SolidBrush(Color.White);



            //Casa
            T1(sb01, p02, 180, 275, 200, 250, 200, 50, 40);

            //Usa
            Window(sb03, p01, 180, 350, 60, 100);

            //Acoperis
            Poly(sb02, p01, 180, 100, 3, 150, 100, (float)Math.PI / 6);

            //Geam stanga
            Poly(sb04, p01, 120, 200, 8, 30, 30, (float)Math.PI / 8);
            Poly(sb04, p01, 120, 200, 8, 25, 25, (float)Math.PI / 8);
            Cross(p01, 120, 200, 25 * 2, 25 * 2);

            //Geam dreapta
            Poly(sb04, p01, 240, 200, 8, 30, 30, (float)Math.PI / 8);
            Poly(sb04, p01, 240, 200, 8, 25, 25, (float)Math.PI / 8);
            Cross(p01, 240, 200, 25 * 2, 25 * 2);





            //g.DrawLine(p01, 10, 10, 200, 300);
            //g.DrawEllipse(p02, 10, 10, 250, 150);

            //Window(sb02, p01, 100, 100, 70, 80);

            //Cross(p01, 100, 100, 70, 80);

            //T1(sb01, p02, 200, 150, 300, 100, 500, 50, 40);

            //for (float a = 0.0f; a <= (float) Math.PI / 2; a += 0.1f)
            //Poly(sb01, p01, 200, 200, 4, 150, 150, a);

            //Poly(sb01, p01, 200, 200, 8, 170, 170, (float)Math.PI/8);
            //Poly(sb01, p01, 200, 200, 8, 150, 150, (float)Math.PI/8);
            //Cross(p02,200,200,300,300);

            pictureBox1.Image = _b;
        }
    }
}
