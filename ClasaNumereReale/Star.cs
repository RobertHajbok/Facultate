using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasaNumereReale
{
    public class Star
    {
        int linii;

        public Star(int linii)
        {
            this.linii = linii;
        }

        public void Print()
        {
            for (int i = 1; i <= linii; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
}
