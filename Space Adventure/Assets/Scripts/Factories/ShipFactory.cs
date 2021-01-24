using UnityEngine;

namespace Asteroids
{
    internal class PlayerShipFactory
    {
        private readonly PlayerSettings _playerSettings;
        private readonly ShotSettings _shotSettings;
        private readonly PoolServices _poolServices;

        public PlayerShipFactory(PlayerSettings playerSettings, ShotSettings shotSettings, PoolServices poolServices)
        {
            _playerSettings = playerSettings;
            _shotSettings = shotSettings;
            _poolServices = poolServices;
        }

        public Ship CreateShip()
        {
            Vector3 startPosition = new Vector3(_playerSettings.StartPositoinX, _playerSettings.StartPositionY);
            var shipObject = GameObject.Instantiate(_playerSettings.PlayerPrefab, startPosition, Quaternion.identity);
            var moveTransform = new AccelerationMove(shipObject.transform, _playerSettings.Speed, _playerSettings.Acceleration);
            var rotation = new RotationShip(shipObject.transform);
            

            var barrel = GameObject.Instantiate(_shotSettings.Barrel, shipObject.transform);
            barrel.transform.localPosition = new Vector3(_shotSettings.BarrelPositon.x, _shotSettings.BarrelPositon.y);
            ShipShoting shipShoting = new ShipShoting(_shotSettings.Bullet, barrel.transform, _shotSettings.Force, _poolServices);

            Ship playerShip = new Ship(moveTransform, rotation, null, shipShoting);
            return playerShip;
        }
    }
}
