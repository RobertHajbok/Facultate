using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rational
{
    class Rational
    {
        int numarator;
        int numitor;

        #region Constructors
        public Rational()
        {
            this.numarator = 0;
            this.numitor = 1;
        }

        public Rational(int numarator)
        {
            this.numarator = numarator;
            this.numitor = 1;
        }

        public Rational(int numarator, int numitor)
        {
            this.numarator = numarator;
            this.numitor = numitor;
        }
        #endregion

        #region Overloaded operators
        public static Rational operator *(Rational r1, int p)
        {
            return new Rational(r1.numarator * p, r1.numitor * p);
        }

        public static Rational operator /(Rational r1, int p)
        {
            return new Rational(r1.numarator / p, r1.numitor / p);
        }

        public static Rational operator +(Rational r1, Rational r2)
        {
            int cmmmc = CMMMC(r1.numitor, r2.numitor);

            int p1 = cmmmc / r1.numitor;
            int p2 = cmmmc / r2.numitor;

            return new Rational((r1.numarator * p1) + (r2.numarator * p2), cmmmc);
        }

        public static Rational operator -(Rational r1, Rational r2)
        {
            return r1 + new Rational(-r2.numarator, r2.numitor);
        }

        public static Rational operator *(Rational r1, Rational r2)
        {
            return new Rational(r1.numarator * r2.numarator, r1.numitor * r2.numitor);
        }

        public static Rational operator /(Rational r1, Rational r2)
        {
            return new Rational(r1.numarator * r2.numitor, r1.numitor * r2.numarator);
        }

        public static bool operator ==(Rational r1, Rational r2)
        {
            return (r1.numarator * r2.numitor == r1.numitor * r2.numarator);
        }

        public static bool operator !=(Rational r1, Rational r2)
        {
            return !(r1 == r2);
        }

        public static bool operator <(Rational r1, Rational r2)
        {
            return (r1.numarator * r2.numitor < r1.numitor * r2.numarator);
        }

        public static bool operator <=(Rational r1, Rational r2)
        {
            return (r1 == r2 || r1 < r2);

        }

        public static bool operator >(Rational r1, Rational r2)
        {
            return !(r1 <= r2);
        }

        public static bool operator >=(Rational r1, Rational r2)
        {
            return !(r1 < r2);
        }

        #endregion

        public Rational Simplificat()
        {
            int numarator = this.numarator;
            int numitor = this.numitor;
            int cmmdc = CMMDC(numarator, numitor);

            while (cmmdc > 1)
            {
                numarator /= cmmdc;
                numitor /= cmmdc;

                cmmdc = CMMDC(numarator, numitor);
            }

            return new Rational(numarator, numitor);
        }

        public override string ToString()
        {
            return (String.Format("{0}/{1}", numarator, numitor));
        }


        #region Helpers
        public static int CMMDC(int a, int b)
        {
            while (b != 0)
            {
                int tmp = b;
                b = a % b;
                a = tmp;
            }

            return a;
        }

        public static int CMMMC(int a, int b)
        {
            return (a * b) / CMMDC(a, b);
        }
        #endregion
    }
}
