using System;
using System.Collections.Generic;

namespace _08._Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            if (Valid(command))
            {
                Console.WriteLine("YES");
            }
            else
                Console.WriteLine("NO");
        }
        //{}{[]}
        static bool Valid(string command)
        {
            var stack = new Stack<char>();

            for (int i = 0; i < command.Length; i++)
            {
                switch (command[i])
                {
                    case '{':
                    case '[':
                    case '(':
                        stack.Push(command[i]);
                        break;
                    case '}':
                        if (stack.Count == 0)
                            return false;
                        if (stack.Pop() != '{')
                            return false;
                        break;
                    case ']':
                        if (stack.Count == 0)
                            return false;
                        if (stack.Pop() != '[')
                            return false;
                        break;
                    case ')':
                        if (stack.Count == 0)
                            return false;
                        if (stack.Pop() != '(')
                            return false;
                        break;
                }
            }
            return true;
        }
    }
}
