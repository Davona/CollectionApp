using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryApp
{
    class _ArrayList:IEnumerable
    {

        private Object[] _items;
        private int _size;
        private int _version;
        private const int _defaultCapacity = 4;
        private static readonly Object[] emptyArray = new Object[0];
        public _ArrayList()
        {
            _items = emptyArray;
        }
        public _ArrayList(int capacity)
        {
            if (capacity == 0)
                _items = emptyArray;
            else
                _items = new Object[capacity];
        }
        public int Capacity
        {
            get
            {
                return _items.Length;
            }
            set
            {
                if (value != _items.Length)
                {
                    if (value > 0)
                    {
                        Object[] newItems = new Object[value];
                        if (_size > 0)
                        {
                            Array.Copy(_items, 0, newItems, 0, _size);
                        }
                        _items = newItems;
                    }
                    else
                    {
                        _items = new Object[_defaultCapacity];
                    }
                }
            }
        }
        public int Count
        {
            get
            {
                return _size;
            }
        }
        public int Add(Object value)
        {

            if (_size == _items.Length) EnsureCapacity(_size + 1);
            _items[_size] = value;
            _version++;
            return _size++;
        }
        private void EnsureCapacity(int min)
        {
            if (_items.Length < min)
            {
                int newCapacity = _items.Length == 0 ? _defaultCapacity : _items.Length * 2;
                if ((uint)newCapacity > 0X7FEFFFFF) newCapacity = 0X7FEFFFFF;
                if (newCapacity < min) newCapacity = min;
                Capacity = newCapacity;
            }
        }
        public void Clear()
        {
            if (_size > 0)
            {
                Array.Clear(_items, 0, _size);
                _size = 0;
            }
            _version++;
        }
        public virtual bool Contains(Object item)
        {
            if (item == null)
            {
                for (int i = 0; i < _size; i++)
                    if (_items[i] == null)
                        return true;
                return false;
            }
            else
            {
                for (int i = 0; i < _size; i++)
                    if ((_items[i] != null) && (_items[i].Equals(item)))
                        return true;
                return false;
            }
        }
        public int IndexOf(Object value, int startIndex)
        {
            return Array.IndexOf((Array)_items, value, startIndex, _size - startIndex);
        }
        public void Insert(int index, Object value)
        {

            if (_size == _items.Length) EnsureCapacity(_size + 1);
            if (index < _size)
            {
                Array.Copy(_items, index, _items, index + 1, _size - index);
            }
            _items[index] = value;
            _size++;
            _version++;
        }
        public void Remove(Object obj)
        {


            int index = IndexOf(obj,0);
          
            if (index >= 0)
                RemoveAt(index);
        }
        public void RemoveAt(int index)
        {
            _size--;
            if (index < _size)
            {
                Array.Copy(_items, index + 1, _items, index, _size - index);
            }
            _items[_size] = null;
            _version++;
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return _items[i];
            }
        }
    }
   
}
