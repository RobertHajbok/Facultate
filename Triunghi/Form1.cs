using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Triunghi
{
    public partial class Form1 : Form
    {
        Graphics g;
        Bitmap b;
        Pen p;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(b);
            p = new Pen(Color.White);
            pictureBox1.Image = b;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //g.Clear(Color.Black);

            //Pen p = new Pen(Color.White);

            //Random rand = new Random();
            //for (int i = 0; i < 1000; i++)
            //{
            //    g.DrawEllipse(p, rand.Next() % pictureBox1.Width, rand.Next() % pictureBox1.Height, 1, 1);
            //}

            //pictureBox1.Refresh();

            g.Clear(Color.Black);

            PointF[] P = new PointF[1000];
            Random r = new Random();

            float MinP = r.Next();
            PointF Min1 = new Point();
            PointF Min2 = new Point();
            PointF Min3 = new Point();

            // d = √[(x-x1)²+(y - y1)²]

            for (int i = 0; i < P.Length; i++)
            {
                P[i].X = r.Next() % pictureBox1.Width;
                P[i].Y = r.Next() % pictureBox1.Height;

                g.DrawEllipse(p, P[i].X, P[i].Y, 1, 1);
            }

            PointF p1 = new Point();
            PointF p2 = new Point();
            PointF p3 = new Point();

            for (int i = 0; i < 10000; i++)
            {

                //do
                //{
                p1.X = P[r.Next() % P.Length].X;
                p1.Y = P[r.Next() % P.Length].Y;

                p2.X = P[r.Next() % P.Length].X;
                p2.Y = P[r.Next() % P.Length].Y;

                p3.X = P[r.Next() % P.Length].X;
                p3.Y = P[r.Next() % P.Length].Y;

                //Console.WriteLine("(" + p1.X + "," + p1.Y + ")" + "(" + p2.X + "," + p2.Y + ")" + "(" + p3.X + "," + p3.Y + ")");
                //}
                //while ((p1.X == p2.X) || (p1.Y == p2.Y) || (p2.X == p3.X) || (p2.Y == p3.Y) || (p3.X == p1.X) || (p3.Y != p1.Y));

                float distanta1 = (float)Math.Sqrt(((p1.X - p2.X) * (p1.X - p2.X)) + ((p1.Y - p2.Y) * (p1.Y - p2.Y)));
                //Console.WriteLine("dist aaaaa " + (p1.X - p2.X));

                float distanta2 = (float)Math.Sqrt(((p2.X - p3.X) * (p2.X - p3.X)) + ((p2.Y - p3.Y) * (p2.Y - p3.Y)));
                float distanta3 = (float)Math.Sqrt(((p3.X - p1.X) * (p3.X - p1.X)) + ((p3.Y - p1.Y) * (p3.Y - p1.Y)));

                float distantaTotala = distanta1 + distanta2 + distanta3;
                //Console.WriteLine("dist totala = " + distantaTotala);

                if (distantaTotala < MinP)
                {
                    //Console.WriteLine("am gasit triunghi mai mic");
                    MinP = distantaTotala;

                    Min1.X = p1.X;
                    Min1.Y = p1.Y;

                    Min2.X = p2.X;
                    Min2.Y = p2.Y;

                    Min3.X = p3.X;
                    Min3.Y = p3.Y;

                    //Console.WriteLine("(" + Min1.X + "," + Min1.Y + ")");
                    //Console.WriteLine("(" + Min2.X + "," + Min2.Y + ")");
                    //Console.WriteLine("(" + Min3.X + "," + Min3.Y + ")");
                }
            }

            Pen pen = new Pen(Color.Red);

            g.DrawLine(pen, Min1, Min2);
            g.DrawLine(pen, Min2, Min3);
            g.DrawLine(pen, Min3, Min1);

            pictureBox1.Refresh();
        }
    }
}
