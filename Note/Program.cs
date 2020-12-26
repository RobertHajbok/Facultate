using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Note
{
    class Program
    {
        static void Main(string[] args)
        {
            int numarPersoane = 0;
            int[][] note = null;
            List<Persoana> datePersoane = new List<Persoana>();
            int contorPersoane = 0;
            int mediaGenerala = 0;

            // Input
            using (StreamReader stream = new StreamReader("D:\\Programare\\C#\\Note\\note.txt"))
            {
                String linie;
                while ((linie = stream.ReadLine()) != null)
                {
                    List<string> cuvinte = linie.Split(' ').ToList();

                    if (cuvinte.Count == 1)
                    {
                        numarPersoane = int.Parse(linie);
                        note = new int[numarPersoane][];
                        Console.WriteLine("numarPersoane {0}", numarPersoane);
                    }
                    else
                    {
                        Persoana persoana = new Persoana();

                        persoana.Nume = cuvinte[0];
                        persoana.Prenume = cuvinte[1];
                        persoana.NumarNote = int.Parse(cuvinte[2]);
                        persoana.Numar = contorPersoane;
                        note[contorPersoane] = new int[persoana.NumarNote];

                        for (int i = 3; i < cuvinte.Count; i++)
                        {
                            note[contorPersoane][i - 3] = int.Parse(cuvinte[i]);
                            persoana.Medie += note[contorPersoane][i - 3];
                        }

                        persoana.Medie /= persoana.NumarNote;

                        mediaGenerala += persoana.Medie;

                        datePersoane.Add(persoana);

                        contorPersoane++;
                    }
                }
            }

            mediaGenerala /= numarPersoane;
            datePersoane = datePersoane.OrderBy(x => x.Nume).ToList();
            //datePersoane.Sort((a, b) => a.Nume.CompareTo(b.Nume));

            for (int i = 0; i < datePersoane.Count; i++)
            {
                Persoana pers = datePersoane[i];
                Console.WriteLine("{0} {1} - Media {2}", pers.Nume, pers.Prenume, pers.Medie);
            }

            Console.WriteLine("Media generala {0}", mediaGenerala);
            Console.ReadKey();
        }
    }
}
