using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enclosing_Circle
{
    public class MyPoint
    {
        private double x;        
        private double y;
        
        public MyPoint()
        {
            x = 0;
            y = 0;
        }
       
        public MyPoint(double xVal, double yVal)
        {
            x = xVal;
            y = yVal;
        }
        
        public MyPoint(MyPoint MyPoint)
        {
            x = MyPoint.x;
            y = MyPoint.y;
        }


        
        public double getX()
        {
            return x;
        }
        
        public double getY()
        {
            return y;
        }
        
        public void setX(double xVal)
        {
            x = xVal;
        }
        
        public void setY(double yVal)
        {
            y = yVal;
        }
                
        public void translate(MyPoint MyPoint)
        {
            translate(MyPoint.x, MyPoint.y);
        }
       
        public void translate(double newX, double newY)
        {
            x = newX;
            y = newY;
        }
        
        public void offset(double dx, double dy)
        {
            x += dx;
            y += dy;
        }
        
       
        public double distance(MyPoint MyPoint)
        {
            double dx = x - MyPoint.x;
            double dy = y - MyPoint.y;
            return Math.Sqrt(dx * dx + dy * dy);
        }
       
        public double distance2(MyPoint MyPoint)
        {
            double dx = x - MyPoint.x;
            double dy = y - MyPoint.y;
            return (dx * dx + dy * dy);
        }
       
        public MyPoint midMyPoint(MyPoint MyPoint)
        {
            return new MyPoint((x + MyPoint.x) / 2, (y + MyPoint.y) / 2);
        }

        
        public bool equals(MyPoint MyPoint)
        {
            return (x == MyPoint.x) && (y == MyPoint.y);
        }
        
        public String toString()
        {
            return "MyPoint = (" + x + "," + y + ")";
        }
    }
}
