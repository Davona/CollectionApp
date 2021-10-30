using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionApp
{
    class _Dictionary<TKey, TValue>
    {
        private struct Entry
        {
            public int hashCode;
            public int next;
            public TKey key;
            public TValue value;

        }

        private int[] buckets;
        private Entry[] entries;
        private int count;
        private int version;
        private int freeList;
        private int freeCount;
        private IEqualityComparer<TKey> comparer;
        public _Dictionary() : this(0, null)
        {

        }
        public _Dictionary(int capacity) : this(capacity, null)
        {

        }
        public _Dictionary(int capacity, IEqualityComparer<TKey> comparer)
        {
            if (capacity > 0) Initialize(capacity);
            this.comparer = comparer ?? EqualityComparer<TKey>.Default;

        }
        public void Add(TKey key, TValue value)
        {
            Insert(key, value, true);
        }
        private void Insert(TKey key, TValue value, bool add)
        {
            if (buckets == null) Initialize(0);
            int hashCode = comparer.GetHashCode(key) & 0x7FFFFFFF;
            int targetBucket = hashCode % buckets.Length;
            int collisionCount = 0;


            for (int i = buckets[targetBucket]; i >= 0; i = entries[i].next)
            {
                if (entries[i].hashCode == hashCode && comparer.Equals(entries[i].key, key))
                {

                    entries[i].value = value;
                    version++;
                    return;
                }
                collisionCount++;
            }
            int index;
            if (freeCount > 0)
            {
                index = freeList;
                freeList = entries[index].next;
                freeCount--;
            }
            else
            {
                if (count == entries.Length)
                {
                    Resize();
                    targetBucket = hashCode % buckets.Length;
                }
                index = count;
                count++;
            }

            entries[index].hashCode = hashCode;
            entries[index].next = buckets[targetBucket];
            entries[index].key = key;
            entries[index].value = value;
            buckets[targetBucket] = index;
            version++;
        }
        private void Initialize(int capacity)
        {
            int size = HashHelpers.GetPrime(capacity);
            buckets = new int[size];
            for (int i = 0; i < buckets.Length; i++)
            {
                buckets[i] = -1;
            }
            entries = new Entry[size];
            freeList = -1;
        }
        private void Resize()
        {
            Resize(HashHelpers.ExpandPrime(count), false);
        }
        private void Resize(int newSize, bool forceNewHashCodes)
        {
            int[] newBuckets = new int[newSize];
            for (int i = 0; i < newBuckets.Length; i++) newBuckets[i] = -1;
            Entry[] newEntries = new Entry[newSize];
            Array.Copy(entries, 0, newEntries, 0, count);
            if (forceNewHashCodes)
            {
                for (int i = 0; i < count; i++)
                {
                    if (newEntries[i].hashCode != -1)
                    {
                        newEntries[i].hashCode = (comparer.GetHashCode(newEntries[i].key) & 0x7FFFFFFF);
                    }
                }
            }
            for (int i = 0; i < count; i++)
            {
                if (newEntries[i].hashCode >= 0)
                {
                    int bucket = newEntries[i].hashCode % newSize;
                    newEntries[i].next = newBuckets[bucket];
                    newBuckets[bucket] = i;
                }
            }
            buckets = newBuckets;
            entries = newEntries;
        }
        public bool TryGetValue(TKey key, out TValue value)
        {
            int i = FindEntry(key);
            if (i >= 0)
            {
                value = entries[i].value;
                return true;
            }
            value = default(TValue);
            return false;
        }
        private int FindEntry(TKey key)
        {
            if (buckets != null)
            {
                int hashCode = comparer.GetHashCode(key) & 0x7FFFFFFF;
                for (int i = buckets[hashCode % buckets.Length]; i >= 0; i = entries[i].next)
                {
                    if (entries[i].hashCode == hashCode && comparer.Equals(entries[i].key, key)) return i;
                }
            }
            return -1;
        }

        internal static class HashHelpers
        {
            public static int GetPrime(int capacity)
            {
                if (capacity <= 1)
                    return 2;

                int prime = capacity;
                bool found = false;

                while (!found)
                {
                    prime++;

                    if (isPrime(prime))
                        found = true;
                }

                return prime;
            }
            private static bool isPrime(int n)
            {
                if (n <= 1) return false;
                if (n <= 3) return true;

                if (n % 2 == 0 || n % 3 == 0) return false;

                for (int i = 5; i * i <= n; i = i + 6)
                    if (n % i == 0 || n % (i + 2) == 0)
                        return false;

                return true;
            }
            public static int ExpandPrime(int oldSize)
            {
                int newSize = 2 * oldSize;

                if ((uint)newSize > 0x7FEFFFFD && 0x7FEFFFFD > oldSize)
                {
                    return 0x7FEFFFFD;
                }

                return GetPrime(newSize);
            }

        }

    }
}

