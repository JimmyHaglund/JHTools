using UnityEngine;

namespace JimmyHaglund.Extensions {
    public static class Vector3Extensions {
        public static Vector3 Z(this Vector3 vector, float zValue) {
            return new Vector3(vector.x, vector.y, zValue);
        }

        public static Vector2 XY(this Vector3 vector) {
            return new Vector2(vector.x, vector.y);
        }
    }
}
