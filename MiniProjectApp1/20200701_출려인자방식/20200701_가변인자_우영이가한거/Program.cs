using System;

namespace _20200701_가변인자_우영이가한거
{
    class Program
    {
        public static void VarMethod(params object[] arr)
        { // 오브젝트 타입은 타입의 관계 없이 다 받는다. 예를 들어 : 문자형, 정수, 실수형 등등
            Console.WriteLine($"가변 인자 개수 : {arr.Length}");

            Console.WriteLine("[인자 전체] :");

            foreach (object item in arr)
            {
                Console.Write(item + "");

                Console.WriteLine();

                Type t = item.GetType(); // 타입을 추출한다. 반환타입이 타입

                if (t.Equals(typeof(System.String)))
                {

                    Console.WriteLine("문자열 타입 : ");
                    Console.WriteLine(item + " ");
                }
                else if (t.Equals(typeof(System.Int32)))

                {
                    Console.WriteLine("정수 타입 : ");
                    Console.Write(item + " ");
                }
                else if (t.Equals(typeof(System.Double)))
                {

                    Console.WriteLine("더블 실수 타입");
                    Console.Write(item + " ");
                }
                else if (t.Equals(typeof(System.Single)))
                {


                    Console.WriteLine("Float(single) 실수 타입");
                    Console.Write(item + " ");

                }

            }
        }
    }
}
