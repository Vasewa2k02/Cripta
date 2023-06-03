using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cripta_Lab3
{
    class NOD
    {
        public int Nod2(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

            if (b == 0)
                return a;
            else
                return Nod2(b, a % b);
        }

        public int Nod3(int a, int b, int c)
        {
            return Nod2(Nod2(a,b),c);
        }
    }
}
