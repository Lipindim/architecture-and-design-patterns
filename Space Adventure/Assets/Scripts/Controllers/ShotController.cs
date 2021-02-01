using System;
using System.Collections.Generic;
using UnityEngine;


namespace Asteroids
{
    internal class ShotController : IUpdateble
    {
        private readonly PoolServices _poolServices;
        private readonly IScreen _screen;
        private readonly IShoting _shoting;
        private readonly List<GameObject> _bullets;

        internal ShotController(IShoting shoting, IScreen screen, PoolServices poolServices)
        {
            _poolServices = poolServices;
            _screen = screen;
            _shoting = shoting;
            _bullets = new List<GameObject>();
        }

        public void Update(float deltaTime)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                _bullets.Add(_shoting.Shot());
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
