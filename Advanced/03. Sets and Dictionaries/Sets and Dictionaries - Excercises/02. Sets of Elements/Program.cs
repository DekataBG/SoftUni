using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nm = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var set1 = new HashSet<int>();
            var set2 = new HashSet<int>();

            for (int i = 0; i < nm[0]; i++)
                set1.Add(int.Parse(Console.ReadLine()));

            for (int i = 0; i < nm[1]; i++)
                set2.Add(int.Parse(Console.ReadLine()));

            foreach (var number in set1)
                if(set2.Contains(number))
                    Console.Write(number + " ");

        }
    }
}
