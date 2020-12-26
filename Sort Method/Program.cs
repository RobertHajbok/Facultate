using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Sort_Method
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList sortare = new ArrayList();
            sortare.Add("aici");
            sortare.Add("zeto");
            sortare.Add("index");
            sortare.Add("841");
            sortare.Add("czr");
            sortare.Add("!3@34");
            sortare.Add("allmighty");
            using (StreamWriter g = new StreamWriter("lista.txt"))
            {
                g.WriteLine("Lista nesortata: ");
                foreach (var item in sortare)
                {
                    g.WriteLine("{0}", item);
                }
                g.WriteLine("Lista sortata: ");
                sortare.Sort();
                foreach (var item in sortare)
                {
                    g.WriteLine("{0}", item);
                }
            }
        }
    }
}
