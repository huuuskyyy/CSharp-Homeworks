using System;
using System.Collections.Generic;
using System.Text;

namespace Generic_Lists
{
        public class GenericList<T> where T : IComparable<T>
        {
            //an array, which we will use for our generic list base
            private T[] genericList;
            private int count = 0;

            //generic list must be declared with his capacity
            public GenericList(int capacity)
            {
                this.genericList = new T[capacity]; ;

            }

            //implementing indexer in order to access elements by their index
            public T this[int index]
            {
                get { return this.genericList[index]; }
                set { this.genericList[index] = value; }
            }

            //can display our list capacity(the whole capacity not only the written elements)
            public int Capacity
            {
                get { return genericList.Length; }
            }

            //method for adding elements
            public void Add(T item)
            {
                //the list will grow if there's no space for the next element
                if (genericList.Length == count)
                {
                    AutoGrow();
                }
                genericList[count] = item;
                count++;
            }

            //method for removing element at specific position
            public void Remove(int position)
            {
                //exception if the position is out of range
                if (position < 0 || position > count)
                {
                    throw new ArgumentOutOfRangeException("The position is out of array's range");
                }

                //rewrite the array in a new array without the new element in the defined position
                T[] tempArr = (T[])genericList.Clone();
                genericList = new T[tempArr.Length - 1];
                Array.Copy(tempArr, 0, genericList, 0, position);
                Array.Copy(tempArr, position + 1, genericList, position + 1, genericList.Length - position + 1);
                count--;

            }

            //insert element in specific position, works similar way to Remove method
            public void Insert(T item, int position)
            {
                if (position < 0 || position > count)
                {
                    throw new ArgumentOutOfRangeException("The position is out of array's range");
                }
                if (genericList.Length == count)
                {
                    AutoGrow();
                }

                T[] tempArr = (T[])genericList.Clone();
                genericList = new T[tempArr.Length + 1];
                Array.Copy(tempArr, 0, genericList, 0, position);
                genericList[position] = item;
                Array.Copy(tempArr, position + 1, genericList, position + 1, genericList.Length - position + 1);
                count++;

            }

            //clear the content of the whole list
            public void Clear()
            {
                int length = genericList.Length;
                genericList = new T[length];

            }

            //get the position of specific element
            public int GetValue(T item)
            {
                int valueIndex = Array.IndexOf(genericList, item);
                return valueIndex;
            }

            public override string ToString()
            {
                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < count; i++)
                {
                    builder.Append(genericList[i] + "\n");
                }

                string result = builder.ToString();
                return result;
            }

            //method for expanding the array to a bigger array
            public void AutoGrow()
            {
                T[] temp = (T[])genericList.Clone();
                genericList = new T[count * 2];

                for (int i = 0; i < count; i++)
                {
                    genericList[i] = temp[i];
                }
            }

            //finding the smallest element
            public T Min()
            {
                int position = 0;

                for (int i = 1; i < count; i++)
                {
                    if (genericList[i].CompareTo(genericList[position]) < 0)
                    {
                        position = i;
                    }
                }

                return genericList[position];

            }

            //finding the biggest element
            public T Max()
            {
                int position = 0;

                for (int i = 1; i < count; i++)
                {
                    if (genericList[i].CompareTo(genericList[position]) > 0)
                    {
                        position = i;
                    }
                }

                return genericList[position];

            }

        }
}
