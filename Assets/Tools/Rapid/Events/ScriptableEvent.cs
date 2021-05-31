using UnityEngine;
using System.Collections.Generic;

namespace JimmyHaglund.Rapid {
    public class ScriptableEvent<T> : ScriptableObject {
        private List<IEventListener<T>> _listeners = new List<IEventListener<T>>();

        private bool _raising = false;
        private List<IEventListener<T>> _queuedRemoves = new List<IEventListener<T>>();

        public void Raise(T data) {
            _raising = true;
            for (int i = _listeners.Count - 1; i >= 0; i--) {
                _listeners[i].OnEventRaised(data);
            }
            _raising = false;
            RemoveQueuedListeners();
        }

        public void RegisterListener(IEventListener<T> listener) {
            if (_listeners.Contains(listener)) return;
            _listeners.Add(listener);
        }

        public void UnRegisterListener(IEventListener<T> listener) {
            if (_raising) {
                _queuedRemoves.Add(listener);
                return;
            }
            _listeners.Remove(listener);
        }

        // In case a listener removes, e.g. deactivates, all listeners from list as a response.
        private void RemoveQueuedListeners() {
            foreach (IEventListener<T> removedListener in _queuedRemoves) {
                _listeners.Remove(removedListener);
            }
        }
    }
}