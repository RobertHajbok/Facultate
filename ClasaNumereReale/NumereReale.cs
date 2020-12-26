using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasaNumereReale
{
    public class NumereReale
    {
        float a;
        float b;

        public NumereReale(float a, float b)
        {
            this.a = a;
            this.b = b;
        }

        public float Adunare()
        {
            return a + b;
        }

        public float Scadere()
        {
            return a - b;
        }

        public float Inmultire()
        {
            return a * b;
        }

        public float Impartire()
        {
            return a / b;
        }
    }
}
