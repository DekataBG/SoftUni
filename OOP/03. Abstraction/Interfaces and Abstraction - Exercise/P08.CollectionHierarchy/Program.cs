using System;
using System.Collections.Generic;

namespace P08.CollectionHierarchy
{
    public class Program
    {
        static void Main(string[] args)
        {
            var addableLists = new List<IAddable<string>>();
            var removableLists = new List<IRemovable<string>>();

            var addCollection = new AddCollection<string>();
            var addRemoveCollection = new AddRemoveCollection<string>();
            var myList = new MyList<string>();


            addableLists.Add(addCollection);
            addableLists.Add(addRemoveCollection);
            addableLists.Add(myList);

            removableLists.Add(addRemoveCollection);
            removableLists.Add(myList);


            var words = Console.ReadLine().Split();
            var n = int.Parse(Console.ReadLine());

            foreach (var addable in addableLists)
                PrintAddResult(words, addable);

            foreach (var removable in removableLists)
                PrintRemoveResult(n, removable);

        }

        static void PrintAddResult(string[] words, IAddable<string> addable)
        {
            foreach (var word in words)
                Console.Write(addable.Add(word) + " ");

            Console.WriteLine();
        }

        static void PrintRemoveResult(int n, IRemovable<string> removable)
        {
            for (int i = 0; i < n; i++)
                Console.Write(removable.Remove() + " ");

            Console.WriteLine();
        }
    }
}
