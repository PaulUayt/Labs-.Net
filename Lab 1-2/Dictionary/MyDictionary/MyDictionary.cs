using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;

namespace MyDictionary
{
    public class MyDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private KeyValuePair<TKey, TValue>[] Items;
        private int size;

        public event EventHandler OnAdd;
        public event EventHandler OnRemove;
        public event EventHandler OnClear;

        public MyDictionary()
        {
            size = 0;
            Items = new KeyValuePair<TKey, TValue>[size];
            IsReadOnly = false;
        }

        public MyDictionary(int newSize)
        {
            size = newSize;
            Items = new KeyValuePair<TKey, TValue>[size];
            IsReadOnly = false;
        }

        public int Count
        {
            get { return size; }
        }

        public bool IsReadOnly { get; set; }

        public ICollection<TKey> Keys
        {
            get
            {
                List<TKey> keys = new List<TKey>();
                for(int i = 0; i < Count; i++)
                {
                    keys.Add(Items[i].Key);
                }
                return keys;
            }
        }

        public ICollection<TValue> Values
        {
            get 
            {
                List<TValue> values = new List<TValue>();
                for (int i = 0; i < Count; i++)
                {
                    values.Add(Items[i].Value);
                }
                return values;
            }
        }

        public TValue this[TKey key] 
        { 
            get 
            {
                if(Keys.Contains(key)) return Search(key);
                return default(TValue);
            }
                
            set {Add(key, value);} 
        }

        public int Capacity
        {
            get {return Items.Length;}
            
            set
            {
                if (value < size) throw new InvalidOperationException();

                if (value != Items.Length)
                {
                    if (value > 0) Items = GetNewArr(value);
                }
            }
        }

        public KeyValuePair<TKey, TValue>[] GetNewArr(int _size)
        {
            KeyValuePair<TKey, TValue>[] copyItems = new KeyValuePair<TKey, TValue>[_size];
            if (_size > 0) CopyTo(copyItems, 0);
            return copyItems;
        }

        private void OnNewEvent(EventHandler myDelegate)
        {
            EventHandler temp = Volatile.Read(ref myDelegate);
            temp?.Invoke(this, null);
        }

        public void Add(TKey key, TValue value)
        {
            if (IsReadOnly) throw new NotSupportedException();
            if (key.Equals(null)) throw new ArgumentNullException();
            if (Keys.Contains(key)) throw new ArgumentException("Elements with this key was create");

            if (size == Items.Length) Capacity = (size+1) * 2;
            Items[size++] = new KeyValuePair<TKey, TValue>(key, value);
            OnNewEvent(OnAdd);
        }


        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Add(item.Key, item.Value);
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            if (Keys.Contains(item.Key))
            {
                Remove(item.Key);
                return true;
            }
            return false;
        }

        public bool Remove(TKey key)
        {
            if (IsReadOnly) throw new NotSupportedException();
            if (key.Equals(default(TKey))) throw new ArgumentNullException();

            if (Keys.Contains(key))
            {
                int index = GetIndexByKey(key);
                for (int i = index + 1; i < size; i++)
                {
                    Items[i - 1] = Items[i];
                }
                Items[size - 1] = default(KeyValuePair<TKey, TValue>);
                size--;
                OnNewEvent(OnRemove);
                return true;
            }
            return false;
        }

        public int GetIndexByKey(TKey key)
        {
            for (int i = 0; i < size; i++)
            {
                if (Items[i].Key.Equals(key))
                {
                    return i;
                }
            }

            return -1;
        }

        public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
        {
            if (key == null) throw new ArgumentNullException();

            int hash = key.GetHashCode();

            if (Keys.Contains(key))
            {
                for (int i = 0; i < Items.Length; i++)
                {
                    if (key.Equals(Items[i].Key))
                    {
                        value = Items[i].Value;
                        return true;
                    }
                }
            }
            value = default(TValue);
            return false;
        }

        public void Clear()
        {
            if (IsReadOnly) throw new NotSupportedException();

            size = 0;
            //freeCount = 0;
            Items = new KeyValuePair<TKey, TValue>[size];
            OnNewEvent(OnClear);
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            if (Keys.Contains(item.Key))
                for (var i = 0; i < Items.Length; i++)
                {
                    if (Items[i].Equals(item))
                    {
                        return true;
                    }
                }
            return false;
        }

        public bool ContainsKey(TKey key)
        {
            if (Keys.Contains(key)) return true;
            return false;
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            if (array == null) throw new ArgumentNullException();
            if (arrayIndex < 0 || arrayIndex > array.Length) throw new ArgumentOutOfRangeException();
            if (array.Length - arrayIndex < Count) throw new ArgumentException();

            for (int i = 0; i < Items.Length; i++)
            {
                if (!Items[i].Equals(default(KeyValuePair<TKey, TValue>)))
                {
                    array[arrayIndex++] = Items[i];
                }
            }
        }

        public TValue Search(TKey key)
        {
            if (Keys.Contains(key))
            {
                foreach (var item in Items)
                {
                    if (item.Key.Equals(key))
                    {
                        return item.Value;
                    }
                }
            }
            return default(TValue);
        }

        IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
        {
            return (IEnumerator<KeyValuePair<TKey, TValue>>)GetEnumerator();
        }

        public IEnumerator GetEnumerator()
        {
            return Items.GetEnumerator();
        }
    }
}
