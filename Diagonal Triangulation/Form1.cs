using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diagonal_Triangulation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
        }

        List<PointF> puncte = new List<PointF>();
        List<PointF> diagonale = new List<PointF>();
        Graphics g;

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            g.Clear(Color.Black);
            puncte.Clear();
            diagonale.Clear();
        }

        private void btn_Draw_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < puncte.Count - 1; i++)
            {
                g.DrawLine(Pens.Red, puncte[i], puncte[i + 1]);
            }
            g.DrawLine(Pens.Red, puncte[0], puncte[puncte.Count - 1]);

            for (int i = 0; i < puncte.Count - 2; i++)// e inclusiv cea de pe pozitia n-3
            {
                for (int j = i + 2; j < puncte.Count; j++)// e inclusiv cea de pe pozitia n-1
                {
                    if (i == 0 && j == puncte.Count - 1)
                    {
                        break;
                    }
                    if (intersectieTotala(puncte[i], puncte[j]) == false)
                    {
                        if (Get3Angle(puncte[invers(i - 1, puncte.Count)], puncte[i], puncte[(i + 1) % puncte.Count]) <= Math.PI)
                        {
                            if (determinant(puncte[i], puncte[j], puncte[i + 1]) < 0 && determinant(puncte[i], puncte[invers(i - 1, puncte.Count)], puncte[j]) < 0)
                            {
                                g.DrawLine(new Pen(Color.Blue, 1), puncte[i], puncte[j]);
                                diagonale.Add(puncte[i]);
                                diagonale.Add(puncte[j]);
                            }
                        }
                    }
                }
            }
        }

        private int invers(int p, int p_2)
        {
            if (p < 0)
            {
                return p_2 + p;
            }
            else
                return p;
        }

        private bool intersectieTotala(PointF a, PointF b)
        {
            bool intersecteaza = false;
            for (int i = 0; i < puncte.Count; i++)
            {
                if (a != puncte[i] && b != puncte[i])
                {
                    if (intersectie(a, b, puncte[i], puncte[(i + 1) % puncte.Count]))
                    {
                        intersecteaza = true;
                    }
                }
            }
            for (int i = 0; i < diagonale.Count; i += 2)
            {
                if (a != diagonale[i] && b != diagonale[i])
                {
                    if (intersectie(a, b, diagonale[i], diagonale[(i + 1) % diagonale.Count]))
                    {
                        intersecteaza = true;
                    }
                }
            }
            return intersecteaza;
        }

        public double determinant(PointF a, PointF b, PointF c)
        {
            return (a.X * b.Y + b.X * c.Y + c.X * a.Y - c.X * b.Y - a.X * c.Y - a.Y * b.X);
        }

        private double unghiMinimDoua(PointF p1, PointF p2)
        {
            double delta;
            if (p1.X != p2.X)
                delta = Math.Atan(Math.Abs((p1.Y - p2.Y) / (p1.X - p2.X)));
            else
                delta = 0;

            if (p2.X > p1.X && p2.Y == p1.Y) delta = 0;
            if (p2.X == p1.X && p2.Y < p1.Y) delta = Math.PI / 2;
            if (p2.X < p1.X && p2.Y < p1.Y) delta = Math.PI - delta;
            if (p2.X < p1.X && p2.Y == p1.Y) delta = Math.PI;
            if (p2.X < p1.X && p2.Y > p1.Y) delta = Math.PI + delta;
            if (p2.X == p1.X && p2.Y > p1.Y) delta = (3 * Math.PI) / 2;
            if (p2.X > p1.X && p2.Y > p1.Y) delta = (2 * Math.PI) - delta;

            return delta;
        }

        private double Get3Angle(PointF p1, PointF p2, PointF p3)
        {
            double unghi = Math.Abs(unghiMinimDoua(p2, p1) - unghiMinimDoua(p2, p3));
            if (unghi > Math.PI)
                return 2 * Math.PI - unghi;
            return unghi;
        }

        public class dreapta
        {
            public PointF p1, p2;
            public double a, b, c;
            public dreapta(PointF p1, PointF p2)
            {
                this.p1 = p1;
                this.p2 = p2;
                a = 0; b = 0; c = 0;
            }
            public void draw(Graphics g)
            {
                g.DrawLine(Pens.Green, p1, p2);
            }
            public void ecuatiaDreptei()
            {
                a = p2.Y - p1.Y;
                b = p1.X - p2.X;
                c = p2.X * p1.Y - p1.X * p2.Y;
            }

        }

        public bool intersectie(PointF p1, PointF p2, PointF q1, PointF q2)
        {
            dreapta d1 = new dreapta(p1, p2);
            dreapta d2 = new dreapta(q1, q2);
            PointF punc = new Point();
            d1.ecuatiaDreptei();
            d2.ecuatiaDreptei();
            if ((int)(d2.b * d1.a - d1.b * d2.a) != 0)// ca sa nu fie paralele
            {
                punc.X = (float)(d1.b * d2.c - d2.b * d1.c) / (float)(d2.b * d1.a - d1.b * d2.a);
                punc.Y = (float)(d1.a * d2.c - d2.a * d1.c) / (float)(d2.a * d1.b - d1.a * d2.b);
                //g.DrawEllipse(p,punc.X-1,punc.Y-1,2,2);
                if (punc.X < max(p1.X, p2.X) &&
                    punc.X > min(p1.X, p2.X) &&
                    punc.X < max(q1.X, q2.X) &&
                    punc.X > min(q1.X, q2.X))
                {
                    return true;
                }
            }
            return false;

        }

        public double max(double a, double b)
        {
            if (a > b)
                return a;
            return b;
        }

        public double min(double a, double b)
        {
            if (a < b)
                return a;
            return b;
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            puncte.Add(new PointF(e.X, e.Y));
            g.DrawEllipse(new Pen(Color.Red, 4), e.X - 1, e.Y - 1, 2, 2);
        }
    }
}
