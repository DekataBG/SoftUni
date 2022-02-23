using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._List_Of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> numbers = Enumerable.Range(1, n).ToList();

            int[] divisors = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Func<int, int[], bool> isDivisibleByAll = IsDivisible;

            Console.WriteLine(String.Join(" ", numbers
                .Where(n => IsDivisible(n, divisors))
                .ToList()));

            static bool IsDivisible(int number, int[] divisors)
            {
                foreach (var divisor in divisors)
                    if (number % divisor != 0)
                        return false;

                return true;
            }
        }
    }
}
