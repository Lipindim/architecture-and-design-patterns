using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class AsteroidsController : IUpdateble
    {
        private readonly IScreen _screen;
        private readonly IEnemySpawner _asteroidSpawner;
        private readonly PoolServices _poolServices;
        private readonly UnityTimer _timer;
        private readonly List<Enemy> _asteroids;


        internal AsteroidsController(EnemySettings asteroidSettings, IEnemySpawner asteroidSpawner, PoolServices poolServices, IScreen screen)
        {
            _screen = screen;
            _poolServices = poolServices;
            _asteroidSpawner = asteroidSpawner;

            _asteroids = new List<Enemy>();
            _timer = new UnityTimer(asteroidSettings.SpawnIntervalTime, 0);
        }

        private void Spawn(float deltaTime)
        {
            _timer.Tick(deltaTime);
            if (_timer.IsTimeUp)
            {
                var asteroid = _asteroidSpawner.SpawnEnemyInRandomPosition();
                _asteroids.Add(asteroid);
                _timer.Reset();
            }
        }

        public void Update(float deltaTime)
        {
            Spawn(deltaTime);

            for (int i = 0; i < _asteroids.Count; i++)
            {
                IMove move = _asteroids[i] as IMove;
                move.Move(0, 0, deltaTime);

                if (_screen.IsPositionOutOfScreen(move.CurrentPosition))
                {
                    _poolServices.Destroy(_asteroids[i].GameObject);
                    _asteroids.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}
