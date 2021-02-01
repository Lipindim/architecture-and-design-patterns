using System;
using UnityEngine;


namespace Asteroids
{
    internal class EnemySpawner : IEnemySpawner
    {
        private readonly EnemySettings _enemySettings;
        private readonly IEnemyFactory _enemyFactory;
        private DateTime? _lastSpawnTime;

        internal EnemySpawner(EnemySettings enemySettings, IEnemyFactory enemyFactory)
        {
            _enemySettings = enemySettings;
            _enemyFactory = enemyFactory;
        }

        public bool IsReadyToSpawn()
        {
            if (_lastSpawnTime == null)
                return true;

            double spendSecondsFromLastSpawn = (DateTime.UtcNow - _lastSpawnTime.Value).TotalSeconds;

            if (_enemySettings.SpawnIntervalTime < spendSecondsFromLastSpawn)
                return true;
            else
                return false;
        }

        public Enemy SpawnEnemyInPosition(Vector3 position)
        {
            if (!IsReadyToSpawn())
                return null;

            Enemy enemy = _enemyFactory.Create();
            _lastSpawnTime = DateTime.UtcNow;
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
