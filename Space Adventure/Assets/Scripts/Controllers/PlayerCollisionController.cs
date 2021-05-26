using UnityEngine;


namespace Asteroids
{
    public class PlayerCollisionController : IUpdateble
    {
        private readonly Ship _playerShip;
        private readonly IUnitCache<Bullet> _enemyBullets;
        private readonly IUnitCache<Enemy> _enemyCache;

        public PlayerCollisionController(Ship playerShip, IUnitCache<Bullet> enemyBullets, IUnitCache<Enemy> enemyCache)
        {
            _playerShip = playerShip;
            _enemyBullets = enemyBullets;
            _enemyCache = enemyCache;
        }

        public void Update(float deltaTime)
        {
            foreach (Bullet bullet in _enemyBullets)
            {
                Vector3 distanse = bullet.Position - _playerShip.CurrentPosition;
                if (distanse.sqrMagnitude < 2)
                {
                    _playerShip.Collision(bullet);
                    _enemyBullets.AddToRemoveUnit(bullet);
                }
            }
            _enemyBullets.Clear();

            foreach (Enemy enemy in _enemyCache)
            {
                Vector3 distanse = enemy.Position - _playerShip.CurrentPosition;
                if (distanse.sqrMagnitude < 4.0f && (enemy.EnemyType == EnemyType.Asteroid || enemy.EnemyType == EnemyType.Bomber))
                {
                    _playerShip.Collision(enemy);
                    _enemyCache.AddToRemoveUnit(enemy);
                }
            }
            _enemyCache.Clear();
        }
    }
}
