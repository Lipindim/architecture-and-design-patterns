using UnityEngine;

namespace Asteroids
{
    internal class Fighter : Enemy, IMove, IRotation, IShoting
    {
        private readonly IMove _move;
        private readonly IRotation _rotation;
        private readonly IShoting _shoting;

        public Fighter(GameObject gameObject, IMove move, IRotation rotation, IShoting shoting)
        {
            GameObject = gameObject;
            _move = move;
            _rotation = rotation;
            _shoting = shoting;
        }
        public Vector3 CurrentPosition => _move.CurrentPosition;

        public float Speed => _move.Speed;

        public void Move(float horizontal, float vertical, float deltaTime)
        {
            _move.Move(horizontal, vertical, deltaTime);
        }

        public void Rotation(Vector3 direction)
        {
            _rotation.Rotation(direction);
        }

        public bool TryShot(out GameObject bullet)
        {
            return _shoting.TryShot(out bullet);
        }
    }
}
