using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace PaintShop
{
    class Dreptunghi: Shape
    {
        public Dreptunghi(Point p1, Point p2, Color lineColor, int lineThickness): base(p1, p2, lineColor, lineThickness)
        {

        }
        public override void Draw(Graphics g)
        {
            Pen pen = new Pen(lineColor, lineThickness);
            g.DrawRectangle(pen, Util.createRectangle(p1, p2));
        }
    }
}
