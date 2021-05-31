using System;
using UnityEngine;

namespace Asteroids
{
    public class ShootingEnemy : Enemy, IRotation, IShoting
    {
        private readonly IRotation _rotation;
        private readonly IShoting _shoting;

        public event Action OnShot;

        public ShootingEnemy(GameObject gameObject, IMove move, IRotation rotation, IShoting shoting, IHealthing healthing, int score, EnemyType enemyType) : base(move, healthing, gameObject, score, enemyType)
        {
            _rotation = rotation;
            _shoting = shoting;
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
