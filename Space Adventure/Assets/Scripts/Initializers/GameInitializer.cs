using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Asteroids
{

    internal class GameInitializer
    {
        internal IEnumerable<IUpdateble> Initialize(PlayerSettings playerSettings, 
            ShotSettings shotSettings,
            EnemySettings asteroidSettings,
            EnemySettings fighterSettings,
            ShotSettings fighterShotSettings,
            Text scoreText)
        {
            var poolServices = new PoolServices();
            var playerFactory = new PlayerShipFactory(playerSettings, shotSettings, poolServices);
            Ship playerShip = playerFactory.CreateShip();
            IScreen screen = new Screen(Camera.main);

            IUnitCache<Enemy> enemyCache = new UnitCache<Enemy>(poolServices);
            IUnitCache<Bullet> playerBulletCache = new UnitCache<Bullet>(poolServices);
            IUnitCache<Bullet> enemyBulletCache = new UnitCache<Bullet>(poolServices);

            MoveController moveController = new MoveController(playerShip, playerShip, screen);
            ShotController shotController = new ShotController(playerShip, screen, playerBulletCache);

            var enemySpawnControllerInitializer = new EnemySpawnControllerInitializer(enemyCache, poolServices, asteroidSettings, fighterSettings, fighterShotSettings);
            EnemySpawnController enemySpawnController = enemySpawnControllerInitializer.Initialize();
            var collistionController = new CollisionController(enemyCache, playerBulletCache);

            var enemyMoveController = new EnemyMoveController(enemyCache);
            var enemyDestroyController = new EnemyDestroyController(enemyCache, screen);
            var enemyRotationToPlayerController = new EnemyRotationToPlayerController(enemyCache, playerShip);
            var enemyShotController = new EnemyShotController(enemyCache, screen, enemyBulletCache);
            var destroyController = new DestroyController(enemyCache);
            IFormatter formatter = new Formatter();
            var scoreController = new ScoreController(enemyCache, scoreText, formatter);

            List<IUpdateble> updatebles = new List<IUpdateble>();
            updatebles.Add(moveController);
            updatebles.Add(shotController);
            updatebles.Add(collistionController);
            updatebles.Add(enemySpawnController);
            updatebles.Add(enemyMoveController);
            updatebles.Add(enemyRotationToPlayerController);
            updatebles.Add(enemyShotController);
            updatebles.Add(enemyDestroyController);

            return updatebles;
        }
    }

}
