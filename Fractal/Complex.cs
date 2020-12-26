using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestImageCreation
{
    public class Complex
    {
        private double real;
        private double img;
        public Complex(double real, double img)
        {
            this.real = real;
            this.img = img;
        }

        public Complex Multiply(Complex c)
        {
            return new Complex(
                       real * c.real - img * c.img,
                       real * c.img + c.real * img);
        }

        public Complex Add(Complex c)
        {
            return new Complex(real + c.real, img + c.img);
        }

        public double Norm()
        {
            return Math.Sqrt(NormSquared());
        }

        public double NormSquared()
        {
            return real * real + img * img;
        }

        public static Complex operator *(Complex c1, Complex c2)
        {
            return c1.Multiply(c2);
        }

        public static Complex operator +(Complex c1, Complex c2)
        {
            return c1.Add(c2);
        }

        public double Real
        {
            get
            {
                return this.real;
            }
        }

        public double Img
        {
            get
            {
                return this.img;
            }
        }
    }

}
