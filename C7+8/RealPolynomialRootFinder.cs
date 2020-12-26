using System;
using System.Collections.Generic;
using System.Numerics;

namespace C7_8
{
    internal class RealPolynomialRootFinder
    {
        //Global variables that assist the computation, taken from the Visual Studio C++ compiler class float
        // smallest such that 1.0+DBL_EPSILON != 1.0 
        private const double DblEpsilon = 2.22044604925031E-16;
        // max value 
        private const double DblMax = 1.79769313486232E+307;
        // min positive value 
        private const double DblMin = 2.2250738585072E-308;
        //If needed, set the maximum allowed degree for the polynomial here:
        private const int MaxDegreePolynomial = 100;
        //It is done to allocate memory for the computation arrays, so be careful to not set i too high, though in practice it should not be a problem as it is now.

        /// <summary>
        ///     The Jenkins–Traub algorithm for polynomial zeros translated into pure VB.NET. It is a translation of the C++
        ///     algorithm, which in turn is a translation of the FORTRAN code by Jenkins. See Wikipedia for referances:
        ///     http://en.wikipedia.org/wiki/Jenkins%E2%80%93Traub_algorithm
        /// </summary>
        /// <param name="input">
        ///     The coefficients for the polynomial starting with the highest degree and ends on the constant,
        ///     missing degree must be implemented as a 0.
        /// </param>
        /// <returns>All the real and complex roots that are found is returned in a list of complex numbers.</returns>
        /// <remarks>
        ///     The maximum alloed degree polynomial for this implementation is set to 100. It can only take real
        ///     coefficients.
        /// </remarks>
        public static List<Complex> FindRoots(params double[] input)
        {
            var result = new List<Complex>();

            var nz = 0;

            //Helper variable that indicates the maximum length of the polynomial array
            const int maxDegreeHelper = MaxDegreePolynomial + 1;

            //Actual degree calculated from the imtems in the Input ParamArray
            var degree = input.Length - 1;

            var op = new double[maxDegreeHelper + 1];
            var k = new double[maxDegreeHelper + 1];
            var p = new double[maxDegreeHelper + 1];
            var pt = new double[maxDegreeHelper + 1];
            var qp = new double[maxDegreeHelper + 1];
            var temp = new double[maxDegreeHelper + 1];
            var zeror = new double[maxDegreeHelper + 1];
            var zeroi = new double[MaxDegreePolynomial + 1];
            double lzi = 0;
            double lzr = 0;
            double szi = 0;
            double szr = 0;

            const double radfac = 3.14159265358979 / 180;
            // Degrees-to-radians conversion factor = pi/180
            var lb2 = Math.Log(2.0);
            // Dummy variable to avoid re-calculating this value in loop below
            const double lo = DblMin / DblEpsilon;
            //Double.MinValue / Double.Epsilon
            var cosr = Math.Cos(94.0 * radfac);
            // = -0.069756474
            var sinr = Math.Sin(94.0 * radfac);
            // = 0.99756405

            //Are the polynomial larger that the maximum allowed?
            if (degree > MaxDegreePolynomial)
            {
                throw new Exception(
                    "The entered Degree is greater than MAXDEGREE. Exiting root finding algorithm. No further action taken.");
            }

            //Check if the leading coefficient is zero
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (input[0] != 0)
            {
                for (var i = 0; i <= input.Length - 1; i++)
                {
                    op[i] = input[i];
                }

                var n = degree;
                var xx = Math.Sqrt(0.5);
                //= 0.70710678
                var yy = -xx;

                // Remove zeros at the origin, if any
                var j = 0;
                // ReSharper disable once CompareOfFloatsByEqualityOperator
                while ((op[n] == 0))
                {
                    zeror[j] = 0;
                    zeroi[j] = 0.0;
                    n -= 1;
                    j += 1;
                }

                var nn = n + 1;

                for (var i = 0; i <= nn - 1; i++)
                {
                    p[i] = op[i];
                }

                while (n >= 1)
                {
                    //Start the algorithm for one zero
                    if (n <= 2)
                    {
                        if (n < 2)
                        {
                            //1st degree polynomial
                            zeror[(degree) - 1] = -(p[1] / p[0]);
                            zeroi[(degree) - 1] = 0.0;
                        }
                        else
                        {
                            //2nd degree polynomial
                            Quad_ak1(p[0], p[1], p[2], ref zeror[((degree) - 2)], ref zeroi[((degree) - 2)],
                                ref zeror[((degree) - 1)], ref zeroi[(degree) - 1]);
                        }
                        //Solutions have been calculated, so exit the loop
                        break;
                    }

                    var moduliMax = 0.0;
                    var moduliMin = DblMax;

                    double x;
                    for (var i = 0; i <= nn - 1; i++)
                    {
                        x = Math.Abs(p[i]);
                        if ((x > moduliMax))
                            moduliMax = x;
                        // ReSharper disable once CompareOfFloatsByEqualityOperator
                        if (((x != 0) & (x < moduliMin)))
                            moduliMin = x;
                    }

                    // Scale if there are large or very small coefficients
                    // Computes a scale factor to multiply the coefficients of the polynomial. The scaling
                    // is done to avoid overflow and to avoid undetected underflow interfering with the
                    // convergence criterion.
                    // The factor is a power of the base.

                    //  Scaling the polynomial
                    var sc = lo / moduliMin;

                    if ((((sc <= 1.0) & (moduliMax >= 10)) | ((sc > 1.0) & (DblMax / sc >= moduliMax))))
                    {
                        // ReSharper disable once CompareOfFloatsByEqualityOperator
                        if (sc == 0)
                        {
                            sc = DblMin;
                        }

                        var l = Convert.ToInt32(Math.Log(sc) / lb2 + 0.5);
                        var factor = Math.Pow(2.0, l);
                        // ReSharper disable once CompareOfFloatsByEqualityOperator
                        if ((factor != 1.0))
                        {
                            for (var i = 0; i <= nn; i++)
                            {
                                p[i] *= factor;
                            }
                        }
                    }

                    //Compute lower bound on moduli of zeros
                    for (var i = 0; i <= nn - 1; i++)
                    {
                        pt[i] = Math.Abs(p[i]);
                    }
                    pt[n] = -(pt[n]);

                    var nm1 = n - 1;

                    // Compute upper estimate of bound
                    x = Math.Exp((Math.Log(-pt[n]) - Math.Log(pt[0])) / Convert.ToDouble(n));

                    double xm;
                    // ReSharper disable once CompareOfFloatsByEqualityOperator
                    if ((pt[nm1] != 0))
                    {
                        // If Newton step at the origin is better, use it
                        xm = -pt[n] / pt[nm1];
                        if (xm < x)
                        {
                            x = xm;
                        }
                    }

                    // Chop the interval (0, x) until ff <= 0
                    xm = x;

                    double ff;
                    do
                    {
                        x = xm;
                        xm = 0.1 * x;
                        ff = pt[0];
                        for (var i = 1; i <= nn - 1; i++)
                        {
                            ff = ff * xm + pt[i];
                        }
                    } while ((ff > 0));

                    double dx;

                    do
                    {
                        var df = pt[0];
                        ff = pt[0];
                        for (var i = 1; i <= n - 1; i++)
                        {
                            ff = x * ff + pt[i];
                            df = x * df + ff;
                        }
                        ff = x * ff + pt[n];
                        dx = ff / df;
                        x -= dx;
                    } while ((Math.Abs(dx / x) > 0.005));

                    var bnd = x;

                    // Compute the derivative as the initial K polynomial and do 5 steps with no shift
                    for (var i = 1; i <= n - 1; i++)
                    {
                        k[i] = Convert.ToDouble(n - i) * p[i] / (Convert.ToDouble(n));
                    }
                    k[0] = p[0];

                    var aa = p[n];
                    var bb = p[nm1];
                    // ReSharper disable once CompareOfFloatsByEqualityOperator
                    var zerok = (k[nm1] == 0) ? 1 : 0;

                    for (var jj = 0; jj <= 4; jj++)
                    {
                        var cc = k[nm1];
                        if ((zerok == 1))
                        {
                            // Use unscaled form of recurrence
                            for (var i = 0; i <= nm1 - 1; i++)
                            {
                                j = nm1 - i;
                                k[j] = k[j - 1];
                            }
                            k[0] = 0;
                            // ReSharper disable once CompareOfFloatsByEqualityOperator
                            zerok = (k[nm1] == 0) ? 1 : 0;
                        }
                        else
                        {
                            // Used scaled form of recurrence if value of K at 0 is nonzero
                            var t = -aa / cc;
                            for (var i = 0; i <= nm1 - 1; i++)
                            {
                                j = nm1 - i;
                                k[j] = t * k[j - 1] + p[j];
                            }
                            k[0] = p[0];
                            zerok = (Math.Abs(k[nm1]) <= Math.Abs(bb) * DblEpsilon * 10.0) ? 1 : 0;
                        }
                    }

                    // Save K for restarts with new shifts
                    for (var i = 0; i <= n - 1; i++)
                    {
                        temp[i] = k[i];
                    }


                    for (var jj = 1; jj <= 20; jj++)
                    {
                        // Quadratic corresponds to a double shift to a non-real point and its
                        // complex conjugate. The point has modulus BND and amplitude rotated
                        // by 94 degrees from the previous shift.

                        var xxx = -(sinr * yy) + cosr * xx;
                        yy = sinr * xx + cosr * yy;
                        xx = xxx;
                        var sr = bnd * xx;
                        var u = -(2.0 * sr);

                        // Second stage calculation, fixed quadratic
                        Fxshfr_ak1(20 * jj, ref nz, sr, bnd, k, n, p, nn, qp, u, ref lzi, ref lzr, ref szi, ref szr);


                        if ((nz != 0))
                        {
                            // The second stage jumps directly to one of the third stage iterations and
                            // returns here if successful. Deflate the polynomial, store the zero or
                            // zeros, and return to the main algorithm.

                            j = (degree) - n;
                            zeror[j] = szr;
                            zeroi[j] = szi;
                            nn = nn - nz;
                            n = nn - 1;
                            for (var i = 0; i <= nn - 1; i++)
                            {
                                p[i] = qp[i];
                            }
                            if ((nz != 1))
                            {
                                zeror[j + 1] = lzr;
                                zeroi[j + 1] = lzi;
                            }

                            //Found roots start all calulations again, with a lower order polynomial
                            break;
                        }
                        // If the iteration is unsuccessful, another quadratic is chosen after restoring K
                        for (var i = 0; i <= n - 1; i++)
                        {
                            k[i] = temp[i];
                        }
                        if ((jj >= 20))
                        {
                            throw new Exception("Failure. No convergence after 20 shifts. Program terminated.");
                        }
                    }
                }
            }
            else
            {
                throw new Exception("The leading coefficient is zero. No further action taken. Program terminated.");
            }

            for (var i = 0; i <= degree - 1; i++)
            {
                result.Add(new Complex(zeror[degree - 1 - i], zeroi[degree - 1 - i]));
            }

            return result;
        }

