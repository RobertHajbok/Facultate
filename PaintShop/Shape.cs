using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintShop
{
    public abstract class Shape
    {
        protected Point p1, p2;
        protected Color lineColor;
        protected int lineThickness;

        public Shape(Point p1, Point p2, Color lineColor, int lineThickness)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.lineColor = lineColor;
            this.lineThickness = lineThickness;
        }

        public abstract void Draw(Graphics g);
    }
}
