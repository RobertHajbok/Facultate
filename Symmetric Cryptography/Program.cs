using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Symmetric_Cryptography
{
    class Program
    {
        static void Main(string[] args)
        {
            SymCryptography cryptic = new SymCryptography();

            string plainText = "O poveste a fost scrisa!";
            cryptic.Key = "wqdj~yriu!@*k0_^fa7431%p$#=@hd+&";
            Console.WriteLine("Plain text: " + plainText);
            Console.WriteLine("Key: " + cryptic.Key + "\n");

            Console.WriteLine("Using Rijndael algorithm:");
            string TestEnc = cryptic.Encrypt(plainText);
            string TestDec = cryptic.Decrypt(TestEnc);
            Console.WriteLine("Encrypted text: " + TestEnc + "\n");

            Console.WriteLine("Using RC2 algorithm:");
            cryptic = new SymCryptography("rc2");
            TestEnc = cryptic.Encrypt(plainText);
            Console.WriteLine("Encrypted text: " + TestEnc + "\n");

            Console.WriteLine("Using DES algorithm:");
            cryptic = new SymCryptography("DES");
            TestEnc = cryptic.Encrypt(plainText);
            Console.WriteLine("Encrypted text: " + TestEnc + "\n");

            Console.WriteLine("Using TripleDES algorithm:");
            cryptic = new SymCryptography("TripleDES");
            TestEnc = cryptic.Encrypt(plainText);
            Console.WriteLine("Encrypted text: " + TestEnc + "\n");

            Hash hash = new Hash("SHA1");
            string TestHash = hash.Encrypt(plainText);
            Console.WriteLine("Using SHA1 algorithm:");
            Console.WriteLine("Encrypted text: " + TestHash + "\n");

            Console.Read();
        }
    }
}
