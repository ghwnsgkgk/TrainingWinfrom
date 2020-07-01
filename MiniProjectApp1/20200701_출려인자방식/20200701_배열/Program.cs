using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20200701_배열
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("행의 갯수를 입력하세요");
            int rows = int.Parse(Console.ReadLine());

            Console.WriteLine("열의 갯수를 입력하세요");
            int cols = int.Parse(Console.ReadLine());


            int[,] myArray = new int[rows, cols];
            Console.WriteLine(rows + "*" + cols + "배열이 생성되었습니다.");

        }
    }
}
