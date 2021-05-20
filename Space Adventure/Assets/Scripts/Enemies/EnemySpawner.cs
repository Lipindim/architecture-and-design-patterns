using System;
using UnityEngine;


namespace Asteroids
{
    public class EnemySpawner : IEnemySpawner
    {
        private readonly EnemySettings _enemySettings;
        private readonly IEnemyFactory _enemyFactory;

        public EnemyType EnemyType => _enemyFactory.EnemyType;

        public EnemySpawner(EnemySettings enemySettings, IEnemyFactory enemyFactory)
        {
            _enemySettings = enemySettings;
            _enemyFactory = enemyFactory;
        }

        public Enemy SpawnEnemyInPosition(Vector3 position)
        {
            Enemy enemy = _enemyFactory.Create();
            enemy.GameObject.transform.position = position;
            return enemy;
        }

        public Enemy SpawnEnemyInRandomPosition()
        {
            Vector3 randomPosition = GetRandomSpawnPosition();
            return SpawnEnemyInPosition(randomPosition);
        }

        private Vector3 GetRandomSpawnPosition()
        {
            float x = UnityEngine.Random.Range(_enemySettings.SpawnStartPoisitionX, _enemySettings.SpawnEntPositionX);
            return new Vector3(x, _enemySettings.SpawnPositionY);
        }
    }
}
