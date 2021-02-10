using System.Collections.Generic;
using UnityEngine;


namespace Asteroids
{
    internal class ShotController : IUpdateble
    {
        private readonly IUnitCache<Bullet> _bulletCache;
        private readonly IScreen _screen;
        private readonly IShoting _shoting;

        internal ShotController(IShoting shoting, IScreen screen, IUnitCache<Bullet> bulletCache)
        {
            _bulletCache = bulletCache;
            _screen = screen;
            _shoting = shoting;
        }

        public void Update(float deltaTime)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (_shoting.TryShot(out Bullet bullet))

                    _bulletCache.AddUnit(bullet);
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
