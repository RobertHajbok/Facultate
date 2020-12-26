using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComplexD
{
    class ComplexD : Complex
    {
        public ComplexD(double real, double imaginar) : base(real, imaginar) { }

        public static double operator ^(ComplexD c, int pow)
        {
            double r = Math.Sqrt(Math.Pow(c.real, 2) + Math.Pow(c.imaginar, 2));
            double theta = Math.Atan(c.imaginar / c.real);

            //double x = r * (Math.Cos(theta) + Math.Sin(theta));
            double xn = (Math.Pow(r, pow)) * (Math.Cos(pow * theta) + Math.Sin(pow * theta));

            return xn;
        }

        public double DistantaMinimaLa(ComplexD[] v)
        {
            double min = double.MaxValue;

            for (int i = 0; i < v.Length; i++)
            {
                double minCurent = Math.Sqrt(Math.Pow(v[i].real - this.real, 2) + Math.Pow(v[i].imaginar - this.imaginar, 2));
                if (minCurent < min)
                    min = minCurent;
            }

            return min;
        }
    }
}
