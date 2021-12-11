using System;
using UnityEngine;
using UnityEditor;

namespace JHTools.Rapid {
    [CreateAssetMenu(menuName = "JHTools/Rapid Variables/Bool")]
    public class BoolVariable : ScriptableVariable<bool> {
        public void Toggle() {
            Value = !Value;
        }
    }

    [Serializable]
    public class BoolReference : VariableReference<bool, BoolVariable> { }
#if (UNITY_EDITOR)
    [CustomPropertyDrawer(typeof(BoolReference))]
    public class BoolReferenceDrawer : ReferenceDrawer { }
#endif
}
