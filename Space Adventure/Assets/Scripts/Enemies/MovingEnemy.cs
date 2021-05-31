using System;
using UnityEngine;


namespace Asteroids
{
    public class MovingEnemy : Enemy
    {
        public MovingEnemy(IMove move, IHealthing healthing, GameObject gameObject, int score, EnemyType enemyType) : base(move, healthing, gameObject, score, enemyType)
        {

        }
    }
}
