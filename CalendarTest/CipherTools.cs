using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace CalendarTest
{
    class CipherTools
    {
        public static byte[] Encrypt(byte[] plain, string password, byte[] salt)
        {
            MemoryStream memoryStream;
            CryptoStream cryptoStream;
            Rijndael rijndael = Rijndael.Create();
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(password, salt);
            rijndael.Key = pdb.GetBytes(32);
            rijndael.IV = pdb.GetBytes(16);
            memoryStream = new MemoryStream();
            cryptoStream = new CryptoStream(memoryStream, rijndael.CreateEncryptor(), CryptoStreamMode.Write);
            cryptoStream.Write(plain, 0, plain.Length);
            cryptoStream.Close();
            Console.WriteLine("Cypher OK");

            return memoryStream.ToArray();
        }

        public static byte[] Decrypt(byte[] cipher, string password, byte[] salt)
        {
            try
            {
                MemoryStream memoryStream;
                CryptoStream cryptoStream;
                Rijndael rijndael = Rijndael.Create();
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(password, salt);
                rijndael.Key = pdb.GetBytes(32);
                rijndael.IV = pdb.GetBytes(16);
                memoryStream = new MemoryStream();
                cryptoStream = new CryptoStream(memoryStream, rijndael.CreateDecryptor(), CryptoStreamMode.Write);
                cryptoStream.Write(cipher, 0, cipher.Length);
                cryptoStream.Close();
                Console.WriteLine("Plain OK");

                return memoryStream.ToArray();
            }
            catch (Exception e)
            {
                Console.WriteLine("Lol erreur visiblement : {0}", e.Message);
            }
            return null;
        }

        public static void GenerateKey(string location, string pwd, byte[] salt)
        {
            string bufferPlain = File.ReadAllText(location);
            byte[] plain = Encoding.Unicode.GetBytes(bufferPlain);
            MemoryStream memoryStream;
            CryptoStream cryptoStream;
            Rijndael rijndael = Rijndael.Create();
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(pwd, salt);
            rijndael.Key = pdb.GetBytes(32);
            rijndael.IV = pdb.GetBytes(16);
            memoryStream = new MemoryStream();
            cryptoStream = new CryptoStream(memoryStream, rijndael.CreateEncryptor(), CryptoStreamMode.Write);
            cryptoStream.Write(plain, 0, plain.Length);
            cryptoStream.Close();

            string cipher = String.Empty;
            byte[] buffer = memoryStream.ToArray();
            foreach (byte b in buffer)
            {
                cipher += b.ToString() + " ";
            }
            File.WriteAllText(location + "cipher", cipher);
        }
    }
}
