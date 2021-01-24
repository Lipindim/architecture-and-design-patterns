using UnityEngine;

namespace Asteroids
{
    internal class Fighter : Enemy, IMove, IRotation
    {
        private readonly IMove _move;
        private readonly IRotation _rotation;

        public Fighter(GameObject gameObject, IMove move, IRotation rotation)
        {
            GameObject = gameObject;
            _move = move;
            _rotation = rotation;
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
    }
}
