using UnityEngine;

namespace JimmyHaglund.Rapid {
    public class GameEventFirer : MonoBehaviour {
        [SerializeField] private GameEvent _event;

        public void Fire() {
            if (_event == null) return;
            _event.Raise();
        }
    }
}