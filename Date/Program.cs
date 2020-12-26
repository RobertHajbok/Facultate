using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Date
{
    class Program
    {
        static void Main(string[] args)
        {
            Date d1 = new Date(18, 4, 2013);
            Date d2 = new Date("18.04.2013");
            Console.WriteLine("Data1: {0}", d1);
            Console.WriteLine("Data2: {0}", d2);
            if (d1 == d2)
                Console.WriteLine("Datele coincid.");
            else
                Console.WriteLine("Datele difera.");
            if (d1 < d2)
                Console.WriteLine("Data1 este mai mica decat data2.");
            else
                Console.WriteLine("Data2 este mai mica decat data1.");
            if (d1 > d2)
                Console.WriteLine("Data1 este mai mare decat data2.");
            else
                Console.WriteLine("Data2 este mai mare decat data1.");

            Console.WriteLine("Diferenta este de {0} zile.", d1 - d2);
            Console.ReadKey();
        }
    }
}
