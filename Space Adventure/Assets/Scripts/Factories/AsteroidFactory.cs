using UnityEngine;


namespace Asteroids
{
    internal class AsteroidFactory : IEnemyFactory
    {
        private readonly EnemySettings _asteroidSettings;
        private readonly PoolServices _poolServices;

        internal AsteroidFactory(EnemySettings asteroidSettings, PoolServices poolServices)
        {
            _asteroidSettings = asteroidSettings;
            _poolServices = poolServices;
        }

        public Enemy Create()
        {
            var asteroidObject = _poolServices.Create(_asteroidSettings.Prefab);
            var move = new LinearDownMove(asteroidObject.transform, _asteroidSettings.Speed);
            var healthing = new UnitHealth(_asteroidSettings.Health);
            var asteroid = new Asteroid(move, healthing, asteroidObject, _asteroidSettings.Score);
            return asteroid;
        }
    }
}
