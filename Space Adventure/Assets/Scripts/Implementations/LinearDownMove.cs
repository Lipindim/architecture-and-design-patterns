using UnityEngine;

namespace Asteroids
{
    public class LinearDownMove : IMove
    {
        private readonly Transform _transform;

        public float Speed { get; protected set; }
        public LinearDownMove(Transform transform, float speed)
        {
            _transform = transform;
            Speed = speed;
        }

        public Vector3 CurrentPosition => _transform.position;


        public void Move(float horizontal, float vertical, float deltaTime)
        {
            _transform.localPosition -= new Vector3(0, Speed * deltaTime);
        }
    }
}
