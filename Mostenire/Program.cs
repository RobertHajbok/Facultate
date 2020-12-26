using System;
using System.Collections.Generic;
using System.Text;

namespace Mostenire
{
    class point
    {
        double x;
        public point() { x = 0; Console.WriteLine("Setez x=0 in clasa de baza!"); }
        public point(double x) { this.x = x; Console.WriteLine("Setez x={0} in clasa de baza!", x); }
        public void setx(double x) { this.x = x; }
        public double getx() { return x; }
    }
    class point2d : point
    {
        double y;
        public point2d() : base() { y = 0; Console.WriteLine("Setez y=0 in clasa derivata!"); }
        public point2d(double x) : base(x) { y = 0; Console.WriteLine("Setez y=0 in clasa derivata!"); }
        public point2d(double x, double y) : base(x) { this.y = y; Console.WriteLine("Setez y={0} in clasa derivata!", y); }
        public void sety(double y) { this.y = y; }
        public double gety() { return y; }
    }
    class mostenire
    {
        static void Main(string[] args)
        {
            point2d p = new point2d(2, 2);
            //Console.WriteLine("[{0},{1}]",p.getx(),p.gety());
            Console.ReadKey();
        }
    }
}
