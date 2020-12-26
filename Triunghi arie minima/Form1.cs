using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Triunghi_arie_minima
{
    public partial class Form1 : Form
    {
        List<Point> points = new List<Point>();
        List<Point> pointsArie = new List<Point>();

        public Form1()
        {
            InitializeComponent();     

            Random r = new Random();

            for (int i = 0; i < 6; i++)
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
            float min = this.Size.Width * this.Size.Height;
            foreach(Point p in points)
            {
                e.Graphics.DrawEllipse(new Pen(Color.Black), p.X - 2, p.Y - 2, 2, 2);
            }

            for (int i = 0; i < points.Count(); i++)
            {
                for (int j = i + 1; j < points.Count(); j++)
                {
                    for (int k = j + 1; k < points.Count(); k++)
                    {
                        float arie = (Math.Abs(points[i].X * points[j].Y + points[i].Y * points[k].X + points[j].X * points[k].Y - points[j].Y * points[k].X - points[i].Y * points[j].X - points[i].X * points[k].Y)) / 2;
                        if (arie < min)
                        {
                            min = arie;
                            pointsArie.Clear();
                            pointsArie.Add(points[i]);
                            pointsArie.Add(points[j]);
                            pointsArie.Add(points[k]);
                        }
                    }
                }
            }
            e.Graphics.DrawLine(new Pen(Color.Green), pointsArie[0], pointsArie[1]);
            e.Graphics.DrawLine(new Pen(Color.Green), pointsArie[1], pointsArie[2]);
            e.Graphics.DrawLine(new Pen(Color.Green), pointsArie[0], pointsArie[2]);
        }
    }
}
