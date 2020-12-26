using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            List<int> lista = new List<int>();

            for (int i = 0; i < 25; i++)
            {
                lista.Add(rand.Next(100));

                Console.Write("{0}, ", lista[i]);
            }
            Console.ReadKey();
        }
    }
}
