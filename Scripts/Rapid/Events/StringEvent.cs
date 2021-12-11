using UnityEngine;
using UnityEditor;

namespace JHTools.Rapid {
    [CreateAssetMenu(menuName = "JimmyHaglund/Rapid/String Event")]
    public class StringEvent : ScriptableEvent<string> {
#if (UNITY_EDITOR)
        [CustomEditor(typeof(StringEvent))]
        public class StringEventEditor : Editor {
            private GUILayoutOption _buttonHeight;
            private string _invokeValue = "EditorTest";
            private StringEvent _target;

            private void Awake() {
                _target = target as StringEvent;
                _buttonHeight = GUILayout.Height(75);
            }

            public override void OnInspectorGUI() {
                base.OnInspectorGUI();
                _invokeValue = EditorGUILayout.TextField("Invoke value", _invokeValue);
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