        private static void Quad_ak1(double a, double b1, double c, ref double sr, ref double si, ref double lr,
            ref double li)
        {
            // Calculates the zeros of the quadratic a*Z^2 + b1*Z + c
            // The quadratic formula, modified to avoid overflow, is used to find the larger zero if the
            // zeros are real and both zeros are complex. The smaller real zero is found directly from
            // the product of the zeros c/a.

            double d;
            double e;

            sr = 0;
            si = 0;
            li = 0.0;

            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (a == 0)
            {
                // ReSharper disable once CompareOfFloatsByEqualityOperator
                if (b1 == 0)
                {
                    sr = -c / b1;
                }
            }

            //Compute discriminant avoiding overflow
            var b = b1 / 2.0;

            if (Math.Abs(b) < Math.Abs(c))
            {
                if (c >= 0)
                {
                    e = a;
                }
                else
                {
                    e = -a;
                }

                e = -e + b * (b / Math.Abs(c));
                d = Math.Sqrt(Math.Abs(e)) * Math.Sqrt(Math.Abs(c));
            }
            else
            {
                e = -((a / b) * (c / b)) + 1.0;
                d = Math.Sqrt(Math.Abs(e)) * (Math.Abs(b));
            }


            if ((e >= 0))
            {
                // Real zero
                if (b >= 0)
                {
                    d *= -1;
                }
                lr = (-b + d) / a;

                // ReSharper disable once CompareOfFloatsByEqualityOperator
                if (lr != 0)
                {
                    sr = (c / (lr)) / a;
                }
            }
            else
            {
                // Complex conjugate zeros
                lr = -(b / a);
                sr = -(b / a);
                si = Math.Abs(d / a);
                li = -(si);
            }
        }

