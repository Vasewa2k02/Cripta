using System;

namespace Cripta_Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            NOD Nod = new NOD();
            PrimeNumber Prime = new PrimeNumber();

            Console.WriteLine("------------1------------------");
            Prime.printInterval(2, 553);
          
            Prime.printLog(553);
            Console.WriteLine("--------------2----------------");
            Prime.printInterval(521, 553);
            Console.WriteLine("---------------3---------------");
            Console.WriteLine("521 = 521" );
            Console.WriteLine("553 = 7*79");
            Console.WriteLine("---------------4---------------");
            Prime.printPrime(521553);
            Console.WriteLine("---------------5---------------");
            Console.WriteLine("НОД(521,553) = " + Nod.Nod2(521, 533));
            Console.WriteLine("---------------7---------------");
            Console.WriteLine("НОД(52,26,13) = " + Nod.Nod3(52, 26, 13));
           
        }
    }
}
