using System;
using System.Linq;

namespace ConsoleTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(FindFactorial(n));
        }

        private static int FindFactorial(int n)
        {
            if (n == 1)
                return 1;

            return n * FindFactorial(n - 1);
        }
    }
}
