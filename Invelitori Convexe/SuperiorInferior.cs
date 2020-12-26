using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invelitori_Convexe
{
    public class SuperiorInferior
    {
        public static void SepararePlanuri(List<PointF> points, PaintEventArgs e)
        {
            List<PointF> pct = Sortare(points);      //Sorteaza punctele dupa abscisa
            List<PointF> PlanSuperior = new List<PointF>();
            List<PointF> PlanInferior = new List<PointF>();
            //Adauga primele doua puncte din pct cu pct[0] ca prim punct
            PlanSuperior.Add(pct[0]);
            PlanSuperior.Add(pct[1]);
            for (int i = 2; i < pct.Count; i++)
            {
                PlanSuperior.Add(pct[i]);
                //Cat timp card(PlanSuperior) > 2
                while (PlanSuperior.Count > 2 && Orientation(PlanSuperior[PlanSuperior.Count - 1], PlanSuperior[PlanSuperior.Count - 2], PlanSuperior[PlanSuperior.Count - 3]) != 1)
                {
                    //Daca ultimele tre puncte nu efectueaza o intoarcere la dreapta, sterge
                    //punctul din mijlocul celor 3
                    PlanSuperior.Remove(PlanSuperior[PlanSuperior.Count - 2]);
                }
            }
            //Adauga ultimele doua puncte din pct cu pct[n] ca prim punct
            PlanInferior.Add(pct[pct.Count - 1]);
            PlanInferior.Add(pct[pct.Count - 2]);
            for (int i = pct.Count - 3; i >= 0; i--)
            {
                PlanInferior.Add(pct[i]);
                //Cat timp card(PlanInferior) > 2
                while (PlanInferior.Count > 2 && Orientation(PlanInferior[PlanInferior.Count - 1], PlanInferior[PlanInferior.Count - 2], PlanInferior[PlanInferior.Count - 3]) != 1)
                {
                    //Daca ultimele tre puncte nu efectueaza o intoarcere la dreapta, sterge
                    //punctul din mijlocul celor 3
                    PlanInferior.Remove(PlanInferior[PlanInferior.Count - 2]);
                }
            }            
            for (int i = 0; i < PlanSuperior.Count - 1; i++)
            {
                e.Graphics.DrawLine(new Pen(Color.Red), PlanSuperior[i], PlanSuperior[i + 1]);
            }
            for (int i = 0; i < PlanInferior.Count - 1; i++)
            {
                e.Graphics.DrawLine(new Pen(Color.Green), PlanInferior[i], PlanInferior[i + 1]);
            }
        }

        private static List<PointF> Sortare(List<PointF> EQ)
        {
            int schimbat = 1;
            do
            {
                schimbat = 0;
                for (int i = 0; i < EQ.Count - 1; i++)
                    if (EQ[i].X > EQ[i + 1].X)
                    {
                        PointF aux = EQ[i];
                        EQ[i] = EQ[i + 1];
                        EQ[i + 1] = aux;
                        schimbat = 1;
                    }
                    else if (EQ[i].X == EQ[i + 1].X)
                    {
                        if (EQ[i].Y > EQ[i + 1].Y)
                        {
                            PointF aux = EQ[i];
                            EQ[i] = EQ[i + 1];
                            EQ[i + 1] = aux;
                            schimbat = 1;
                        }
                    }
            }
            while (schimbat == 1);
            return EQ.ToList();
        }

        private static int Orientation(PointF p1, PointF p2, PointF p)
        {
            // Determinant
            float Orin = (p2.X - p1.X) * (p.Y - p1.Y) - (p.X - p1.X) * (p2.Y - p1.Y);

            if (Orin > 0)
                return -1; //          (* Orientaion is to the left-hand side  *)
            if (Orin < 0)
                return 1; // (* Orientaion is to the right-hand side *)

            return 0; //  (* Orientaion is neutral aka collinear  *)
        }
    }
}
