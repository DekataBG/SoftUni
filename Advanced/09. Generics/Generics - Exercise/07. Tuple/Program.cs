using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace _07._Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");

            var info1 = Console.ReadLine().Split();
            var tuple1 = new MyTuple<string, string>(info1[0] + " " + info1[1], info1[2]);

            var info2 = Console.ReadLine().Split();
            var tuple2 = new MyTuple<string, int>(info2[0], int.Parse(info2[1]));

            var info3 = Console.ReadLine().Split();
            var tuple3 = new MyTuple<int, double>(int.Parse(info3[0]), double.Parse(info3[1]));

            Console.WriteLine($"{tuple1.Item1} -> {tuple1.Item2}");
            Console.WriteLine($"{tuple2.Item1} -> {tuple2.Item2}");
            Console.WriteLine($"{tuple3.Item1} -> {tuple3.Item2}");
        }
    }
}