        private static void Fxshfr_ak1(int L2, ref int NZ, double sr, double v, double[] K, int N, double[] p, int NN,
            double[] qp, double u, ref double lzi, ref double lzr, ref double szi, ref double szr)
        {
            // Computes up to L2 fixed shift K-polynomials, testing for convergence in the linear or
            // quadratic case. Initiates one of the variable shift iterations and returns with the
            // number of zeros found.

            // L2 limit of fixed shift steps
            // NZ number of zeros found

            int j;
            var iFlag = 1;
            double a = 0;
            double a1 = 0;
            double a3 = 0;
            double a7 = 0;
            double b = 0;
            double c = 0;
            double d = 0;
            double e = 0;
            double f = 0;
            double g = 0;
            double h = 0;
            double ots = 0;
            double otv = 0;
            double ui = 0;
            double vi = 0;
            var qk = new double[100 + 2];
            var svk = new double[100 + 2];

            NZ = 0;
            var betav = 0.25;
            var betas = 0.25;
            var oss = sr;
            var ovv = v;

            // Evaluate polynomial by synthetic division
            QuadSD_ak1(NN, u, v, p, qp, ref a, ref b);

            var tFlag = calcSC_ak1(N, a, b, ref a1, ref a3, ref a7, ref c, ref d, ref e, ref f,
                ref g, ref h, K, u, v, qk);


            for (j = 0; j <= L2 - 1; j++)
            {
                const int fflag = 1;
                // Calculate next K polynomial and estimate v
                nextK_ak1(N, tFlag, a, b, a1, ref a3, ref a7, K, qk, qp);
                tFlag = calcSC_ak1(N, a, b, ref a1, ref a3, ref a7, ref c, ref d, ref e, ref f,
                    ref g, ref h, K, u, v, qk);
                newest_ak1(tFlag, ref ui, ref vi, a, a1, a3, a7, b, c, d,
                    f, g, h, u, v, K, N, p);

                var vv = vi;

                // Estimate s
                double ss;
                // ReSharper disable once CompareOfFloatsByEqualityOperator
                if (K[N - 1] != 0)
                {
                    ss = -(p[N] / K[N - 1]);
                }
                else
                {
                    ss = 0;
                }

                double ts = 1;
                var tv = 1.0;


                if (((j != 0) & (tFlag != 3)))
                {
                    // Compute relative measures of convergence of s and v sequences
                    // ReSharper disable once CompareOfFloatsByEqualityOperator
                    if (vv != 0)
                    {
                        tv = Math.Abs((vv - ovv) / vv);
                    }

                    // ReSharper disable once CompareOfFloatsByEqualityOperator
                    if (ss != 0)
                    {
                        ts = Math.Abs((ss - oss) / ss);
                    }


                    // If decreasing, multiply the two most recent convergence measures

                    double tvv;
                    if (tv < otv)
                    {
                        tvv = tv * otv;
                    }
                    else
                    {
                        tvv = 1;
                    }


                    double tss;
                    if (ts < ots)
                    {
                        tss = ts * ots;
                    }
                    else
                    {
                        tss = 1;
                    }

                    // Compare with convergence criteria

                    var vpass = tvv < betav ? 1 : 0;

                    var spass = tss < betas ? 1 : 0;


                    if (((spass == 1) | (vpass == 1)))
                    {
                        // At least one sequence has passed the convergence test.
                        // Store variables before iterating

                        int i;
                        for (i = 0; i <= N - 1; i++)
                        {
                            svk[i] = K[i];
                        }

                        var s = ss;

                        // Choose iteration according to the fastest converging sequence
                        var stry = 0;
                        var vtry = 0;


                        do
                        {
                            if ((fflag == 1 & ((fflag == 0))) & ((spass == 1) & (vpass != 1 | (tss < tvv))))
                            {
                                // Do nothing. Provides a quick "short circuit".
                            }
                            else
                            {
                                QuadIT_ak1(N, ref NZ, ui, vi, ref szr, ref szi, ref lzr, ref lzi, qp, NN,
                                    ref a, ref b, p, qk, ref a1, ref a3, ref a7, ref c, ref d, ref e,
                                    ref f, ref g, ref h, K);

                                if (((NZ) > 0))
                                    return;

                                // Quadratic iteration has failed. Flag that it has been tried and decrease the
                                // convergence criterion

                                iFlag = 1;
                                vtry = 1;
                                betav *= 0.25;

                                // Try linear iteration if it has not been tried and the s sequence is converging
                                if ((stry == 1 | (spass != 1)))
                                {
                                    iFlag = 0;
                                }
                                else
                                {
                                    for (i = 0; i <= N - 1; i++)
                                    {
                                        K[i] = svk[i];
                                    }
                                }
                            }

                            if ((iFlag != 0))
                            {
                                RealIT_ak1(ref iFlag, ref NZ, ref s, N, p, NN, qp, ref szr, ref szi, K,
                                    qk);

                                if (((NZ) > 0))
                                    return;

                                // Linear iteration has failed. Flag that it has been tried and decrease the
                                // convergence criterion
                                stry = 1;
                                betas *= 0.25;


                                if ((iFlag != 0))
                                {
                                    // If linear iteration signals an almost double real zero, attempt quadratic iteration
                                    ui = -(s + s);
                                    vi = s * s;
                                }
                            }

                            // Restore variables
                            for (i = 0; i <= N - 1; i++)
                            {
                                K[i] = svk[i];
                            }


                            // Try quadratic iteration if it has not been tried and the v sequence is converging
                            if ((vpass != 1 | vtry == 1))
                            {
                                // Break out of infinite for loop
                                break;
                            }
                        } while (true);

                        // Re-compute qp and scalar values to continue the second stage
                        QuadSD_ak1(NN, u, v, p, qp, ref a, ref b);
                        tFlag = calcSC_ak1(N, a, b, ref a1, ref a3, ref a7, ref c, ref d, ref e, ref f,
                            ref g, ref h, K, u, v, qk);
                    }
                }

                ovv = vv;
                oss = ss;
                otv = tv;
                ots = ts;
            }
        }

