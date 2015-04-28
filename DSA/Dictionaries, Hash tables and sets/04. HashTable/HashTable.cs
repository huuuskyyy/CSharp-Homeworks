using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
        public class HashTable<K, T> : IEnumerable<KeyValuePair<K, T>>
        {
            private LinkedList<KeyValuePair<K, T>>[] table;
            private int count;
            private const int InitialCapacity = 16;

            public HashTable()
            {
                table = new LinkedList<KeyValuePair<K, T>>[InitialCapacity];
                count = 0;
            }

            public LinkedList<KeyValuePair<K, T>> this[int index]
            {
                get
                {
                    return this.table[index];
                }
                set
                {
                    this.table[index] = value;
                }
            }

            public int Count
            {
                get
                {
                    return this.count;
                }
            }

            public int Capacity
            {
                get
                {
                    return this.table.Length;
                }
            }

            public K[] Keys()
            {
                List<K> keys = new List<K>();

                foreach (var list in this.table)
                {
                    if (list != null)
                    {
                        foreach (var pair in list)
                        {
                            if (keys.Contains(pair.Key))
                            {
                                continue;
                            }

                            if (pair.Key != null)
                            {
                                keys.Add(pair.Key);
                            }
                        }
                    }
                }

                return keys.ToArray();
            }

            public void Clear()
            {
                table = new LinkedList<KeyValuePair<K, T>>[InitialCapacity];
            }

            public void Remove(K key)
            {
                var hash = Math.Abs(key.GetHashCode());
                hash %= this.Capacity;

                if (table[hash] == null)
                {
                    return;

                }

                table[hash] = null;

            }

            public T Find(K key)
            {
                var hash = Math.Abs(key.GetHashCode());
                hash %= this.Capacity;

                if (table[hash] == null)
                {
                    return default(T);
                }
                
                if(!table[hash].Any(item => item.Key.Equals(key)))
                {
                    return default(T);
                }

                return table[hash].First(item => item.Key.Equals(key)).Value;
            }

            public T[] FindAll(K key)
            {
                var hash = Math.Abs(key.GetHashCode());
                hash %= this.Capacity;

                if (table[hash] == null)
                {
                    return null;

                }

                var searchedElement = table[hash].Select(item => item).Where(pair => pair.Key.Equals(key));
                T[] searchedValues = new T[searchedElement.Count()];
                int position = 0;

                foreach (var pair in searchedElement)
                {
                    searchedValues[position] = pair.Value;
                    position++;
                }

                return searchedValues;
            }

            public void Add(K key, T itemValue)
            {
                var pair = new KeyValuePair<K, T>(key, itemValue);

                var hash = Math.Abs(key.GetHashCode());
                hash %= this.Capacity;

                if (table[hash] == null)
                {
                    LinkedList<KeyValuePair<K, T>> list = new LinkedList<KeyValuePair<K, T>>();
                    table[hash] = list;
                    this.count++;

                }

                table[hash].AddLast(pair);

                if (this.count > 0.75 * this.Capacity)
                {
                    Resize();
                }
            }

            public IEnumerator<KeyValuePair<K, T>> GetEnumerator()
            {
                foreach (var lists in this.table)
                {
                    if (lists != null)
                    {
                        foreach (var pair in lists)
                        {
                            yield return pair;
                        }
                    }
                }
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            private void Resize()
            {
                Console.WriteLine("Here");
                LinkedList<KeyValuePair<K, T>>[] tableCopy = table;
                table = new LinkedList<KeyValuePair<K, T>>[2 * this.Capacity];
                this.count = 0;

                foreach (var list in tableCopy)
                {
                    if (list != null)
                    {
                        foreach (var pair in list)
                        {
                            this.Add(pair.Key, pair.Value);
                        }
                    }
                }

            }

        }
    }
