using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Distanta_Puncte
{
    public partial class Form1 : Form
    {
        List<Point> points = new List<Point>();
        List<Point> points2 = new List<Point>();

        public Form1()
        {
            InitializeComponent();

            Random r = new Random();

            for (int i = 0; i < 10; i++)
            {
                Point p = new Point(r.Next() % this.Size.Width - 20, r.Next() % this.Size.Height - 20);
                if (p.X < 20)
                    p.X = 20;
                if (p.Y < 20)
                    p.Y = 20;
                points.Add(p);
            }

            for (int i = 0; i < 10; i++)
            {
                Point p2 = new Point(r.Next() % this.Size.Width - 20, r.Next() % this.Size.Height - 20);
                if (p2.X < 20)
                    p2.X = 20;
                if (p2.Y < 20)
                    p2.Y = 20;
                points2.Add(p2);
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {            
            Point apropiat = new Point(0, 0);

            foreach (Point p in points)
            {
                e.Graphics.DrawEllipse(new Pen(Color.Black), p.X - 2, p.Y - 2, 2, 2);
            }

            foreach (Point p2 in points2)
            {
                e.Graphics.DrawEllipse(new Pen(Color.Red), p2.X - 2, p2.Y - 2, 2, 2);
                double min = this.Size.Width;
                foreach (Point p in points)
                {
                    double dist = Math.Sqrt((p2.X - p.X) * (p2.X - p.X) + (p2.Y - p.Y) * (p2.Y - p.Y));
                    if (dist < min)
                    {
                        min = dist;
                        apropiat = p;
                    }
                }
                e.Graphics.DrawLine(new Pen(Color.Green), p2, apropiat);
            }
        }
    }
}
