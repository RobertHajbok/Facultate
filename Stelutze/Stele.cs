using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stelutze
{
    public class Stele
    {
        public Stele(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                for (int nr = 1; nr < i; nr++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
}
