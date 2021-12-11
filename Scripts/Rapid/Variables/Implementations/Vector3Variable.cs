using System;
using UnityEngine;
using UnityEditor;

namespace JHTools.Rapid {
    [CreateAssetMenu(menuName = "JHTools/Rapid Variables/Float")]
    public class Vector3Variable : ScriptableVariable<Vector3> { }

    [Serializable]
    public class Vector3Reference : VariableReference<Vector3, Vector3Variable> { }
#if (UNITY_EDITOR)
    [CustomPropertyDrawer(typeof(Vector3Reference))]
    public class Vector3VariableDrawer : ReferenceDrawer { }
#endif
}