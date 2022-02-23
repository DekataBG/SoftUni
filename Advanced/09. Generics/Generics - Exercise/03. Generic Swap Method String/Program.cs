using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Generic_Swap_Method_String
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<string>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
                list.Add(Console.ReadLine());

            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            list = Swap(list, indexes[0], indexes[1]);

            foreach (var item in list)
                Console.WriteLine($"{typeof(string)}: {item}");
        }

        public static List<T> Swap<T>(List<T> list, int firstIndex, int secondIndex)
        {
            var temp = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = temp;

            return list;
        }
    }
}
