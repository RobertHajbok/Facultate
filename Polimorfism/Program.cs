using System;
namespace Polimorfism
{
    class vehicul
    {
        uint viteza;
        uint greutate;

        public vehicul(uint v, uint g)
        {
            viteza = v;
            greutate = g;
        }
        public virtual uint getgreutate()
        {
            return greutate;
        }
    }
    class automobil : vehicul
    {
        uint nr_usi;
        uint nr_locuri;
        public automobil(uint v, uint g, uint u, uint l) : base(v, g) { nr_usi = u; nr_locuri = l; }
    }
    class camion : vehicul
    {
        uint greutate_remorca;
        public camion(uint v, uint g, uint gr) : base(v, g) { greutate_remorca = gr; }
        public override uint getgreutate()
        {
            return greutate_remorca + base.getgreutate();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            automobil a = new automobil(110, 1, 4, 5);
            Console.WriteLine(a.getgreutate());
            camion c = new camion(90, 10, 40);
            Console.WriteLine(c.getgreutate());
            Console.ReadKey();
        }
    }
}
