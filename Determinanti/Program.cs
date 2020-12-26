using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Determinant
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Introduceti nr de linii/coloane: ");
            int n = int.Parse(Console.ReadLine().ToString());
            double[,] Matrice = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.WriteLine("A[" + (i + 1) + "]" + "[" + (j + 1) + "]: ");
                    Matrice[i, j] = double.Parse(Console.ReadLine().ToString());
                }
            }
            Console.WriteLine("Matricea data este: ");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(Matrice[i, j].ToString() + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Determinantul matricei dupa metoda care ocupa memorie este " + Determinant(Matrice));
            Console.WriteLine("Determinantul dupa metoda profei este " + det(Matrice, n));
            Console.ReadKey();
        }
        //Metoda care ocupa memorie
        static int Semn(int i, int j)
        {
            if ((i + j) % 2 == 0)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
        static double[,] MicsorareMatrice(double[,] Matrice, int i, int j)
        {
            int ordin = int.Parse(System.Math.Sqrt(Matrice.Length).ToString());
            double[,] output = new double[ordin - 1, ordin - 1];
            int x = 0, y = 0;
            for (int m = 0; m < ordin; m++, x++)
            {
                if (m != i)
                {
                    y = 0;
                    for (int n = 0; n < ordin; n++)
                    {
                        if (n != j)
                        {
                            output[x, y] = Matrice[m, n];
                            y++;
                        }
                    }
                }
                else
                {
                    x--;
                }
            }
            return output;
        }
        static double Determinant(double[,] Matrice)
        {
            double Suma = 0.0;
            int ordin = int.Parse(System.Math.Sqrt(Matrice.Length).ToString());
            if (ordin == 1)
            {
                return (Matrice[0, 0]);
            }
            for (int j = 0; j < ordin; j++)
            {
                double[,] Temp = MicsorareMatrice(Matrice, 0, j);
                Suma = Suma + Matrice[0, j] * Semn(0, j) * Determinant(Temp);
            }
            return Suma;
        }
        //Metoda profei
        static double det(double[,] a, int n)
        {
            int i, j;
            double aux, e, d = 0.0;
            if (n == 1)
                return a[0, 0];
            for (j = 0; j < n; j++)
            {
                if ((n - 1 - j) % 2 == 1 || j == n - 1)
                    e = a[n - 1, j];
                else
                    e = -a[n - 1, j];
                for (i = 0; i < n; i++)
                {
                    aux = a[i, j];
                    a[i, j] = a[i, n - 1];
                    a[i, n - 1] = aux;
                }
                if ((n - 1 + j) % 2 == 0)
                    d += e * det(a, n - 1);
                else
                    d -= e * det(a, n - 1);
                for (i = 0; i < n; i++)
                {
                    aux = a[i, j];
                    a[i, j] = a[i, n - 1];
                    a[i, n - 1] = aux;
                }
            }
            return d;
        }
    }
}