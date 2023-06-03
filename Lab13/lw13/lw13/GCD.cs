using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_13
{
    class GCD
    {
        public static int Mod(int x, int m)
        {
            return (x % m + m) % m;
        }

        public static int ModInverse(int a, int m)
        {
            a = a % m;
            for (int x = 1; x < m; x++)
                if ((a * x) % m == 1)
                    return x;
            return 1;
        }
    }
}
