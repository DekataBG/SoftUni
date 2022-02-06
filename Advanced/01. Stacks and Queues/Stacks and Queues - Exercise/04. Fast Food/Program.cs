using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());
            int[] order = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var queue = new Queue<int>();
            int j = 0;

            Console.WriteLine(order.Max());

            for (int i = 0; i < order.Count(); i++)
            {
                if (quantity >= order[i])
                    quantity -= order[i];

                else
                {
                    j = i;
                    break;
                }
            }

            if (j == 0)
            {
                Console.WriteLine("Orders complete ");
            }
            else
            {
                Console.Write("Orders left:");
                for (int i = j; i < order.Count(); i++)
                {
                    Console.Write(" " + order[i]);
                }
                Console.WriteLine();
            }
        }
    }
}
