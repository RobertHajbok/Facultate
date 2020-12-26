namespace C7_8
{
    public class Matrix
    {
        public double[][] Matr;
        public double[][] Lu;
        private readonly int _n;
        public int Pivsign;

        public Matrix(double[][] matr, int n)
        {
            Lu = matr;
            _n = n;
            Pivsign = 1;
            Matr = matr;

            var lUcolj = new double[n];
            for (var j = 0; j < n; j++)
            {

                for (var i = 0; i < n; i++)
                {
                    lUcolj[i] = Lu[i][j];
                }

                for (var i = 0; i < n; i++)
                {
                    var lUrowi = Lu[i];

                    var kmax = System.Math.Min(i, j);
                    var s = 0.0;
                    for (var k = 0; k < kmax; k++)
                    {
                        s += lUrowi[k] * lUcolj[k];
                    }

                    lUrowi[j] = lUcolj[i] -= s;
                }

                var p = j;
                for (var i = j + 1; i < n; i++)
                {
                    if (System.Math.Abs(lUcolj[i]) > System.Math.Abs(lUcolj[p]))
                    {
                        p = i;
                    }
                }
                if (p != j)
                {
                    for (var k = 0; k < n; k++)
                    {
                        var t = Lu[p][k]; Lu[p][k] = Lu[j][k]; Lu[j][k] = t;
                    }
                    Pivsign = -Pivsign;
                }

                // ReSharper disable once CompareOfFloatsByEqualityOperator
                if (!(j < n & Lu[j][j] != 0.0)) continue;
                for (var i = j + 1; i < n; i++)
                {
                    Lu[i][j] /= Lu[j][j];
                }
            }
        }

        public double Determinant()
        {
            double d = Pivsign;
            for (var j = 0; j < _n; j++)
            {
                d *= Lu[j][j];
            }
            return d;
        }
    }
}
