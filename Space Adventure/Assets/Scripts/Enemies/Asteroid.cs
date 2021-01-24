using UnityEngine;


namespace Asteroids
{
    internal class Asteroid : Enemy, IMove
    {
        private readonly IMove _move;

        public float Speed => _move.Speed;
        public Vector3 CurrentPosition => _move.CurrentPosition;
        public Asteroid(IMove move, GameObject gameObject)
        {
            GameObject = gameObject;
            _move = move;
        }
        public void Move(float horizontal, float vertical, float deltaTime)
        {
            _move.Move(horizontal, vertical, deltaTime);
        }
    }
}
