using System;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Text;
using System.Linq;

namespace Lab10ElGam
{
    internal class Program
    {
        private static void Main()
        {
            Stopwatch time = new Stopwatch();
            
            string text = "Bulauski kirill Sergey";

            time.Start();

            string cryptedText = ElGam.EnCrypt(text);

            time.Stop();
            Console.WriteLine($"Зашифрованное: {cryptedText} | {(float)time.ElapsedMilliseconds / 1000} с");

            time.Reset();

            time.Start();
            string decryptedText = ElGam.DeCrypt(cryptedText);
            time.Stop();
            Console.WriteLine($"Расшифрованное: {decryptedText} | {(float)time.ElapsedMilliseconds / 1000} с");

            Console.ReadKey();
        }
    }


    public class ElGam
    {
        private static string Crypt(int p, int g, int x, string inString)
        {
            var result = "";
            var y = Power(g, x, p);
            var rand = new Random();
            Console.WriteLine($"Открытый ключ (p,g,y)=({p},{g},{y})");
            Console.WriteLine($"Закрытый ключ (p,g,x)=({p},{g},{x})");

            foreach (int code in inString)
                if (code > 0)
                {
                    //случайное число k (1 < k < p-1)
                    var k = rand.Next() % (p - 2) + 1;
                    //a = g ^ k mod p
                    var a = Power(g, k, p);
                    //b = (y ^ k * m) mod p
                    var b = Mul(Power(y, k, p), code, p);
                    //зашифрованный блок текста
                    result += a + " " + b + " ";
                }

            return result;
        }



        private static string Decrypt(int p, int x, string inText)
        {
            var result = "";

            var arr = inText.Split(' ').Where(xx => xx != "").ToArray();

            for (var i = 0; i < arr.Length; i += 2)
            {
                var a = int.Parse(arr[i]);
                var b = int.Parse(arr[i + 1]);

                if (a != 0 && b != 0)
                {
                    //m = (b * (a ^ x) ^ -1) mod p
                    var deM = Mul(b, Power(a, p - 1 - x, p), p);

                    //расшифрованный символ
                    var m = (char)deM;
                    result += m;
                }
            }

            return result;
        }



        private static int Power(int a, int b, int n)
        { 
            // a ^ b mod n
            var tmp = a;
            var sum = tmp;
            for (var i = 1; i < b; i++)
            {
                for (var j = 1; j < a; j++)
                {
                    sum += tmp;
                    if (sum >= n)
                    {
                        sum -= n;
                    }
                }

                tmp = sum;
            }

            return tmp;
        }

        private static int Mul(int a, int b, int n)
        { 
            // a*b mod n 
            var sum = 0;

            for (var i = 0; i < b; i++)
            {
                sum += a;

                if (sum >= n)
                {
                    sum -= n;
                }
            }

            return sum;
        }

        public static string EnCrypt(string str)
        {
            return Crypt(593, 123, 8, str);
        }

        public static string DeCrypt(string str)
        {
            return Decrypt(593, 8, str);
        }
    }
}
