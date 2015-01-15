using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Hash_Table
{
    public class HashDictionary<K, V> : IEnumerable<KeyValuePair<K, V>>
    {
        const int InitialValuesSize = 4;

        LinkedList<KeyValuePair<K, V>>[] values;

        public HashDictionary()
        {
            this.values = new LinkedList<KeyValuePair<K, V>>[InitialValuesSize];
        }

        public int Count
        {
            get;
            private set;
        }

        public int Capacity
        {
            get
            {
                return this.values.Length;
            }
        }
        
        public void Add(K key, V value)
        {
            var hash = this.HashKey(key);

            if (this.values[hash] == null)
            {
                this.values[hash] = new LinkedList<KeyValuePair<K, V>>();
            }

            var alreadyHasKey = this.values[hash].Any(p => p.Key.Equals(key));

            if (alreadyHasKey)
            {
                throw new ArgumentException("Key already exists");
            }

            var pair = new KeyValuePair<K, V>(key, value);
            this.values[hash].AddLast(pair);
            this.Count++;

            if (this.Count >= 0.75 * this.Capacity)
            {
                this.ResizeAndReaddValues();
            }
        }

        public bool ContainsKey(K key)
        {
            var hash = HashKey(key);

            if (this.values[hash] == null)
            {
                return false;
            }

            var pairs = this.values[hash];

            return pairs.Any(pair => pair.Key.Equals(key));
        }
        
        private int HashKey(K key)
        {
            var hash = key.GetHashCode();
            hash %= this.Capacity;
            hash = Math.Abs(hash);
            return hash;
        }

        private void ResizeAndReaddValues()
        {
            var cachedValues = this.values;

            this.values = new LinkedList<KeyValuePair<K, V>>[2 * this.Capacity];

            this.Count = 0;
            foreach (var valueCollection in cachedValues)
            {
                if (valueCollection != null)
                {
                    foreach (var value in valueCollection)
                    {
                        this.Add(value.Key, value.Value);
                    }
                }
            }
        }

        public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            foreach (var valueCollection in this.values)
            {
                if (valueCollection != null)
                {
                    foreach (var value in valueCollection)
                    {
                        yield return value;
                    }
                }
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
