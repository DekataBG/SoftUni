using System;
using System.Globalization;
using System.Threading;

namespace _08._Threeuple
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");

            var info1 = Console.ReadLine().Split();
            var tuple1 = new MyThreeuple<string, string, string>(info1[0] + " " + info1[1], info1[2], info1[3]);

            var info2 = Console.ReadLine().Split();
            var tuple2 = new MyThreeuple<string, int, string>(info2[0], int.Parse(info2[1]), info2[2]);

            var info3 = Console.ReadLine().Split();
            var tuple3 = new MyThreeuple<string, double, string>(info3[0], double.Parse(info3[1]), info3[2]);

            Console.WriteLine($"{tuple1.Item1} -> {tuple1.Item2} -> {tuple1.Item3}");
            Console.WriteLine($"{tuple2.Item1} -> {tuple2.Item2} -> {tuple2.Item3 == "drunk"}");
            Console.WriteLine($"{tuple3.Item1} -> {tuple3.Item2} -> {tuple3.Item3}");
        }
    }
}
