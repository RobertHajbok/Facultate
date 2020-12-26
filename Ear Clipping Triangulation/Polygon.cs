using System;
using System.Collections.Generic;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Ear_Clipping_Triangulation
{
    public class Polygon
    {
        public Polygon()
        {
        }
        public Polygon(PointF[] points)
        {
            Points = points;
        }

        public PointF[] Points;

        // Find the polygon's centroid.
        public PointF FindCentroid()
        {
            // Add the first point at the end of the array.
            int nuPoints = Points.Length;
            PointF[] pts = new PointF[nuPoints + 1];
            Points.CopyTo(pts, 0);
            pts[nuPoints] = Points[0];

            // Find the centroid.
            float X = 0;
            float Y = 0;
            float second_factor;
            for (int i = 0; i < nuPoints; i++)
            {
                second_factor =
                    pts[i].X * pts[i + 1].Y -
                    pts[i + 1].X * pts[i].Y;
                X += (pts[i].X + pts[i + 1].X) * second_factor;
                Y += (pts[i].Y + pts[i + 1].Y) * second_factor;
            }

            // Divide by 6 times the polygon's area.
            float polygon_area = PolygonArea();
            X /= (6 * polygon_area);
            Y /= (6 * polygon_area);

            // If the values are negative, the polygon is
            // oriented counterclockwise so reverse the signs.
            if (X < 0)
            {
                X = -X;
                Y = -Y;
            }

            return new PointF(X, Y);
        }

        // Return True if the point is in the polygon.
        public bool PointInPolygon(float X, float Y)
        {
            // Get the angle between the point and the
            // first and last vertices.
            int max_point = Points.Length - 1;
            float total_angle = GetAngle(
                Points[max_point].X, Points[max_point].Y,
                X, Y,
                Points[0].X, Points[0].Y);

            // Add the angles from the point
            // to each other pair of vertices.
            for (int i = 0; i < max_point; i++)
            {
                total_angle += GetAngle(
                    Points[i].X, Points[i].Y,
                    X, Y,
                    Points[i + 1].X, Points[i + 1].Y);
            }

            // The total angle should be 2 * PI or -2 * PI if
            // the point is in the polygon and close to zero
            // if the point is outside the polygon.
            return (Math.Abs(total_angle) > 0.000001);
        }

        #region "Orientation Routines"
        // Return True if the polygon is oriented clockwise.
        public bool PolygonIsOrientedClockwise()
        {
            return (SignedPolygonArea() < 0);
        }

        // If the polygon is oriented counterclockwise,
        // reverse the order of its points.
        private void OrientPolygonClockwise()
        {
            if (!PolygonIsOrientedClockwise())
                Array.Reverse(Points);
        }
        #endregion // Orientation Routines

        #region "Area Routines"
        // Return the polygon's area in "square units."
        // Add the areas of the trapezoids defined by the
        // polygon's edges dropped to the X-axis. When the
        // program considers a bottom edge of a polygon, the
        // calculation gives a negative area so the space
        // between the polygon and the axis is subtracted,
        // leaving the polygon's area. This method gives odd
        // results for non-simple polygons.
        public float PolygonArea()
        {
            // Return the absolute value of the signed area.
            // The signed area is negative if the polyogn is
            // oriented clockwise.
            return Math.Abs(SignedPolygonArea());
        }

        // Return the polygon's area in "square units."
        // Add the areas of the trapezoids defined by the
        // polygon's edges dropped to the X-axis. When the
        // program considers a bottom edge of a polygon, the
        // calculation gives a negative area so the space
        // between the polygon and the axis is subtracted,
        // leaving the polygon's area. This method gives odd
        // results for non-simple polygons.
        //
        // The value will be negative if the polyogn is
        // oriented clockwise.
        private float SignedPolygonArea()
        {
            // Add the first point to the end.
            int nuPoints = Points.Length;
            PointF[] pts = new PointF[nuPoints + 1];
            Points.CopyTo(pts, 0);
            pts[nuPoints] = Points[0];

            // Get the areas.
            float area = 0;
            for (int i = 0; i < nuPoints; i++)
            {
                area +=
                    (pts[i + 1].X - pts[i].X) *
                    (pts[i + 1].Y + pts[i].Y) / 2;
            }

            // Return the result.
            return area;
        }
        #endregion // Area Routines

        // Return True if the polygon is convex.
        public bool PolygonIsConvex()
        {
            // For each set of three adjacent points A, B, C,
            // find the dot product AB · BC. If the sign of
            // all the dot products is the same, the angles
            // are all positive or negative (depending on the
            // order in which we visit them) so the polygon
            // is convex.
            bool got_negative = false;
            bool got_positive = false;
            int nuPoints = Points.Length;
            int B, C;
            for (int A = 0; A < nuPoints; A++)
            {
                B = (A + 1) % nuPoints;
                C = (B + 1) % nuPoints;

                float cross_product =
                    CrossProductLength(
                        Points[A].X, Points[A].Y,
                        Points[B].X, Points[B].Y,
                        Points[C].X, Points[C].Y);
                if (cross_product < 0)
                {
                    got_negative = true;
                }
                else if (cross_product > 0)
                {
                    got_positive = true;
                }
                if (got_negative && got_positive) return false;
            }

            // If we got this far, the polygon is convex.
            return true;
        }

        #region "Cross and Dot Products"
        // Return the cross product AB x BC.
        // The cross product is a vector perpendicular to AB
        // and BC having length |AB| * |BC| * Sin(theta) and
        // with direction given by the right-hand rule.
        // For two vectors in the X-Y plane, the result is a
        // vector with X and Y components 0 so the Z component
        // gives the vector's length and direction.
        public static float CrossProductLength(float Ax, float Ay,
            float Bx, float By, float Cx, float Cy)
        {
            // Get the vectors' coordinates.
            float BAx = Ax - Bx;
            float BAy = Ay - By;
            float BCx = Cx - Bx;
            float BCy = Cy - By;

            // Calculate the Z coordinate of the cross product.
            return (BAx * BCy - BAy * BCx);
        }

        // Return the dot product AB · BC.
        // Note that AB · BC = |AB| * |BC| * Cos(theta).
        private static float DotProduct(float Ax, float Ay,
            float Bx, float By, float Cx, float Cy)
        {
            // Get the vectors' coordinates.
            float BAx = Ax - Bx;
            float BAy = Ay - By;
            float BCx = Cx - Bx;
            float BCy = Cy - By;

            // Calculate the dot product.
            return (BAx * BCx + BAy * BCy);
        }
        #endregion // Cross and Dot Products

        // Return the angle ABC.
        // Return a value between PI and -PI.
        // Note that the value is the opposite of what you might
        // expect because Y coordinates increase downward.
        public static float GetAngle(float Ax, float Ay, float Bx, float By, float Cx, float Cy)
        {
            // Get the dot product.
            float dot_product = DotProduct(Ax, Ay, Bx, By, Cx, Cy);

            // Get the cross product.
            float cross_product = CrossProductLength(Ax, Ay, Bx, By, Cx, Cy);

            // Calculate the angle.
            return (float)Math.Atan2(cross_product, dot_product);
        }

        #region "Triangulation"
        // Find the indexes of three points that form an "ear."
        private void FindEar(ref int A, ref int B, ref int C)
        {
            int nuPoints = Points.Length;

            for (A = 0; A < nuPoints; A++)
            {
                B = (A + 1) % nuPoints;
                C = (B + 1) % nuPoints;

                if (FormsEar(Points, A, B, C)) return;
            }

            // We should never get here because there should
            // always be at least two ears.
            Debug.Assert(false);
        }

        // Return True if the three points form an ear.
        private static bool FormsEar(PointF[] points, int A, int B, int C)
        {
            // See if the angle ABC is concave.
            if (GetAngle(
                points[A].X, points[A].Y,
                points[B].X, points[B].Y,
                points[C].X, points[C].Y) > 0)
            {
                // This is a concave corner so the triangle
                // cannot be an ear.
                return false;
            }

            // Make the triangle A, B, C.
            Triangle triangle = new Triangle(
                points[A], points[B], points[C]);

            // Check the other points to see 
            // if they lie in triangle A, B, C.
            for (int i = 0; i < points.Length; i++)
            {
                if ((i != A) && (i != B) && (i != C))
                {
                    if (triangle.PointInPolygon(points[i].X, points[i].Y))
                    {
                        // This point is in the triangle 
                        // do this is not an ear.
                        return false;
                    }
                }
            }

            // This is an ear.
            return true;
        }

        // Remove an ear from the polygon and
        // add it to the triangles array.
        private void RemoveEar(List<Triangle> triangles)
        {
            // Find an ear.
            int A = 0, B = 0, C = 0;
            FindEar(ref A, ref B, ref C);

            // Create a new triangle for the ear.
            triangles.Add(new Triangle(Points[A], Points[B], Points[C]));

            // Remove the ear from the polygon.
            RemovePointFromArray(B);
        }

        // Remove point target from the array.
        private void RemovePointFromArray(int target)
        {
            PointF[] pts = new PointF[Points.Length - 1];
            Array.Copy(Points, 0, pts, 0, target);
            Array.Copy(Points, target + 1, pts, target, Points.Length - target - 1);
            Points = pts;
        }

        // Triangulate the polygon.
        //
        // For a nice, detailed explanation of this method,
        // see Ian Garton's Web page:
        // http://www-cgrl.cs.mcgill.ca/~godfried/teaching/cg-projects/97/Ian/cutting_ears.html
        public List<Triangle> Triangulate()
        {
            // Copy the points into a scratch array.
            PointF[] pts = new PointF[Points.Length];
            Array.Copy(Points, pts, Points.Length);

            // Make a scratch polygon.
            Polygon pgon = new Polygon(pts);

            // Orient the polygon clockwise.
            pgon.OrientPolygonClockwise();

            // Make room for the triangles.
            List<Triangle> triangles = new List<Triangle>();

            // While the copy of the polygon has more than
            // three points, remove an ear.
            while (pgon.Points.Length > 3)
            {
                // Remove an ear from the polygon.
                pgon.RemoveEar(triangles);
            }

            // Copy the last three points into their own triangle.
            triangles.Add(new Triangle(pgon.Points[0], pgon.Points[1], pgon.Points[2]));

            return triangles;
        }
        #endregion // Triangulation/       
    }
}
