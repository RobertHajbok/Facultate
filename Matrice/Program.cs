using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrice
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrice a = new Matrice(new int[,] {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            });
            Matrice b = new Matrice(new int[,] {
                { 4, 3, 2 },
                { 6, 5, 4 },
                { 9, 8, 7 }
            });

            Console.WriteLine("a + b = {0}", a.Aduna(b));
            Console.WriteLine("a - b = {0}", a.Scade(b));
            Console.WriteLine("a * b = {0}", a.Inmulteste(b));
            Console.WriteLine("a ^ 2 = {0}", a.Putere(2));
            Console.ReadKey();
        }
    }
}
