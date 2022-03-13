using System;
using System.Collections.Generic;

namespace _06._Generic_Count_Method_Double
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<double>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
                list.Add(double.Parse(Console.ReadLine()));

            Console.WriteLine(Compare(list, double.Parse(Console.ReadLine())));
        }
        public static int Compare<T>(List<T> list, T element) where T : IComparable
        {
            int count = 0;

            foreach (var item in list)
                if (item.CompareTo(element) > 0)
                    count++;

            return count;
        }
    }
}
