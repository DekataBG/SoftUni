using System;
using System.Linq;

namespace ConsoleTesting
{
    class Program
    {
        static int sum = 0;
        static void Main(string[] args)
        {
            var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Console.WriteLine(FindSum(arr, arr.Length - 1));

        }
        static int FindSum(int[] arr, int index)
        {
            if (index == -1)
                return 0;

            return arr[index] + FindSum(arr, index - 1);
        }
    }
}
