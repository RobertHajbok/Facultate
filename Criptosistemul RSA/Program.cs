using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Criptosistemul_RSA
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a UnicodeEncoder to convert between byte array and string.
            UnicodeEncoding ByteConverter = new UnicodeEncoding();

            //Create byte arrays to hold original, encrypted, and decrypted data. 
            byte[] dataToEncrypt = ByteConverter.GetBytes("12345");
            byte[] encryptedData;
            byte[] decryptedData;

            //Create a new instance of RSACryptoServiceProvider to generate 
            //public and private key data. 
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {             
                //Pass the data to ENCRYPT, the public key information  
                //(using RSACryptoServiceProvider.ExportParameters(false), 
                //and a boolean flag specifying no OAEP padding.
                encryptedData = RSAEncrypt(dataToEncrypt, RSA.ExportParameters(false), false);
                Console.WriteLine("Encrypted plaintext: ");
                for (int i = 0; i < encryptedData.Length; i++)
                {
                    Console.Write(encryptedData[i]);
                }
                Console.WriteLine();

                //Pass the data to DECRYPT, the private key information  
                //(using RSACryptoServiceProvider.ExportParameters(true), 
                //and a boolean flag specifying no OAEP padding.
                decryptedData = RSADecrypt(encryptedData, RSA.ExportParameters(true), false);

                //Display the decrypted plaintext to the console. 
                Console.WriteLine("Decrypted plaintext: ");
                Console.WriteLine(ByteConverter.GetString(decryptedData));

                string publicKeyXml = RSA.ToXmlString(true);
                Console.WriteLine("Cheile au fost generate in folderul proiectului!");
                System.IO.StreamWriter file = new System.IO.StreamWriter(@".\Chei.txt");
                file.WriteLine(publicKeyXml);
                file.Close();
            }
            Console.ReadKey();
        }

        static public byte[] RSAEncrypt(byte[] DataToEncrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            byte[] encryptedData;
            //Create a new instance of RSACryptoServiceProvider. 
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {

                //Import the RSA Key information. This only needs 
                //toinclude the public key information.
                RSA.ImportParameters(RSAKeyInfo);

                //Encrypt the passed byte array and specify OAEP padding.   
                //OAEP padding is only available on Microsoft Windows XP or 
                //later.  
                encryptedData = RSA.Encrypt(DataToEncrypt, DoOAEPPadding);
            }
            return encryptedData;
        }

        static public byte[] RSADecrypt(byte[] DataToDecrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {

            byte[] decryptedData;
            //Create a new instance of RSACryptoServiceProvider. 
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                //Import the RSA Key information. This needs 
                //to include the private key information.
                RSA.ImportParameters(RSAKeyInfo);

                //Decrypt the passed byte array and specify OAEP padding.   
                //OAEP padding is only available on Microsoft Windows XP or 
                //later.  
                decryptedData = RSA.Decrypt(DataToDecrypt, DoOAEPPadding);
            }
            return decryptedData;
        }
    }
}