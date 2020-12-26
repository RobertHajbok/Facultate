using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Distante_in_plan
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
            Random r = new Random();

            Point q = new Point(r.Next() % this.Size.Width - 20, r.Next() % this.Size.Height - 20);
            if (q.X < 20)
                q.X = 20;
            if (q.Y < 20)
                q.Y = 20;
            e.Graphics.DrawEllipse(new Pen(Color.Green), q.X - 2, q.Y - 2, 3, 3);

            int d = 100;

            foreach (Point p in points)
            { 
                double dist = Math.Sqrt((q.X - p.X) * (q.X - p.X) + (q.Y - p.Y) * (q.Y - p.Y));
                if (dist < d)
                {
                    e.Graphics.DrawEllipse(new Pen(Color.Red), p.X - 2, p.Y - 2, 3, 3);
                }
                else
                {
                    e.Graphics.DrawEllipse(new Pen(Color.Black), p.X - 2, p.Y - 2, 1, 1);
                }
            }
        }
    }
}
