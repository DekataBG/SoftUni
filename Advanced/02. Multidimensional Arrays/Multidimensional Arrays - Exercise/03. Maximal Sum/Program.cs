using System;
using System.Linq;

namespace _03._Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();

            var matrix = new int[dimensions[0], dimensions[1]];

            for (int rows = 0; rows < dimensions[0]; rows++)
            {

                var numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();


                for (int cols = 0; cols < dimensions[1]; cols++)
                {

                    matrix[rows, cols] = numbers[cols];
                }
            }

            var bestSum = int.MinValue;
            var bestMatrix = new int[3, 3];


            for (int rows = 0; rows < matrix.GetLength(0) - 2; rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1) - 2; cols++)
                {

                    var tempMatrix = new int[3, 3];

                    for (int tempr = 0; tempr < tempMatrix.GetLength(0); tempr++)
                    {
                        for (int tempc = 0; tempc < tempMatrix.GetLength(1); tempc++)
                        {
                            tempMatrix[tempr, tempc] = matrix[rows + tempr, cols + tempc];
                        }
                    }

                    var sum = 0;


                    foreach (var item in tempMatrix)
                    {
                        sum += item;
                    }

                    if (sum > bestSum)
                    {

                        bestSum = sum;
                        bestMatrix = tempMatrix;

                    }

                }


            }
            Console.WriteLine("Sum = {0}", bestSum);
            for (int r = 0; r < bestMatrix.GetLength(0); r++)
            {
                for (int c = 0; c < bestMatrix.GetLength(1); c++)
                {
                    Console.Write(bestMatrix[r, c] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
