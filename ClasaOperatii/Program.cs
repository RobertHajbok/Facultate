using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasaOperatii
{
    class Program
    {
        static void Main(string[] args)
        {
            Operatii x = new Operatii(12, 32);
            Console.WriteLine("Suma este {0} ", x.suma());
            Console.WriteLine("Diferenta este {0} ", x.diferenta());
            Console.WriteLine("Produsul este {0} ", x.produs());
            Console.WriteLine("Catul este {0} ", x.impartire());
            Console.ReadKey();
        }
    }
}
