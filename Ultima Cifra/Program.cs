using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ultima_Cifra
{
    class Program
    {
        static void Main(string[] args)
        {
            int x, n, k, ux;
            Console.Write("Dati un numar natural ca baza a puterii : ");
            x = Convert.ToInt32(Console.ReadLine());
            Console.Write("Dati un numar natural ca exponent a puterii : ");
            n = Convert.ToInt32(Console.ReadLine());
            ux = x % 10;    //ma intereseaza doar ultima cifra
            Console.Write("Ultima cifra a lui {0} la puterea {1} este : ", x, n);
            if (n == 0)
                Console.WriteLine("1");
            else
                switch (ux)
                {
                    case 0: Console.WriteLine(" 0 "); break;
                    case 1: Console.WriteLine(" 1 "); break;
                    case 2:
                        k = n % 4;
                        switch (k)
                        {
                            case 0: Console.WriteLine(" 6 "); break;
                            case 1: Console.WriteLine(" 2 "); break;
                            case 2: Console.WriteLine(" 4 "); break;
                            case 3: Console.WriteLine(" 8 "); break;
                        }
                        break;
                    case 3:
                        k = n % 4;
                        switch (k)
                        {
                            case 0: Console.WriteLine(" 1 "); break;
                            case 1: Console.WriteLine(" 3 "); break;
                            case 2: Console.WriteLine(" 9 "); break;
                            case 3: Console.WriteLine(" 7 "); break;
                        }
                        break;
                    case 4:
                        if (n % 2 == 0)
                            Console.WriteLine(" 6 ");
                        else
                            Console.WriteLine(" 4 ");
                        break;
                    case 5:
                        Console.WriteLine(" 5 ");
                        break;
                    case 6:
                        Console.WriteLine(" 6 ");
                        break;
                    case 7:
                        k = n % 4;
                        switch (k)
                        {
                            case 0: Console.WriteLine(" 1 "); break;
                            case 1: Console.WriteLine(" 7 "); break;
                            case 2: Console.WriteLine(" 9 "); break;
                            case 3: Console.WriteLine(" 3 "); break;
                        }
                        break;
                    case 8:
                        k = n % 4;
                        switch (k)
                        {
                            case 0: Console.WriteLine(" 6 "); break;
                            case 1: Console.WriteLine(" 8 "); break;
                            case 2: Console.WriteLine(" 4 "); break;
                            case 3: Console.WriteLine(" 2 "); break;
                        }
                        break;
                    case 9:
                        if (n % 2 == 0)
                            Console.WriteLine(" 1 ");
                        else
                            Console.WriteLine(" 9 ");
                        break;
                }
            Console.ReadKey();
        }
    }
}
