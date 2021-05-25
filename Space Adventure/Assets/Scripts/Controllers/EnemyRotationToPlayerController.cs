using UnityEngine;


namespace Asteroids
{
    public class EnemyRotationToPlayerController : IUpdateble
    {
        private readonly ILocation _playerLocation;
        private readonly IUnitCache<Enemy> _enemyCache;

        public EnemyRotationToPlayerController(IUnitCache<Enemy> enemyCache, ILocation playerLocation)
        {
            _enemyCache = enemyCache;
            _playerLocation = playerLocation;
        }
        public void Update(float deltaTime)
        {
            foreach (Enemy enemy in _enemyCache)
            {
                if (enemy is IRotation rotation && enemy is IMove move)
                {
                    Vector3 directionToRotate = _playerLocation.CurrentPosition - move.CurrentPosition;
                    rotation.Rotation(directionToRotate);
                }
            }
        }
    }
}
