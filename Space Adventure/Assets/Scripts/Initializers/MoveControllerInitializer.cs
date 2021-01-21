using System;
using UnityEngine;


namespace Asteroids
{
    internal static class MoveControllerInitializer
    {
        internal static MoveController Initialize(Transform playerTransform, PlayerSettings playerSettings, Camera camera)
        {
            if (playerSettings == null)
                throw new ArgumentNullException(nameof(playerSettings));
            if (playerTransform == null)
                throw new ArgumentNullException(nameof(playerTransform));
            if (camera == null)
                throw new ArgumentNullException(nameof(camera));

            var moveTransform = new AccelerationMove(playerTransform, playerSettings.Speed, playerSettings.Acceleration);
            var rotation = new RotationShip(playerTransform);
            Ship ship = new Ship(moveTransform, rotation);
            return new MoveController(ship, camera, playerTransform);
        }
    }
}
