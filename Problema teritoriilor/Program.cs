using System;

namespace Problema_teritoriilor
{
    class Program
    {
        static void Main()
        {
            var a = new int[4, 4];
            var b = new int[4, 4];
            var r = new Random();

            for (var i = 0; i < 4; i++)
            {
                for (var j = 0; j < 4; j++)
                {
                    a[i, j] = r.Next(4);
                    b[i, j] = 0;

                    Console.Write("{0} ", a[i, j]);
                }

                Console.WriteLine();
            }

            var min = 0;
            for (var i = 0; i < 4; i++)
            {
                for (var j = 0; j < 4; j++)
                {
                    int t = a[i, j];
                    int dim = 0;

                    Pa(a, b, 4, ref dim, t, i, j);

                    if (dim > min)
                        min = dim;
                }
            }

            Console.WriteLine("\nMaxim = {0}", min);

            Console.ReadKey();
        }

        static void Pa(int[,] a, int[,] b, int n, ref int dim, int t, int i, int j)
        {
            if (i >= 0 && j >= 0 && i < n && j < n && b[i, j] == 0 && a[i, j] == t)
            {
                if (t == a[i, j])
                    dim++;

                //Console.WriteLine("A[{0}][{1}] = {2}", i, j, A[i, j]);

                b[i, j] = 1;

                Pa(a, b, n, ref dim, t, i + 1, j);
                Pa(a, b, n, ref dim, t, i - 1, j);
                Pa(a, b, n, ref dim, t, i, j + 1);
                Pa(a, b, n, ref dim, t, i, j - 1);
            }
        }
    }
}
