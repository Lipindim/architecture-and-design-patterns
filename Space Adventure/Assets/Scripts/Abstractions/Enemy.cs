using System;
using UnityEngine;


namespace Asteroids
{
    public abstract class Enemy : Unit, IMove, IHealthing
    {
        protected readonly IMove _move;
        protected readonly IHealthing _healthing;

        public int Score { get; protected set; }
        public EnemyType EnemyType { get; protected set; }

        public float Health => _healthing.Health;

        public float MaxHealth => _healthing.MaxHealth;

        public float Speed => _move.Speed;

        public Vector3 CurrentPosition => _move.CurrentPosition;

        public event Action<IHealthing> OnDestroy;
        public event Action<IHealthing> OnGetDamage;

        public Enemy(IMove move, IHealthing healthing, GameObject gameObject, int score, EnemyType enemyType)
        {
            EnemyType = enemyType;
            Score = score;
            _healthing = healthing;
            GameObject = gameObject;
            _move = move;

            _healthing.OnDestroy += HealthingOnDestroy;
            _healthing.OnGetDamage += HealthingOnGetDamage;
        }

        ~Enemy()
        {
            _healthing.OnGetDamage -= HealthingOnGetDamage;
        }

        private void HealthingOnGetDamage(IHealthing healthing)
        {
            OnGetDamage?.Invoke(this);
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
