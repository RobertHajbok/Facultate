using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComplexD
{
    class Complex
    {
        public double real;
        public double imaginar;

        #region Constructors
        public Complex()
        {
            this.real = 0;
            this.imaginar = 0;
        }

        public Complex(double real)
        {
            this.real = real;
            this.imaginar = 0;
        }

        public Complex(double real, double imaginar)
        {
            this.real = real;
            this.imaginar = imaginar;
        }
        #endregion

        #region Overloaded operators

        public static Complex operator +(Complex c1, Complex c2)
        {
            return new Complex(c1.real + c2.real, c1.imaginar + c2.imaginar);
        }

        public static Complex operator -(Complex c1, Complex c2)
        {
            return new Complex(c1.real - c2.real, c1.imaginar - c2.imaginar);
        }

        public static Complex operator *(Complex c1, Complex c2)
        {
            return new Complex((c1.real * c2.real) - (c1.imaginar * c2.imaginar), (c1.real * c2.real) + (c1.imaginar * c2.imaginar));
        }

        //public static Complex operator ^(Complex c, int pow)
        //{
        //    int i = 0;
        //    Complex x = new Complex();

        //    if (pow == 0)
        //    {
        //        return x;
        //    }
        //    else
        //    {
        //        x = c;
        //        for (i = 1; i < pow; i++)
        //        {
        //            x = x * c;
        //        }
        //        return x;
        //    }
        //}  

        #endregion

        public override string ToString()
        {
            double theta = Math.Atan(imaginar / real);
            return String.Format("{0}(cos {1} + i * sin {1})", Math.Pow(Math.Sqrt(real) + Math.Sqrt(imaginar), 1 / 2), theta);
        }
    }
}
