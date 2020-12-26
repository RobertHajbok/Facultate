using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVP_OrosH
{
    [Serializable]
    class Persoana
    {
        private string nume, prenume;
        private DateTime dataNasterii;

        public Persoana(string nume, string prenume, DateTime dataNasterii)
        {
            this.nume = nume;
            this.prenume = prenume;
            this.dataNasterii = dataNasterii;
        }
        public override string ToString()
        {
            return this.nume + " " + this.prenume + " - " + this.dataNasterii.ToShortDateString();
        }
    }
}
