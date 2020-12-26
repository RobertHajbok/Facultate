using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persoane
{
    class Persoana : IComparable
    {
        public string nume;
        public int varsta;

        public Persoana(string nume, int varsta)
        {
            this.nume = nume;
            this.varsta = varsta;
        }

        public int CompareTo(object obj)
        {
            Persoana persoana = obj as Persoana;

            return nume.CompareTo(persoana.nume);
            //return varsta.CompareTo(persoana.varsta);
        }
    }
}
