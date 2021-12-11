using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace JHTools.Rapid {
    public abstract class ScriptableDictionary<TKey, TValue> : ScriptableObject, IDictionary<TKey, TValue> {
        protected Dictionary<TKey, TValue> _items = new Dictionary<TKey, TValue>();
        public TValue this[TKey key] { get => _items[key]; set => _items[key] = value; }
        public Dictionary<TKey, TValue> Items => _items;
        public ICollection<TKey> Keys => _items.Keys;
        public ICollection<TValue> Values => _items.Values;
        public int Count => _items.Count;
        bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly => ((ICollection<KeyValuePair<TKey, TValue>>)_items).IsReadOnly;

        public virtual void Add(TKey key, TValue value) {
            if (!_items.ContainsKey(key)) {
                _items.Add(key, value);
            }
        }
        public bool ContainsKey(TKey key) => _items.ContainsKey(key);
        public bool ContainsValue(TValue value) => _items.ContainsValue(value);
        public virtual bool Remove(TKey key) => _items.Remove(key);

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => _items.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => _items.GetEnumerator();

        public bool TryGetValue(TKey key, out TValue value) {
            return _items.TryGetValue(key, out value);
        }

        public void Add(KeyValuePair<TKey, TValue> item) {
            ((ICollection<KeyValuePair<TKey, TValue>>)_items).Add(item);
        }

        public void Clear() {
            ((ICollection<KeyValuePair<TKey, TValue>>)_items).Clear();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item) {
            return ((ICollection<KeyValuePair<TKey, TValue>>)_items).Contains(item);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex) {
            ((ICollection<KeyValuePair<TKey, TValue>>)_items).CopyTo(array, arrayIndex);
        }

        public bool Remove(KeyValuePair<TKey, TValue> item) {
            return ((ICollection<KeyValuePair<TKey, TValue>>)_items).Remove(item);
        }
    }
}