using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20200701_출려인자방식
{
    public class ParamValue
    {
        public void Increase(out int n) //쓰기 용이지 읽기 용이아니다 
        {
            
            n = 11;
            Console.WriteLine(n);
        }
        public static void Main(string[] args)
        {
            int i;
            ParamValue paramValue = new ParamValue();
            paramValue.Increase(out i);
            Console.WriteLine($"호출후 값 : {i}");
            
        }
    }
}