        private static void QuadSD_ak1(int NN, double u, double v, IReadOnlyList<double> p, IList<double> q, ref double a, ref double b)
        {
            // Divides p by the quadratic 1, u, v placing the quotient in q and the remainder in a, b

            int i;

            b = p[0];
            q[0] = p[0];

            a = -((b) * u) + p[1];
            q[1] = -((b) * u) + p[1];

            for (i = 2; i <= NN - 1; i++)
            {
                q[i] = -((a) * u + (b) * v) + p[i];
                b = (a);
                a = q[i];
            }
        }

        private static int calcSC_ak1(int N, double a, double b, ref double a1, ref double a3, ref double a7,
            ref double c, ref double d, ref double e, ref double f,
            ref double g, ref double h, double[] K, double u, double v, double[] qk)
        {
            // This routine calculates scalar quantities used to compute the next K polynomial and
            // new estimates of the quadratic coefficients.

            // calcSC - integer variable set here indicating how the calculations are normalized
            // to avoid overflow.

            var dumFlag = 3;
            // TYPE = 3 indicates the quadratic is almost a factor of K

            // Synthetic division of K by the quadratic 1, u, v
            QuadSD_ak1(N, u, v, K, qk, ref c, ref d);

            if ((Math.Abs((c)) <= (100.0 * DblEpsilon * Math.Abs(K[N - 1]))))
            {
                if ((Math.Abs((d)) <= (100.0 * DblEpsilon * Math.Abs(K[N - 2]))))
                {
                    return dumFlag;
                }
            }

            h = v * b;
            if ((Math.Abs((d)) >= Math.Abs((c))))
            {
                dumFlag = 2;
                // TYPE = 2 indicates that all formulas are divided by d
                e = a / (d);
                f = (c) / (d);
                g = u * b;
                a3 = (e) * ((g) + a) + (h) * (b / (d));
                a1 = -a + (f) * b;
                a7 = (h) + ((f) + u) * a;
            }
            else
            {
                dumFlag = 1;
                // TYPE = 1 indicates that all formulas are divided by c
                e = a / (c);
                f = (d) / (c);
                g = (e) * u;
                a3 = (e) * a + ((g) + (h) / (c)) * b;
                a1 = -(a * ((d) / (c))) + b;
                a7 = (g) * (d) + (h) * (f) + a;
            }

            return dumFlag;
        }

