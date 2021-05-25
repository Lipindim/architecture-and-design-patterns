namespace Asteroids
{
    public class BobmerFactory : IEnemyFactory
    {
        private readonly EnemySettings _enemySettings;
        private readonly PoolServices _poolServices;
        private readonly ILocation _playerLocation;

        public EnemyType EnemyType => EnemyType.Bomber;

        public BobmerFactory(EnemySettings enemySettings, PoolServices poolServices, ILocation playerLocation)
        {
            _enemySettings = enemySettings;
            _poolServices = poolServices;
            _playerLocation = playerLocation;
        }

        public Enemy Create()
        {
            var enemyObject = _poolServices.Create(_enemySettings.Prefab);
            var move = new ChaseMove(enemyObject.transform, _playerLocation, _enemySettings.Speed, 0.0f);
            var rotarion = new RotationShip(enemyObject.transform);
            var healthing = new UnitHealth(_enemySettings.Health);
            var enemy = new RotationEnemy(move, healthing, rotarion, enemyObject, _enemySettings.Score, EnemyType);
            return enemy;
        }
    }
}
