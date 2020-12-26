using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasaOperatii
{
    public class Operatii
    {
        float a, b;
        public Operatii(float x, float y)
        {
            a = x;
            b = y;
        }
        public float suma()
        {
            return a + b;
        }
        public float diferenta()
        {
            return a - b;
        }
        public float produs()
        {
            return a * b;
        }
        public float impartire()
        {
            return a / b;
        }
    }
}
