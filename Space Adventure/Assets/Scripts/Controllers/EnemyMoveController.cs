﻿namespace Asteroids
{
    internal class EnemyMoveController : IUpdateble
    {
        private readonly IEnemyCache _enemyCache;

        public EnemyMoveController(IEnemyCache enemyCache)
        {
            _enemyCache = enemyCache;
        }

        public void Update(float deltaTime)
        {
            foreach (Enemy enemy in _enemyCache)
            {
                if (enemy is IMove enemyMove)
                {
                    enemyMove.Move(0, 0, deltaTime);
                }
            }
        }
    }
}