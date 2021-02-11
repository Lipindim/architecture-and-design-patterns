using UnityEngine;


namespace Asteroids
{
    internal class PlayerCollisionController : IUpdateble
    {
        private readonly Ship _playerShip;
        private readonly IUnitCache<Bullet> _enemyBullets;

        public PlayerCollisionController(Ship playerShip, IUnitCache<Bullet> enemyBullets)
        {
            _playerShip = playerShip;
            _enemyBullets = enemyBullets;
        }

        public void Update(float deltaTime)
        {
            foreach (Bullet bullet in _enemyBullets)
            {
                Vector3 distanse = bullet.Position - _playerShip.CurrentPosition;
                if (distanse.sqrMagnitude < 2)
                {
                    _playerShip.Collision(bullet);
                    _enemyBullets.AddToRemoveUnit(bullet);
                }
            }

            _enemyBullets.Clear();
        }
    }
}
