using System;

namespace List
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new MyList<int>();

            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Add(6);

            foreach (var item in list.Arr)
                Console.Write(item + " ");

            list.RemoveAt(1);
            Console.WriteLine();
            foreach (var item in list.Arr)
                Console.Write(item + " ");
            Console.WriteLine();

            Console.WriteLine(list.Contains(4));

            list.Swap(0, list.Count - 1);
            foreach (var item in list.Arr)
                Console.Write(item + " ");
            Console.WriteLine();
        }
    }
}
