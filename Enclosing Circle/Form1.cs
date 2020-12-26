using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Enclosing_Circle
{

    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            MyPoints = new ArrayList();
            g = this.MainDrawingArea.CreateGraphics();
            p = new MyPoint[1000];
            b = new MyPoint[3];
            sec = new Circle();
            prev_x = prev_y = prev_width = prev_height = 0;
        }

        private MyPoint[] p;					
        private int n = 0;					// numarul de puncte
        private MyPoint[] b;					
        private Circle sec;				// Smallest Enclosing Circle
        private double prev_x, prev_y, prev_width, prev_height;
        private ArrayList MyPoints;
        private Graphics g;

        private Circle findSec(int n, MyPoint[] p, int m, MyPoint[] b)
        {
            Circle sec = new Circle();

            // Compune cel mai mic cerc definit de B
            if (m == 1)
            {
                sec = new Circle(b[0]);
            }
            else if (m == 2)
            {
                sec = new Circle(b[0], b[1]);
            }
            else if (m == 3)
            {
                return new Circle(b[0], b[1], b[2]);
            }

            // Verifica daca toata punctele sunt in cerc
            for (int i = 0; i < n; i++)
            {
                // Daca un punct este in afara cercului
                if (sec.belongsToCircle(p[i]) == -1)
                {
                    // Recursiv
                    b[m] = new MyPoint(p[i].getX(), p[i].getY());
                    
                    sec = findSec(i, p, m + 1, b);
                }
            }

            return sec;
        }


        private void MainDrawingArea_MouseClick(object sender, MouseEventArgs e)
        {
            g.DrawArc(new Pen(Color.Red), (float)e.X, (float)e.Y, (float)4.0, (float)4.0, (float)0.0, (float)360.0);
            p[n++] = new MyPoint(e.X, e.Y);
            sec = findSec(n, p, 0, b);
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"Log.txt", true))
            {
                file.WriteLine("Num MyMyPoints: {0}", n);
                for (int i = 0; i < n; i++)
                {
                    string formatString = String.Format("Center {0} {1} MyPoint {2} {3} Radius: {4} Distance: {5}",
                        sec.getCenter().getX(), sec.getCenter().getY(), p[i].getX(), p[i].getY(), sec.getRadius(), sec.getCenter().distance(p[i]));
                    file.WriteLine(formatString);
                }
                file.WriteLine("");
            }
            if (n > 1)
            {
                try
                {
                    MyPoint center = sec.getCenter();
                    int r = (int)sec.getRadius();
                    if (prev_height > 0)
                    {
                        g.DrawArc(new Pen(Color.White), (float)prev_x, (float)prev_y, (float)prev_width, (float)prev_height, 0, 360);
                    }
                    double x = center.getX() - r; prev_x = x;
                    double y = center.getY() - r; prev_y = y;
                    double width = 2 * r; prev_width = width;
                    int height = 2 * r; prev_height = height;
                    g.DrawArc(new Pen(Color.Blue), (float)x, (float)y, (float)width, (float)height, 0, 360);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void ClearPoints_Click_1(object sender, EventArgs e)
        {
            Bitmap cleanBitmap = new Bitmap(this.MainDrawingArea.Width, this.MainDrawingArea.Height);
            this.MainDrawingArea.Image = cleanBitmap;
            p = new MyPoint[1000];
            b = new MyPoint[3];
            sec = new Circle();
            n = 0; prev_x = prev_y = prev_height = prev_width = 0;
        }

    }
}
