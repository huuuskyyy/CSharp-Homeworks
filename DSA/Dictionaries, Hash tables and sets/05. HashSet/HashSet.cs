using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HashTable;

namespace HashSet
{
    public class HashSet<T> : IEnumerable<T>
    {
        private HashTable<T, bool> table;

        public HashSet()
        {
            this.table = new HashTable<T, bool>();
        }

        public void Add(T element)
        {
            if (!this.Find(element))
            {
                this.table.Add(element, true);
            }
        }

        public void Remove(T element)
        {
            this.table.Remove(element);
        }

        public bool Find(T element)
        {
            var item = this.table.Find(element);

            if (item == false)
            {
                return false;
            }

            return true;
        }

        public int Count()
        {
            return this.table.Count();
        }

        public void Clear()
        {
            this.table.Clear();
        }

        public void Union(HashSet<T> setToUnite)
        {
            foreach (var item in setToUnite)
            {
                this.Add(item);
            }
        }

        public HashSet<T> Intersect(HashSet<T> setToIntersect)
        {
            HashSet<T> intersectedSet = new HashSet<T>();

            foreach (var item in setToIntersect)
            {
                if (!this.Find(item))
                {
                    intersectedSet.Add(item);
                }
            }

            return intersectedSet;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.table)
            {
                yield return item.Key;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}
