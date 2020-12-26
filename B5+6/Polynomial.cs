using System;
using System.Collections.Generic;
using System.Linq;

namespace B5_6
{
    public class Polynomial
    {
        /// <summary>
        /// Coefficients a_0,...,a_n of a polynomial p, such that
        /// p(x) = a_0 + a_1*x + a_2*x^2 + ... + a_n*x^n.
        /// </summary>
        public Complex[] Coefficients;

        /// <summary>
        /// Degree of the polynomial.
        /// </summary>
        public int Degree => Coefficients.Length - 1;

        /// <summary>
        /// Inits polynomial from given complex coefficient array.
        /// </summary>
        /// <param name="coeffs"></param>
        public Polynomial(params Complex[] coeffs)
        {
            if (coeffs == null || coeffs.Length < 1)
            {
                Coefficients = new Complex[1];
                Coefficients[0] = Complex.Zero;
            }
            else
            {
                Coefficients = (Complex[])coeffs.Clone();
            }
        }

        /// <summary>
        /// Inits polynomial from given real coefficient array.
        /// </summary>
        /// <param name="coeffs"></param>
        public Polynomial(params double[] coeffs)
        {
            if (coeffs == null || coeffs.Length < 1)
            {
                Coefficients = new Complex[1];
                Coefficients[0] = Complex.Zero;
            }
            else
            {
                Coefficients = new Complex[coeffs.Length];
                for (var i = 0; i < coeffs.Length; i++)
                    Coefficients[i] = new Complex(coeffs[i]);
            }
        }

        /// <summary>
        /// Computes the roots of polynomial via Weierstrass iteration.
        /// </summary>        
        /// <returns></returns>
        public Complex[] Roots()
        {
            const double tolerance = 1e-12;
            const int maxIterations = 30;

            var q = Normalize(this);
            //Polynomial q = p;

            var z = new Complex[q.Degree]; // approx. for roots
            var w = new Complex[q.Degree]; // Weierstraß corrections

            // init z
            for (var k = 0; k < q.Degree; k++)
                //z[k] = (new Complex(.4, .9)) ^ k;
                z[k] = Complex.Exp(2 * Math.PI * Complex.I * k / q.Degree);

            for (var iter = 0; iter < maxIterations
                && MaxValue(q, z) > tolerance; iter++)
                for (var i = 0; i < 10; i++)
                {
                    for (var k = 0; k < q.Degree; k++)
                        w[k] = q.Evaluate(z[k]) / WeierNull(z, k);

                    for (var k = 0; k < q.Degree; k++)
                        z[k] -= w[k];
                }

            // clean...
            for (var k = 0; k < q.Degree; k++)
            {
                z[k].Re = Math.Round(z[k].Re, 12);
                z[k].Im = Math.Round(z[k].Im, 12);
            }

            return z;
        }

        /// <summary>
        /// Normalizes the polynomial, e.i. divides each coefficient by the
        /// coefficient of a_n the greatest term if a_n != 1.
        /// </summary>
        public static Polynomial Normalize(Polynomial p)
        {
            var q = Clean(p);

            if (ReferenceEquals(q.Coefficients[q.Degree], Complex.One)) return q;
            for (var k = 0; k <= q.Degree; k++)
                q.Coefficients[k] /= q.Coefficients[q.Degree];

            return q;
        }

        /// <summary>
        /// Removes unncessary leading zeros.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Polynomial Clean(Polynomial p)
        {
            int i;

            for (i = p.Degree; i >= 0 && p.Coefficients[i] == 0; i--)
            {
            }

            var coeffs = new Complex[i + 1];

            for (var k = 0; k <= i; k++)
                coeffs[k] = p.Coefficients[k];

            return new Polynomial(coeffs);
        }

        /// <summary>
        /// Computes the greatest value |p(z_k)|.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public static double MaxValue(Polynomial p, Complex[] z)
        {
            return z.Select(t => Complex.Abs(p.Evaluate(t))).Concat(new double[] {0}).Max();
        }

        /// <summary>
        /// Evaluates polynomial by using the horner scheme.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public Complex Evaluate(Complex x)
        {
            var buf = Coefficients[Degree];

            for (var i = Degree - 1; i >= 0; i--)
            {
                buf = Coefficients[i] + x * buf;
            }

            return buf;
        }

        /// <summary>
        /// For g(x) = (x-z_0)*...*(x-z_n), this method returns
        /// g'(z_k) = \prod_{j != k} (z_k - z_j).
        /// </summary>
        /// <param name="z"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        private static Complex WeierNull(IReadOnlyList<Complex> z, int k)
        {
            if (k < 0 || k >= z.Count)
                throw new ArgumentOutOfRangeException();

            return z.Where((t, j) => j != k).Aggregate(Complex.One, (current, t) => current*(z[k] - t));
        }
    }
}
