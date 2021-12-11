using System;
using System.Collections.Generic;

namespace JHTools {
    /// <summary>
    /// A priority list that allows multiple items with the same priority.
    /// Useful when running breadth-first searches.
    /// </summary>
    public class PriorityList<TPriority, TValue> where TPriority : IComparable {
        private List<PrioritisedItem> _items { get; set; } = new List<PrioritisedItem>();

        public TValue this[int index] {
            get {
                if (_items == null) return default(TValue);
                return _items[index].Value;
            }
        }

        public int Count { get => _items.Count; }


        /// <summary>
        /// Adds item to list with specified priority.
        /// </summary>
        /// <param name="priority"></param>
        /// <param name="value"></param>
        public int Insert(TPriority priority, TValue value) {
            if (_items == null) _items = new List<PrioritisedItem>();
            if (_items.Count == 0) {
                _items.Add(new PrioritisedItem(priority, value));
                return 0;
            }
            return Insert(0, _items.Count - 1, new PrioritisedItem(priority, value));
        }

        public bool RemoveAt(int index) {
            if (_items == null) return false;
            if (_items.Count > index) {
                _items.RemoveAt(index);
                return true;
            }
            return false;
        }

        public TPriority NextPriority => _items[_items.Count - 1].Priority;
        public TValue Next => _items[_items.Count - 1].Value;

        public TValue Pop() {
            if (_items.Count == 0) return default;
            var index = _items.Count - 1;
            var result = _items[index];
            _items.RemoveAt(index);
            return result.Value;
        }

        /// <summary>
        /// Recursive function for adding item to priority list.
        /// </summary>
        private int Insert(int indexA, int indexB, PrioritisedItem item) {
            int index = indexA + (indexB - indexA) / 2;
            // Last index? Compare & insert
            if (indexA == indexB) {
                if (item.Priority.CompareTo(_items[index].Priority) < 0) {
                    index++;
                }
                _items.Insert(index, item);
                return index;
            }
            // Not last index? Partition & iterate
            if (item.Priority.CompareTo(_items[index].Priority) > 0) {
                if (index == 0) {
                    _items.Insert(index, item);
                    return index;
                }
                indexB = index;
            }
            else {
                if (index == _items.Count - 1) {
                    _items.Insert(++index, item);
                    return index;
                }
                indexA = index + 1;
            }
            return Insert(indexA, indexB, item);
        }

        private struct PrioritisedItem {
            public TPriority Priority { get; private set; }
            public TValue Value { get; private set; }
            public PrioritisedItem(TPriority priority, TValue value) {
                Priority = priority;
                Value = value;
            }
        }
    }
}