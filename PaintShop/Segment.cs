using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace PaintShop
{
    public class Segment: Shape
    {
        public Segment(Point p1, Point p2, Color lineColor, int lineThickness): base(p1, p2, lineColor, lineThickness)
        {

        }
        public override void Draw(Graphics g)
        {
            Pen pen = new Pen(lineColor, lineThickness);
            g.DrawLine(pen, p1, p2);
        }
    }
}
