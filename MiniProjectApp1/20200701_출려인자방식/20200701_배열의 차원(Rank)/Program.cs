using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20200701_배열의_차원_Rank_
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[4];
            int[,] array2 = new int[2, 3];
            int[,,] array3 = new int[2, 4, 3];

            
            Console.WriteLine("array1의 차원 : " + array.Rank);
            Console.WriteLine("array2의 차원 : " + array2.Rank);
            Console.WriteLine("array3의 차원 : " + array3.Rank);

        }
    }
}
