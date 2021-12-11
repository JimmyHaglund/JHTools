using System;

namespace JHTools {
    /// <summary>
    /// An event that can be executed. By instantiating a WriteAction and exposing it as
    /// a ReadAction via a read property, it's possible to add and remove reactions whilst
    /// preventing it from bein executed. A decent use-case for inheritance.
    /// </summary>
    public sealed class WriteAction : ReadAction {
        public Action Action {
            get => _action;
            set => _action = value;
        }
        public WriteAction(Action action = null) : base(action) {
            Action = action;
        }
    }
    public sealed class WriteAction<T> : ReadAction<T> {
        public Action<T> Action { get; set; }
        public WriteAction(Action<T> action = null) {
            Action = action;
            Create(this);
        }
    }
    public sealed class WriteAction<T1, T2> : ReadAction<T1, T2> {
        public Action<T1, T2> Action { get; set; }
        public WriteAction(Action<T1, T2> action = null) {
            Action = action;
            Create(this);
        }
    }
    public sealed class WriteAction<T1, T2, T3> : ReadAction<T1, T2, T3> {
        public Action<T1, T2, T3> Action { get; set; }
        public WriteAction(Action<T1, T2, T3> action = null) {
            Action = action;
            Create(this);
        }
    }
}