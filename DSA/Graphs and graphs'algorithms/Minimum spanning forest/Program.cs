using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    public class Node : IEnumerable<Node>
    {
        private string id;
        private List<Node> children;
        private Dictionary<string, int> distances;

        public Node(string id)
        {
            this.id = id;
            this.children = new List<Node>();
            distances = new Dictionary<string, int>();
        }

        public string Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        public void Add(Node nodeToAdd,int distance)
        {
            this.AddLinkedNode(nodeToAdd);
            this.AddDistanceToChild(nodeToAdd.Id, distance);
        }

        private void AddLinkedNode(Node nodeToAdd)
        {
            this.children.Add(nodeToAdd);
        }

        private void AddDistanceToChild(string id, int distance)
        {
            this.distances.Add(id, distance);
        }

        public int GetDistance(string id)
        {
            return this.distances[id];
        }

        public IEnumerator<Node> GetEnumerator()
        {
            foreach (var child in this.children)
            {
                yield return child;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }

    public class Graph : IEnumerable<Node>
    {
         private Dictionary<string, Node> nodes;

         public Graph()
        {
            this.nodes = new Dictionary<string, Node>();
        }

        public bool Search(string id)
        {
            return this.nodes.ContainsKey(id);
        }

        public void Add(Node node)
        {
            this.nodes.Add(node.Id, node);
        }

        public IEnumerator<Node> GetEnumerator()
        {
            foreach (var child in this.nodes)
            {
                yield return child.Value;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class Tree : IEnumerable<Node>
    {
        private Node root;
        private Dictionary<string, Node> nodes;

        public Tree(Node root)
        {
            this.root = root;
            this.nodes = new Dictionary<string, Node>();
            nodes.Add(this.root.Id, this.root);
        }

        public bool Search(string id)
        {
            return this.nodes.ContainsKey(id);
        }

        public Node GetChild(string id)
        {
            return this.nodes[id];
        }

        public void Add(Node node)
        {
            this.nodes.Add(node.Id, node);
        }

        public IEnumerator<Node> GetEnumerator()
        {
            foreach (var child in this.nodes)
            {
                yield return child.Value;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class Link : IComparable
    {
        private Node parent;
        private Node child;
        private int distance;

        public Link(Node parent, Node child, int distance)
        {
            this.parent = parent;
            this.child = child;
            this.distance = distance;

        }

        public Node Parent
        {
            get
            {
                return this.parent;
            }
            set
            {
                this.parent = value;
            }
        }

        public Node Child
        {
            get
            {
                return this.child;
            }
            set
            {
                this.child = value;
            }
        }

        public int Distance
        {
            get
            {
                return this.distance;
            }
            set
            {
                this.distance = value;
            }
        }

        public int CompareTo(Object obj)
        {
            return this.distance.CompareTo((obj as Link).Distance);
        }
    }

    public class PriorityQueue<T> where T : IComparable
    {
        private T[] heap;
        private int index;

        public int Count
        {
            get
            {
                return this.index - 1;
            }
        }

        public PriorityQueue()
        {
            this.heap = new T[16];
            this.index = 1;
        }

        public void Enqueue(T element)
        {
            if (this.index >= this.heap.Length - 1)
            {
                IncreaseArray();
            }

            this.heap[this.index] = element;

            int childIndex = this.index;
            int parentIndex = childIndex / 2;
            this.index++;

            while (parentIndex >= 1 && this.heap[childIndex].CompareTo(this.heap[parentIndex]) < 0)
            {
                T swapValue = this.heap[parentIndex];
                this.heap[parentIndex] = this.heap[childIndex];
                this.heap[childIndex] = swapValue;

                childIndex = parentIndex;
                parentIndex = childIndex / 2;
            }
        }

        public T Dequeue()
        {
            T result = this.heap[1];

            this.heap[1] = this.heap[this.Count];
            this.index--;

            int rootIndex = 1;

            int minChild;

            while (true)
            {
                int leftChildIndex = rootIndex * 2;
                int rightChildIndex = rootIndex * 2 + 1;

                if (leftChildIndex > this.index)
                {
                    break;
                }
                else if (rightChildIndex > this.index)
                {
                    minChild = leftChildIndex;
                }
                else
                {
                    if (this.heap[leftChildIndex].CompareTo(this.heap[rightChildIndex]) < 0)
                    {
                        minChild = leftChildIndex;
                    }
                    else
                    {
                        minChild = rightChildIndex;
                    }
                }

                if (this.heap[minChild].CompareTo(this.heap[rootIndex]) < 0)
                {
                    T swapValue = this.heap[rootIndex];
                    this.heap[rootIndex] = this.heap[minChild];
                    this.heap[minChild] = swapValue;

                    rootIndex = minChild;
                }
                else
                {
                    break;
                }
            }

            return result;
        }

        public T Peek()
        {
            return this.heap[1];
        }

        private void IncreaseArray()
        {
            T[] copiedHeap = new T[this.heap.Length * 2];

            for (int i = 0; i < this.heap.Length; i++)
            {
                copiedHeap[i] = this.heap[i];
            }

            this.heap = copiedHeap;
        }
    }

    static void Main()
    {
        Node a = new Node("a");
        Node b = new Node("b");
        Node c = new Node("c");
        Node d = new Node("d");
        Node e = new Node("e");
        Node f = new Node("f");

        Graph graph = new Graph();

        a.Add(b, 4);
        a.Add(c, 5);
        a.Add(d, 9);
        graph.Add(a);

        b.Add(a, 4);
        b.Add(d, 2);
        graph.Add(b);

        c.Add(a, 5);
        c.Add(d, 20);
        c.Add(e, 7);
        graph.Add(c);

        d.Add(b, 2);
        d.Add(c, 20);
        d.Add(a, 9);
        d.Add(e, 8);
        graph.Add(d);

        e.Add(c, 7);
        e.Add(d, 8);
        e.Add(f, 12);
        graph.Add(e);

        f.Add(e, 12);
        graph.Add(f);

        PriorityQueue<Link> q = new PriorityQueue<Link>();
        Tree tree = new Tree(new Node("a"));

        foreach(var child in a)
        {
            Link currentLink = new Link(a, child, a.GetDistance(child.Id));
            q.Enqueue(currentLink);
        }

        while(q.Count > 0)
        {
            Link currentLink = q.Dequeue();

            if(tree.Search(currentLink.Child.Id))
            {
                continue;
            }

            tree.Add(new Node(currentLink.Child.Id));
            //Console.WriteLine(currentLink.Child.Id+" distance => "+ currentLink.Distance+" parent id => "+currentLink.Parent.Id);
            tree.GetChild(currentLink.Parent.Id).Add(currentLink.Child, currentLink.Distance);
           //5 Console.WriteLine("pass");

            foreach (var linkage in currentLink.Child)
            {
                if(!tree.Search(linkage.Id))
                {
                    Link link = new Link(currentLink.Child, linkage, currentLink.Child.GetDistance(linkage.Id));
                    q.Enqueue(link);
                }
                
            }
        }

        int shortestDistance = 0;

        foreach(var child in tree)
        {
            foreach(var subChild in child)
            {
                shortestDistance += child.GetDistance(subChild.Id);
            }
        }

        Console.WriteLine(shortestDistance);
    }
}
