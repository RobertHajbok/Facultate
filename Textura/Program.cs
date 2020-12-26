using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Textura
{
    class Program
    {
        private static bool strchr(string p, char p_2)
        {
            for (int i = 0; i < p.Length; i++)
                if (p[i] == p_2)
                    return true;
            return false;
        }
        static void Main()
        {
            String s1 = Console.ReadLine();
            String s2 = Console.ReadLine();
            String v = String.Copy("aeiouAEIOU");
            bool textura = true;
            int i;
            if (s1.Length != s2.Length)
                textura = false;
            else
            {
                for (i = 0; i < s1.Length; i++)
                    if (strchr(v, s1[i]) && !strchr(v, s2[i]) || !strchr(v, s1[i]) && strchr(v, s2[i]))
                        textura = false;
            }
            if (textura)
                Console.WriteLine("Au aceeasi textura");
            else
                Console.WriteLine("Nu au aceeasi textura");
            Console.ReadKey();
        }
    }
}
