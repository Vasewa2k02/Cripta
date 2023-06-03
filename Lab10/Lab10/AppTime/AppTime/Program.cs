using System;
using System.Diagnostics;
using System.Numerics;

namespace AppTime
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            BigInteger a = 30;
            BigInteger p = 712489;
            BigInteger q = 944929;
            BigInteger n = p * q;

            for (int i = 0; i < 10; i++)
            {
                Stopwatch stopwatch = new Stopwatch();

                BigInteger x = random.Next(103, 10100);
                while (!isSimple(x))
                {
                    x = random.Next(103, 10100);
                }

                stopwatch.Start();

                BigInteger y = Y(a, x, n);

                stopwatch.Stop();

                Console.WriteLine("x = " + x + "\n" + "y = " + y +
                    "\n" + "Потрачено на выполнение: " 
                    + stopwatch.ElapsedMilliseconds + " мс" + "\n\n");
            }
        }

        static BigInteger Y(BigInteger a, BigInteger x, BigInteger n)
        {
            BigInteger aPowX = a;
            for (BigInteger i = 1; i < x; i++)
            {
                aPowX *= a;
            }
            return aPowX % n;
        }

        static bool isSimple(BigInteger n)
        {
            bool isSimple = true;
            for (int i = 2; i < n; i++)
                if (n % i == 0) isSimple = false;
            return isSimple;
        }
    }

    
}
