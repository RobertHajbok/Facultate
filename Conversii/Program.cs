using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Conversii
{
    class Program
    {
        static void Main(string[] args)
        {
            short srez, sv = 13;
            int iv = 123;
            long lrez;
            float frez, fv = 13.47F;
            double drez = 87.86;
            string strrez, strv = "15";
            bool bv = false;
            Console.WriteLine("Exemple de conversii:\n");


            Console.WriteLine("Implicite:");
            drez = fv + sv;
            Console.WriteLine("short si float spre double {0} + {1} = {2}", fv, sv, drez);
            frez = iv + sv;
            Console.WriteLine("int si short spre float {0} + {1} = {2}\n", iv, sv, frez);


            Console.WriteLine("Explicite:");
            srez = (short)fv;
            Console.WriteLine("float spre short folosind cast {0} spre {1}", fv, srez);
            strrez = Convert.ToString(bv) + Convert.ToString(frez);
            Console.WriteLine("bool si float spre string folosind metoda ToString \"{0}\" + \"{1}\" = {2}", bv, frez, strrez);
            lrez = iv + Convert.ToInt64(strv);
            Console.WriteLine("int si string cu ToInt64 spre long {0} + {1} = {2}\n", iv, strv, lrez);


            int i = 13;
            object ob = i;  //boxing implicit
            if (ob is int)
            {
                Console.WriteLine("Impachetarea s-a facut pentru int");
            }
            i = 6;
            Console.WriteLine("In ob se pastreaza {0}", ob);
            Console.WriteLine("Valoarea actuala a lui i este {0}", i);
            i = (int)ob;    //unboxing explicit


            string s;
            const int a = 13;
            const long b = 100000;
            const float c = 2.15F;
            double d = 3.1415;

            Console.WriteLine("CONVERSII\n");
            Console.WriteLine("TIP\tVAL. \tSTRING");
            Console.WriteLine("----------------------");
            s = "" + a;
            Console.WriteLine("int\t{0} \t{1}", a, s);
            s = "" + b;
            Console.WriteLine("long\t{0} \t{1}", b, s);
            s = "" + c;
            Console.WriteLine("float\t{0} \t{1}", c, s);
            s = "" + d;
            Console.WriteLine("double\t{0} \t{1}", d, s);
            Console.WriteLine("\nSTRING\tVAL. \tTIP");
            Console.WriteLine("----------------------");
            int a1;
            a1 = int.Parse("13");
            Console.WriteLine("{0}\t{1}\tint", "13", a1);
            long b2;
            b2 = long.Parse("1000");
            Console.WriteLine("{0}\t{1}\tlong", "1000", b2);
            float c2;
            c2 = float.Parse("2.15");
            Console.WriteLine("{0}\t{1}\tlong", "2.15", c2);
            double d2;
            d2 = double.Parse("3.1415", System.Globalization.CultureInfo.InvariantCulture);
            Console.WriteLine("{0}\t{1}\tdouble", "3.1415", d2);
            Console.ReadKey();
        }
    }
}
