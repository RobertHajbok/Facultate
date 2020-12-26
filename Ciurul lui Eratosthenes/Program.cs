using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ciurul_lui_Eratosthenes
{
    class Program
    {
        static void Main()
        {
            int n, i, j;
            int[] c;
            n = Convert.ToInt32(Console.ReadLine());
            c = new int[n + 1];
            for (i = 2; i <= n; i++)
                c[i] = i;
            i = 2;
            while (i <= n / 2)  //cel mai mare divizor propriu al unui numar este<=jumatatea sa
            {
                if (c[i] != 0)
                {
                    j = 2 * i;
                    while (j <= n)
                    {
                        if (c[j] != 0)
                            c[j] = 0;
                        j += i;
                    }
                }
                i++;
            }
            for (i = 2; i <= n; i++)
                if (c[i] != 0)
                    Console.Write(c[i] + " ");
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
