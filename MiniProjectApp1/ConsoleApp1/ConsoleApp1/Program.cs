using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class ParamRef
    {
        public int myVal = 10;
    }
    
    public class ParamTest
    {
        public static  void Increase(ref ParamRef varRef)
        {
            varRef.myVal++;
        }
        public static void Main(string[] args)
        {
            
            ParamRef pr = new ParamRef();
            Console.WriteLine($"호출전 : {pr.myVal}");
            ParamTest.Increase(ref pr);
            Console.WriteLine($"호출후 : {pr.myVal}");
        }
    
       

    }
}

