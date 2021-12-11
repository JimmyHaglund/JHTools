using UnityEngine;
using System.Collections;

namespace JHTools {
    /// <summary>
    /// Causes a GameObject to destroy itself after a number of seconds.
    /// </summary>
    public class SelfDestroy : MonoBehaviour {
        [SerializeField, Min(0.0f)] private float _lifeTimeSeconds = 1.0f;

        private void Start() {
            StartCoroutine(CO_DestroyAfterSeconds(_lifeTimeSeconds));
        }

        private IEnumerator CO_DestroyAfterSeconds(float seconds) {
            yield return new WaitForSeconds(seconds);
            Destroy(gameObject);
        }
    }
}