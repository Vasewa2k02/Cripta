using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cripta_Lab3
{
    class PrimeNumber
    {
        public bool isPrime(int a)
        {
            for (int i = 2; i <= Math.Sqrt(a); i++)
            {
                if (a % i == 0)
                    return false;
            }
            return true;
        }

        public void printPrime(int a)
        {
            if (isPrime(a))
                Console.WriteLine(a + "- простое");
            else 
                Console.WriteLine(a + "- не простое");
        }

        public List<int> primeInInterval(int bef, int aft)
        {
            if (bef < 2) bef = 2;
            var primes = new List<int>();

            for(int i = bef; i <= aft; i++)
            {
                if (isPrime(i)) primes.Add(i);
            }

            return primes;
        }

        public void printInterval(int bef, int aft){
            Console.WriteLine("Простые числа на интервале [" + bef + "-" + aft + "]");
            var pr = primeInInterval(bef, aft);
            foreach (var p in pr)
            {
                Console.Write(p + ", ");
            }
            Console.WriteLine("\nВсего их:" + pr.Count);
        }

        public void printLog(int a)
        {
            Console.WriteLine("\n" + a + "/ln" + a + "=" + a/Math.Log(a));
        }
    }
}
