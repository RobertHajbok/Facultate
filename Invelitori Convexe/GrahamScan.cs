using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invelitori_Convexe
{
    public class GrahamScan
    {
        public static void ScanareGraham(List<PointF> points, PaintEventArgs e)
        {
            //Cauta cel mai mic Y
            int indice = findSmallestY(points);
            //Cel mai mic Y vine pe prima pozitie
            PointF aux = points[indice];
            points[indice] = points[0];
            points[0] = aux;
            //Genereaza vectorul cu unghiurile fata de punctul points[indice]
            double[] unghiuri = createAngleArray(points, 0);
            //Sorteaza lista unghiurilor fata de punctul points[indice]
            List<PointF> pctSortate = sortAngleArray(unghiuri, points);
            //Gaseste invelitoarea
            findConvexHull(pctSortate, e);
        }

        private static int findSmallestY(List<PointF> points)
        {
            float min = points[0].Y;
            int indice = 0;
            for (int i = 1; i < points.Count; i++)
            {
                if (points[i].Y < min)
                {
                    min = points[i].Y;
                    indice = i;
                }
            }
            float min2 = points[indice].X;
            for (int i = 0; i < points.Count; i++)
            {
                if (min == points[i].Y && points[i].X < min2)
                {
                    min2 = points[i].Y;
                    indice = i;
                }
            }
            return indice;
        }

        private static double[] createAngleArray(List<PointF> points, int indice)
        {
            double[] angle = new double[points.Count];
            double kone;

            for (int i = 0; i < points.Count; i++)
            {
                double mainPointX = (double)points[indice].X;
                double mainPointY = (double)points[indice].Y;
                if ((double)points[i].X == mainPointX && (double)points[i].Y == mainPointY)
                    kone = 0;
                else
                {
                    double otherPointX = (double)points[i].X - (double)points[indice].X;
                    double otherPointY = (double)points[i].Y - (double)points[indice].Y;
                    kone = Angle(otherPointX, otherPointY);
                }
                angle[i] = kone;
            }
            return angle;
        }

        private static double Angle(double px2, double py2)
        {
            double angle = 0.0;
            //Calculeaza unghiul
            angle = System.Math.Atan(System.Math.Abs(py2) / System.Math.Abs(px2));
            //Converteste in grade
            angle = angle * 180 / System.Math.PI;
            if (px2 < 0)
                angle = 180 - angle;
            return angle;
        }

        private static List<PointF> sortAngleArray(double[] unghiuri, List<PointF> puncte)
        {
            List<PointF> pctSortate = puncte;
            for (int i = unghiuri.Count() - 1; i >= 0; i--)
            {
                for (int j = 1; j <= i; j++)
                {
                    if (unghiuri[j - 1] > unghiuri[j])
                    {
                        double temp = unghiuri[j - 1];
                        unghiuri[j - 1] = unghiuri[j];
                        unghiuri[j] = temp;
                        PointF tmp = pctSortate[j - 1];
                        pctSortate[j - 1] = pctSortate[j];
                        pctSortate[j] = tmp;
                    }
                }
            }
            return pctSortate;
        }

        private static void findConvexHull(List<PointF> pctSortate, PaintEventArgs e)
        {
            //Creeaza o stiva goala
            Stack<PointF> Stiva = new Stack<PointF>();
            Stiva.Push(pctSortate[0]);
            Stiva.Push(pctSortate[1]);
            Stiva.Push(pctSortate[2]);
            // Verifica celelalte n-3 puncte
            for (int i = 3; i < pctSortate.Count; i++)
            {
                // Keep removing top while the angle formed by points next-to-top, 
                // top, and points[i] makes a non-left turn
                while (orientation(nextToTop(Stiva), Stiva.Peek(), pctSortate[i]) == 1)
                    Stiva.Pop();
                Stiva.Push(pctSortate[i]);
            }
            List<PointF> Hull = Stiva.ToList<PointF>();
            for (int i = 0; i < Stiva.Count - 1; i++)
            {
                e.Graphics.DrawLine(new Pen(Color.Red), Hull[i], Hull[i + 1]);
            }
            e.Graphics.DrawLine(new Pen(Color.Red), Hull[0], Hull[Hull.Count - 1]);
        }

        private static int orientation(PointF p, PointF q, PointF r)
        {
            float val = (q.Y - p.Y) * (r.X - q.X) - (q.X - p.X) * (r.Y - q.Y);
            if (val == 0)
                return 0;  // sunt colineare
            return (val > 0) ? 1 : 2; // clock or counterclock wise
        }

        private static PointF nextToTop(Stack<PointF> st)
        {
            PointF p = st.Peek();            
            st.Pop();
            PointF res = st.Peek();            
            st.Push(p);
            return res;
        }
    }    
}