        private static void nextK_ak1(int n, int tFlag, double a, double b, double a1, ref double a3, ref double a7,
            IList<double> k, IReadOnlyList<double> qk, IReadOnlyList<double> qp)
        {
            // Computes the next K polynomials using the scalars computed in calcSC_ak1

            int i;
            double temp;

            // Use unscaled form of the recurrence
            switch (tFlag)
            {
                case 3:
                    k[1] = 0;
                    k[0] = 0.0;

                    for (i = 2; i <= n - 1; i++)
                    {
                        k[i] = qk[i - 2];
                    }

                    return;
                case 1:
                    temp = b;
                    break;
                default:
                    temp = a;
                    break;
            }


            if ((Math.Abs(a1) > (10.0 * DblEpsilon * Math.Abs(temp))))
            {
                // Use scaled form of the recurrence

                a7 = a7 / a1;
                a3 = a3 / a1;
                k[0] = qp[0];
                k[1] = -((a7) * qp[0]) + qp[1];

                for (i = 2; i <= n - 1; i++)
                {
                    k[i] = -((a7) * qp[i - 1]) + (a3) * qk[i - 2] + qp[i];
                }
            }
            else
            {
                // If a1 is nearly zero, then use a special form of the recurrence

                k[0] = 0.0;
                k[1] = -(a7) * qp[0];

                for (i = 2; i <= n - 1; i++)
                {
                    k[i] = -((a7) * qp[i - 1]) + (a3) * qk[i - 2];
                }
            }
        }

