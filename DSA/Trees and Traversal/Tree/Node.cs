using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public class Node<T>
    {
        private Node<T> leftChild;
        private Node<T> rightChild;
        private int nodeValue;
        public Node(int nodeValue)
        {
            this.nodeValue = nodeValue;
        }
        public int Value
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
        public int Sum()
        {
            int sum = this.nodeValue;
            Stack<Node<T>> nodes = new Stack<Node<T>>();

            if (this.leftChild != null)
            {
                nodes.Push(this.leftChild);
            }

            if (this.rightChild != null)
            {
                nodes.Push(this.rightChild);
            }

            while (nodes.Count > 0)
            {
                Node<T> currentNode = nodes.Pop();

                sum += currentNode.Value;

                if (currentNode.leftChild != null)
                {
                    nodes.Push(currentNode.leftChild);
                }

                if (currentNode.rightChild != null)
                {
                    nodes.Push(currentNode.rightChild);
                }
            }

            return sum;
        }
    }
}
