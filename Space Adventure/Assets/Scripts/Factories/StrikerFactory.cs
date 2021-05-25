
using UnityEngine;

namespace Asteroids
{
    public class StrikerFactory : IEnemyFactory
    {
        private readonly EnemySettings _strikerSettings;
        private readonly PoolServices _poolServices;
        private readonly ILocation _playerLocation;
        private readonly float _distance = 10.0f;

        public EnemyType EnemyType => EnemyType.Striker;

        public StrikerFactory(EnemySettings fighterSettings, PoolServices poolServices, ILocation playerLocation)
        {
            _strikerSettings = fighterSettings;
            _poolServices = poolServices;
            _playerLocation = playerLocation;
        }

        public Enemy Create()
        {
            var enemyObject = _poolServices.Create(_strikerSettings.Prefab);
            var move = new ChaseMove(enemyObject.transform, _playerLocation, _strikerSettings.Speed, _distance);
            var rotarion = new RotationShip(enemyObject.transform);

            var barrel = GameObject.Instantiate(_strikerSettings.ShotSettings.Barrel, enemyObject.transform);
            barrel.transform.localPosition = new Vector3(_strikerSettings.ShotSettings.BarrelPositon.x, _strikerSettings.ShotSettings.BarrelPositon.y);
            ShipShoting shipShoting = new ShipShoting(_strikerSettings.ShotSettings.Bullet, barrel.transform, _strikerSettings.ShotSettings.Force, _poolServices, AttackType.Damage, 1);
            ShipShotingWithReload shipShotingWithReload = new ShipShootingWithReloadAndRange(shipShoting, _strikerSettings.ShotSettings.ReloadTimeSec, 15.0f, _playerLocation, enemyObject.transform);
            var healthing = new UnitHealth(_strikerSettings.Health);

            var enemy = new ShootingEnemy(enemyObject, move, rotarion, shipShotingWithReload, healthing, _strikerSettings.Score, EnemyType);
            return enemy;
        }
    }
}
