using System;
using UnityEngine;
using UnityEngine.Events;

namespace JHTools.Rapid {
    public class BoolEventListener : ScriptableEventListener<bool> {
        [Serializable] public class BoolUnityEvent : UnityEvent<bool> { }

        [SerializeField] private BoolEvent _event;
        [SerializeField] private BoolUnityEvent _response;

        protected override ScriptableEvent<bool> TargetEvent => _event;

        public override void OnEventRaised(bool data) {
            _response.Invoke(data);
        }
    }
}