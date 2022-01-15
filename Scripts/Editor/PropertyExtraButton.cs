#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace JHTools {
    public class PropertyExtraButton {
        private bool _textureLoaded = false;
        private const int BUTTONSIZE = 16;
        private const int BUTTONOFFSET = -18;
        
        public GUIStyle Style { get; set; } = new GUIStyle();
        public GUIContent Content { get; set; } = null;
        public string TextureId { get; set; }
        public string Tooltip { get; set; }
        public Rect Position { get; private set; }
    
        public PropertyExtraButton(string textureId = "DropDownEditButtonTexture", string tooltip = "") {
            TextureId = textureId;
            Tooltip = tooltip;
        }

        public PropertyExtraButton LoadTexture() {
            if (!_textureLoaded) {
                var buttonTexture = Resources.Load(TextureId, typeof(Texture2D)) as Texture2D;
                Content = new GUIContent(buttonTexture, Tooltip);
            }
            return this;
        }

        public PropertyExtraButton SetPosition(Rect propertyPosition) {
            Position = GetButtonRect(propertyPosition);
            return this;
        }

        private Rect GetButtonRect(Rect propertyPosition) {
            var buttonPosition = new Vector2(GetButtonX(), propertyPosition.y);
            var buttonDimensions = new Vector2(BUTTONSIZE, BUTTONSIZE);
            return new Rect(buttonPosition, buttonDimensions);

            float GetButtonX() => propertyPosition.x + EditorGUIUtility.labelWidth + BUTTONOFFSET;
        }
    }
}
#endif
