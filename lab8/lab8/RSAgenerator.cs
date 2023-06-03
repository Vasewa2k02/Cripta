using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Security.Cryptography;
using System.Security;
using System.Threading;

namespace lab8
{
    public static class PrimeExtensions
    {
        // Random generator (thread safe)
        private static ThreadLocal<Random> s_Gen = new ThreadLocal<Random>(
          () => {
              return new Random();
          }
        );

        // Random generator (thread safe)
        private static Random Gen
        {
            get
            {
                return s_Gen.Value;
            }
        }

        public static Boolean IsProbablyPrime(this BigInteger value, int witnesses = 10)
        {
            if (value <= 1)
                return false;

            if (witnesses <= 0)
                witnesses = 10;

            BigInteger d = value - 1;
            int s = 0;

            while (d % 2 == 0)
            {
                d /= 2;
                s += 1;
            }

            Byte[] bytes = new Byte[value.ToByteArray().LongLength];
            BigInteger a;

            for (int i = 0; i < witnesses; i++)
            {
                do
                {
                    Gen.NextBytes(bytes);

                    a = new BigInteger(bytes);
                }
                while (a < 2 || a >= value - 2);

                BigInteger x = BigInteger.ModPow(a, d, value);
                if (x == 1 || x == value - 1)
                    continue;

                for (int r = 1; r < s; r++)
                {
                    x = BigInteger.ModPow(x, 2, value);

                    if (x == 1)
                        return false;
                    if (x == value - 1)
                        break;
                }

                if (x != value - 1)
                    return false;
            }

            return true;
        }
    }
    class RSAgenerator
    {
        static Random random = new Random();
        static public BigInteger getRandom(int length)
        {
            
            byte[] data = new byte[length];
            random.NextBytes(data);
            BigInteger resData = new BigInteger(data);
            if (resData < 0)
            {
                resData *= -1;
            }
            return resData;
        }

       static public BigInteger resRand()
        {
            BigInteger randNum = new BigInteger();
            
            bool isPrime = false;
            
            while(isPrime == false)
            {
                randNum = getRandom(2);
                isPrime = randNum.IsProbablyPrime(10);
            }

            return randNum;
        }

        public static bool IsCoprime(BigInteger num1, BigInteger num2)
        {
            bool isCo = false;
            if (BigInteger.GreatestCommonDivisor(num1, num2) == 1)
            {
                isCo = true;
            }
            return isCo;
        }
        public static BigInteger Pow(BigInteger value, BigInteger exponent)
        {
            BigInteger originalValue = value;
            while (exponent-- > 1)
                value = BigInteger.Multiply(value, originalValue);
            return value;
        }

        static public Array rsaGen(int m)
        {
            BigInteger p = resRand();
            BigInteger q = resRand();
            BigInteger N = p * q;

            BigInteger fN = (p - 1) * (q - 1);

            BigInteger randNum = new BigInteger();
            bool isCopr = false;
            while(isCopr == false)
            {
                randNum = resRand();
                if (randNum < fN)
                {
                    isCopr = IsCoprime(randNum, fN);
                }
            }

            BigInteger k = randNum;
            BigInteger u0 = new BigInteger();
            bool smaller = false;
            while(smaller == false)
            {
                u0 = resRand();
                if (u0 < N)
                {
                    smaller = true;
                }
            }

            BigInteger[] resArr = new BigInteger[m+1];
            resArr[0] = u0;

            int[] resIntArr = new int[m];
            

            for (int i = 1; i < m+1; i++)
            {
                resArr[i] = Pow(resArr[i - 1], k) % N;
                byte[] positiveBytes = resArr[i].ToByteArray();
                resIntArr[i - 1] = Convert.ToInt32(positiveBytes.Last());
            }


            return resIntArr;

        }

        static public string getRSAres()
        {
            string resStr = "";
            Array newArr = rsaGen(5);
            foreach(int num in newArr)
            {
                resStr += num + " ";
            }
            return resStr;
        }


    }
}
