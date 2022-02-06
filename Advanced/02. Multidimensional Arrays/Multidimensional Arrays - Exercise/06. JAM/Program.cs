using System;
using System.Linq;

namespace _06._JAM
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double[][] matrix = new double[n][];

            for (int i = 0; i < n; i++)
                matrix[i] = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();

            for (int i = 0; i < n - 1; i++)
            {
                if (matrix[i].Length == matrix[i + 1].Length)
                {
                    for (int j = 0; j < matrix[i].Length; j++)
                    {
                        matrix[i][j] *= 2;
                        matrix[i + 1][j] *= 2;
                    }
                }
                else
                {
                    for (int j = 0; j < matrix[i].Length; j++)
                    {
                        matrix[i][j] /= 2;
                    }
                    for (int j = 0; j < matrix[i + 1].Length; j++)
                    {
                        matrix[i + 1][j] /= 2;
                    }
                }
            }

            string[] command = Console.ReadLine().Split(' ').ToArray();

            while (command[0] != "End")
            {
                int rows = int.Parse(command[1]);
                int cols = int.Parse(command[2]);
                int value = int.Parse(command[3]);

                if (rows >= 0 && rows < n && cols >= 0 && cols < matrix[rows].Length)
                {
                    if (command[0] == "Add")
                        matrix[rows][cols] += value;

                    else
                        matrix[rows][cols] -= value;
                }

                command = Console.ReadLine().Split(' ').ToArray();
            }

            for (int i = 0; i < n; i++)
                Console.WriteLine(String.Join(" ", matrix[i]));

        }
    }
}
