using System;
using System.Collections.Generic;

namespace _03._Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            var set = new SortedSet<string>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] elements = Console.ReadLine().Split();

                foreach (var el in elements)
                    set.Add(el);
            }

            Console.WriteLine(String.Join(" ", set));
        }
    }
}
