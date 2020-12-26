using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algoritmul_Bentley_Ottmann
{
    public partial class Form1 : Form
    {
        List<Point> points = new List<Point>();

        public Form1()
        {
            InitializeComponent();

            Random r = new Random();

            for (int i = 0; i < 12; i++)
            {
                Point p = new Point(r.Next() % this.Size.Width - 20, r.Next() % this.Size.Height - 20);
                if (p.X < 20)
                    p.X = 20;
                if (p.Y < 20)
                    p.Y = 20;                
                points.Add(p);
            }
        }

        public struct Segment
        {
            public PointF Start;
            public PointF End;
        }

        public PointF? Intersects(Segment AB, Segment CD)
        {
            double deltaACy = AB.Start.Y - CD.Start.Y;
            double deltaDCx = CD.End.X - CD.Start.X;
            double deltaACx = AB.Start.X - CD.Start.X;
            double deltaDCy = CD.End.Y - CD.Start.Y;
            double deltaBAx = AB.End.X - AB.Start.X;
            double deltaBAy = AB.End.Y - AB.Start.Y;

            double denominator = deltaBAx * deltaDCy - deltaBAy * deltaDCx;
            double numerator = deltaACy * deltaDCx - deltaACx * deltaDCy;

            if (denominator == 0)
            {
                if (numerator == 0)
                {
                    // collinear. Potentially infinite intersection points.
                    // Check and return one of them.
                    if (AB.Start.X >= CD.Start.X && AB.Start.X <= CD.End.X)
                    {
                        return AB.Start;
                    }
                    else if (CD.Start.X >= AB.Start.X && CD.Start.X <= AB.End.X)
                    {
                        return CD.Start;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                { // parallel
                    return null;
                }
            }

            double r = numerator / denominator;
            if (r < 0 || r > 1)
            {
                return null;
            }

            double s = (deltaACy * deltaBAx - deltaACx * deltaBAy) / denominator;
            if (s < 0 || s > 1)
            {
                return null;
            }

            return new PointF((float)(AB.Start.X + r * deltaBAx), (float)(AB.Start.Y + r * deltaBAy));
        }

        public void SolutiaGrosiera(Segment[] sg, PaintEventArgs e)
        {
            for (int i = 0; i < sg.Length; i++)
            {
                for (int j = i + 1; j < sg.Length; j++)
                {
                    if (Intersects(sg[i], sg[j]) != null)
                    {
                        PointF pct = (PointF)Intersects(sg[i], sg[j]);
                        e.Graphics.DrawEllipse(new Pen(Color.Red), pct.X - 1, pct.Y - 1, 3, 3);
                    }
                }
            }            
        }

        public List<PointF> SolutiaOptimizata(Segment[] sg)
        {
            // http://geomalgorithms.com/a09-_intersect-3.html
            List<PointF> EQ = new List<PointF>();      //Event Queue
            List<Segment> SL = new List<Segment>();     //Sweep Line
            List<PointF> IL = new List<PointF>();      //Output Intersection List       

            for (int i = 0; i < sg.Length; i++)
            {
                EQ.Add(sg[i].Start);
                EQ.Add(sg[i].End);
            }
            Sortare(EQ);

            for (int j = 0; j < EQ.Count; j++)
            {
                if ((IsStartPoint(EQ[j], sg)) != null)
                {
                    Segment s = new Segment();
                    s.Start = EQ[j];
                    s.End = (PointF)(IsStartPoint(EQ[j], sg));
                    SL.Add(s);

                    for (int i = 0; i < SL.Count; i++)
                    {
                        for (int k = i + 1; k < SL.Count; k++)
                        {
                            if (Intersects(SL[i], SL[k]) != null)
                            {
                                PointF pct = new PointF();
                                pct = (PointF)Intersects(SL[i], SL[k]);
                                IL.Add(pct);
                            }
                        }
                    }
                }
                else if ((IsEndPoint(EQ[j], sg)) != null)
                {
                    Segment s = new Segment();
                    s.Start = (PointF)(IsEndPoint(EQ[j], sg));
                    s.End = EQ[j];
                    SL.Remove(s);
                    for(int i=0;i<SL.Count;i++)
                    {
                        if (LineToPointDistance(SL[i].Start, SL[i].End, EQ[j]) == 0)
                        {
                            IL.Add(EQ[j]);
                        }
                    }
                }                
            }
            return IL;
        }        

        public List<PointF> Sortare(List<PointF> EQ)
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
            }
            while (schimbat == 1);
            return EQ.ToList();
        }

        public PointF? IsStartPoint(PointF point, Segment[] sg)
        {
            for (int i = 0; i < sg.Length; i++)
                if (point == sg[i].Start)
                    return sg[i].End;
            return null;
        }

        public PointF? IsEndPoint(PointF point, Segment[] sg)
        {
            for (int i = 0; i < sg.Length; i++)
                if (point == sg[i].Start)
                    return sg[i].End;
            return null;
        }

        //Compute the dot product AB . AC
        private double DotProduct(PointF pointA, PointF pointB, PointF pointC)
        {
            return (pointB.X - pointA.X) * (pointC.X - pointB.X) + (pointB.Y - pointA.Y) * (pointC.Y - pointB.Y);
        }

        //Compute the cross product AB x AC
        private double CrossProduct(PointF pointA, PointF pointB, PointF pointC)
        {
            return (pointB.X - pointA.X) * (pointC.Y - pointA.Y) - (pointB.Y - pointA.Y) * (pointC.Y - pointA.Y);
        }

        //Compute the distance from A to B
        double Distance(PointF pointA, PointF pointB)
        {
            return Math.Sqrt((pointA.X - pointB.X) * (pointA.X - pointB.X) + (pointA.Y - pointB.Y) * (pointA.Y - pointB.Y));
        }

        //Compute the distance from AB to C
        //if isSegment is true, AB is a segment, not a line.
        double LineToPointDistance(PointF pointA, PointF pointB, PointF pointC)
        {
            if (DotProduct(pointA, pointB, pointC) > 0)
                return Distance(pointB, pointC);
            if (DotProduct(pointB, pointA, pointC) > 0)
                return Distance(pointA, pointC);
            return Math.Abs(CrossProduct(pointA, pointB, pointC) / Distance(pointA, pointB));
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Segment[] sg = new Segment[points.Count / 2];
            for (int i = 0; i < sg.Length; i++)
            {
                sg[i].Start = points[i * 2];
                sg[i].End = points[i * 2 + 1];
            }
            foreach (Segment s in sg)
            {
                e.Graphics.DrawLine(new Pen(Color.Black), s.Start, s.End);
            }
            //SolutiaGrosiera(sg, e);
            foreach (PointF p in SolutiaOptimizata(sg))
            {
                e.Graphics.DrawEllipse(new Pen(Color.Red), p.X - 1, p.Y - 1, 3, 3);
            }
        }
    }
}
