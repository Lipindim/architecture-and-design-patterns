using System;
using System.Collections;
using System.Collections.Generic;


namespace Asteroids
{
    internal class EnemyCache : IEnemyCache
    {
        private readonly PoolServices _poolServices;
        private IList<Enemy> _enemies;
        private IList<Enemy> _enemiesToRemove;

        internal EnemyCache(PoolServices poolServices)
        {
            _poolServices = poolServices;
            _enemies = new List<Enemy>();
            _enemiesToRemove = new List<Enemy>();
        }

        public void AddEnemy(Enemy enemy)
        {
            if (enemy == null)
                throw new ArgumentNullException(nameof(enemy));

            _enemies.Add(enemy);
        }

        public void AddToRemoveEnemy(Enemy enemy)
        {
            if (_enemies.Contains(enemy))
                _enemiesToRemove.Add(enemy);
        }

        public void Clear()
        {
            foreach (Enemy enemyToRemove in _enemiesToRemove)
            {
                _enemies.Remove(enemyToRemove);
                _poolServices.Destroy(enemyToRemove.GameObject);
            }

            _enemiesToRemove.Clear();
        }

        public IEnumerator GetEnumerator()
        {
            return _enemies.GetEnumerator();
        }
    }
}
