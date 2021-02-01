using UnityEngine;

namespace Asteroids
{
    internal class FighterFactory : IEnemyFactory
    {
        private readonly ShotSettings _fithgerShotSettings;
        private readonly EnemySettings _fighterSettings;
        private readonly PoolServices _poolServices;

        internal FighterFactory(EnemySettings fighterSettings, PoolServices poolServices, ShotSettings fithgerShotSettings)
        {
            _fithgerShotSettings = fithgerShotSettings;
            _fighterSettings = fighterSettings;
            _poolServices = poolServices;
        }

        public Enemy Create()
        {
            var fighterObject = _poolServices.Create(_fighterSettings.Prefab);
            var move = new LinearDownMove(fighterObject.transform, _fighterSettings.Speed);
            var rotarion = new RotationShip(fighterObject.transform);

            var barrel = GameObject.Instantiate(_fithgerShotSettings.Barrel, fighterObject.transform);
            barrel.transform.localPosition = new Vector3(_fithgerShotSettings.BarrelPositon.x, _fithgerShotSettings.BarrelPositon.y);
            ShipShoting shipShoting = new ShipShoting(_fithgerShotSettings.Bullet, barrel.transform, _fithgerShotSettings.Force, _poolServices);
            ShipShotingWithReload shipShotingWithReload = new ShipShotingWithReload(shipShoting, _fithgerShotSettings.ReloadTimeSec);

            var fighter = new Fighter(fighterObject, move, rotarion, shipShotingWithReload);
            return fighter;
        }
    }
}
