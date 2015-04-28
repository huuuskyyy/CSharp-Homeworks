using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
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
            if(this.root == null)
            {
                this.root = element;
            }
            else
            {
                Node<T> current = this.root;
                
                while(true)
                {
                    if(element.Value.CompareTo(current.Value) > 0)
                    {
                        if(current.RightChild != null)
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
                       if(current.LeftChild != null)
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
            level+=3;
            
            if(current.RightChild != null)
            {
                stack.Push(current.RightChild);
                PrintChildren(stack, level);
            }
            Console.WriteLine(new string(' ', level)+current.Value);
            if(current.LeftChild != null)
            {
                stack.Push(current.LeftChild);
                PrintChildren(stack, level);
            }
        }
        
        public List<Tree<T>> FindSubtreesWithSum(int sum)
        {
            List<Tree<T>> subtrees = new List<Tree<T>>();
            Node<T> leftStartTree, rightStartTree;
            
            if(this.root.LeftChild != null)
            {
                leftStartTree = this.root.LeftChild;
                TraverseSubtreesForSum(leftStartTree, ref subtrees, sum);
            }
            
            if(this.root.RightChild != null)
            {
                rightStartTree = this.root.RightChild;
                TraverseSubtreesForSum(rightStartTree, ref subtrees, sum);
            }
            
            return subtrees;
        }
        
        public void TraverseSubtreesForSum (Node<T> currentSubtree, ref List<Tree<T>> foundSubtreesWithSum, int sumToLook)
        {
            if(currentSubtree.Sum() == sumToLook)
            {
                foundSubtreesWithSum.Add(new Tree<T>(currentSubtree));
            }
            
            if(currentSubtree.LeftChild != null)
            {
               Node<T> leftStartTree = currentSubtree.LeftChild;
                TraverseSubtreesForSum(leftStartTree, ref foundSubtreesWithSum, sumToLook);
            }
            
            if(currentSubtree.RightChild != null)
            {
               Node<T> rightStartTree = currentSubtree.RightChild;
                TraverseSubtreesForSum(rightStartTree, ref foundSubtreesWithSum, sumToLook);
            }
            
        }
        
        public List<List<Node<T>>> FindAllPathsWithSum(int sum)
        {
            List<List<Node<T>>> allPaths = this.FindAllPaths();
            List<List<Node<T>>> allPathsWithSum = new List<List<Node<T>>>();
            int currentPathSum = 0;
            
            for(int i = 0; i < allPaths.Count; i++)
            {
                foreach(var item in allPaths[i])
                {
                    currentPathSum += item.Value;
                }
                
                if(currentPathSum == sum)
                {
                    allPathsWithSum.Add(allPaths[i]);
                }
                
                currentPathSum = 0;
            }
            
            return allPathsWithSum;
        }
        
        public List<List<Node<T>>> FindAllPaths()
        {
            Node<T> root = this.root;
            List<List<Node<T>>> paths = new List<List<Node<T>>>();
            bool hasChild = true;
            
            paths.Add(new List<Node<T>>(){root});
            
            if(root.LeftChild != null)
            {
                paths[0].Insert(0,root.LeftChild);
            }
            
            if(root.RightChild != null)
            {
                paths[0].Add(root.RightChild);
            }
            
            while(hasChild)
            {
                hasChild = false;
                
                for(int i = 0; i< paths.Count; i++)
                {
                    List<Node<T>> currentPath = paths[i];
                    Node<T> leftChild = currentPath[0];
                    Node<T> rightChild = currentPath[currentPath.Count-1];
                   
                    if(leftChild.HasChildren() || rightChild.HasChildren())
                    {
                        hasChild = true;
                        AddNewPathsLeft(ref paths, i, leftChild);
                        AddNewPathsRight(ref paths, i, rightChild);
                    }
                }
            }
            
            return paths;
        }
        
        public void AddNewPathsRight(ref List<List<Node<T>>> paths,int pathPosition, Node<T> child)
        {
            if(child.LeftChild != null && child.RightChild != null)
            {
                    var newPath = paths[pathPosition].ToList();
                    newPath.Add(child.RightChild);
                    paths[pathPosition].Add(child.LeftChild);
                    paths.Add(newPath);
                
                List<Node<T>> newSubTree = new List<Node<T>>(){child.LeftChild, child, child.RightChild};
                var isExist = paths.Any(path => path.SequenceEqual(newSubTree));
                
                if(!isExist)
                   {
                       paths.Add(newSubTree);
                   }
            }
            else if(child.LeftChild != null)
            {
                paths[pathPosition].Add(child.LeftChild);
            }
            else if(child.RightChild != null)
            {
                paths[pathPosition].Add(child.RightChild);
            }
        }
        
        public void AddNewPathsLeft(ref List<List<Node<T>>> paths,int pathPosition, Node<T> child)
        {
            if(child.LeftChild != null && child.RightChild != null)
            {
                var newPath = paths[pathPosition].ToList();
                newPath.Insert(0, child.LeftChild);
                paths[pathPosition].Insert(0, child.RightChild);
                paths.Add(newPath);
                
                List<Node<T>> newSubTree = new List<Node<T>>(){child.LeftChild, child, child.RightChild};
                var isExist = paths.Any(path => path.SequenceEqual(newSubTree));
                
                if(!isExist)
                   {
                       paths.Add(newSubTree);
                   }
            }
            else if(child.LeftChild != null)
            {
                paths[pathPosition].Insert(0, child.LeftChild);
            }
            else if(child.RightChild != null)
            {
                paths[pathPosition].Insert(0, child.RightChild);
            }
        }
        
        public void FindLongestPath()
        {
            Queue<Node<T>> stack = new Queue<Node<T>>();
            int level = 0;
            int max = 0;
            List<List<int>> paths = new List<List<int>>();
            stack.Enqueue(this.root);
            
            int longestPath = FindLongest(stack, level,ref max, ref paths);
            
            Console.WriteLine("LONGEST PATH "+(max+1));
        }
        
        private int FindLongest(Queue<Node<T>> stack, int level, ref int max, ref List<List<int>> paths)
        {
            Node<T> current = stack.Dequeue();
            int currentLongestLeft = 0;
            int currentLongestRight = 0;
            paths.Add(new List<int>(){current.Value});
            
            if(current.RightChild != null)
            {
                currentLongestRight++;
                stack.Enqueue(current.RightChild);
                int path = FindLongest(stack, level, ref max, ref  paths);
                currentLongestRight += path;
            }
            
            if(current.LeftChild != null)
            {
                currentLongestLeft++;
                stack.Enqueue(current.LeftChild);
                int path = FindLongest(stack, level, ref max, ref paths);
                currentLongestLeft += path;
            }
            
            if(currentLongestRight + currentLongestLeft >= max)
            {
                max = currentLongestRight + currentLongestLeft;
            }
            
            return currentLongestRight>currentLongestLeft?currentLongestRight:currentLongestLeft;
        }
    }
}

