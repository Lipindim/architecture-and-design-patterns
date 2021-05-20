using System;
using UnityEngine;


namespace Asteroids
{
    public sealed class Ship : IMove, IRotation, IHealthing, IShoting, ICollision
    {
        private readonly IHealthing _healthingImplementation;
        private readonly IShoting _shotingImplementation;
        private readonly IMove _moveImplementation;
        private readonly IRotation _rotationImplementation;

        public event Action<Unit> OnCollision;

        public event Action OnShot
        {
            add
            {
                _shotingImplementation.OnShot += value;
            }
            remove
            {
                _shotingImplementation.OnShot -= value;
            }
        }

        public event Action<IHealthing> OnDestroy
        {
            add
            {
                _healthingImplementation.OnDestroy += value;
            }
            remove
            {
                _healthingImplementation.OnDestroy -= value;
            }
        }


        public float Speed => _moveImplementation.Speed;
        public float Health => _healthingImplementation.Health;

        public Vector3 CurrentPosition => _moveImplementation.CurrentPosition;

        public Ship(IMove moveImplementation, 
            IRotation rotationImplementation,
            IHealthing healthingImplementation,
            IShoting shotingImplementation)
        {
            _healthingImplementation = healthingImplementation;
            _shotingImplementation = shotingImplementation;
            _moveImplementation = moveImplementation;
            _rotationImplementation = rotationImplementation;
        }

        public void Move(float horizontal, float vertical, float deltaTime)
        {
            _moveImplementation.Move(horizontal, vertical, deltaTime);
        }

        public void Rotation(Vector3 direction)
        {
            _rotationImplementation.Rotation(direction);
        }

        public void AddAcceleration()
        {
            if (_moveImplementation is AccelerationMove accelerationMove)
            {
                accelerationMove.AddAcceleration();
            }
        }

        public void RemoveAcceleration()
        {
            if (_moveImplementation is AccelerationMove accelerationMove)
            {
                accelerationMove.RemoveAcceleration();
            }
        }

        public bool TryShot(out Bullet bullet)
        {
            return _shotingImplementation.TryShot(out bullet);
        }

        public void GetDamage(float damage)
        {
            _healthingImplementation.GetDamage(damage);
        }

        public void Collision(Unit unit)
        {
            OnCollision?.Invoke(unit);
        }
    }
}
