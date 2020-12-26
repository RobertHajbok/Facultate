using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Apropiere_Puncte
{
    public partial class Form1 : Form
    {
        List<PointF> points = new List<PointF>();

        public Form1()
        {
            InitializeComponent();

            Random r = new Random();

            for (int i = 0; i < 20; i++)
            {
                PointF p = new PointF(r.Next() % this.Size.Width - 20, r.Next() % this.Size.Height - 20);
                if (p.X < 20)
                    p.X = 20;
                if (p.Y < 20)
                    p.Y = 20;
                points.Add(p);
            }
        }

        public class Segment
        {
            public Segment(PointF p1, PointF p2)
            {
                P1 = p1;
                P2 = p2;
            }

            public readonly PointF P1;
            public readonly PointF P2;

            public float Length()
            {
                return (float)Math.Sqrt(LengthSquared());
            }

            public float LengthSquared()
            {
                return (P1.X - P2.X) * (P1.X - P2.X) + (P1.Y - P2.Y) * (P1.Y - P2.Y);
            }
        }

        public static Segment Closest_BruteForce(List<PointF> points)
        {
            int n = points.Count;
            var result = Enumerable.Range(0, n - 1)
                .SelectMany(i => Enumerable.Range(i + 1, n - (i + 1))
                    .Select(j => new Segment(points[i], points[j])))
                    .OrderBy(seg => seg.LengthSquared())
                    .First();

            return result;
        }

        public static Segment MyClosestDivide(List<PointF> points)
        {
            return MyClosestRec(points.OrderBy(p => p.X).ToList());
        }

        private static Segment MyClosestRec(List<PointF> pointsByX)
        {
            int count = pointsByX.Count;
            if (count <= 4)
                return Closest_BruteForce(pointsByX);

            // left and right lists sorted by X, as order retained from full list
            var leftByX = pointsByX.Take(count / 2).ToList();
            var leftResult = MyClosestRec(leftByX);

            var rightByX = pointsByX.Skip(count / 2).ToList();
            var rightResult = MyClosestRec(rightByX);

            var result = rightResult.Length() < leftResult.Length() ? rightResult : leftResult;

            // There may be a shorter distance that crosses the divider
            // Thus, extract all the points within result.Length either side
            var midX = leftByX.Last().X;
            var bandWidth = result.Length();
            var inBandByX = pointsByX.Where(p => Math.Abs(midX - p.X) <= bandWidth);

            // Sort by Y, so we can efficiently check for closer pairs
            var inBandByY = inBandByX.OrderBy(p => p.Y).ToArray();

            int iLast = inBandByY.Length - 1;
            for (int i = 0; i < iLast; i++)
            {
                var pLower = inBandByY[i];

                for (int j = i + 1; j <= iLast; j++)
                {
                    var pUpper = inBandByY[j];

                    // Comparing each point to successivly increasing Y values
                    // Thus, can terminate as soon as deltaY is greater than best result
                    if ((pUpper.Y - pLower.Y) >= result.Length())
                        break;

                    Segment segment = new Segment(pLower, pUpper);
                    if (segment.Length() < result.Length())
                        result = segment;// new Segment(pLower, pUpper);
                }
            }
            return result;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (PointF p in points)
            {
                e.Graphics.DrawEllipse(new Pen(Color.Black), p.X - 1, p.Y - 1, 2, 2);
            }

            while (points.Count >= 2)
            {
                var result2 = MyClosestDivide(points);
                e.Graphics.DrawLine(new Pen(Color.Green), result2.P1, result2.P2);
                points.Remove(result2.P1);
                points.Remove(result2.P2);
            }
        }
    }
}
