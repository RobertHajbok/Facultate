using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasaNumereReale
{
    class Program
    {
        static void Main(string[] args)
        {
            NumereReale x = new NumereReale(37.704f, 14.22f);

            Console.WriteLine("Adunare = {0}", x.Adunare());
            Console.WriteLine("Scadere = {0}", x.Scadere());
            Console.WriteLine("Inmultire = {0}", x.Inmultire());
            Console.WriteLine("Impartire = {0}", x.Impartire());

            Star s = new Star(5);
            s.Print();
            Console.ReadKey();
        }
    }
}
