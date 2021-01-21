using System;
using UnityEngine;


namespace Asteroids
{
    internal static class ShotControllerInitializer
    {
        internal static ShotController Initialize(ShotSettings shotSettings, Transform playerTransform)
        {
            if (shotSettings == null)
                throw new ArgumentNullException(nameof(shotSettings));
            if (playerTransform == null)
                throw new ArgumentNullException(nameof(playerTransform));
            if (shotSettings.Bullet == null)
                throw new ArgumentNullException(nameof(shotSettings.Bullet));

            var barrel = GameObject.Instantiate(shotSettings.Barrel, playerTransform);
            ShotController shotController = new ShotController(shotSettings.Bullet, barrel.transform, shotSettings.Force);
            return shotController;
        }
    }
}
