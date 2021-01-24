using System;
using System.Collections.Generic;
using UnityEngine;


namespace Asteroids
{
    internal class ShotController : IUpdateble
    {
        private readonly PoolServices _poolServices;
        private readonly Camera _camera;
        private readonly IShoting _shoting;
        private readonly List<GameObject> _bullets;

        internal ShotController(IShoting shoting, Camera camera, PoolServices poolServices)
        {
            _poolServices = poolServices;
            _camera = camera;
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
                if (IsPositionOutOfScreen(_bullets[i].transform.position))
                {
                    _poolServices.Destroy(_bullets[i]);
                    _bullets.RemoveAt(i);
                    i--;
                }
            }
        }

        private bool IsPositionOutOfScreen(Vector3 position)
        {
            Vector3 point = _camera.WorldToViewportPoint(position);
            return point.y < 0.0f
                || point.y > 1.0f
                || point.x > 1.0f
                || point.x < 0.0f;
        }
    }
}
