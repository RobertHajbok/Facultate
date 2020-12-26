using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace WordSeparator
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack stiva = new Stack();

            // Input
            using (StreamReader stream = new StreamReader("D:\\Programare\\C#\\WordSeparator\\in.txt"))
            {
                String linie = stream.ReadLine();

                List<string> cuvinte = linie.Split(' ').ToList();

                for (int i = 0; i < cuvinte.Count; i++)
                {
                    stiva.Push(cuvinte[i].StripPunctuation());
                }
            }

            // Output
            using (StreamWriter stream = new StreamWriter("D:\\Programare\\C#\\WordSeparator\\in.txt"))
            {
                while (stiva.Count > 0)
                {
                    stream.WriteLine("{0}          \t ( {1} )", stiva.Pop(), DateTime.Now.ToString());
                }
            }            
        }
    }
}
