using UnityEngine;


namespace Asteroids
{
    internal class EnemyRotationToPlayerController : IUpdateble
    {
        private readonly IMove _playerMove;
        private readonly IEnemyCache _enemyCache;

        public EnemyRotationToPlayerController(IEnemyCache enemyCache, IMove playerMove)
        {
            _enemyCache = enemyCache;
            _playerMove = playerMove;
        }
        public void Update(float deltaTime)
        {
            foreach (Enemy enemy in _enemyCache)
            {
                if (enemy is Fighter fighter)
                {
                    Vector3 directionToRotate = _playerMove.CurrentPosition - fighter.CurrentPosition;
                    fighter.Rotation(directionToRotate);
                }
            }
        }
    }
}
