using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Fractali_patrate
{
    public static class AppEngine
    {
        public static int maxx;
        public static int maxy;
        public static Graphics g;
        public static Bitmap b;

        public static void initGraph(int x, int y)
        {
            b = new Bitmap(x, y);
            g = Graphics.FromImage(b);

            maxx = x;
            maxy = y;
        }
    }
}
