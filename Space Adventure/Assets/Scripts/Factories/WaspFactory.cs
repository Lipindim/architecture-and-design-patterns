using UnityEngine;


namespace Asteroids
{
    public class WaspFactory : IEnemyFactory
    {
        private readonly EnemySettings _waspSettings;
        private readonly PoolServices _poolServices;

        public EnemyType EnemyType => EnemyType.Wasp;

        public WaspFactory(EnemySettings fighterSettings, PoolServices poolServices)
        {
            _waspSettings = fighterSettings;
            _poolServices = poolServices;
        }

        public Enemy Create()
        {
            var enemyObject = _poolServices.Create(_waspSettings.Prefab);
            var move = new DiagonalDownMove(enemyObject.transform, _waspSettings.Speed, _waspSettings.Speed / 1.5f, _waspSettings.SpawnStartPoisitionX, _waspSettings.SpawnEntPositionX);
            var rotarion = new RotationShip(enemyObject.transform);

            var barrel = GameObject.Instantiate(_waspSettings.ShotSettings.Barrel, enemyObject.transform);
            barrel.transform.localPosition = new Vector3(_waspSettings.ShotSettings.BarrelPositon.x, _waspSettings.ShotSettings.BarrelPositon.y);
            ShipShoting shipShoting = new ShipShoting(_waspSettings.ShotSettings.Bullet, barrel.transform, _waspSettings.ShotSettings.Force, _poolServices, AttackType.Damage, 1);
            ShipShotingWithReload shipShotingWithReload = new ShipShotingWithReload(shipShoting, _waspSettings.ShotSettings.ReloadTimeSec);
            var healthing = new UnitHealth(_waspSettings.Health);

            var enemy = new ShootingEnemy(enemyObject, move, rotarion, shipShotingWithReload, healthing, _waspSettings.Score, EnemyType);
            return enemy;
        }
    }
}
