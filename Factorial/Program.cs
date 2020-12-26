using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Introduceti numarul : ");
            long n = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("n!= " + Factorial(n));
            Console.ReadKey();
        }
        public static long Factorial(long numar)
        {
            if (numar <= 1)
                return 1;
            else
                return numar * Factorial(numar - 1);
        }
    }
}
