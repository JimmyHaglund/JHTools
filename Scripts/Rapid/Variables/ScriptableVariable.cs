using System.Collections;
using UnityEngine;

namespace JHTools.Rapid {
    public class ScriptableVariable<VariableType> : ScriptableObject {
        [SerializeField] public VariableType Value;
    }
}