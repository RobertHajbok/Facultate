using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Secventa_Virus
{
    class Program
    {
        static void Main(string[] args)
        {
            string resource_data = Properties.Resources.Text;
            resource_data = resource_data.Replace("\r\n", " ").Replace("\n", " ").Replace("\r", " ");
            Console.WriteLine(resource_data);
            System.Text.StringBuilder strBuilder = new System.Text.StringBuilder(resource_data);

            bool found = false;
            for (int i = 0; i < resource_data.Length - 4; i++)
            {
                for (int j = 1; i + 4 * j < resource_data.Length; j++)
                {
                    if ((resource_data[i] == 'v' || resource_data[i] == 'V') && (resource_data[i + j] == 'i' || resource_data[i + j] == 'I') && (resource_data[i + 2 * j] == 'r' || resource_data[i + 2 * j] == 'R') && (resource_data[i + 3 * j] == 'u' || resource_data[i + 3 * j] == 'U') && (resource_data[i + 4 * j] == 's' || resource_data[i + 4 * j] == 'S'))
                    {
                        Console.WriteLine("Virus found!");
                        found = true;

                        strBuilder[i] = 'S';
                        strBuilder[i + j] = 'P';
                        strBuilder[i + 2 * j] = 'A';
                        strBuilder[i + 3 * j] = 'C';
                        strBuilder[i + 4 * j] = 'E';

                        Console.WriteLine("Virus removed!");
                    }
                }
            }
            if (!found)
                Console.WriteLine("No virus found");
            Console.WriteLine();
            Console.Write(strBuilder);
            Console.ReadKey();
        }
    }
}
