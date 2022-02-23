using System;
using System.Linq;

namespace _03._Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> smallestNumber = PrintSmallestNumber;

            Console.WriteLine(smallestNumber(Console.ReadLine()));
        }
        static int PrintSmallestNumber(string input)
        {
            int[] numbers = input.Split().Select(int.Parse).ToArray();
            int smallest = numbers[0];

            foreach (var number in numbers)
                if (smallest > number)
                    smallest = number;

            return smallest;
        }
    }
}
