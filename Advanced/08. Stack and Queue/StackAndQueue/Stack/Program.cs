using System;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new MyStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);
            Console.WriteLine(stack.Peek());
            Console.WriteLine(stack.Pop());
            stack.ForEach(s => Console.WriteLine(s));
        }
    }
}
