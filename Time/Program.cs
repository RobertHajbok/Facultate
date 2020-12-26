using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time
{
    class Program
    {
        static void Main(string[] args)
        {
            Time t1 = new Time(16, 30, 15, 250);
            Time t2 = new Time(2, 10, 10);

            Console.WriteLine("{0}", t1 + t2);
            Console.WriteLine("{0}", t1 - t2);

            Console.ReadKey();
        }
    }
}
