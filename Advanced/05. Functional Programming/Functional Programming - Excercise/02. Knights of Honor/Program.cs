using System;

namespace _02._Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> print = Print;

            print(Console.ReadLine());
        }
        static void Print(string input)
        {
            string[] names = input.Split();

            foreach (var name in names)
                Console.WriteLine($"Sir {name}");
        }
    }
}
