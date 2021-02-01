using System.Collections.Generic;


namespace Asteroids
{
    internal class EnemySpawnControllerInitializer
    {
        private readonly IEnemyCache _enemyCache;
        private readonly PoolServices _poolServices;
        private readonly EnemySettings _astetoidSettings;
        private readonly EnemySettings _fightersSettings;
        private readonly ShotSettings _fighterShotSettings;

        public EnemySpawnControllerInitializer(IEnemyCache enemyCache, PoolServices poolServices, EnemySettings astetoidSettings, EnemySettings fightersSettings, ShotSettings fighterShotSettings)
        {
            _enemyCache = enemyCache;
            _poolServices = poolServices;
            _astetoidSettings = astetoidSettings;
            _fightersSettings = fightersSettings;
            _fighterShotSettings = fighterShotSettings;
        }

        public EnemySpawnController Initialize()
        {
            IEnemyFactory asteroidFactory = new AsteroidFactory(_astetoidSettings, _poolServices);
            IEnemySpawner asteroidSpawner = new EnemySpawner(_astetoidSettings, asteroidFactory);

            IEnemyFactory fighterFactory = new FighterFactory(_fightersSettings, _poolServices, _fighterShotSettings);
            IEnemySpawner fighterSpawner = new EnemySpawner(_fightersSettings, fighterFactory);

            IEnumerable<IEnemySpawner> enemySpawners = new IEnemySpawner[] { asteroidSpawner, fighterSpawner };

            EnemySpawnController enemySpawnController = new EnemySpawnController(enemySpawners, _enemyCache);

            return enemySpawnController;
        }
    }
}
