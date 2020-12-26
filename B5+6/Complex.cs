using System;
using System.Globalization;

namespace B5_6
{
    public class Complex
    {
        protected bool Equals(Complex other)
        {
            return Re.Equals(other.Re) && Im.Equals(other.Im);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Complex)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                // ReSharper disable once NonReadonlyMemberInGetHashCode
                return (Re.GetHashCode() * 397) ^ Im.GetHashCode();
            }
        }

        /// <summary>
        /// Contains the real part of a complex number.
        /// </summary>
        public double Re { get; set; }

        /// <summary>
        /// Contains the imaginary part of a complex number.
        /// </summary>
        public double Im { get; set; }

        /// <summary>
        /// Inits complex number.
        /// </summary>
        /// <param name="imaginaryPart"></param>
        /// <param name="realPart"></param>
        public Complex(double realPart, double imaginaryPart)
        {
            Re = realPart;
            Im = imaginaryPart;
        }

        /// <summary>
        /// Inits complex number with imaginary part = 0.
        /// </summary>
        /// <param name="realPart"></param>
        public Complex(double realPart)
        {
            Re = realPart;
            Im = 0;
        }

        /// <summary>
        /// Complex number zero.
        /// </summary>
        public static Complex Zero => new Complex(0, 0);

        /// <summary>
        /// Complex exponential function.
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Complex Exp(Complex a)
        {
            return new Complex(Math.Exp(a.Re) * Math.Cos(a.Im), Math.Exp(a.Re) * Math.Sin(a.Im));
        }

        /// <summary>
        /// Imaginary unit.
        /// </summary>
        public static Complex I => new Complex(0, 1);

        /// <summary>
        /// Complex number one.
        /// </summary>
        public static Complex One => new Complex(1, 0);

        public static bool operator ==(Complex a, double b)
        {
            return ReferenceEquals(a, new Complex(b));
        }

        public static bool operator !=(Complex a, double b)
        {
            return !(a == b);
        }

        public static Complex operator +(Complex a, Complex b)
        {
            return new Complex(a.Re + b.Re, a.Im + b.Im);
        }

        public static Complex operator -(Complex a, Complex b)
        {
            return new Complex(a.Re - b.Re, a.Im - b.Im);
        }

        public static Complex operator *(Complex a, Complex b)
        {
            return new Complex(a.Re * b.Re - a.Im * b.Im, a.Im * b.Re + a.Re * b.Im);
        }

        public static Complex operator *(Complex a, double d)
        {
            return new Complex(d * a.Re, d * a.Im);
        }

        public static Complex operator *(double d, Complex a)
        {
            return new Complex(d * a.Re, d * a.Im);
        }

        public static Complex operator /(Complex a, Complex b)
        {
            return a * Conj(b) * (1 / (Abs(b) * Abs(b)));
        }

        public static Complex operator /(Complex a, double b)
        {
            return a * (1 / b);
        }

        /// <summary>
        /// Computes the conjugation of a complex number.
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Complex Conj(Complex a)
        {
            return new Complex(a.Re, -a.Im);
        }

        /// <summary>
        /// Calcs the absolute value of a complex number.
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static double Abs(Complex a)
        {
            return Math.Sqrt(a.Im * a.Im + a.Re * a.Re);
        }

        public override string ToString()
        {
            if (ReferenceEquals(this, Zero)) return "0";

            string im, sign;

            if (Im < 0)
            {
                // ReSharper disable once CompareOfFloatsByEqualityOperator
                sign = Re == 0 ? "-" : " - ";
            }
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            else if (Im > 0 && Re != 0) sign = " + ";
            else sign = "";

            // ReSharper disable once CompareOfFloatsByEqualityOperator
            var re = Re == 0 ? "" : Re.ToString(CultureInfo.InvariantCulture);

            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (Im == 0) im = "";
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            else if (Im == -1 || Im == 1) im = "i";
            else im = Math.Abs(Im) + "i";

            return re + sign + im;
        }
    }
}
