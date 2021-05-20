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
            var waspObject = _poolServices.Create(_waspSettings.Prefab);
            var move = new LinearDownMove(waspObject.transform, _waspSettings.Speed);
            var rotarion = new RotationShip(waspObject.transform);

            var barrel = GameObject.Instantiate(_waspSettings.ShotSettings.Barrel, waspObject.transform);
            barrel.transform.localPosition = new Vector3(_waspSettings.ShotSettings.BarrelPositon.x, _waspSettings.ShotSettings.BarrelPositon.y);
            ShipShoting shipShoting = new ShipShoting(_waspSettings.ShotSettings.Bullet, barrel.transform, _waspSettings.ShotSettings.Force, _poolServices, AttackType.Damage, 1);
            ShipShotingWithReload shipShotingWithReload = new ShipShotingWithReload(shipShoting, _waspSettings.ShotSettings.ReloadTimeSec);
            var healthing = new UnitHealth(_waspSettings.Health);

            var fighter = new Fighter(waspObject, move, rotarion, shipShotingWithReload, healthing, _waspSettings.Score);
            return fighter;
        }
    }
}
