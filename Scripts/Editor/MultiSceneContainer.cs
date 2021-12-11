using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

namespace JHTools {
    [CreateAssetMenu(menuName = "JHTools/Scene Container")]
    public class MultiSceneContainer : ScriptableObject {
        [SerializeField] private SceneAsset[] _scenes = new SceneAsset[0];
        public void PrintScenes() {
            Debug.Log("Scene container " + name + " contains the following " + _scenes.Length + " scenes: ");
            foreach(SceneAsset scene in _scenes) {
                if (scene == null) Debug.Log("<null>");
                Debug.Log(scene.name);
            }
        }

        public void OpenScenes() {
            if (_scenes == null || _scenes.Length == 0 || _scenes[0] == null) return;
            EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();

            var openedFirst = false;
            foreach(var scene in _scenes) {
                openedFirst = OpenScene(scene, openedFirst);
            }
        }

        private bool OpenScene(SceneAsset scene, bool additive = true) {
            if (scene == null) return false;
            var path = AssetDatabase.GetAssetPath(scene);
            EditorSceneManager.OpenScene(path, additive ? OpenSceneMode.Additive : OpenSceneMode.Single);
            return true;
        }
    }
}