﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Asteroids
{

    public class GameInitializer
    {
        public (IEnumerable<IUpdateble>, RoundsController) Initialize(PlayerSettings playerSettings, 
            ShotSettings shotSettings,
            EnemySettings[] enemiesSettings,
            Text scoreText,
            AudioSource audioSource,
            SoundSettings soundSettings,
            AudioSource backgroundAudioSource,
            RoundSettings[] roundsSettings,
            GameObject background,
            HealthView healthView)
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

            var enemySpawnControllerInitializer = new EnemySpawnControllerInitializer(enemyCache, poolServices, enemiesSettings, playerShip);
            EnemySpawnController enemySpawnController = enemySpawnControllerInitializer.Initialize();
            var collistionController = new CollisionController(enemyCache, playerBulletCache);

            var enemyMoveController = new EnemyMoveController(enemyCache);
            var enemyDestroyController = new EnemyDestroyController(enemyCache, screen);
            var enemyRotationToPlayerController = new EnemyRotationToPlayerController(enemyCache, playerShip);
            var enemyShotController = new EnemyShotController(enemyCache, screen, enemyBulletCache);
            var destroyController = new DestroyController(enemyCache);
            IFormatter formatter = new Formatter();
            var scoreController = new ScoreController(enemyCache, scoreText, formatter);
            var soundPlayer = new PlayerAudioPlayer(playerShip, soundSettings, audioSource);
            var playerCollisionController = new PlayerCollisionController(playerShip, enemyBulletCache, enemyCache);
            var backroundMusicController = new BackgroundMusicController(backgroundAudioSource);
            var backMover = new BackgroundMover(background, screen);
            var roundsController = new RoundsController(roundsSettings, backroundMusicController, enemySpawnController, backMover);
            var playerHealthController = new PlayerHealthController(playerShip, healthView);
            

            List<IUpdateble> updatebles = new List<IUpdateble>();
            updatebles.Add(moveController);
            updatebles.Add(shotController);
            updatebles.Add(collistionController);
            updatebles.Add(enemySpawnController);
            updatebles.Add(enemyMoveController);
            updatebles.Add(enemyRotationToPlayerController);
            updatebles.Add(enemyShotController);
            updatebles.Add(enemyDestroyController);
            updatebles.Add(playerCollisionController);
            updatebles.Add(backMover);

            return (updatebles, roundsController);
        }
    }

}
