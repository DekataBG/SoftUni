﻿using System;

namespace _02._Generic_Box_of_Integer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Box<int> box = new Box<int>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
                box.Add(int.Parse(Console.ReadLine()));

            Console.WriteLine(box.ToString());       
        }
    }
}
