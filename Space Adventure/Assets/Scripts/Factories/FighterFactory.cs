using UnityEngine;


namespace Asteroids
{
    public class FighterFactory : IEnemyFactory
    {
        private readonly EnemySettings _fighterSettings;
        private readonly PoolServices _poolServices;

        public EnemyType EnemyType => EnemyType.Fighter;

        public FighterFactory(EnemySettings fighterSettings, PoolServices poolServices)
        {
            _fighterSettings = fighterSettings;
            _poolServices = poolServices;
        }

        public Enemy Create()
        {
            var fighterObject = _poolServices.Create(_fighterSettings.Prefab);
            var move = new LinearDownMove(fighterObject.transform, _fighterSettings.Speed);
            var rotarion = new RotationShip(fighterObject.transform);

            var barrel = GameObject.Instantiate(_fighterSettings.ShotSettings.Barrel, fighterObject.transform);
            barrel.transform.localPosition = new Vector3(_fighterSettings.ShotSettings.BarrelPositon.x, _fighterSettings.ShotSettings.BarrelPositon.y);
            ShipShoting shipShoting = new ShipShoting(_fighterSettings.ShotSettings.Bullet, barrel.transform, _fighterSettings.ShotSettings.Force, _poolServices, AttackType.Paralysis, 2);
            ShipShotingWithReload shipShotingWithReload = new ShipShotingWithReload(shipShoting, _fighterSettings.ShotSettings.ReloadTimeSec);
            var healthing = new UnitHealth(_fighterSettings.Health);

            var fighter = new ShootingEnemy(fighterObject, move, rotarion, shipShotingWithReload, healthing, _fighterSettings.Score, EnemyType);
            return fighter;
        }
    }
}
