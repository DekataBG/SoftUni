using System;
using System.Linq;
using _03.MinHeap;
using _04.CookiesProblem;

namespace Playground
{
    class Program
    {
        static void Main(string[] args)
        {
            var cookies = new CookiesProblem();

            var k = int.Parse(Console.ReadLine());
            var integers = Console.ReadLine().Split().Select(i => int.Parse(i)).ToArray();

            var result = cookies.Solve(k, integers);

            Console.WriteLine(result);
        }
    }
}
