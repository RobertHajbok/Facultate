using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tema1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Genereaza numerele aleatorii
            int[] numere = new int[6];
            Random rand = new Random();

            for (int i = 0; i < numere.Length; i++)
            {
                numere[i] = rand.Next() % 10;
            }

            Console.WriteLine("numere = " + ArrayToString<int>(numere));

            // Afiseaza numerele in casute
            numar1.Text = numere[0].ToString();
            numar2.Text = numere[1].ToString();
            numar3.Text = numere[2].ToString();
            numar4.Text = numere[3].ToString();
            numar5.Text = numere[4].ToString();
            numar6.Text = numere[5].ToString();

            //// Sorteaza numerele
            //for (int i = 0; i < numere.Length; i++)
            //{
            //    int min = 10;
            //    int pozitieMin = 0;

            //    for (int j = i; j < numere.Length; j++)
            //    {
            //        if (numere[j] < min)
            //        {
            //            min = numere[j];
            //            pozitieMin = j;
            //        }
            //    }

            //    numere[pozitieMin] = numere[i];
            //    numere[i] = min;
            //}

            //

            // Gaseste numarul de perechi
            int[] contor = new int[10];

            for (int i = 0; i < numere.Length; i++)
            {
                contor[numere[i]] += 1;
            }

            Console.WriteLine("contor = " + ArrayToString<int>(contor));

            int perechi = 0;
            int bucati = 0;

            for (int i = 0; i < contor.Length; i++)
            {
                int numarPerechi = (int)((double)contor[i] / 2);

                if (numarPerechi > 0)
                {
                    perechi += numarPerechi;
                }
                else if (contor[i] != 0)
                {
                    bucati++;
                }
                else if (contor[i] == 3)
                {
                    Console.WriteLine("3 de " + contor[i]);
                }
                else if (contor[i] == 4)
                {
                    Console.WriteLine("4 de " + contor[i]);
                }
            }

            Console.WriteLine("perechi = " + perechi);
            Console.WriteLine("bucati = " + bucati);
        }

        static string ArrayToString<T>(T[] array)
        {
            StringBuilder builder = new StringBuilder("{");

            for (int i = 0; i < array.Length; i++)
            {
                if (i != 0) builder.Append(",");

                builder.Append(array[i].ToString());
            }

            builder.Append("}");

            return builder.ToString();
        }

        private void numar4_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
