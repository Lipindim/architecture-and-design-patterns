using System;
using UnityEngine;


namespace Asteroids
{
    public class RotationEnemy : Enemy, IMove, IRotation, IHealthing
    {
        private readonly IMove _move;
        private readonly IRotation _rotation;
        private readonly IHealthing _healthing;

        public event Action<IHealthing> OnDestroy;

        public float Speed => _move.Speed;
        public Vector3 CurrentPosition => _move.CurrentPosition;

        public float Health => _healthing.Health;

        public RotationEnemy(IMove move, IHealthing healthing, IRotation rotation, GameObject gameObject, int score, EnemyType enemyType)
        {
            EnemyType = enemyType;
            Score = score;
            _healthing = healthing;
            GameObject = gameObject;
            _move = move;
            _rotation = rotation;

            _healthing.OnDestroy += HealthingOnDestroy;
        }

        private void HealthingOnDestroy(IHealthing healthing)
        {
            OnDestroy?.Invoke(this);
            _healthing.OnDestroy -= HealthingOnDestroy;
        }

        public void Move(float horizontal, float vertical, float deltaTime)
        {
            _move.Move(horizontal, vertical, deltaTime);
        }

        public void GetDamage(float damage)
        {
            _healthing.GetDamage(damage);
        }

        public void Rotation(Vector3 direction)
        {
            _rotation.Rotation(direction);
        }
    }
}
