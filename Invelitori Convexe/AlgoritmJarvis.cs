using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invelitori_Convexe
{
    public class AlgoritmJarvis
    {
        public static void AlgoritmulJarvis(List<PointF> points, PaintEventArgs e)
        {
            if (points.Count < 3)
            {
                throw new ArgumentException("At least 3 points reqired", "points");
            }

            List<PointF> hull = new List<PointF>();

            // get leftmost point
            PointF vPointOnHull = points.Where(p => p.X == points.Min(min => min.X)).First();

            PointF vEndpoint;
            do
            {
                hull.Add(vPointOnHull);
                vEndpoint = points[0];

                for (int i = 1; i < points.Count; i++)
                {
                    if ((vPointOnHull == vEndpoint)
                        || (Orientation(vPointOnHull, vEndpoint, points[i]) == -1))
                    {
                        vEndpoint = points[i];
                    }
                }

                vPointOnHull = vEndpoint;

            }
            while (vEndpoint != hull[0]);

            for (int i = 1; i < hull.Count; i++)
            {
                e.Graphics.DrawLine(new Pen(Color.Red), hull[i], hull[i - 1]);
            }
            e.Graphics.DrawLine(new Pen(Color.Red), hull[0], hull[hull.Count - 1]);
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
