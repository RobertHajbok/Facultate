using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insertion_Sort_recursiv
{
    class Program
    {
        static void InsertionNormal(int[] vector)
        {
            int j, aux;

            for (int i = 1; i < vector.Length; i++)
            {
                j = i;
                while (j > 0 && vector[j - 1] > vector[j])
                {
                    aux = vector[j];
                    vector[j] = vector[j - 1];
                    vector[j - 1] = aux;
                    j--;
                }
            }
        }

        static void InsertionRecursiv(int[] vector, int first, int last)
        {
            if (first < last)
            {
                InsertionRecursiv(vector, first, last - 1); // scapa de for-ul din vector de la 0 la last-1
                InsertInOrder(vector[last], vector, first, last - 1); // considera vector[last] ca fiind primul element din vectorul nesortat
            }
        }

        static void InsertInOrder(int element, int[] vector, int first, int last)
        {
            if (element >= vector[last])
                vector[last + 1] = element;
            else if (first < last)
            {
                vector[last + 1] = vector[last];
                InsertInOrder(element, vector, first, last - 1);
            }
            else // first == last and element < vector[last]
            {
                vector[last + 1] = vector[last];
                vector[last] = element;
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Dati dimensiunea vectorului: ");
            int n = int.Parse(Console.ReadLine());
            int[] vector = new int[n];
            
            for (int i = 0; i < n; i++)
            {
                Console.Write("Introduceti elementul {0} al vectorului : ", i + 1);
                vector[i] = int.Parse(Console.ReadLine());
            }

            //InsertionNormal(vector);
            InsertionRecursiv(vector, 0, n - 1);

            Console.Write("Vectorul sortat: ");
            for (int i = 0; i < n; i++)
            {
                Console.Write(vector[i]);
                Console.Write(" ");
            }

            Console.ReadKey();
        }
    }
}
