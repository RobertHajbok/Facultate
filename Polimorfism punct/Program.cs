using System;
namespace Polimorfism_punct
{
    class Punct
    {
        double x;
        public Punct() { x = 0; }
        public Punct(double x) { this.x = x; }
        public double getx() { return x; }
        public void setx(double x) { this.x = x; }
        public double distanta(Punct P) { return this.x - P.x; }
        public virtual string pozitie()
        {
            if (this.x > 0) return "dreapta";
            if (this.x < 0) return "stanga";
            return "origine";
        }
    }

    class Punct2D : Punct
    {
        double y;
        public Punct2D() : base(0) { y = 0; }
        public Punct2D(double x) : base(x) { }
        public Punct2D(double x, double y)
        {
            this.setx(x); this.y = y;
        }
        public double gety() { return y; }
        public void sety(double y) { this.y = y; }
        public double distanta(Punct2D P) //supraincarc functia distanta (semnatura diferita-paramtri diferiti ca tip si/sau numar)
        {
            return Math.Sqrt(Math.Pow(this.getx() - P.getx(), 2) + Math.Pow(this.y - P.y, 2));
        }
        public override string pozitie() //suprascriu functia pozitie (aceasi semnatura-paramertii indentici)
        {
            if (this.getx() == 0) return "Oy";
            if (this.gety() == 0) return "Ox";
            if (this.getx() == 0 && this.gety() == 0) return "origine";
            if (this.getx() > 0 && this.gety() > 0) return "cadran I";
            return "";
        }

    }
    class Punct3D : Punct2D
    {
        double z;
        public Punct3D() { z = 0; }
        public Punct3D(double x) : base(x) { }
        public Punct3D(double x, double y) : base(x, y) { }
        public Punct3D(double x, double y, double z)
        {
            this.setx(x); this.sety(y); this.z = z;
        }
        public double getz() { return z; }
        public void setz(double z) { this.z = z; }
        public double distanta(Punct3D P) //supraincarc functia distanta (semnatura diferita-paramtri diferiti ca tip si/sau numar)
        {
            return Math.Sqrt(Math.Pow(this.getx() - P.getx(), 2) + Math.Pow(this.gety() - P.gety(), 2) + Math.Pow(this.z - P.z, 2));
        }
        public override string pozitie() //suprascriu functia pozitie (aceeasi semnatura-paramertii indentici)
        {
            return "spatiu";
        }

    }


    class Class1
    {
        static void Main(string[] args)
        {
            Punct3D P = new Punct3D(1, 1, 1);
            Console.WriteLine("x={0},y={1},z={2}", P.getx(), P.gety(), P.getz());
            Console.WriteLine(P.distanta(new Punct3D()));
            Console.WriteLine(P.pozitie());
            Console.ReadKey();
        }
    }
}