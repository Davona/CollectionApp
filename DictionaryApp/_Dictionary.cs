using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryApp
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

        }
        public void Add(TKey key, TValue value)
        {

        }
        private void Insert(TKey key, TValue value, bool add)
        {

        }
        //private void Initialize(int capacity) 
        //{
        //    int size=HashHelpers

        //}

    }
}
    
