using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using Tree;

class Program
{
    static void Main()
    {
        Node<int> root = new Node<int>(5);
        Tree<int> tree = new Tree<int>(root);

        tree.Add(new Node<int>(7));
        tree.Add(new Node<int>(1));
        tree.Add(new Node<int>(2));
        tree.Add(new Node<int>(9));
        tree.Add(new Node<int>(4));
        tree.Add(new Node<int>(8));
        tree.Add(new Node<int>(0));
        tree.Add(new Node<int>(11));
        tree.Add(new Node<int>(-3));
        tree.Add(new Node<int>(-6));
        tree.Add(new Node<int>(-5));
        tree.Add(new Node<int>(-8));
        tree.Add(new Node<int>(5));
        tree.Add(new Node<int>(12));

        tree.Print();
        tree.FindLongestPath();
        //var allPaths = tree.FindAllPaths();
        //Console.WriteLine(allPaths.Count);

        //foreach (var path in allPaths)
        //{
        //    foreach (var item in path)
        //    {
        //        Console.Write(item.Value + " ");
        //    }

        //    Console.WriteLine();
        //}

    }

}
