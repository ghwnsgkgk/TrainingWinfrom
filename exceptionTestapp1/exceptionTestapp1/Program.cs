using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exceptionTestapp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int x= 10, y=5, value=0; //선언이라 에러날 일없는부분
             // 최근에 나온 문자열 방식 더 쉽다 .
            //예외처리//
            //비정상적으로 종료 될 거 같은 위치에 try구문으로 //
            //일단 throw 로 던지는 걸 catch로 받기 
            //try 예외 검사 catch  예외처리 finally 마무리
            try //에러가 날 만한 부분
            {
                value = x / y;
                Console.WriteLine($"{x}/{y}={value}");//에러 날만한  부분을 트라이에 적었다.
                throw new Exception("사용자 에러"); // 사용자가 일부러 에러내는 코드 exception을 분리해야한다.
            }
            catch(DivideByZeroException ex) //자식 익셉션
            {
                Console.WriteLine("2.y의 값을 0보다 크게 입력하세요");
            }
            catch (Exception ex)// 부모 익셉션
            {
                Console.WriteLine("3."+ex.Message); //에러가 날경우에 명령어
                
            }
            finally
            {
                Console.WriteLine("4.프로그램이 종료했습니다.");//에러가 나든 안나든 마지막에 이루어질 출력문 (무조건실행)
            }
        }
    }
}
