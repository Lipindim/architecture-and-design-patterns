using System.Collections.Generic;
using UnityEngine;


namespace Asteroids
{
    internal class EnemyShotController : IUpdateble
    {
        private readonly PoolServices _poolServices;
        private readonly IScreen _screen;
        private readonly IEnemyCache _enemyCache;
        private readonly List<GameObject> _bullets;

        internal EnemyShotController(IEnemyCache enemyCache, IScreen screen, PoolServices poolServices)
        {
            _poolServices = poolServices;
            _screen = screen;
            _enemyCache = enemyCache;
            _bullets = new List<GameObject>();
        }

        public void Update(float deltaTime)
        {
            foreach (Enemy enemy in _enemyCache)
            {
                if (enemy is IShoting enemyShoting)
                {
                    if (enemyShoting.TryShot(out GameObject bullet))
                        _bullets.Add(bullet);
                }
            }

            RemoveBulletsOutOfScreen();
        }

        private void RemoveBulletsOutOfScreen()
        {
            for (int i = 0; i < _bullets.Count; i++)
            {
                Vector3 bulletPosition = _bullets[i].transform.position;
                if (_screen.IsPositionOutOfScreen(bulletPosition))
                {
                    _poolServices.Destroy(_bullets[i]);
                    _bullets.RemoveAt(i);
                    i--;
                }
            }
        }

    }
}
