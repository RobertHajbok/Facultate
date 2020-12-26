using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_sum
{
    public class Triplets
    {
        private int a;
        private int b;
        private int c;

        public int A { get { return a; } set { a = value; } }
        public int B { get { return b; } set { b = value; } }
        public int C { get { return c; } set { c = value; } }

        public Triplets(int n1, int n2, int n3)
        {
            A = n1;
            B = n2;
            C = n3;
        }
    }
}
