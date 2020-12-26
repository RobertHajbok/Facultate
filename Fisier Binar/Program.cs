using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Fisier_Binar
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, j, x;
            int[,] a = new int[10, 10];
            //se creeaza un fisier si un flux
            FileStream f = new FileStream("D:\\Programare\\C#\\Fisier Binar\\fisier2.dat", FileMode.CreateNew);
            //se creeaza un scriitor binar si il ataseaza la flux
            //acesta traduce datele fluxului in format binar
            BinaryWriter outputFile = new BinaryWriter(f);
            for (i = 1; i <= 4; i++)
                for (j = 1; j <= 4; j++)
                    if (i == j)
                        a[i, j] = 1;
                    else if (j == 5 - i)
                        a[i, j] = 2;
                    else
                        a[i, j] = 0;
            for (i = 1; i <= 4; i++)
                for (j = 1; j <= 4; j++)
                    outputFile.Write(a[i, j]);
            //se inchide fisierul creat
            outputFile.Close();
            f.Close();
            //incepe citirea datelor din fisierul creat mai sus
            //se creeaza un obiect FileStream
            FileStream g = new FileStream("D:\\Programare\\C#\\Fisier Binar\\fisier2.dat", FileMode.Open);
            //se creeaza un obiect BinaryReader
            BinaryReader inputFile = new BinaryReader(g);
            bool final;
            for (final = false, i = 1; !final; i++)
            {
                for (final = false, j = 1; !final; j++)
                {
                    //se apeleaza functia PeekChar care face parte din clasa BinaryReader 
                    //si examineaza urmatorul caracter din flux, daca acesta este diferit de -1
                    //atunci se executa citirea urmatorului caracter din flux prin functia ReadInt32()
                    if (inputFile.PeekChar() != -1)
                    {
                        x = inputFile.ReadInt32();
                        System.Console.Write("{0} ", x);
                    }
                }
                System.Console.Write("\n");
            }
        }
    }
}
