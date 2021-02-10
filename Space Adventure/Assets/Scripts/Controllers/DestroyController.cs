using System;
using UnityEngine;


namespace Asteroids
{
    public class DestroyController
    {
        private readonly IUnitCache<Enemy> _enemyCache;

        public DestroyController(IUnitCache<Enemy> enemiesCache)
        {
            _enemyCache = enemiesCache;
            _enemyCache.OnAdd += EnemyCacheOnAdd;
            _enemyCache.OnRemove += EnemyCacheOnRemove;
        }

        private void EnemyCacheOnAdd(Enemy enemy)
        {
            if (enemy is IHealthing healthing)
                healthing.OnDestroy += EnemyOnDestroy;
        }

        private void EnemyCacheOnRemove(Enemy enemy)
        {
            if (enemy is IHealthing healthing)
                healthing.OnDestroy -= EnemyOnDestroy;
        }

        private void EnemyOnDestroy(IHealthing healthing)
        {
            Debug.Log($"Убит.");

            if (healthing is Enemy enemy)
                _enemyCache.AddToRemoveUnit(enemy);
        }

        
    }
}
