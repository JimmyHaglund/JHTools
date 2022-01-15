using UnityEngine;
using UnityEditor;

namespace JHTools.Rapid {
#if (UNITY_EDITOR)
    public abstract class ReferenceDrawer : PropertyDrawer {
        private const string TEXTUREID = "DropDownEditButtonTexture";
        private const string TOOLTIP = "Switch between using a constant value or a Scriptable Object variable";
        private PropertyExtraButton _extraButton = new PropertyExtraButton(TEXTUREID, TOOLTIP);
        private bool _initialized = false;
        private bool _useConstant;
        
        protected bool UseConstant { get => _useConstant; private set => _useConstant = value; }
        protected bool UseVariable { get => !UseConstant; private set => UseConstant = !value; } 
        
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            var useConstantProperty = property.FindPropertyRelative("_useConstant");
            var useConstant = useConstantProperty.boolValue;

            if (!_initialized) {
                UseConstant = useConstant;
                _initialized = true;
            }
            DisplayConstantValueDropDownButton(_extraButton.SetPosition(position).LoadTexture(), useConstantProperty);
            useConstantProperty.boolValue = UseConstant;
            DrawProperty(position, property, label, useConstant);
        }

        private void DrawProperty(Rect position, SerializedProperty property, GUIContent label, bool useConstant) {
            if (useConstant) {
                var constantProperty = property.FindPropertyRelative("_constantValue");
                DrawConstantProperty(position, constantProperty, label);
                return;
            }
            var variableProperty = property.FindPropertyRelative("_variable");
            DrawVariableProperty(position, variableProperty, label);
        }

        private void DrawVariableProperty(Rect position, SerializedProperty property, GUIContent label) {
            EditorGUI.PropertyField(position, property, label);
        }

        protected virtual void DrawConstantProperty(Rect position, SerializedProperty property, GUIContent label) {
            EditorGUI.PropertyField(position, property, label);
        }

        private void DisplayConstantValueDropDownButton(PropertyExtraButton button, SerializedProperty constantProperty) {
            if (EditorGUI.DropdownButton(button.Position, button.Content, FocusType.Passive, button.Style)) {
                var menu = MakeConstantValueSelectMenu(constantProperty);
                menu.ShowAsContext();
            }
        }

        private GenericMenu MakeConstantValueSelectMenu(SerializedProperty useConstantProperty) {
            var menu = new GenericMenu();
            menu.AddItem(new GUIContent("Use constant value"), UseConstant, UseConstant);
            menu.AddItem(new GUIContent("Use variable"), !UseConstant, UseVariable);
            return menu;
        }
    }
#endif
}
