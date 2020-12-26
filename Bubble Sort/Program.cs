using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bubble_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, j, n, ok = 0, aux;
            int[] t;
            Console.Write("Dati dimensiunea vectorului: ");
            n = int.Parse(Console.ReadLine());
            t = new int[n];
            Random r = new Random();
            for (i = 0; i < n; i++)
                t[i] = r.Next(0, 100);
            Console.WriteLine("Vectorul generat initial:");
            for (i = 0; i < n; i++)
                Console.Write(t[i] + " ");
            Console.WriteLine();
            for (i = n - 1; i > 0 && ok == 0; i--)
            {
                ok = 1;
                for (j = 0; j < i; j++)
                    if (t[j] > t[j + 1])
                    {
                        aux = t[j];
                        t[j] = t[j + 1];
                        t[j + 1] = aux;
                        ok = 0;
                    }
            }
            Console.WriteLine("Vectorul ordonat este:");
            for (i = 0; i < t.Length; i++)
                Console.Write(t[i] + " ");
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
