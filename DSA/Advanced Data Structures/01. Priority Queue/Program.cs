using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    public class PriorityQueue<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        private T[] body;
        private const int InitialLength = 16;
        private int position = 0;

        public PriorityQueue()
        {
            this.body = new T[InitialLength];
        }

        public void Add(T element)
        {
            if (this.position == this.body.Length - 1)
            {
                Resize();
            }

            this.body[position] = element;

            if (this.position == 0)
            {
                this.position++;
                return;
            }

            int parentPosition = (this.position - 1) / 2;
            T parent = this.body[parentPosition];

            if (parent.CompareTo(element) > -1)
            {
                this.position++;
                return;
            }

            int elementPosition = this.position;
            T elementKeeper;

            while (parent.CompareTo(element) < 0)
            {
                elementKeeper = this.body[elementPosition];
                this.body[elementPosition] = this.body[parentPosition];
                this.body[parentPosition] = elementKeeper;

                elementPosition = parentPosition;
                parentPosition = (elementPosition - 1) / 2;

                if (elementPosition == 0)
                {
                    this.position++;
                    return;
                }

                parent = this.body[parentPosition];
            }

            this.position++;
        }

        public T Get()
        {
            if (this.position == 0)
            {
                return default(T);
            }

            T elementToGet = this.body[0];

            RearangeBody();

            return elementToGet;
        }

        private void RearangeBody()
        {
            T currentElement = this.body[position - 1];
            this.body[position - 1] = default(T);
            this.body[0] = currentElement;

            int parentPosition = 0;
            int firstChildPosition = 2 * parentPosition + 1;
            int secondChildPosition = 2 * parentPosition + 2;
            T firstChild = default(T);
            T secondChild = default(T);

            GetChildren(ref firstChild, ref secondChild, firstChildPosition, secondChildPosition);

            while (currentElement.CompareTo(firstChild) < 0 || currentElement.CompareTo(secondChild) < 0
                 || this.position < firstChildPosition || this.position < secondChildPosition)
            {
                // Console.WriteLine("first " + firstChildPosition + " second " + secondChildPosition + " current " + currentElement);

                if (firstChild.CompareTo(secondChild) > 0)
                {
                    T elementKeeper = this.body[parentPosition];
                    this.body[parentPosition] = this.body[firstChildPosition];
                    this.body[firstChildPosition] = elementKeeper;
                    parentPosition = firstChildPosition;
                }
                else
                {
                    T elementKeeper = this.body[parentPosition];
                    this.body[parentPosition] = this.body[secondChildPosition];
                    this.body[secondChildPosition] = elementKeeper;
                    parentPosition = secondChildPosition;
                }

                firstChildPosition = 2 * parentPosition + 1;
                secondChildPosition = 2 * parentPosition + 2;
                GetChildren(ref firstChild, ref secondChild, firstChildPosition, secondChildPosition);
            }

        }

        private void GetChildren(ref T first, ref T second, int firstPosition, int secondPosition)
        {
            if (this.position >= firstPosition)
            {
                first = this.body[firstPosition];
            }

            if (this.position >= secondPosition)
            {
                second = this.body[secondPosition];
            }
        }

        private void Resize()
        {
            var oldBodyCopy = this.body;
            this.body = new T[this.position * 2];
            this.position = 0;

            foreach (var item in oldBodyCopy)
            {
                this.Add(item);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.body)
            {
                yield return item;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }

    static void Main()
    {
        PriorityQueue<int> testQ = new PriorityQueue<int>();

        testQ.Add(4);
        testQ.Add(2);
        testQ.Add(6);
        testQ.Add(3);
        testQ.Add(8);
        testQ.Add(14);
        testQ.Add(5);
        testQ.Add(4);
        testQ.Add(4);
        testQ.Add(2);
        testQ.Add(44);
        testQ.Add(11);

        Console.WriteLine("Initial Q");
        foreach (var item in testQ)
        {
            Console.Write(item+" ");
        }
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Get element of the Q");
        Console.WriteLine(testQ.Get());
        Console.WriteLine();
        Console.WriteLine("Again all Q elements");
        foreach (var item in testQ)
        {
            Console.Write(item + " ");
        }

    }
}
