using UnityEngine;

namespace Asteroids
{
    internal class EnemyDestroyController : IUpdateble
    {
        private readonly IUnitCache<Enemy> _enemyCache;
        private readonly IScreen _screen;

        public EnemyDestroyController(IUnitCache<Enemy> enemyCache, IScreen screen)
        {
            _enemyCache = enemyCache;
            _screen = screen;
        }

        public void Update(float deltaTime)
        {
            foreach (Enemy enemy in _enemyCache)
            {
                if (enemy is IMove enemyMove)
                {
                    if (_screen.IsPositionOutOfScreen(enemyMove.CurrentPosition))
                    {
                        _enemyCache.AddToRemoveUnit(enemy);
                    }
                }
            }

            _enemyCache.Clear();
        }
    }
}
