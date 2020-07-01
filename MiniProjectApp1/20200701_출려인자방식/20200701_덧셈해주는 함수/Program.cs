using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20200701_덧셈해주는_함수
{
    class Program
    {
        static double add(double dnum, double dnum1)
        {
            double dnum2 = dnum + dnum1;
            return dnum2;
        }
        static float add(float fnum, float fnum1)
        {
            float fnum2 = fnum + fnum1;
            return fnum2;
        }
        static int add(int inum, int inum1)
        {
            int inum2 = inum + inum1;
            return inum2;
        }
        static void Main(string[] args)
        {
            int num = 3;
            int num1 = 4;
            int num2 = num + num1;
            Console.WriteLine($"{num}+{num1}={num2}");
            int inum3 = add(5, 6);
            Console.WriteLine($"{inum3}={5}+{6}");
            Console.WriteLine(inum3);
            double dnum3 = add(5.1, 6.1);
            Console.WriteLine($"{dnum3}={5.1}+{6.2}");
            Console.WriteLine(dnum3);
            float fnum3 = add(5.2f ,6.2f);
            Console.WriteLine($"{fnum3}={5.2f}+{6.2f}");
            Console.WriteLine(fnum3);

        }
    }
}
