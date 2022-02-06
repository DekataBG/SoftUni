using System;
using System.Linq;

namespace _07._Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();

            Predicate<string> shortNames = name => name.Length <= n;

            names = names.Where(x => shortNames(x)).ToArray();

            Console.WriteLine(String.Join(Environment.NewLine, names));
        }
    }
}
