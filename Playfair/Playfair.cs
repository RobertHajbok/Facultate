using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playfair
{
    public class Playfair
    {
        /*
       'Prepare' toate caracterele care nu sunt litere, de ex. spatii libere, semne de 
        punctuatie etc. Numerele trebuie inlocuite cu 'unu', 'doi'...

       Daca o litera se gaseste pe doua pozitii consecutive, a doua se inlocuieste cu un x
        */

        public static string Prepare(string originalText)
        {
            int length = originalText.Length;
            originalText = originalText.ToLower();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                char c = originalText[i];
                if (c >= 97 && c <= 122)
                {
                    //Daca o litera se gaseste pe doua pozitii consecutive, a doua se inlocuieste cu un x
                    if (sb.Length % 2 == 1 && sb[sb.Length - 1] == c)
                    {
                        sb.Append('x');
                    }
                    sb.Append(c);
                }
            }

            //Daca sirul este de lungime impara, adauga un x
            if (sb.Length % 2 == 1)
            {
                sb.Append('x');
            }

            return sb.ToString();
        }
        
        public static string Encipher(string key, string plainText)
        {
            int length = plainText.Length;
            char a, b;
            int a_ind, b_ind, a_row, b_row, a_col, b_col;
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < length; i += 2)
            {
                a = plainText[i];
                b = plainText[i + 1];

                a_ind = key.IndexOf(a);
                b_ind = key.IndexOf(b);
                a_row = a_ind / 5;
                b_row = b_ind / 5;
                a_col = a_ind % 5;
                b_col = b_ind % 5;

                if (a_row == b_row)
                {
                    if (a_col == 4)
                    {
                        sb.Append(key[a_ind - 4]);
                        sb.Append(key[b_ind + 1]);
                    }
                    else if (b_col == 4)
                    {
                        sb.Append(key[a_ind + 1]);
                        sb.Append(key[b_ind - 4]);
                    }
                    else
                    {
                        sb.Append(key[a_ind + 1]);
                        sb.Append(key[b_ind + 1]);
                    }
                }
                else if (a_col == b_col)
                {
                    if (a_row == 4)
                    {
                        sb.Append(key[a_ind - 20]);
                        sb.Append(key[b_ind + 5]);
                    }
                    else if (b_row == 4)
                    {
                        sb.Append(key[a_ind + 5]);
                        sb.Append(key[b_ind - 20]);
                    }
                    else
                    {
                        sb.Append(key[a_ind + 5]);
                        sb.Append(key[b_ind + 5]);
                    }
                }
                else
                {
                    sb.Append(key[5 * a_row + b_col]);
                    sb.Append(key[5 * b_row + a_col]);
                }
            }
            return sb.ToString();
        }

        public static string Decipher(string key, string cipherText)
        {
            int length = cipherText.Length;
            char a, b;
            int a_ind, b_ind, a_row, b_row, a_col, b_col;
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < length; i += 2)
            {
                a = cipherText[i];
                b = cipherText[i + 1];

                a_ind = key.IndexOf(a);
                b_ind = key.IndexOf(b);
                a_row = a_ind / 5;
                b_row = b_ind / 5;
                a_col = a_ind % 5;
                b_col = b_ind % 5;

                if (a_row == b_row)
                {
                    if (a_col == 0)
                    {
                        sb.Append(key[a_ind + 4]);
                        sb.Append(key[b_ind - 1]);
                    }
                    else if (b_col == 0)
                    {
                        sb.Append(key[a_ind - 1]);
                        sb.Append(key[b_ind + 4]);
                    }
                    else
                    {
                        sb.Append(key[a_ind - 1]);
                        sb.Append(key[b_ind - 1]);
                    }
                }
                else if (a_col == b_col)
                {
                    if (a_row == 0)
                    {
                        sb.Append(key[a_ind + 20]);
                        sb.Append(key[b_ind - 5]);
                    }
                    else if (b_row == 0)
                    {
                        sb.Append(key[a_ind - 5]);
                        sb.Append(key[b_ind + 20]);
                    }
                    else
                    {
                        sb.Append(key[a_ind - 5]);
                        sb.Append(key[b_ind - 5]);
                    }
                }
                else
                {
                    sb.Append(key[5 * a_row + b_col]);
                    sb.Append(key[5 * b_row + a_col]);
                }
            }
            return sb.ToString();
        }
    }
}
