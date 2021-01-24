using UnityEngine;

namespace Asteroids
{
    internal class MoveController : IUpdateble
    {
        private readonly IMove _move;
        private readonly IRotation _rotation;
        private readonly Camera _camera;

        internal MoveController( IMove move, IRotation rotation, Camera camera)
        {
            _move = move;
            _rotation = rotation;
            _camera = camera;
        }
        public void Update(float deltaTime)
        {
            var direction = Input.mousePosition - _camera.WorldToScreenPoint(_move.CurrentPosition);
            _rotation.Rotation(direction);
            _move.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), deltaTime);

            //if (Input.GetKeyDown(KeyCode.LeftShift))
            //{
            //    _playerShip.AddAcceleration();
            //}

            //if (Input.GetKeyUp(KeyCode.LeftShift))
            //{
            //    _playerShip.RemoveAcceleration();
            //}
        }
    }
}
