using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Enclosing_Circle
{
    class Circle
    {
        MyPoint Center;
        double radius;

        public Circle()
        {
            this.Center = new MyPoint(0, 0);
            radius = 0;
        }

        public Circle(MyPoint Center, double radius)
        {
            this.Center = Center;
            this.radius = radius;
        }

        public Circle(MyPoint Center)
        {
            this.Center = Center;
            this.radius = 0;
        }

        public Circle(MyPoint first, MyPoint second)
        {
            Center = new MyPoint((first.getX() + second.getX()) / 2, (first.getY() + second.getY()) / 2);
            radius = Center.distance(first);
        }

        public Circle(MyPoint p1, MyPoint p2, MyPoint p3)
        {
            try
            {
                double x = (p3.getX() * p3.getX() * (p1.getY() - p2.getY()) + (p1.getX() * p1.getX() + (p1.getY() - p2.getY()) * (p1.getY() - p3.getY()))
                          * (p2.getY() - p3.getY()) + p2.getX() * p2.getX() * (-p1.getY() + p3.getY()))
                          / (2 * (p3.getX() * (p1.getY() - p2.getY()) + p1.getX() * (p2.getY() - p3.getY()) + p2.getX() * (-p1.getY() + p3.getY())));
                double y = (p2.getY() + p3.getY()) / 2 - (p3.getX() - p2.getX()) / (p3.getY() - p2.getY()) * (x - (p2.getX() + p3.getX()) / 2);

                Center = new MyPoint(x, y);
                radius = Center.distance(p1);
            }
            catch (Exception e)
            {
                MessageBox.Show("Nu se poate crea cercul cu cele trei puncte: " + e.ToString());
            }

        }

        public MyPoint getCenter()
        {
            return Center;
        }

        public double getRadius()
        {
            return radius;
        }

        public int belongsToCircle(MyPoint other)
        {
            if ((Center.distance(other) - radius) < 0.000001) return 0;
            if (Center.distance(other) > radius) return -1;
            return 1;
        }
    }
}