        private static void newest_ak1(int tFlag, ref double uu, ref double vv, double a, double a1, double a3,
            double a7, double b, double c, double d, double f, double g, double h, double u, double v, IReadOnlyList<double> k, int n, IReadOnlyList<double> p)
        {
            // Compute new estimates of the quadratic coefficients using the scalars computed in calcSC_ak1

            vv = 0;
            //The quadratic is zeroed
            uu = 0.0;
            //The quadratic is zeroed


            if ((tFlag == 3)) return;
            double a4;
            double a5;
            if ((tFlag != 2))
            {
                a4 = a + u * b + h * f;
                a5 = c + (u + v * f) * d;
            }
            else
            {
                a4 = (a + g) * f + h;
                a5 = (f + u) * c + v * d;
            }

            // Evaluate new quadratic coefficients
            var b1 = -k[n - 1] / p[n];
            var b2 = -(k[n - 2] + b1 * p[n - 1]) / p[n];
            var c1 = v * b2 * a1;
            var c2 = b1 * a7;
            var c3 = b1 * b1 * a3;
            var c4 = -(c2 + c3) + c1;
            var temp = -c4 + a5 + b1 * a4;
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if ((temp == 0.0)) return;
            uu = -((u * (c3 + c2) + v * (b1 * a1 + b2 * a7)) / temp) + u;
            vv = v * (1.0 + c4 / temp);
        }

