using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[][] arr = new int[n][];
            int alive = 0;
            int sum = 0;

            for (int i = 0; i < n; i++)
                arr[i] = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            string[] coordinates = Console.ReadLine().Split(' ');
            var queue = new Queue<Tuple<int, int>>();

            foreach (var coord in coordinates)
            {
                int[] subArr = coord.Split(',').Select(int.Parse).ToArray();
                queue.Enqueue(new Tuple<int, int>(subArr[0], subArr[1]));
            }

            while (queue.Count > 0)
            {
                var coordinate = queue.Dequeue();

                arr = NewArr(arr, coordinate.Item1, coordinate.Item2);
            }

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    if (arr[i][j] > 0)
                    {
                        alive++;
                        sum += arr[i][j];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {alive}");
            Console.WriteLine($"Sum: {sum}");
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    Console.Write(arr[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

        static int[][] NewArr(int[][] arr, int row, int col)
        {
            int bomb = arr[row][col];

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    if (arr[i][j] > 0)
                    {
                        if ((i == row - 1 || i == row + 1) && (j == col - 1 || j == col || j == col + 1))
                            arr[i][j] -= bomb;

                        else if (i == row)
                        {
                            if (j == col - 1 || j == col + 1)
                                arr[i][j] -= bomb;
                            else if (j == col)
                                arr[i][j] = 0;
                        }
                    }
                }
            }

            return arr;
        }
    }
}
