namespace Asteroids
{
    public class PlayerParalysisController
    {
        private readonly IHealthing _playerHealthing;
        private readonly ICollision _playerCollision;
        private readonly ShipShotingWithLock _shipShotingWithLock;

        public PlayerParalysisController(ICollision playerCollision, ShipShotingWithLock shipShotingWithLock, IHealthing playerHealthing)
        {
            _playerHealthing = playerHealthing;
            _playerCollision = playerCollision;
            _shipShotingWithLock = shipShotingWithLock;

            _playerCollision.OnCollision += OnPlayerCollision;
        }

        ~ PlayerParalysisController()
        {
            _playerCollision.OnCollision -= OnPlayerCollision;
        }

        private void OnPlayerCollision(Unit unit)
        {
            if (unit is IBullet bullet)
            {
                if (bullet.AttackType == AttackType.Paralysis)
                    _shipShotingWithLock.Lock(bullet.Damage);
                else if (bullet.AttackType == AttackType.Damage)
                    _playerHealthing.GetDamage(bullet.Damage);
            }
            else if (unit is Enemy enemy)
            {
                if (enemy.EnemyType == EnemyType.Asteroid)
                    _playerHealthing.GetDamage(1.0f);
                else if (enemy.EnemyType == EnemyType.Bomber)
                    _playerHealthing.GetDamage(3.0f);
            }
        }
    }
}
