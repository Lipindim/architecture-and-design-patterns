using System;
using UnityEngine;

namespace Asteroids
{
    internal class Fighter : Enemy, IMove, IRotation, IShoting, IHealthing
    {
        private readonly IMove _move;
        private readonly IRotation _rotation;
        private readonly IShoting _shoting;
        private readonly IHealthing _healthing;

        public Vector3 CurrentPosition => _move.CurrentPosition;

        public float Speed => _move.Speed;

        public float Health => _healthing.Health;

        public event Action<IHealthing> OnDestroy;

        public Fighter(GameObject gameObject, IMove move, IRotation rotation, IShoting shoting, IHealthing healthing, int score)
        {
            Score = score;
            _healthing = healthing;
            GameObject = gameObject;
            _move = move;
            _rotation = rotation;
            _shoting = shoting;

            _healthing.OnDestroy += HealthingOnDestroy;
        }

        private void HealthingOnDestroy(IHealthing healthing)
        {
            OnDestroy?.Invoke(this);
            _healthing.OnDestroy -= HealthingOnDestroy;
        }

        public void GetDamage(float damage)
        {
            _healthing.GetDamage(damage);
        }

        public void Move(float horizontal, float vertical, float deltaTime)
        {
            _move.Move(horizontal, vertical, deltaTime);
        }

        public void Rotation(Vector3 direction)
        {
            _rotation.Rotation(direction);
        }

        public bool TryShot(out Bullet bullet)
        {
            return _shoting.TryShot(out bullet);
        }
    }
}
