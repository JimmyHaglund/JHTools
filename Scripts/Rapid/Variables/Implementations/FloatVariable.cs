using System;
using UnityEngine;
using UnityEditor;

namespace JHTools.Rapid {
    [CreateAssetMenu(menuName = "JHTools/Rapid Variables/Float")]
    public class FloatVariable : ScriptableVariable<float> { }

    [Serializable]
    public class FloatReference : VariableReference<float, FloatVariable> { }
#if (UNITY_EDITOR)
    [CustomPropertyDrawer(typeof(FloatReference))]
    public class FloatReferenceDrawer : ReferenceDrawer { }
#endif
}