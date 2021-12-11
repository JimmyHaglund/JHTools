using UnityEngine;
using UnityEditor;

namespace JHTools {
    /// <summary>
    /// Add this attribute to an object reference field and it'll place a button next to the object field that
    /// assigns a component of that type to the field using GetComponentInChildren()
    /// </summary>
    public class ChildReferenceButton : PropertyAttribute {
#if (UNITY_EDITOR)
        [CustomPropertyDrawer(typeof(ChildReferenceButton))]
        public class ChildReferenceDrawer : AutoReferenceButtonDrawer {
            private const string TEXTUREID = "ChildReferenceButtonTexture";
            private const string TOOLTIP = "Find a child of this object and assign it to this field.";
            protected override PropertyExtraButton _button { get; set; } = new PropertyExtraButton(TEXTUREID, TOOLTIP);

            protected override void AssignObjectReference(SerializedProperty property) {
                AssignObjectFieldFromChildren(property);
            }

            private void AssignObjectFieldFromChildren(SerializedProperty property) {
                var targetType = GetSerializedPropertyTarget.From(property);
                var targetObject = property.serializedObject.targetObject as Component;
                property.objectReferenceValue = targetObject.GetComponentInChildren(targetType);
                property.serializedObject.ApplyModifiedProperties();
            }
        }
#endif
    }
}