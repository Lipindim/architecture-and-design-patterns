using System;
using System.Collections.Generic;


namespace Asteroids
{
    public class EnemySpawnControllerInitializer
    {
        private readonly IUnitCache<Enemy> _enemyCache;
        private readonly PoolServices _poolServices;
        private readonly EnemySettings[] _enemiesSettings;
        private readonly ILocation _playerLocation;

        public EnemySpawnControllerInitializer(IUnitCache<Enemy> enemyCache, PoolServices poolServices, EnemySettings[] enemiesSettings, ILocation playerLocatoin)
        {
            _enemyCache = enemyCache;
            _poolServices = poolServices;
            _enemiesSettings = enemiesSettings;
            _playerLocation = playerLocatoin;
        }

        public EnemySpawnController Initialize()
        {
            List<IEnemySpawner> enemySpawners = new List<IEnemySpawner>();

            foreach (var enemySettings in _enemiesSettings)
            {
                IEnemyFactory factory = CreateEnemyFactory(enemySettings);
                IEnemySpawner spawner = new EnemySpawner(enemySettings, factory);
                enemySpawners.Add(spawner);
            }

            EnemySpawnController enemySpawnController = new EnemySpawnController(enemySpawners, _enemyCache);

            return enemySpawnController;
        }

        private IEnemyFactory CreateEnemyFactory(EnemySettings enemySettings)
        {
            switch (enemySettings.EnemyType)
            {
                case EnemyType.Asteroid:
                    return new AsteroidFactory(enemySettings, _poolServices);
                case EnemyType.Fighter:
                    return new FighterFactory(enemySettings, _poolServices);
                case EnemyType.Wasp:
                    return new WaspFactory(enemySettings, _poolServices);
                case EnemyType.Striker:
                    return new StrikerFactory(enemySettings, _poolServices, _playerLocation);
                case EnemyType.Bomber:
                    return new BobmerFactory(enemySettings, _poolServices, _playerLocation);
                default:
                    throw new ArgumentException($"Unsupported enemy type: {enemySettings.EnemyType}");
            }
        }
    }
}
