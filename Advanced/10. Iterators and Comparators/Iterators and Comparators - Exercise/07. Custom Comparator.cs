using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace ConsoleTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Array.Sort(arr, Compare);

            Console.WriteLine(String.Join(" ", arr));
        }
        public static int Compare(int x, int y)
        {
            if ((x % 2 != 0 && y % 2 != 0) || (x % 2 == 0 && y % 2 == 0))
                return x.CompareTo(y);
            else if (x % 2 == 0 && y % 2 != 0)
                return -1;
            else
                return 1;
        }
    }
}
