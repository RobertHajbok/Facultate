using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delegari
{
    public delegate bool pereche_ok(object t1, object t2);
    public class Vector
    {
        public const int nmax = 4;
        public int[] v = new int[nmax];
        public Vector()
        {
            Random rand = new Random();
            for (int i = 0; i < nmax; i++)
                v[i] = rand.Next(0, 5);
        }
        public void scrie()
        {
            for (int i = 0; i < nmax; i++)
                Console.Write("{0}, ", v[i]);
            Console.WriteLine();
        }
        public bool aranj(pereche_ok ok)    //ok e o delegare către o funcţie necunoscută
        {
            for (int i = 0; i < nmax - 1; i++)
                if (!ok(v[i], v[i + 1]))
                    return false;
            return true;
        }
    }
    class Program
    {
        public static bool f1(object t1, object t2)
        {
            if ((int)t1 >= (int)t2)
                return true;
            else
                return false;
        }
        public static bool f2(object t1, object t2)
        {
            if ((int)t1 <= (int)t2)
                return true;
            else
                return false;
        }
        static void Main(string[] args)
        {
            Vector x;
            do
            {
                x = new Vector();
                x.scrie();
                if (x.aranj(f1))
                    Console.WriteLine("Monoton descrescator");
                if (x.aranj(f2))
                    Console.WriteLine("Monoton crescator");
            } while (Console.ReadKey(true).KeyChar != '\x001B'); //Escape
        }
    }
}
