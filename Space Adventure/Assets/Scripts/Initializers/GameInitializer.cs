using System.Collections.Generic;
using UnityEngine;


namespace Asteroids
{

    internal class GameInitializer
    {
        internal IEnumerable<IUpdateble> Initialize(PlayerSettings playerSettings, 
            ShotSettings shotSettings,
            EnemySettings asteroidSettings,
            EnemySettings fighterSettings,
            ShotSettings fighterShotSettings)
        {
            var poolServices = new PoolServices();
            var playerFactory = new PlayerShipFactory(playerSettings, shotSettings, poolServices);
            Ship playerShip = playerFactory.CreateShip();
            IScreen screen = new Screen(Camera.main);

            MoveController moveController = new MoveController(playerShip, playerShip, screen);
            ShotController shotController = new ShotController(playerShip, screen, poolServices);

            IEnemyCache enemyCache = new EnemyCache(poolServices);

            var enemySpawncontrollerInitializer = new EnemySpawnControllerInitializer(enemyCache, poolServices, asteroidSettings, fighterSettings, fighterShotSettings);
            EnemySpawnController enemySpawnController = enemySpawncontrollerInitializer.Initialize();

            var enemyMoveController = new EnemyMoveController(enemyCache);
            var enemyDestroyController = new EnemyDestroyController(enemyCache, screen);
            var enemyRotationToPlayerController = new EnemyRotationToPlayerController(enemyCache, playerShip);
            var enemyShotController = new EnemyShotController(enemyCache, screen, poolServices);

            List<IUpdateble> updatebles = new List<IUpdateble>();
            updatebles.Add(moveController);
            updatebles.Add(shotController);
            updatebles.Add(enemySpawnController);
            updatebles.Add(enemyMoveController);
            updatebles.Add(enemyRotationToPlayerController);
            updatebles.Add(enemyShotController);
            updatebles.Add(enemyDestroyController);

            return updatebles;
        }
    }

}
