using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hungarian_Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] costuri = new int[4, 4];
            int[] sarcini = new int[5];
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Introduceti costurile pentru agentul {0}: ", i + 1);
                for (int j = 0; j < 4; j++)
                {
                    costuri[i, j] = int.Parse(Console.ReadLine());
                }
            }
            sarcini = HungarianAlgorithm.FindAssignments(costuri);
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Agentul {0} primeste sarcina {1}", i + 1, sarcini[i] + 1);
            }
            Console.ReadKey();
        }
    }
}
