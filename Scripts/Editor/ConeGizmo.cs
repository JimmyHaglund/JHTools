#if UNITY_EDITOR
using UnityEngine;
using System.Collections.Generic;
using System;

namespace JHTools {
    /// <summary>
    /// Allows drawing a cone gizmo with definable radius, height and orientation.
    /// </summary>
    public class ConeGizmo : MonoSingleton<ConeGizmo> {
        private Dictionary<ConeProperties, Mesh> _meshes = new Dictionary<ConeProperties, Mesh>();

        protected override void OnCreated() {
            gameObject.hideFlags = HideFlags.HideInHierarchy;
        }

        public static void Clear() {
            Instance._meshes = new Dictionary<ConeProperties, Mesh>();
        }

        public static void DrawCone(Vector3 position, Vector3 pointForward, float radius = 1.0f, float height = 1.0f) {
            var mesh = GetMesh(radius, height);
            var rotation = Quaternion.FromToRotation(Vector3.forward, pointForward);
            Gizmos.DrawMesh(mesh, position, rotation);
        }

        private static Mesh GetMesh(float radius, float height) {
            var properties = new ConeProperties(radius, height);
            if (Instance._meshes.TryGetValue(properties, out var mesh)) return mesh;
            mesh = MakeMesh(radius, height);
            Instance._meshes.Add(properties, mesh);
            return mesh;
        }

        private static Mesh MakeMesh(float radius, float height) {
            var result = new Mesh();
            var baseCornerCount = 8;
            var totalCornerCount = baseCornerCount * 2 + 2;

            var vertices = GetVertices(baseCornerCount, radius, height);
            var tris = GetTris(totalCornerCount);
            var uv = new Vector2[totalCornerCount];

            result.vertices = vertices;
            result.triangles = tris;
            result.uv = uv;
            result.RecalculateNormals();

            return result;
        }

        private static Vector3[] GetVertices(int baseCornerCount, float radius, float height) {
            var bottom = GetBottomVertices(baseCornerCount, radius);
            var top = GetTopVertices(baseCornerCount, radius, height);
            var result = new Vector3[bottom.Length + top.Length];
            Array.Copy(top, result, top.Length);
            Array.Copy(bottom, 0, result, top.Length, bottom.Length);
            return result;
        }

        private static Vector3[] GetBottomVertices(int baseCornerCount, float radius) {
            var corona = GetConeBaseRing(baseCornerCount, radius);
            var centreVertex = Vector3.zero;
            var result = new Vector3[corona.Length + 1];
            Array.Copy(corona, result, corona.Length);
            result[result.Length - 1] = centreVertex;
            return result;
        }

        private static Vector3[] GetTopVertices(int baseCornerCount, float radius, float height) {
            var corona = GetConeBaseRing(baseCornerCount, radius);
            var topVertex = Vector3.forward * height;
            var result = new Vector3[corona.Length + 1];
            Array.Copy(corona, result, corona.Length);
            result[result.Length - 1] = topVertex;
            return result;
        }

        private static Vector3[] GetConeBaseRing(int baseCornerCount, float radius) {
            var right = Vector3.right * radius;
            var angleBetweenBasePoints = 360.0f / (baseCornerCount);
            var vertices = new Vector3[baseCornerCount];
            for (var n = 0; n < baseCornerCount; n++) {
                var rotation = Quaternion.AngleAxis(n * angleBetweenBasePoints, Vector3.forward);
                vertices[n] = rotation * right;
            }
            return vertices;
        }

        private static int[] GetTris(int vertexCount) {
            var tris = new int[vertexCount * 3];
            var i = 0;
            
            var topVertexIndex = vertexCount / 2 - 1;
            for (int n = 0; n < vertexCount / 2 - 2; n++, i += 3) {
                var cornerA = n + 1;
                var cornerB = topVertexIndex;
                var cornerC = n;
                tris[i] = cornerA;
                tris[i + 1] = cornerB;
                tris[i + 2] = cornerC;
            }
            {
                var cornerA = 0;
                var cornerB = topVertexIndex;
                var cornerC = vertexCount / 2 - 2;
                tris[i] = cornerA;
                tris[i + 1] = cornerB;
                tris[i + 2] = cornerC;
                i += 3;
            }

            var baseVertexIndex = vertexCount - 1;
            for (int n = vertexCount / 2; n < vertexCount - 2; n++, i += 3) {
                var cornerA = n;
                var cornerB = baseVertexIndex;
                var cornerC = n + 1;
                tris[i] = cornerA;
                tris[i + 1] = cornerB;
                tris[i + 2] = cornerC;
            }
            {
                var cornerA = vertexCount - 2;
                var cornerB = baseVertexIndex;
                var cornerC = vertexCount / 2;
                tris[i] = cornerA;
                tris[i + 1] = cornerB;
                tris[i + 2] = cornerC;
            }
            return tris;
        }

        private struct ConeProperties : IEquatable<ConeProperties> {
            public float Radius;
            public float Height;
            public ConeProperties(float radius, float height) {
                Radius = radius;
                Height = height;
            }

            public bool Equals(ConeProperties other) => Radius == other.Radius && Height == other.Height;
            public override int GetHashCode() => (Radius, Height).GetHashCode();
            public override bool Equals(object obj) => obj is ConeProperties other && this.Equals(other);
            public static bool operator ==(ConeProperties a, ConeProperties b) => a.Equals(b);
            public static bool operator !=(ConeProperties a, ConeProperties b) => !(a.Equals(b));
        }
    }
}
#endif
