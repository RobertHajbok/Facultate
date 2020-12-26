using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrierea_matematica_ab
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("Input.txt");

            string[] arr;
            arr = sr.ReadLine().Split(' ').ToArray();
            int[] msj = arr.Select(x => int.Parse(x)).ToArray();

            for (int i = 0; i < msj.Length; i++)
                Console.Write(msj[i] + " ");
            Console.WriteLine();

            //Frequency array
            int[] values = new int[msj.Length];
            for (int i = 0; i < msj.Length; i++)
                values[Convert.ToInt32(msj[i])]++;
            Console.WriteLine();
            for (int i = 0; i < values.Length; i++)
                if (values[i] > 0)
                    Console.WriteLine("Value {0} was entered {1} time(s)..", i, values[i]);
            Console.WriteLine();

            string output = "";
            for (int i = 0; i < msj.Length; i++)
            {
                output += "a" + msj[i];
                if (i == msj.Length - 1)
                    output += "b";
                else if (msj[i + 1] == msj[i] + 1)
                    output += "b";
            }

            Console.WriteLine(output);

            Console.ReadKey();
        }
    }
}
