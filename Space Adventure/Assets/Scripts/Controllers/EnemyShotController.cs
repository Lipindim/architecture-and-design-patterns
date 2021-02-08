namespace Asteroids
{
    internal class EnemyShotController : IUpdateble
    {
        private readonly IUnitCache<Bullet> _bulletCache;
        private readonly IScreen _screen;
        private readonly IUnitCache<Enemy> _enemyCache;

        internal EnemyShotController(IUnitCache<Enemy> enemyCache, IScreen screen, IUnitCache<Bullet> bulletCache)
        {
            _bulletCache = bulletCache;
            _screen = screen;
            _enemyCache = enemyCache;
        }

        public void Update(float deltaTime)
        {
            foreach (Enemy enemy in _enemyCache)
            {
                if (enemy is IShoting enemyShoting)
                {
                    if (enemyShoting.TryShot(out Bullet bullet))
                        _bulletCache.AddUnit(bullet);
                }
            }

            RemoveBulletsOutOfScreen();
        }

        private void RemoveBulletsOutOfScreen()
        {
            foreach (Bullet bullet in _bulletCache)
            {
                if (_screen.IsPositionOutOfScreen(bullet.Position))
                {
                    _bulletCache.AddToRemoveUnit(bullet);
                }
            }

            _bulletCache.Clear();
        }
    }
}
