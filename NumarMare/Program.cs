using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumarMare
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] numar1 = new byte[5];
            for (int i = 0; i < numar1.Length; i++)
            {
                numar1[i] = (byte)(7 + i % 3);
            }

            byte[] numar2 = new byte[8];
            for (int i = 0; i < numar2.Length; i++)
            {
                numar2[i] = 2;
            }

            NumarMare n1 = new NumarMare(numar1);
            NumarMare n2 = new NumarMare(numar2);

            Console.WriteLine("n1 = {0}", n1);
            Console.WriteLine("n2 = {0}", n2);
            Console.WriteLine("n1 + n2 = {0}", n1 + n2);

            NumarMare a = new NumarMare(new byte[] { 1, 2, 4 });
            NumarMare b = new NumarMare(new byte[] { 3, 2 });

            Console.WriteLine("a * b = {0}", a * b);

            Console.WriteLine("\nFibonacci(100) : {0}", Fibonacci(100));
            Console.ReadKey();
        }

        public static NumarMare Fibonacci(int n)
        {
            NumarMare a = new NumarMare(new byte[] { 0 });
            NumarMare b = new NumarMare(new byte[] { 1 });
            for (int i = 0; i < n; i++)
            {
                NumarMare temp = a;
                a = b;
                b = temp + b;
                //Console.WriteLine("{0} + {1} = {2}", temp, a, b);
            }
            return a;
        }
    }
}
