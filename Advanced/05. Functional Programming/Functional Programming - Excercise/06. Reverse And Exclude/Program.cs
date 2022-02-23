using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            int n = int.Parse(Console.ReadLine());

            Func<int, int, bool> isNotDivisible = (x, y) => { return y % x != 0; };

            numbers = numbers.Where((x) => isNotDivisible(n, x)).Reverse().ToList();

            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
