using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class AsteroidsController : IUpdateble
    {
        private readonly AsteroidSettings _asteroidSettings;
        private readonly PoolServices _poolServices;
        private readonly IEnemyFactory _asteroidFactory;
        private List<Enemy> _asteroids;

        private float _timeUntilNextSpawn;

        internal AsteroidsController(AsteroidSettings asteroidSettings, IEnemyFactory asteroidFactory, PoolServices poolServices)
        {
            _asteroidSettings = asteroidSettings;
            _poolServices = poolServices;
            _asteroidFactory = asteroidFactory;

            _asteroids = new List<Enemy>();
        }

        private void Spawn(float deltaTime)
        {
            _timeUntilNextSpawn -= deltaTime;
            if (_timeUntilNextSpawn <= 0)
            {
                var asteroid = _asteroidFactory.Create();
                _asteroids.Add(asteroid);
                _timeUntilNextSpawn = _asteroidSettings.SpawnIntervalTime;
                asteroid.GameObject.transform.position = GetNewPosition();
            }
        }

        private Vector3 GetNewPosition()
        {
            float x = Random.Range(_asteroidSettings.SpawnStartPoisitionX, _asteroidSettings.SpawnEntPositionX);
            return new Vector3(x, _asteroidSettings.SpawnPositionY);
        }

        public void Update(float deltaTime)
        {
            Spawn(deltaTime);

            for (int i = 0; i < _asteroids.Count; i++)
            {
                IMove move = _asteroids[i] as IMove;
                move.Move(0, 0, deltaTime);

                if (move.CurrentPosition.y < 0)
                {
                    _poolServices.Destroy(_asteroids[i].GameObject);
                    _asteroids.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}
