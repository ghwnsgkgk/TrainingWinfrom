using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20200701_카피배열
{
    class CopyArray
    {
        static void Main(string[] args)
        {
            long[] Original = new long[4] { 3, 1, 2, 0 }; //스택 영역만 2개가 만들어지고 힙영역은 1개만
            long[] Copy = Original;

            Console.WriteLine("1 : " + Copy[3]);
            
            Original[3] = Original[1] + Original[2]; //3번자리가 0에서 합의 값 3으로 바뀐다. ,,,,,,,
            long CopyVALUE = Copy[3];
            
            Console.WriteLine("2 : " + Copy[3]); //아 배열을 이렇게 수정을 할 수 있구나 !! 
        }
    }
}
