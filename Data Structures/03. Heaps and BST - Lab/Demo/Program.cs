using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using _01.BinaryTree;
using _02.BinarySearchTree;
using _03.MaxHeap;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new BinaryTree<int>(
                        17,
                        new BinaryTree<int>(
                            9,
                            new BinaryTree<int>(3, null, null),
                            new BinaryTree<int>(11, null, null)
                        ),
                        new BinaryTree<int>(
                            25,
                            new BinaryTree<int>(20, null, null),
                            new BinaryTree<int>(31, null, null)
                        )
        );

            Console.WriteLine(String.Join(" ",
                tree.InOrder().Select(t => t.Value)));


        }
    }
}