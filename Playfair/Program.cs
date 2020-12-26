using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playfair
{
    class Program
    {
        static void Main(string[] args)
        {
            string originalText = "A fost odata ca niciodata un mare rege";
            Console.WriteLine(originalText);
            string plainText = Playfair.Prepare(originalText);
            Console.WriteLine(plainText);
            //Exemplu de key de pe wikipedia
            string key = "playfirexmbcdghknoqstuvwz";
            string cipherText = Playfair.Encipher(key, plainText);
            Console.WriteLine(cipherText);
            plainText = Playfair.Decipher(key, cipherText);
            Console.WriteLine(plainText);            
            Console.ReadKey();
        }
    }
}
