using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrice
{
    class Matrice
    {
        public int linii;
        public int coloane;
        public int[,] matrice;

        public Matrice(int[,] mat)
        {
            matrice = mat;
            linii = mat.GetLength(0);
            coloane = mat.GetLength(1);
        }

        public Matrice Aduna(Matrice matrice2)
        {
            if (linii != matrice2.linii || coloane != matrice2.coloane)
                return null;

            int[,] temp = new int[linii, coloane];

            for (int i = 0; i < linii; i++)
            {
                for (int j = 0; j < coloane; j++)
                {
                    temp[i, j] = matrice[i, j] + matrice2.matrice[i, j];
                }
            }

            return new Matrice(temp);
        }

        public Matrice Scade(Matrice matrice2)
        {
            if (linii != matrice2.linii || coloane != matrice2.coloane)
                return null;

            int[,] temp = new int[linii, coloane];

            for (int i = 0; i < linii; i++)
            {
                for (int j = 0; j < coloane; j++)
                {
                    temp[i, j] = matrice[i, j] - matrice2.matrice[i, j];
                }
            }

            return new Matrice(temp);
        }

        public Matrice Inmulteste(Matrice matrice2)
        {
            if (linii != matrice2.linii || coloane != matrice2.coloane)
                return null;

            int[,] temp = new int[linii, coloane];

            for (int i = 0; i < linii; i++)
            {
                for (int j = 0; j < coloane; j++)
                {
                    int suma = 0;
                    for (int k = 0; k < coloane; k++)
                    {
                        suma += matrice[i, k] * matrice2.matrice[k, i];
                    }
                    temp[i, j] = suma;
                }
            }

            return new Matrice(temp);
        }

        public Matrice Putere(int putere)
        {
            Matrice m = this;

            for (int i = 0; i < putere; i++)
            {
                m = m.Inmulteste(m);
            }

            return m;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            {
                sb.AppendLine();
                for (int i = 0; i < linii; i++)
                {
                    for (int j = 0; j < coloane; j++)
                    {
                        sb.AppendFormat(" \t{0}", matrice[i, j]);
                    }
                    sb.AppendLine();
                }
            }

            return sb.ToString();
        }
    }
}
