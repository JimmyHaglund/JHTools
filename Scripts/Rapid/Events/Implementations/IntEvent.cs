﻿using UnityEngine;
using System.Collections.Generic;
using UnityEditor;

namespace JHTools.Rapid {
    [CreateAssetMenu(menuName = "JHTools/Rapid Events/Int")]
    public class IntEvent : ScriptableObject {
        private List<IEventListener<int>> _listeners = new List<IEventListener<int>>();

        public void Raise(int value) {
            for (int i = _listeners.Count - 1; i >= 0; i--) {
                _listeners[i].OnEventRaised(value);
            }
        }

        public void RegisterListener(IEventListener<int> listener) {
            if (_listeners.Contains(listener)) return;
            _listeners.Add(listener);
        }

        public void UnRegisterListener(IEventListener<int> listener) {
            _listeners.Remove(listener);
        }


#if (UNITY_EDITOR)
        [CustomEditor(typeof(IntEvent))]
        public class IntEventEditor : Editor {
            private IntEvent _target;
            private GUILayoutOption _buttonHeight;
            private int _invokeValue = 0;
            private void Awake() {
                _target = target as IntEvent;
                _buttonHeight = GUILayout.Height(75);
            }

            public override void OnInspectorGUI() {
                base.OnInspectorGUI();
                _invokeValue = EditorGUILayout.IntField("Invoke value", _invokeValue);
                var buttonStyle = new GUIStyle(GUI.skin.button);
                buttonStyle.fontSize = 32;
                if (GUILayout.Button("Raise", buttonStyle, _buttonHeight)) {
                    _target.Raise(_invokeValue);
                }
            }
        }
#endif
    }
}