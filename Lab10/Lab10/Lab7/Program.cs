using System;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Text;

namespace Lab8
{
    internal class Program
    {
        private static void Main()
        {
            Stopwatch time = new Stopwatch();
            time.Start();
            time.Stop();


            //Шифрование RSA
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();

            time.Start();
            byte[] text = Encoding.UTF8.GetBytes("Булавский Кирилл Сергеевич");
            byte[] crypted = RSAcl.Encryption(text, RSA.ExportParameters(false), false);
            string cryptedText = Convert.ToBase64String(crypted);
            time.Stop();
            Console.WriteLine($"Зашифрованное сообщение:\n{cryptedText} | {(float)time.ElapsedMilliseconds / 1000} c");
            Console.WriteLine();

            time.Reset();

            time.Start();
            string decryptedText = RSAcl.Decryption(crypted, RSA.ExportParameters(true), false);
            time.Stop();
            Console.WriteLine($"Расшифрованное сообщение:\n{decryptedText} | {(float)time.ElapsedMilliseconds / 1000} c");

            Console.ReadKey();
        }
    }


    public class RSAcl
    {
        static public byte[] Encryption(byte[] Data, RSAParameters RSAKey, bool DoOAEPPadding)
        {
            byte[] encryptedData;
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(512))
            {
                RSA.ImportParameters(RSAKey);
                encryptedData = RSA.Encrypt(Data, DoOAEPPadding);
            }
            return encryptedData;
        }

        static public string Decryption(byte[] Data, RSAParameters RSAKey, bool DoOAEPPadding)
        {
            byte[] decryptedData;
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(512))
            {
                RSA.ImportParameters(RSAKey);
                decryptedData = RSA.Decrypt(Data, DoOAEPPadding);
            }
            return Encoding.UTF8.GetString(decryptedData);
        }
    }

}

// p и q

// n e d
// n e - открытый
// n d - закрытый

// n = p * q
// (p – 1)(q – 1) - ф-я Эйлера
// e и ф-я Эйлера взаимно обратные числа
// ed ≡ 1 (mod φ(n)). - находим d
// c ≡ m * e mod n
// m ≡ c * d mod n
