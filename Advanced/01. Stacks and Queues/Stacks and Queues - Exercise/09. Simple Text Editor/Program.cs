using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var stack = new Stack<string>();
            string word = "";
            stack.Push(word);

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(' ').ToArray();

                switch (command[0])
                {
                    case "1":
                        word += command[1];
                        stack.Push(word);
                        break;
                    case "2":
                        string newWord = "";
                        for (int j = 0; j < word.Length - int.Parse(command[1]); j++)
                            newWord += word[j];
                        word = newWord;
                        stack.Push(newWord);
                        break;
                    case "3":
                        Console.WriteLine(stack.Peek()[int.Parse(command[1]) - 1]);
                        break;
                    case "4":
                        stack.Pop();
                        word = stack.Peek();
                        break;
                }
            }
        }
    }
}
