using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] n = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var numbers = new List<int>();

            Predicate<int> isEven = n => n % 2 == 0;
            Predicate<int> isOdd = n => n % 2 != 0;

            string command = Console.ReadLine();

            for (int i = n[0]; i <= n[1]; i++)
                numbers.Add(i);

            numbers = command == "even" ?
                numbers.FindAll(isEven) :
                numbers.FindAll(isOdd);

                Console.WriteLine(String.Join(" ", numbers));

        }
    }
}
