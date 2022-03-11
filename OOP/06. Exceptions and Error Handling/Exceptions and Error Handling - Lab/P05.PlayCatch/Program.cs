using System;
using System.Linq;

namespace P05.PlayCatch
{
    class Program
    {
        static void Main(string[] args)
        {
            var exceptions = 0;
            var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            while (exceptions < 3)
            {
                try
                {
                    var command = Console.ReadLine().Split();

                    var index = int.Parse(command[1]);

                    if (command[0] == "Replace")
                    {
                        arr[index] = int.Parse(command[2]);
                    }
                    else if(command[0] == "Print")
                    {
                        ShowNewArray(index, int.Parse(command[2]), arr);
                    }
                    else
                    {
                        Console.WriteLine(arr[index]);
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("The variable is not in the correct format!");
                    exceptions++;
                }
                catch(IndexOutOfRangeException)
                {
                    Console.WriteLine("The index does not exist!");
                    exceptions++;
                }

            }

            Console.WriteLine(string.Join(", ", arr));
        }

        static void ShowNewArray(int start, int end, int[] arr)
        {
            var newArr = new int[end - start + 1];

            for (int i = 0; i < newArr.Length; i++)
            {
                newArr[i] = arr[i + start];
            }

            Console.WriteLine(String.Join(", ", newArr));
        }
    }
    
}
