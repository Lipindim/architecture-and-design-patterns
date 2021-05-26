using UnityEngine;


namespace Asteroids
{
    public class Screen : IScreen
    {
        private readonly Camera _camera;

        public Screen(Camera camera)
        {
            _camera = camera;
        }

        public bool IsPositionOutOfScreen(Vector3 position)
        {
            Vector3 point = _camera.WorldToViewportPoint(position);
            return point.y < 0.0f
                || point.y > 1.0f
                || point.x > 1.0f
                || point.x < 0.0f;
        }

        public Vector3 WorldToScreenPoint(Vector3 position)
        {
            return _camera.WorldToScreenPoint(position);
        }

        public float GetPixelHeight()
        {
            return _camera.pixelHeight;
        }
    }
}
