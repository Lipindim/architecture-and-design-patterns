using UnityEngine;


namespace Asteroids
{
    internal class EnemySpawner : IEnemySpawner
    {
        private readonly EnemySettings _enemySettings;
        private readonly IEnemyFactory _enemyFactory;

        internal EnemySpawner(EnemySettings enemySettings, IEnemyFactory enemyFactory)
        {
            _enemySettings = enemySettings;
            _enemyFactory = enemyFactory;
        }

        public Enemy SpawnEnemyInPosition(Vector3 position)
        {
            var enemy = _enemyFactory.Create();
            enemy.GameObject.transform.position = position;
            return enemy;
        }

        public Enemy SpawnEnemyInRandomPosition()
        {
            Vector3 randomPosition = GetRandomPosition();
            return SpawnEnemyInPosition(randomPosition);
        }

        private Vector3 GetRandomPosition()
        {
            float x = Random.Range(_enemySettings.SpawnStartPoisitionX, _enemySettings.SpawnEntPositionX);
            return new Vector3(x, _enemySettings.SpawnPositionY);
        }
    }
}
