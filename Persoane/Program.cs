using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Persoane
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList persoane = new ArrayList();

            persoane.Add(new Persoana("AAAAA 11111", 34));
            persoane.Add(new Persoana("ZZZZZ 22222", 30));
            persoane.Add(new Persoana("MMMMM 33333", 82));
            persoane.Add(new Persoana("GGGGG 44444", 5));

            //persoane.Sort();
            persoane.Sort(new Comparator());

            for (int i = 0; i < persoane.Count; i++)
            {
                Persoana persoana = persoane[i] as Persoana;
                Console.WriteLine("{0} {1}", persoana.nume, persoana.varsta);
            }
            Console.ReadKey();
        }
    }
}
