namespace Demo
{
    using System;
    using System.Linq;
    using System.Text;
    using Tree;

    class Program
    {
        static void Main(string[] args)
        {
            //var tree = new Tree<int>(1, 
            //                new Tree<int>(2, 
            //                    new Tree<int>(5, 
            //                        new Tree<int>(8)),
            //                    new Tree<int>(6)),
            //                new Tree<int>(3, 
            //                    new Tree<int>(7)),
            //                new Tree<int>(4));


            //Console.WriteLine(tree.AsString());

            string[] input = new string[]
               {
                "7 19", "7 21", "7 14", "19 1", "19 12", "19 31", "14 23", "14 6"
               };

            var tree = new IntegerTreeFactory().CreateTreeFromStrings(input);

            Console.WriteLine(tree.AsString());

           //Console.WriteLine(String.Join(" ", tree.GetInternalKeys()));

            //Console.WriteLine(String.Join(" ", tree.GetLongestPath()));

            Console.WriteLine(String.Join("\n", tree.GetPathsWithGivenSum(28)
                .Select(n => String.Join(" ", n))));
        }
    }
}