        private static void QuadIT_ak1(int n, ref int nz, double uu, double vv, ref double szr, ref double szi, ref double lzr, ref double lzi,
            double[] qp, int nn, ref double a, ref double b, IReadOnlyList<double> p, double[] qk, ref double a1, ref double a3, 
            ref double a7, ref double c, ref double d, ref double e, ref double f, ref double g, ref double h, double[] k)
        {
            // Variable-shift K-polynomial iteration for a quadratic factor converges only if the
            // zeros are equimodular or nearly so.

            var j = 0;
            var triedFlag = 0;

            double omp = 0;
            double relstp = 0;
            double ui = 0;
            double vi = 0;

            nz = 0;
            //Number of zeros found
            var u = uu;
            //uu and vv are coefficients of the starting quadratic
            var v = vv;

            do
            {
                Quad_ak1(1.0, u, v, ref szr, ref szi, ref lzr, ref lzi);

                // Return if roots of the quadratic are real and not close to multiple or nearly
                // equal and of opposite sign.
                if ((Math.Abs(Math.Abs(szr) - Math.Abs(lzr)) > 0.01 * Math.Abs(lzr)))
                {
                    break;
                }

                // Evaluate polynomial by quadratic synthetic division
                QuadSD_ak1(nn, u, v, p, qp, ref a, ref b);

                var mp = Math.Abs(-((szr) * (b)) + (a)) + Math.Abs((szi) * (b));

                // Compute a rigorous bound on the rounding error in evaluating p
                var zm = Math.Sqrt(Math.Abs(v));
                var ee = 2.0 * Math.Abs(qp[0]);
                var t = -((szr) * (b));

                int i;
                for (i = 1; i <= n - 1; i++)
                {
                    ee = ee * zm + Math.Abs(qp[i]);
                }

                ee = ee * zm + Math.Abs((a) + t);
                ee = (9.0 * ee + 2.0 * Math.Abs(t) - 7.0 * (Math.Abs((a) + t) + zm * Math.Abs((b)))) * DblEpsilon;

                // Iteration has converged sufficiently if the polynomial value is less than 20 times this bound
                if ((mp <= 20.0 * ee))
                {
                    nz = 2;
                    break;
                }

                j += 1;

                // Stop iteration after 20 steps
                if ((j > 20))
                    break;

                int tFlag;
                if ((j >= 2))
                {
                    if (((relstp <= 0.01) & (mp >= omp) & (triedFlag != 1)))
                    {
                        // A cluster appears to be stalling the convergence. Five fixed shift
                        // steps are taken with a u, v close to the cluster.
                        relstp = Math.Sqrt(relstp < DblEpsilon ? DblEpsilon : relstp);

                        u -= u * relstp;
                        v += v * relstp;

                        QuadSD_ak1(nn, u, v, p, qp, ref a, ref b);

                        for (i = 0; i <= 4; i++)
                        {
                            tFlag = calcSC_ak1(n, a, b, ref a1, ref a3, ref a7, ref c, ref d, ref e, ref f,
                                ref g, ref h, k, u, v, qk);
                            nextK_ak1(n, tFlag, a, b, a1, ref a3, ref a7, k, qk, qp);
                        }

                        triedFlag = 1;
                        j = 0;
                    }
                }

                omp = mp;

                // Calculate next K polynomial and new u and v
                tFlag = calcSC_ak1(n, a, b, ref a1, ref a3, ref a7, ref c, ref d, ref e, ref f,
                    ref g, ref h, k, u, v, qk);
                nextK_ak1(n, tFlag, a, b, a1, ref a3, ref a7, k, qk, qp);
                tFlag = calcSC_ak1(n, a, b, ref a1, ref a3, ref a7, ref c, ref d, ref e, ref f,
                    ref g, ref h, k, u, v, qk);
                newest_ak1(tFlag, ref ui, ref vi, a, a1, a3, a7, b, c, d,
                    f, g, h, u, v, k, n, p);

                // If vi is zero, the iteration is not converging
                // ReSharper disable once CompareOfFloatsByEqualityOperator
                if ((vi == 0)) continue;
                relstp = Math.Abs((-v + vi) / vi);
                u = ui;
                v = vi;
                // ReSharper disable once CompareOfFloatsByEqualityOperator
            } while ((vi != 0));
        }

