﻿namespace Asteroids
{
    public class AsteroidFactory : IEnemyFactory
    {
        private readonly EnemySettings _asteroidSettings;
        private readonly PoolServices _poolServices;

        public EnemyType EnemyType => EnemyType.Asteroid;

        public AsteroidFactory(EnemySettings asteroidSettings, PoolServices poolServices)
        {
            _asteroidSettings = asteroidSettings;
            _poolServices = poolServices;
        }

        public Enemy Create()
        {
            var asteroidObject = _poolServices.Create(_asteroidSettings.Prefab);
            var move = new LinearDownMove(asteroidObject.transform, _asteroidSettings.Speed);
            var healthing = new UnitHealth(_asteroidSettings.Health);
            var enemy = new MovingEnemy(move, healthing, asteroidObject, _asteroidSettings.Score, EnemyType);
            return enemy;
        }
    }
}
