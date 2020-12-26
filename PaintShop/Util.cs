using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace PaintShop
{
    static class Util
    {
        public static Rectangle createRectangle(Point p1, Point p2)
        {
            int x, y, width, height;

            x = Math.Min(p1.X, p2.X);
            y = Math.Min(p1.Y, p2.Y);
            width = Math.Abs(p1.X - p2.X);
            height = Math.Abs(p1.Y - p2.Y);

            return new Rectangle(x, y, width, height);
        }
    }
}
