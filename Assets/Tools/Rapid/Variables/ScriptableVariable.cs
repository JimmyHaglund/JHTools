using System.Collections;
using UnityEngine;

namespace JimmyHaglund.Rapid {
    public class ScriptableVariable<VariableType> : ScriptableObject {
        [SerializeField] public VariableType Value;
    }
}