using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumarMare
{
    class NumarMare
    {
        public byte[] Numar { get; private set; }

        public NumarMare(byte[] numar)
        {
            this.Numar = numar;
        }

        #region Overloaded operators
        public static NumarMare operator +(NumarMare n1, NumarMare n2)
        {
            List<byte> numarNou = new List<byte>();

            int max = (n1.Numar.Length > n2.Numar.Length) ? n1.Numar.Length : n2.Numar.Length;

            n1.PadToLength(max);
            n2.PadToLength(max);

            byte carry = 0;
            for (int i = 1; i < n1.Numar.Length + 1; i++)
            {
                byte cifra = (byte)(n1.Numar[n1.Numar.Length - i] + n2.Numar[n1.Numar.Length - i]);
                if (carry > 0)
                {
                    cifra += carry;
                    carry = 0;
                }
                if (cifra >= 10)
                {
                    cifra -= 10;
                    carry = 1;
                }

                numarNou.Add(cifra);
            }

            if (carry > 0)
            {
                numarNou.Add(carry);
            }

            n1.RemovePadding();
            n2.RemovePadding();

            numarNou.Reverse();

            return new NumarMare(numarNou.ToArray());
        }

        public static NumarMare operator *(NumarMare n1, NumarMare n2)
        {
            byte[] c;
            byte t = 0;

            int cLength = n1.Numar.Length + n2.Numar.Length - 1;

            c = new byte[cLength + 1];



            for (int i = 0; i < n1.Numar.Length + n2.Numar.Length; i++)
                c[i] = 0;



            for (int i = 0; i < n1.Numar.Length; i++)
                for (int j = 0; j < n2.Numar.Length; j++)
                    c[i + j] += (byte)(n1.Numar[i] * n2.Numar[j]);



            for (int i = 0; i < cLength; i++)
            {
                c[i] += t;
                t = (byte)(c[i] / 10);
                c[i] %= 10;
            }

            if (t != 0)
                c[cLength++] = t;

            return new NumarMare(c);
        }
        #endregion

        public override string ToString()
        {
            var builder = new StringBuilder();
            Array.ForEach(Numar, x => builder.Append(x));
            return builder.ToString();

            //return String.Join("", new List<int>(Numar).ConvertAll(i => i.ToString()).ToArray());
        }

        public void PadToLength(int length)
        {
            if (Numar.Length == length)
                return;

            byte[] paddedNumber = new byte[length];
            for (int i = length - Numar.Length; i < length; i++)
            {
                paddedNumber[i] = Numar[i - (length - Numar.Length)];
            }
            Numar = paddedNumber;
        }

        public void RemovePadding()
        {
            if (Numar.Length == 1)
                return;

            int pos = 0;
            for (int i = 0; i < Numar.Length; i++)
            {
                if (Numar[i] != 0)
                {
                    pos = i;
                    break;
                }
            }

            List<byte> unpaddedNumber = new List<byte>();
            for (int i = pos; i < Numar.Length; i++)
            {
                unpaddedNumber.Add(Numar[i]);
            }
            Numar = unpaddedNumber.ToArray();
        }
    }
}
