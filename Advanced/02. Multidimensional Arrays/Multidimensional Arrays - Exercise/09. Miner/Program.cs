using System;
using System.Collections.Generic;

namespace _09._Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine().Split(' ');

            var queue = new Queue<string>();
            int[] currentPosition = new int[2];
            int coals = 0;
            bool end = false;

            foreach (var command in commands)
                queue.Enqueue(command);

            string[][] arr = new string[n][];

            for (int i = 0; i < n; i++)
                arr[i] = Console.ReadLine().Split(' ');

            //Start row,Start  col, coals
            int[] initialInfo = StartPosition(arr);

            currentPosition = new int[2] { initialInfo[0], initialInfo[1] };

            while (queue.Count > 0)
            {
                string command = queue.Dequeue();
                switch (command)
                {
                    case "up":
                        if (currentPosition[0] - 1 >= 0)
                            currentPosition = new int[2] { currentPosition[0] - 1, currentPosition[1] };
                        break;
                    case "down":
                        if (currentPosition[0] + 1 < arr.Length)
                            currentPosition = new int[2] { currentPosition[0] + 1, currentPosition[1] };
                        break;
                    case "left":
                        if (currentPosition[1] - 1 >= 0)
                            currentPosition = new int[2] { currentPosition[0], currentPosition[1] - 1 };
                        break;
                    case "right":
                        if (currentPosition[1] + 1 < arr.Length)
                            currentPosition = new int[2] { currentPosition[0], currentPosition[1] + 1 };
                        break;
                }

                int row = currentPosition[0];
                int col = currentPosition[1];

                if (arr[row][col] == "c")
                {
                    coals++;
                    arr[row][col] = "*";
                    if (coals == initialInfo[2])
                        break;
                }

                else if (arr[row][col] == "e")
                {
                    end = true;
                    break;
                }
            }

            if (coals == initialInfo[2])
                Console.WriteLine($"You collected all coals! ({currentPosition[0]}, {currentPosition[1]})");

            else if (end == true)
                Console.WriteLine($"Game over! ({currentPosition[0]}, {currentPosition[1]})");

            else
                Console.WriteLine($"{initialInfo[2] - coals} coals left. ({currentPosition[0]}, {currentPosition[1]})");

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

            return arr; ;
        }

        static int[] StartPosition(string[][] arr)
        {
            int coals = 0;
            int row = 0, col = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    if (arr[i][j] == "s")
                    {
                        row = i;
                        col = j;
                    }
                    if (arr[i][j] == "c")
                        coals++;
                }
            }

            return new int[] { row, col, coals };
        }
    }
}
