using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace BiDictionary
{
    public class BiDictionary<K1, K2, V>
    {
        private MultiDictionary<K1, V> firstKeyDictionary;
        private MultiDictionary<K2, V> secondKeyDictionary;

        public BiDictionary()
        {
            firstKeyDictionary = new MultiDictionary<K1, V>(true);
            secondKeyDictionary = new MultiDictionary<K2, V>(true);
        }

        public void Add(K1 firstKey, K2 secondKey, V elementValue)
        {
            firstKeyDictionary.Add(firstKey, elementValue);
            secondKeyDictionary.Add(secondKey, elementValue);
        }

        public V[] SearchFirstKey(K1 firstKeyToSearch)
        {
            return firstKeyDictionary[firstKeyToSearch].ToArray();
        }

        public V[] SearchSecondKey(K2 secondKeyToSearch)
        {
            return secondKeyDictionary[secondKeyToSearch].ToArray();
        }

        public V[] SearchMultiKeys(K1 firstKeyToSearch, K2 secondKeyToSearch)
        {
            V[] firstCollection = this.SearchFirstKey(firstKeyToSearch);
            V[] secondCollection = this.SearchSecondKey(secondKeyToSearch);
            return firstCollection.Union(secondCollection).ToArray();
        }
    }
}
