using UnityEngine;


namespace Asteroids
{
    public class CollisionController : IUpdateble
    {
        private readonly IUnitCache<Enemy> _enemiesCache;
        private readonly IUnitCache<Bullet> _playerBulletsCache;

        public CollisionController(IUnitCache<Enemy> enemiesCache, IUnitCache<Bullet> playerBulletsCache)
        {
            _enemiesCache = enemiesCache;
            _playerBulletsCache = playerBulletsCache;
        }

        public void Update(float deltaTime)
        {
            foreach (Bullet bullet in _playerBulletsCache)
            {
                foreach (Enemy enemy in _enemiesCache)
                {
                    Vector3 distanse = bullet.Position - enemy.Position;
                    if (distanse.sqrMagnitude < 2)
                    {
                        if (enemy is IHealthing healthing)
                            healthing.GetDamage(bullet.Damage);

                        _playerBulletsCache.AddToRemoveUnit(bullet);
                        break;
                    }
                }
            }

            _enemiesCache.Clear();
            _playerBulletsCache.Clear();
        }
    }
}
