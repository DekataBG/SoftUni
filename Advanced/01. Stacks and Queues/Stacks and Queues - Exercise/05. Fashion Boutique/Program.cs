using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clothes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int capacity = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();
            int racks = 1;
            int sum = 0;

            for (int i = 0; i < clothes.Length; i++)
                stack.Push(clothes[i]);

            while (stack.Count() > 0)
            {
                if (sum + stack.Peek() <= capacity)
                    sum += stack.Peek();
                else
                {
                    sum = stack.Peek();
                    racks++;
                }
                stack.Pop();
            }

            Console.WriteLine(racks);
        }
    }
}
