using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dreptunghi
{
    public partial class Form1 : Form
    {
        List<Point> points = new List<Point>();

        public Form1()
        {
            InitializeComponent();

            Random r = new Random();

            for (int i = 0; i < 20; i++)
            {
                Point p = new Point(r.Next() % this.Size.Width - 20, r.Next() % this.Size.Height - 20);
                if (p.X < 20)
                    p.X = 20;
                if (p.Y < 20)
                    p.Y = 20;
                points.Add(p);
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            int minX = this.Size.Width;
            int minY = this.Size.Height;
            int maxX = 0;
            int maxY = 0;

            foreach (Point p in points)
            {
                e.Graphics.DrawEllipse(new Pen(Color.Black), p.X - 2, p.Y - 2, 2, 2);

                if (p.X < minX)
                    minX = p.X;

                if (p.Y < minY)
                    minY = p.Y;

                if (p.X > maxX)
                    maxX = p.X;

                if (p.Y > maxY)
                    maxY = p.Y;
            }

            e.Graphics.DrawRectangle(new Pen(Color.Red), minX, minY, maxX - minX, maxY - minY);
        }
    }
}
