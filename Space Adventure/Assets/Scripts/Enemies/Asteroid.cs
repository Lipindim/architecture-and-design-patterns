using System;
using UnityEngine;


namespace Asteroids
{
    public class Asteroid : Enemy, IMove, IHealthing
    {
        private readonly IMove _move;
        private readonly IHealthing _healthing;

        public event Action<IHealthing> OnDestroy;

        public float Speed => _move.Speed;
        public Vector3 CurrentPosition => _move.CurrentPosition;

        public float Health => _healthing.Health;

        public Asteroid(IMove move, IHealthing healthing, GameObject gameObject, int score)
        {
            Score = score;
            _healthing = healthing;
            GameObject = gameObject;
            _move = move;

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
    }
}
