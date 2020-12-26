using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Suma_Segmente
{
    public partial class Form1 : Form
    {
        List<PointF> points = new List<PointF>();
        
        int nrPuncte = 8;
        double sumaMin = 1000000000;

        List<PointF> st = new List<PointF>();
        List<PointF> sol = new List<PointF>();

        public Form1()
        {
            InitializeComponent();

            Random r = new Random();

            for (int i = 0; i < nrPuncte; i++)
            {
                PointF p = new PointF(r.Next() % this.Size.Width - 20, r.Next() % this.Size.Height - 20);
                if (p.X < 20)
                    p.X = 20;
                if (p.Y < 20)
                    p.Y = 20;                
                points.Add(p);
                st.Add(p);
                sol.Add(p);
            }
        }

        public static double Euclidean(PointF p1, PointF p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }

        private bool valid(int p)
        {
            bool ok = true;            
            for (int i = 0; i < p; i++)
                if (st[p].Equals(st[i]))
                    ok = false;
            return ok;
        }   

        private void backtracking(int p)
        {
            for (int val = 0; val < nrPuncte; val++)
            {
                st[p] = points[val];
                if (valid(p))
                {
                    if (p == nrPuncte - 1)
                    {
                        double suma = 0;

                        for (int i = 0; i < nrPuncte; i += 2)
                        {
                            suma += Euclidean(st[i], st[i + 1]);
                        }

                        if (suma < sumaMin)
                        {
                            sumaMin = suma;
                            for (int i = 0; i < nrPuncte; i++)
                            {
                                sol[i] = st[i];
                            }
                        }
                    }
                    else
                    {
                        backtracking(p + 1);
                    }
                }
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {      
            foreach (PointF p in points)
            {
                e.Graphics.DrawEllipse(new Pen(Color.Blue), p.X - 1, p.Y - 1, 2, 2);
            }

            backtracking(0);           

            for (int i = 0; i < nrPuncte; i += 2)
            {
                e.Graphics.DrawLine(new Pen(Color.Red), sol[i], sol[i + 1]);
            }
        }
    }
}
