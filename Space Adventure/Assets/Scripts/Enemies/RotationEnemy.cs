using System;
using UnityEngine;


namespace Asteroids
{
    public class RotationEnemy : Enemy, IMove, IRotation, IHealthing
    {
        private readonly IRotation _rotation;

        public RotationEnemy(IMove move, IHealthing healthing, IRotation rotation, GameObject gameObject, int score, EnemyType enemyType) : base(move, healthing, gameObject, score, enemyType)
        {
            _rotation = rotation;
        }


        public void Rotation(Vector3 direction)
        {
            _rotation.Rotation(direction);
        }
    }
}