        private static void RealIT_ak1(ref int iFlag, ref int nz, ref double sss, int n, IReadOnlyList<double> p, int nn, IList<double> qp,
            ref double szr, ref double szi, IList<double> k, IList<double> qk)
        {
            // Variable-shift H-polynomial iteration for a real zero

            // sss - starting iterate
            // NZ - number of zeros found
            // iFlag - flag to indicate a pair of zeros near real axis
            var j = 0;
            var nm1 = n - 1;
            double omp = 0;
            double t = 0;

            iFlag = 0;
            nz = 0;
            var s = sss;

            do
            {
                var pv = p[0];

                // Evaluate p at s
                qp[0] = pv;
                int i;
                for (i = 1; i <= nn - 1; i++)
                {
                    qp[i] = pv * s + p[i];
                    pv = pv * s + p[i];
                }
                var mp = Math.Abs(pv);

                // Compute a rigorous bound on the error in evaluating p
                var ms = Math.Abs(s);
                var ee = 0.5 * Math.Abs(qp[0]);
                for (i = 1; i <= nn - 1; i++)
                {
                    ee = ee * ms + Math.Abs(qp[i]);
                }

                // Iteration has converged sufficiently if the polynomial value is less than
                // 20 times this bound
                if ((mp <= 20.0 * DblEpsilon * (2.0 * ee - mp)))
                {
                    nz = 1;
                    szr = s;
                    szi = 0.0;
                    break;
                }

                j += 1;

                // Stop iteration after 10 steps
                if ((j > 10))
                    break;

                if ((j >= 2))
                {
                    if (((Math.Abs(t) <= 0.001 * Math.Abs(-t + s)) & (mp > omp)))
                    {
                        // A cluster of zeros near the real axis has been encountered                    
                        // Return with iFlag set to initiate a quadratic iteration

                        iFlag = 1;
                        sss = s;
                        break;
                    }
                }

                // Return if the polynomial value has increased significantly
                omp = mp;

                // Compute t, the next polynomial and the new iterate
                qk[0] = k[0];
                var kv = k[0];
                for (i = 1; i <= n - 1; i++)
                {
                    kv = kv * s + k[i];
                    qk[i] = kv;
                }
                if ((Math.Abs(kv) > Math.Abs(k[nm1]) * 10.0 * DblEpsilon))
                {
                    // Use the scaled form of the recurrence if the value of K at s is non-zero
                    t = -(pv / kv);
                    k[0] = qp[0];
                    for (i = 1; i <= n - 1; i++)
                    {
                        k[i] = t * qk[i - 1] + qp[i];
                    }
                }
                else
                {
                    // Use unscaled form
                    k[0] = 0.0;
                    for (i = 1; i <= n - 1; i++)
                    {
                        k[i] = qk[i - 1];
                    }
                }

                kv = k[0];
                for (i = 1; i <= n - 1; i++)
                {
                    kv = kv * s + k[i];
                }

                if ((Math.Abs(kv) > (Math.Abs(k[nm1]) * 10.0 * DblEpsilon)))
                {
                    t = -(pv / kv);
                }
                else
                {
                    t = 0.0;
                }

                s += t;
            } while (true);
        }
    }
}