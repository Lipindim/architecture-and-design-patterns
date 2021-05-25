using UnityEngine;


namespace Asteroids
{
    public class ChaseMove : IMove
    {
        private readonly Transform _transform;
        private readonly ILocation _target;
        private readonly float _sqrDistance;

        public float Speed { get; protected set; }
        public ChaseMove(Transform transform, ILocation target, float speed, float distance)
        {
            _transform = transform;
            Speed = speed;
            _target = target;
            _sqrDistance = distance * distance;
        }

        public Vector3 CurrentPosition => _transform.position;

        public void Move(float horizontal, float vertical, float deltaTime)
        {
            Vector3 moveDirection = _target.CurrentPosition - _transform.position;
            if (_sqrDistance < moveDirection.sqrMagnitude)
                _transform.localPosition += moveDirection.normalized * Speed * deltaTime;
            
        }
    }
}
