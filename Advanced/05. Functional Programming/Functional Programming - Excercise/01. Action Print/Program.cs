using System;

namespace _01._Action_Print
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> print = Print;

            print(Console.ReadLine());
        }
        static void Print(string line)
        {
            string[] lines = line.Split();

            foreach (var item in lines)
                Console.WriteLine(item);
        }
    }
}
