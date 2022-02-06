using System;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], string, int[]> commands = ManageCommands;

            commands(Console.ReadLine().Split().Select(int.Parse).ToArray(), Console.ReadLine());
        }

        static int[] ManageCommands(int[] numbers, string command)
        {
            switch (command)
            {
                case "add":
                    numbers = Add(numbers);
                    break;
                case "multiply":
                    numbers = Multiply(numbers);
                    break;
                case "subtract":
                    numbers = Subtract(numbers);
                    break;
                case "print":
                    Print(numbers);
                    break;
                case "end":
                    return null;
            }
            command = Console.ReadLine();
            ManageCommands(numbers, command);

            return numbers;
        }
        static int[] Add(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
                numbers[i]++;

            return numbers;
        }
        static int[] Multiply(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
                numbers[i] *= 2;

            return numbers;
        }
        static int[] Subtract(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
                numbers[i]--;

            return numbers;
        }
        static void Print(int[] numbers)
        {
            Console.WriteLine(String.Join(" ",  numbers));
        }
    }
}
