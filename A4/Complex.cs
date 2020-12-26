using System;
using System.Linq;

namespace A4
{
    class Complex : ICloneable
    {
        protected bool Equals(Complex other)
        {
            return Real.Equals(other.Real) && Imaginar.Equals(other.Imaginar);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Complex) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                // ReSharper disable once NonReadonlyMemberInGetHashCode
                return (Real.GetHashCode()*397) ^ Imaginar.GetHashCode();
            }
        }

        public readonly double Real;
        public double Imaginar;

        public override string ToString()
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (Imaginar == 0) return Real + "";
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (Real != 0)
                // ReSharper disable once CompareOfFloatsByEqualityOperator
                return Real + (Imaginar > 0 ? "+" : "") + (Math.Abs(Imaginar) > 1 ? Imaginar + "" : "") + (Math.Abs(Imaginar) == 1 ? "-" : "") + "i";
            if (Imaginar > 0)
                return (Math.Abs(Imaginar) > 1 ? Imaginar + "" : "") + "i";
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return (Math.Abs(Imaginar) > 1 ? Imaginar + "" : "") + (Math.Abs(Imaginar) == 1 ? "-" : "") + "i";
        }

        public Complex(string prop)
        {
            if (prop.Remove(0, 1).Contains("-") || prop.Remove(0, 1).Contains("+"))
            {
                var sep = new[] { "+", "-" };
                var temp = prop.Split(sep, StringSplitOptions.RemoveEmptyEntries);
                Real = double.Parse(temp[0]);
                if (prop[0] == '-')
                    Real *= -1;
                Imaginar = double.Parse(temp[temp.Length - 1].Replace("i", "") == "" ? "1" : temp[temp.Length - 1].Replace("i", ""));
                if (prop.Remove(0, 1).Contains("-"))
                    Imaginar *= -1;
            }
            else if (prop.Contains("i"))
            {
                if (prop.Any(char.IsDigit))
                {
                    Imaginar = double.Parse(prop.Replace("i", ""));
                }
                else
                {
                    if (prop.Contains("-"))
                        Imaginar = -1;
                    else
                    {
                        Imaginar = 1;
                    }
                }
            }
            else
            {
                Real = double.Parse(prop);
            }

        }
        public void Invert()
        {
            Imaginar *= -1;
        }
        public static bool operator ==(Complex a, Complex b)
        {
            return a.Real == b.Real && b.Imaginar == a.Imaginar;
        }

        public static bool operator !=(Complex a, Complex b)
        {
            return a.Real != b.Real || b.Imaginar != a.Imaginar;
        }

        public Complex(double real, double imaginar)
        {
            Real = real;
            Imaginar = imaginar;
        }

        public object Clone()
        {
            return new Complex(Real, Imaginar);
        }
    }
}
