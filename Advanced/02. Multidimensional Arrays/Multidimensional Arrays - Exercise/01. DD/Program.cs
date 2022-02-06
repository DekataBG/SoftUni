using System;
using System.Linq;

namespace _01._DD
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int pd = 0, sd = 0;
            int[][] matrix = new int[n][];
            for (int i = 0; i < n; i++)
                matrix[i] = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();


            for (int i = 0; i < n; i++)
                pd += matrix[i][i];

            for (int i = 0; i < n; i++)
                sd += matrix[i][n - 1 - i];

            Console.WriteLine(Math.Abs(pd - sd));
        }
    }
}
