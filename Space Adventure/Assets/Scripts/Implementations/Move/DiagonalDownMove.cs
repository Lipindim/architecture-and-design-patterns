using UnityEngine;

namespace Asteroids
{
    public class DiagonalDownMove : IMove
    {
        private readonly Transform _transform;
        private readonly float _minX;
        private readonly float _maxX;
        private bool _rightDirection;
        private readonly float _horizontalSpeed;
        private readonly float _verticalSpeed;

        public float Speed { get; protected set; }

        public DiagonalDownMove(Transform transform, float horizontalSpeed, float verticalSpeed, float minX, float maxX)
        {
            _transform = transform;
            Speed = Mathf.Sqrt(horizontalSpeed * horizontalSpeed + verticalSpeed * verticalSpeed);
            _horizontalSpeed = horizontalSpeed;
            _verticalSpeed = verticalSpeed;
            _minX = minX;
            _maxX = maxX;
            _rightDirection = Randomizer.GetBool();
        }

        public Vector3 CurrentPosition => _transform.position;


        public void Move(float horizontal, float vertical, float deltaTime)
        {
            if (_rightDirection && _transform.position.x > _maxX)
                _rightDirection = false;
            if (!_rightDirection && _transform.position.x < _minX)
                _rightDirection = true;
            int mulityplier = _rightDirection ? 1 : -1;
            _transform.localPosition += new Vector3(mulityplier * _horizontalSpeed * deltaTime, -1 *_verticalSpeed * deltaTime);
        }
    }
}
