using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestImageCreation
{


    public static class MathUtils
    {
        public static Func<double, double> InterpFunc(double x1, double y1, double x2, double y2)
        {
            double m = (y2 - y1) / (x2 - x1);
            double b = y1 - (m * x1);
            return (x => m * x + b);
        }
    }
}
