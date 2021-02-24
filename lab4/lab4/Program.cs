using System;

namespace lab4
{
    class Program
    {
        public static int Greater(int a, int b) => (a>b? a:b);
        public static void swap(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }
        public static bool Factorial (int a, ref long answer)
        {
            answer = 1;
            for(int i = 2; i<1+a; i++)
            {
                answer *= i;
            }
            return true;
        }
        public static long RecFact(int a)
        {
            if (a == 1) return a;
            return a * RecFact(a - 1);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите два целых числа через enter");
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            int greater = Greater(x, y);
            Console.WriteLine("Большее из них это {0}", greater);
            Console.WriteLine("Введите два целых числа через enter");
            x = int.Parse(Console.ReadLine());
            y = int.Parse(Console.ReadLine());
            swap(ref x, ref y);
            Console.WriteLine("x - {0}, y - {1}", x, y);
            Console.WriteLine("Введите натуральное число");
            x = int.Parse(Console.ReadLine());
            long answer = 1;
            if(Factorial(x, ref answer))
            {
                Console.WriteLine("Факториал числа {0} равен {1}", x, answer);
            }
            Console.WriteLine("Рекурсивно вычисленный факториал числа {0} равен {1}", x, RecFact(x));
        }
    }
}
