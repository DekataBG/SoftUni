using System;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(String.Join(" ", Sort(Console.ReadLine().Split().Select(int.Parse).ToArray())));
        }

        static int[] Merge(int[] arr1, int[] arr2)
        {
            var newArr = new List<int>();
            int rightUsed = 0, leftUsed = 0;

            if (arr1.Length == 0)
            {
                newArr = arr2.ToList();
                return newArr.ToArray();
            }
            if (arr2.Length == 0)
            {
                newArr = arr1.ToList();
                return newArr.ToArray();
            }

            // 1 4     2 3
            for (int i = leftUsed; i < arr1.Length; i++)
            {
                for (int j = rightUsed; j < arr2.Length; j++)
                {
                    if (arr2[j] <= arr1[i])
                    {
                        newArr.Add(arr2[j]);
                        rightUsed++;
                    }
                    else
                    {
                        newArr.Add(arr1[i]);
                        leftUsed++;
                        break;
                    }
                }
            }

            for (int i = leftUsed; i < arr1.Length; i++)
                newArr.Add(arr1[i]);
            for (int i = rightUsed; i < arr2.Length; i++)
                newArr.Add(arr2[i]);

            return newArr.ToArray();
        }

        static int[] Sort(int[] arr)
        {
            var arr1 = new int[arr.Length / 2 + arr.Length % 2];
            var arr2 = new int[arr.Length / 2];

            for (int i = 0; i < arr1.Length; i++)
                arr1[i] = arr[i];
            for (int i = 0; i < arr2.Length; i++)
                arr2[i] = arr[i + arr1.Length];

            if (arr.Length > 1)
            {
                arr1 = Sort(arr1);
                arr2 = Sort(arr2);
            }

            return Merge(arr1, arr2);
        }
    }
}
