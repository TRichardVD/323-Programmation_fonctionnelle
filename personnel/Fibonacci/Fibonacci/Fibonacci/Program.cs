using System;

namespace MyApp
{
    internal class Program
    {
        static int Fibonacci(int n)
        {
            if (n <= 0) return 0;
            else if (n == 1) return 1;
            else return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("====== FIBONACCI ======");

            for(int i = 0; i < 13; i++)
            {
                Console.Write(Fibonacci(i) + ", ");
            }
        }
    }
}