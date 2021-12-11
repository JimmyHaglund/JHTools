using UnityEngine;

namespace JHTools {
    /// <summary>
    /// Base class for monobehaviour singletons. Use if a static class requires lifetime methods.
    /// Classes that implement this should never be placed in a scene in the editor - this is a 
    /// lazy-loaded singleton, and it's recommended to make any public-facing methods static.
    /// </summary>
    public abstract class MonoSingleton<ImplementingType> : MonoBehaviour where ImplementingType : MonoBehaviour {
        private static ImplementingType _instance;
        protected static ImplementingType Instance {
            get {
                if (_instance == null) {
                    _instance = GameObject.FindObjectOfType<ImplementingType>();
                    if (_instance == null) {
                        GameObject newObject = new GameObject();
                        newObject.name = typeof(ImplementingType).ToString();
                        _instance = newObject.AddComponent<ImplementingType>();
                    }
                }
                (_instance as MonoSingleton<ImplementingType>).OnCreated();
                return _instance;
            }
        }
        /// <summary>
        /// Singleton pattern, assigns self as instance and ensures only one instance exists.
        /// </summary>
        private void OnEnable() {
            if (_instance != null && _instance != this) {
                Debug.Log("Doublet created for " + this.GetType().ToString());
                Destroy(this);
                return;
            }
            Debug.Log("Singleton created for " + this.GetType().ToString());
            _instance = this as ImplementingType;
            OnOnEnable();
        }
        
        private void OnDisable() {
            if (_instance == this) {
                _instance = null;
                OnOnDisable();
            }
        }
        protected virtual void OnOnEnable() { }
        protected virtual void OnOnDisable() { }
        protected virtual void OnCreated() { }
    }
}
