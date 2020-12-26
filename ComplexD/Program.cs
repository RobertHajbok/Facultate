using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComplexD
{
    class Program
    {
        static void Main(string[] args)
        {
            ComplexD c = new ComplexD(5, 5);

            Console.WriteLine("c^3 = {0}", c ^ 3);

            ComplexD[] v = new ComplexD[5];

            Random r = new Random();
            for (int i = 0; i < 5; i++)
            {
                v[i] = new ComplexD(r.Next(1, 10), r.Next(1, 10));

                Console.WriteLine("v[{0}] = {1}", i, v[i]);
            }

            Console.WriteLine("Distanta minima : {0}", c.DistantaMinimaLa(v));
            Console.ReadKey();
        }
    }
}
