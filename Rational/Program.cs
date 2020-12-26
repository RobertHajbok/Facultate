using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rational
{
    class Program
    {
        static void Main(string[] args)
        {
            Rational r1, r2;

            // Adunare
            r1 = new Rational(2, 12);
            r2 = new Rational(4, 6);

            Console.WriteLine("{0} + {1} = {2}", r1, r2, r1 + r2);

            // Scadere
            r1 = new Rational(3, 4);
            r2 = new Rational(2, 5);

            Console.WriteLine("{0} - {1} = {2}", r1, r2, r1 - r2);

            // Inmultire
            r1 = new Rational(1, 3);
            r2 = new Rational(2, 5);

            Console.WriteLine("{0} * {1} = {2}", r1, r2, r1 * r2);

            // Impartire
            r1 = new Rational(2, 5);
            r2 = new Rational(6, 7);

            Console.WriteLine("{0} / {1} = {2}", r1, r2, r1 / r2);

            // Simplificare
            r1 = new Rational(6, 3);

            Console.WriteLine("{0} simplificat e {1}", r1, r1.Simplificat());
            Console.ReadKey();
        }
    }
}
