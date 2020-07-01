using Microsoft.Win32.SafeHandles;
using System;

namespace _20200701_가변인자
{
    public class ParamValue
    {
        public static void VarMethod(params object[] arr) //오브젝트 타입으로 받는다는거는 아무타입 다받을 수 있음 
        {
            Console.WriteLine("[가변 인자 개수] :" + arr.Length.ToString());
            Console.Write("[인자 전체] : ");
            foreach (object item in arr)
            {
                Console.Write(item.ToString() + " ");
            }
            Console.WriteLine();

            Console.Write("[문자열 타입] : ");
            for (int i = 0; i < arr.Length; i++)
            {
                Type T = arr[i].GetType(); //이거 왜 나와? -> 겟타입 타입을 추출하는 메서드  반환 타입이 타입이다.
                if (T.Equals(typeof(string))) //typeof -> 예약어 
                {
                    Console.Write(arr[i] + " ");
                }
            }
            Console.WriteLine();

            Console.Write("[정수 타입] : ");
            foreach (object item in arr)
            {
                Type t = item.GetType();
                if (t.Equals(typeof(int)))
                {
                    Console.Write(item + " ");
                }
            }
            Console.WriteLine();

            Console.Write("[실수 타입] : ");
            foreach (object item in arr)
            {
                Type t = item.GetType();
                if (t.Equals(typeof(float)))
                {
                    Console.Write(item + " ");
                }
            }
            Console.WriteLine();
        }
        public static void Main(string[] args)
        {
            VarMethod(1000, 2000, "3000", "헬로", 3.1, 3.2f);
        }
    }
}
