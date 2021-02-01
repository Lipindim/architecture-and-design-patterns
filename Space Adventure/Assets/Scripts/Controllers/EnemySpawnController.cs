using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    internal class EnemySpawnController : IUpdateble
    {
        private readonly IEnumerable<IEnemySpawner> _enemySpawners;
        private readonly IEnemyCache _enemyCache;

        public EnemySpawnController(IEnumerable<IEnemySpawner> enemySpawners, IEnemyCache enemyCache)
        {
            _enemySpawners = enemySpawners;
            _enemyCache = enemyCache;
        }

        public void Update(float deltaTime)
        {
            foreach (IEnemySpawner enemySpawner in _enemySpawners)
            {
                if (enemySpawner.IsReadyToSpawn())
                {
                    Enemy enemy = enemySpawner.SpawnEnemyInRandomPosition();
                    _enemyCache.AddEnemy(enemy);
                }
            }
        }
    }
}
