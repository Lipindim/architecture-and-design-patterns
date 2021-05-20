namespace Asteroids
{
    public class PlayerParalysisController
    {
        private readonly ICollision _playerCollision;
        private readonly ShipShotingWithLock _shipShotingWithLock;

        public PlayerParalysisController(ICollision playerCollision, ShipShotingWithLock shipShotingWithLock)
        {
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
                {
                    _shipShotingWithLock.Lock(bullet.Damage);
                }
            }
        }
    }
}
