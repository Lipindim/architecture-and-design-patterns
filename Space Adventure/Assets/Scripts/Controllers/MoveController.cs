using UnityEngine;

namespace Asteroids
{
    internal class MoveController : IUpdateble
    {
        private readonly IMove _move;
        private readonly IRotation _rotation;
        private readonly IScreen _screen;

        internal MoveController( IMove move, IRotation rotation, IScreen screen)
        {
            _move = move;
            _rotation = rotation;
            _screen = screen;
        }
        public void Update(float deltaTime)
        {
            var direction = Input.mousePosition - _screen.WorldToScreenPoint(_move.CurrentPosition);
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
