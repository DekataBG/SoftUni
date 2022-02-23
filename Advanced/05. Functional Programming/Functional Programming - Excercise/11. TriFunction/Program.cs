using System;
using System.Linq;

namespace _11._TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();

            Func<string, int, bool> isLarger = (name, n) => { return name.Sum(x => x) >= n; };

            Func<string[], int, Func<string, int, bool>, string> getName =
                (names, sum, func) =>  names.Where(x => func(x, sum)).FirstOrDefault();

            Console.WriteLine(getName(names, n, isLarger));
        }
    }
}
