using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Problem05.ReverseNumbersWithAStack
{
    public class Program
    {
        static void Main(string[] args)
        {
            var inputArray = Console.ReadLine().Split().Select(i => int.Parse(i)).ToArray();

            Console.WriteLine(String.Join(" ", ReverseArray(inputArray)));
        }

        public static int[] ReverseArray(int[] array)
        {
            var stack = new Stack<int>();

            foreach (var item in array)
            {
                stack.Push(item);
            }

            var newArray = new int[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = stack.Pop();
            }

            return newArray;
        }
    }
}
