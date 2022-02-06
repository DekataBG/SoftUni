using System;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            MyLinkedList<int> myList = new MyLinkedList<int>();
            myList.AddFirst(3);
            myList.AddFirst(2);
            myList.AddFirst(1);
            myList.AddLast(4);
            myList.AddLast(5);
            myList.AddLast(6);
            myList.RemoveFirst();
            myList.RemoveLast();

            myList.ForEach(x => Console.Write(x + " "));
            Console.WriteLine();

            myList.Reverse();
            myList.ForEach(x => Console.Write(x + " "));

            myList.Reverse();
        }
    }
}
