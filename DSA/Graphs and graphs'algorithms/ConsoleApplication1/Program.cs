using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Program
{
    static void Main()
    {
        PriorityQueue<Edge> q = new PriorityQueue<Edge>();

        string[] initialInputNumbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int totalPoints = int.Parse(initialInputNumbers[0]);
        int totalLinks = int.Parse(initialInputNumbers[1]);
        int totalHospital = int.Parse(initialInputNumbers[2]);

        string[] allHospitals = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        Graph graph = new Graph();

        for (int i = 0; i < totalLinks; i++)
        {
            string[] link = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int firstPointId = int.Parse(link[0]);
            int secondPointId = int.Parse(link[1]);
            int distanceBetweenPoints = int.Parse(link[2]);

            graph.AddLinkage(firstPointId, secondPointId, distanceBetweenPoints);
        }

        for (int i = 0; i < allHospitals.Length; i++)
        {
            int hospitalId = int.Parse(allHospitals[i]);
            graph.GetPoint(hospitalId).IsHospital = true;
        }


        int minPath = Int32.MaxValue;

        for (int i = 0; i < allHospitals.Length; i++)
        {
            int hospitalId = int.Parse(allHospitals[i]);
            Edge startHospital = graph.GetPoint(hospitalId);
            startHospital.DijkstraDistance = 0;
            q.Enqueue(startHospital);
            int currentPath = 0;
            HashSet<int> visited = new HashSet<int>();

            while (q.Count > 0)
            {
                Edge current = q.Dequeue();

                if (visited.Contains(current.Id))
                {
                    continue;
                }

                visited.Add(current.Id);

                KeyValuePair<Edge, int>[] neighbours = graph.GiveNeighbours(current);

                foreach (var neighbour in neighbours)
                {
                    Edge neighbourEdge = neighbour.Key;
                    if (visited.Contains(neighbourEdge.Id))
                    {
                        continue;
                    }
                    int distanceToNeighbourEdge = neighbour.Value;

                    if ((current.DijkstraDistance + distanceToNeighbourEdge) < neighbourEdge.DijkstraDistance)
                    {
                        neighbourEdge.DijkstraDistance = current.DijkstraDistance + distanceToNeighbourEdge;
                        graph.ChangePointDijkstraDistance(neighbourEdge.Id, current.DijkstraDistance + distanceToNeighbourEdge);
                    }

                    if (!visited.Contains(neighbourEdge.Id))
                    {
                        q.Enqueue(neighbourEdge);
                    }


                }

            }

            foreach (var point in graph)
            {
                if (!point.IsHospital)
                {
                    currentPath += point.DijkstraDistance;
                }

                point.DijkstraDistance = Int32.MaxValue;
            }

            if (currentPath < minPath)
            {
                minPath = currentPath;
            }
        }
        // graph.Add(new Edge(1));
        // graph.AddLinkage(1,2,5);
        // graph.AddLinkage(1,4,5);
        // graph.Add(new Edge(3));
        // graph.AddLinkage(3,2,5);
        // graph.AddLinkage(3,6,5);
        // graph.AddLinkage(4,2,5);
        // graph.AddLinkage(5,6,5);

        //graph.Print();
        Console.WriteLine(minPath);

    }

    public class Graph : IEnumerable<Edge>
    {
        private Dictionary<int, Edge> points;

        public Graph()
        {
            this.points = new Dictionary<int, Edge>();
        }

        public KeyValuePair<Edge, int>[] GiveNeighbours(Edge source)
        {
            return source.Links();
        }

        public void Add(Edge edge)
        {
            this.points.Add(edge.Id, edge);
        }

        public void AddLinkage(int targetEdgeId, int linkedEdgeId, int distance)
        {
            if (!points.ContainsKey(targetEdgeId))
            {
                this.Add(new Edge(targetEdgeId));
            }

            if (!points.ContainsKey(linkedEdgeId))
            {
                this.Add(new Edge(linkedEdgeId));
            }

            this.GetPoint(targetEdgeId).Add(this.GetPoint(linkedEdgeId), distance);
            this.GetPoint(linkedEdgeId).Add(this.GetPoint(targetEdgeId), distance);

        }

        public Edge GetPoint(int id)
        {
            return this.points[id];
        }

        public void ChangePointDijkstraDistance(int id, int newDistance)
        {
            this.points[id].DijkstraDistance = newDistance;
        }

        public void Print()
        {
            foreach (var point in this.points)
            {
                Console.Write("Point ID {0} => ", point.Key);
                point.Value.Print();
            }
        }

        public IEnumerator<Edge> GetEnumerator()
        {
            foreach (var item in this.points)
            {
                yield return item.Value;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }

    public class Edge : IComparable
    {
        private int id;
        private Dictionary<int, KeyValuePair<Edge, int>> neighbours;
        private bool isHospital;
        private int dijkstraDistance;

        public Edge(int id)
        {
            this.id = id;
            this.neighbours = new Dictionary<int, KeyValuePair<Edge, int>>();
            this.isHospital = false;
            this.dijkstraDistance = Int32.MaxValue;
        }

        public int Id
        {
            get
            {
                return this.id;
            }
        }

        public bool IsHospital
        {
            get
            {
                return this.isHospital;
            }
            set
            {
                this.isHospital = value;
            }
        }

        public int DijkstraDistance
        {
            get
            {
                return this.dijkstraDistance;
            }
            set
            {
                this.dijkstraDistance = value;
            }
        }

        public void Print()
        {
            Console.Write("{ ");
            foreach (var point in this.neighbours)
            {
                Console.Write(point.Value.Key.Id + " ");
            }
            Console.Write("}");
            Console.Write(" + Lengths " + this.neighbours.Count + " ");
            Console.WriteLine();
        }

        public void Add(Edge edge, int distance)
        {
            if (!this.neighbours.ContainsKey(edge.Id))
            {
                this.neighbours.Add(edge.Id, new KeyValuePair<Edge, int>(edge, distance));
            }
            else
            {
                this.neighbours[edge.Id] = new KeyValuePair<Edge, int>(edge, distance);
            }

        }

        public KeyValuePair<Edge, int>[] Links()
        {
            List<KeyValuePair<Edge, int>> links = new List<KeyValuePair<Edge, int>>();

            foreach (var pair in this.neighbours)
            {
                links.Add(pair.Value);
            }

            return links.ToArray();
        }

        public int CompareTo(Object obj)
        {
            //Edge edgeToCompare = obj as Edge;
            return this.dijkstraDistance.CompareTo((obj as Edge).DijkstraDistance);
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

}



