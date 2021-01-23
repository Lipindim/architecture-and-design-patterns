using UnityEngine;

namespace Asteroids
{
    internal class MoveController : IUpdateble
    {
        private readonly Ship _playerShip;
        private readonly Camera _camera;
        private readonly Transform _transform;

        internal MoveController(Ship playerShip, Camera camera, Transform transform)
        {
            _playerShip = playerShip;
            _camera = camera;
            _transform = transform;
        }
        public void Update(float deltaTime)
        {
            var direction = Input.mousePosition - _camera.WorldToScreenPoint(_transform.position);
            _playerShip.Rotation(direction);

            _playerShip.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), deltaTime);

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _playerShip.AddAcceleration();
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                _playerShip.RemoveAcceleration();
            }
        }
    }
}
