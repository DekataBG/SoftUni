using System;
using System.Linq;

namespace _04._Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            string[,] matrix = new string[size[0], size[1]];

            for (int i = 0; i < size[0]; i++)
            {
                string[] input = Console.ReadLine().Split(' ').ToArray();
                for (int j = 0; j < size[1]; j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            string[] command = Console.ReadLine().Split(' ');

            while (command[0] != "END")
            {
                if (!CheckValidity(command, matrix.GetLength(0), matrix.GetLength(1)))
                    Console.WriteLine("Invalid input!");
                else
                {
                    string temp = matrix[int.Parse(command[1]), int.Parse(command[2])];
                    matrix[int.Parse(command[1]), int.Parse(command[2])] =
                        matrix[int.Parse(command[3]), int.Parse(command[4])];
                    matrix[int.Parse(command[3]), int.Parse(command[4])] = temp;

                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            Console.Write(matrix[i, j] + " ");
                        }
                        Console.WriteLine();
                    }

                }

                command = Console.ReadLine().Split(' ');
            }
        }

        static bool CheckValidity(string[] command, int rows, int cols)
        {
            if (command.Count() != 5)
                return false;
            if (command[0] != "swap")
                return false;
            if (int.Parse(command[1]) < 0 || int.Parse(command[1]) >= rows)
                return false;
            if (int.Parse(command[3]) < 0 || int.Parse(command[3]) >= rows)
                return false;
            if (int.Parse(command[2]) < 0 || int.Parse(command[2]) >= cols)
                return false;
            if (int.Parse(command[4]) < 0 || int.Parse(command[4]) >= cols)
                return false;

            return true;
        }
    }
}
