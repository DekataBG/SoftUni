using System;
using System.Linq;

namespace _02._SiM
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] n = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            string[][] matrix = new string[n[0]][];
            int ctr = 0;

            for (int i = 0; i < n[0]; i++)
                matrix[i] = Console.ReadLine().Split(' ').ToArray();

            for (int i = 0; i < n[0] - 1; i++)
            {
                for (int j = 0; j < n[1] - 1; j++)
                {
                    string main = matrix[i][j];
                    string topRight = matrix[i][j + 1];
                    string downLeft = matrix[i + 1][j];
                    string downRight = matrix[i + 1][j + 1];

                    if (matrix[i][j] == matrix[i][j + 1] &&
                        matrix[i][j] == matrix[i + 1][j] &&
                            matrix[i][j] == matrix[i + 1][j + 1])
                        ctr++;

                }
            }
            Console.WriteLine(ctr);
        }
    }
}
