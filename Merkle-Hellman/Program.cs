using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merkle_Hellman
{
    class Program
    {
        static void Main()
        {
            int[] w = { 2, 7, 11, 21, 42, 89, 180, 354 }; // super-increasing
            int q = 881;
            int r = 588;
            int[] beta = GetPublicKey(w, q, r);
            int[] priv = GetPrivateKey(w, q, r);

            Console.Write("Introduceti un numar : ");
            string plainText = Console.ReadLine();

            Console.Write("Cheia publica este : ");
            for (int i = 0; i < beta.Length; i++)
            {
                Console.Write("{0}", beta[i]);
            }

            Console.Write("\nCheia privata este : ");
            for (int i = 0; i < priv.Length; i++)
            {
                Console.Write("{0}", priv[i]);
            }

            int[] encoded = Encrypt(plainText, beta);
            Console.Write("\nNumarul criptat este : ");            

            for (int i = 0; i < encoded.Length; i++)
            {
                Console.Write("{0}", encoded[i]);                
            }


            string decoded = Decrypt(encoded, w, q, r);
            Console.WriteLine("\nNumarul decriptat este : {0}", decoded);
            Console.ReadKey();
        }

        public static void Shuffle<T>(T[] array)
        {
            Random rnd = new Random();
            for (int i = array.Length; i > 1; i--)
            {
                // Pick random element to swap.
                int j = rnd.Next(i); // 0 <= j <= i-1
                // Swap.
                T tmp = array[j];
                array[j] = array[i - 1];
                array[i - 1] = tmp;
            }
        }

        public static int[] GetPublicKey(int[] w, int q, int r)
        {
            int[] beta = new int[w.Length];            
            for (int i = 0; i < w.Length; i++)
                beta[i] = w[i] * r % q;
            return beta;
        }

        public static int[] GetPrivateKey(int[] w, int q, int r)
        {
            int[] pi = new int[w.Length];
            for (int i = 0; i < pi.Length; i++)
            {
                pi[i] = i;
            }
            Shuffle(pi);
            int[] priv = new int[pi.Length + w.Length + 2];
            for (int i = 0; i < priv.Length; i++)
            {
                if (i < pi.Length)
                {
                    priv[i] = pi[i];
                }
                else if (i > w.Length + 1)
                {
                    priv[i] = w[i - w.Length - 2];
                }
                else
                {
                    priv[pi.Length] = q;
                    priv[pi.Length] = r;
                }
            }
            return priv;
        }

        static int[] Encrypt(string plainText, int[] beta)
        {
            if (String.IsNullOrEmpty(plainText)) 
                return null;
            int[] encoded = new int[plainText.Length];

            for (int i = 0; i < encoded.Length; i++)
            {
                string bin = ConvertToBinary(plainText[i]);
                int sum = 0;
                for (int j = 0; j < 8; j++) sum += (bin[j] - 48) * beta[j];
                encoded[i] = sum;
            }

            return encoded;
        }

        static string Decrypt(int[] encoded, int[] w, int q, int r)
        {
            if (encoded == null || encoded.Length == 0) return null;
            char[] chars = new char[encoded.Length];
            int mir = ModInverse(r, q);
            if (mir == 0)
            {
                Console.WriteLine("Inversul modular nu exista. Decriptarea anulata!");
                return null;
            }

            for (int i = 0; i < encoded.Length; i++)
            {
                char[] bin = new char[8];
                for (int j = 0; j < 8; j++) bin[j] = '0';
                int temp = encoded[i] * mir % q;

                while (temp > 0)
                {
                    int index = 7;

                    for (int j = 1; j < w.Length; j++)
                    {
                        if (w[j] > temp)
                        {
                            index = j - 1;
                            break;
                        }
                    }

                    bin[index] = '1';
                    temp -= w[index];
                }

                chars[i] = ConvertFromBinary(new string(bin));
            }

            return new string(chars);
        }

        static string ConvertToBinary(char c)
        {
            return Convert.ToString((int)c, 2).PadLeft(8, '0');
        }

        static char ConvertFromBinary(string bin)
        {
            return (char)Convert.ToInt32(bin, 2);
        }


        static int ModInverse(int r, int q)
        {
            int i = q, v = 0, d = 1;

            while (r > 0)
            {
                int t = i / r, x = r;
                r = i % x;
                i = x;
                x = d;
                d = v - t * x;
                v = x;
            }

            v %= q;
            if (v < 0) 
                v = (v + q) % q;
            return v;
        }
    }
}
