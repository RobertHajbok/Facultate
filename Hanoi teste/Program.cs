using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hanoi_teste
{
    class Program
    {
        static int nr1 = 0;
        static int nr2 = 0;        

        static void Main(string[] args)
        {
            Console.Write("Introduceti numarul de discuri: ");
            int nrDiscuri = int.Parse(Console.ReadLine());
            Hanoi4tije(nrDiscuri, 'A', 'B', 'C', 'D');
            Hanoi3tije(nrDiscuri, 'A', 'B', 'C');
            Console.WriteLine("Numarul de mutari necesare pentru 4 tije cu {0} discuri este {1} ", nrDiscuri, nr1);
            Console.WriteLine("Numarul de mutari necesare pentru 3 tije cu {0} discuri este {1} ", nrDiscuri, nr2);
            Console.ReadKey();
        }

        static void Hanoi4tije(int nDiscuri, char tSursa, char tInter1, char tInter2, char tDest)
        {
            if (nDiscuri == 1)
                nr1++;
            else
                if (nDiscuri == 2)
                {
                    nr1 += 3;
                }
                else
                {
                    Hanoi4tije(nDiscuri - 2, tSursa, tInter2, tDest, tInter1);
                    nr1 += 3;
                    Hanoi4tije(nDiscuri - 2, tInter1, tSursa, tInter2, tDest);
                }
        }

        static void Hanoi3tije(int n, char x, char y, char z)
        {
            if (n == 1)
                nr2++;
            else
            {
                Hanoi3tije(n - 1, x, z, y);
                nr2++;
                Hanoi3tije(n - 1, z, y, x);
            }
        }
    }
}
