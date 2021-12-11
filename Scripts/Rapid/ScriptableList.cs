using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace JHTools.Rapid {
    public abstract class ScriptableList<T> : ScriptableObject, IList<T> {
        protected List<T> _items = new List<T>();

        public T this[int index] { get => ((IList<T>)_items)[index]; set => ((IList<T>)_items)[index] = value; }

        public List<T> Items => _items;

        public int Count => ((ICollection<T>)_items).Count;

        public bool IsReadOnly => ((ICollection<T>)_items).IsReadOnly;

        public void Add(T item) {
            if (!_items.Contains(item)) {
                _items.Add(item);
            }
        }

        public void Clear() {
            ((ICollection<T>)_items).Clear();
        }

        public bool Contains(T item) {
            return ((ICollection<T>)_items).Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex) {
            ((ICollection<T>)_items).CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator() {
            return ((IEnumerable<T>)_items).GetEnumerator();
        }

        public int IndexOf(T item) {
            return ((IList<T>)_items).IndexOf(item);
        }

        public void Insert(int index, T item) {
            ((IList<T>)_items).Insert(index, item);
        }

        public void Remove(T item) {
            _items.Remove(item);
        }

        public void RemoveAt(int index) {
            ((IList<T>)_items).RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return ((IEnumerable)_items).GetEnumerator();
        }

        bool ICollection<T>.Remove(T item) {
            return ((ICollection<T>)_items).Remove(item);
        }
    }
}