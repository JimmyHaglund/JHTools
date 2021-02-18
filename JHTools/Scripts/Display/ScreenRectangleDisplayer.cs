using UnityEngine;

namespace JimmyHaglund.Display {
    public class ScreenRectangleDisplayer : MonoBehaviour {
        [Header("Settings")]
        [SerializeField] private Color _fillColor = Color.gray - new Color(0.0f, 0.0f, 0.0f, 0.75f);
        [SerializeField] private Color _borderColor = Color.black;
        [SerializeField] [Min(0.0f)] private float _borderThickness = 2.0f;

        private bool _isDisplaying = false;
        private Vector2 _rectangleStartScreenPosition = default;
        private Vector2 _screenPosition = default;

        public void StartDisplay() {
            _isDisplaying = true;
            _rectangleStartScreenPosition = _screenPosition;
        }

        public void SetScreenPosition(float x, float y) {
            _screenPosition = new Vector2(x, y);
        }

        public void StopDisplay() {
            _isDisplaying = false;
        }

        private void OnGUI() {
            if (_isDisplaying && enabled) {
                Rect selection = ScreenRect.GetScreenRect(_rectangleStartScreenPosition, _screenPosition);
                ScreenRect.DrawScreenRect(selection, _fillColor);
                ScreenRect.DrawScreenRectBorders(selection, _borderColor, _borderThickness);
            }
        }
    }
}