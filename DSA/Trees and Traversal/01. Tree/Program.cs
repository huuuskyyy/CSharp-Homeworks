using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;


class Program
{
    static void Main()
    {

        Node<int> root = new Node<int>(5);
        Tree<int> tree = new Tree<int>(root);

        tree.Add(new Node<int>(7));
        //tree.Add(new Node<int>(4));
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

    }

    public class Node<T>
    {
        private Node<T> leftChild;
        private Node<T> rightChild;
        private T nodeValue;

        public Node(T nodeValue)
        {
            this.nodeValue = nodeValue;
        }

        public T Value
        {
            get
            {
                return this.nodeValue;
            }

            set
            {
                this.nodeValue = value;
            }
        }

        public Node<T> LeftChild
        {
            get
            {
                return this.leftChild;
            }

            set
            {
                this.leftChild = value;
            }
        }

        public Node<T> RightChild
        {
            get
            {
                return this.rightChild;
            }

            set
            {
                this.rightChild = value;
            }
        }

        public bool HasChildren()
        {
            if (this.rightChild != null || this.leftChild != null)
            {
                return true;
            }

            return false;
        }
    }

    public class Tree<T> where T : IComparable<T>
    {
        private Node<T> root;

        public Tree(Node<T> root)
        {
            this.root = root;
        }

        public Node<T> Root
        {
            get
            {
                return this.root;
            }

            set
            {
                this.root = value;
            }
        }

        public void Add(Node<T> element)
        {
            if (this.root == null)
            {
                this.root = element;
            }
            else
            {
                Node<T> current = this.root;

                while (true)
                {
                    if (element.Value.CompareTo(current.Value) > 0)
                    {
                        if (current.RightChild != null)
                        {
                            current = current.RightChild;
                        }
                        else
                        {
                            current.RightChild = element;
                            break;
                        }
                    }
                    else
                    {
                        if (current.LeftChild != null)
                        {
                            current = current.LeftChild;
                        }
                        else
                        {
                            current.LeftChild = element;
                            break;
                        }
                    }
                }


            }
        }

        public void Print()
        {
            Stack<Node<T>> stack = new Stack<Node<T>>();
            int level = 1;
            stack.Push(this.root);

            PrintChildren(stack, level);

        }

        public void PrintChildren(Stack<Node<T>> stack, int level)
        {
            Node<T> current = stack.Pop();
            level += 3;

            if (current.RightChild != null)
            {
                stack.Push(current.RightChild);
                PrintChildren(stack, level);
            }
            Console.WriteLine(new string(' ', level) + current.Value);
            if (current.LeftChild != null)
            {
                stack.Push(current.LeftChild);
                PrintChildren(stack, level);
            }


        }

        public List<List<Node<T>>> FindAllPaths(Tree<T> tree)
        {
            Node<T> root = tree.Root;
            List<List<Node<T>>> paths = new List<List<Node<T>>>();
            bool hasChild = true;

            paths.Add(new List<Node<T>>() { root });

            if (root.LeftChild != null)
            {
                paths[0].Insert(0, root.LeftChild);
            }

            if (root.RightChild != null)
            {
                paths[0].Add(root.RightChild);
            }

            while (hasChild)
            {
                hasChild = false;

                for (int i = 0; i < paths.Count; i++)
                {
                    List<Node<T>> currentPath = paths[i];
                    Node<T> leftChild = currentPath[0];
                    Node<T> rightChild = currentPath[currentPath.Count - 1];

                    if (leftChild.HasChildren() || rightChild.HasChildren())
                    {
                        hasChild = true;
                        AddNewPaths(ref paths, i, leftChild);
                    }
                    else
                    {
                        continue;
                    }
                    //AddNewPaths(paths,leftChild, rightChild);
                }

            }
            return paths;

        }

        public void AddNewPaths(ref List<List<Node<T>>> paths, int pathPosition, Node<T> child)
        {
            if (child.LeftChild != null && child.RightChild != null)
            {
                paths.Add(new List<Node<T>>() { child.LeftChild, child, child.RightChild });
            }
        }

        public void FindLongestPath()
        {
            Queue<Node<T>> stack = new Queue<Node<T>>();
            int level = 0;
            int max = 0;
            List<List<T>> paths = new List<List<T>>();
            stack.Enqueue(this.root);

            int longestPath = FindLongest(stack, level, ref max, ref paths);

            Console.WriteLine("LONGEST PATH " + (max + 1));
        }

        private int FindLongest(Queue<Node<T>> stack, int level, ref int max, ref List<List<T>> paths)
        {
            Node<T> current = stack.Dequeue();
            int currentLongestLeft = 0;
            int currentLongestRight = 0;
            paths.Add(new List<T>() { current.Value });


            if (current.RightChild != null)
            {
                currentLongestRight++;
                stack.Enqueue(current.RightChild);
                int path = FindLongest(stack, level, ref max, ref  paths);
                currentLongestRight += path;
            }

            if (current.LeftChild != null)
            {
                currentLongestLeft++;
                stack.Enqueue(current.LeftChild);
                int path = FindLongest(stack, level, ref max, ref paths);
                currentLongestLeft += path;
            }

            if (currentLongestRight + currentLongestLeft >= max)
            {
                max = currentLongestRight + currentLongestLeft;
            }

            return currentLongestRight > currentLongestLeft ? currentLongestRight : currentLongestLeft;
        }
    }
}

