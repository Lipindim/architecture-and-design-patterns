using System;


namespace Asteroids
{
    internal class ShipHealth : IHealthing
    {
        public event Action OnDestroy;

        public float Health => _currentHealth;

        private float _currentHealth;

        internal ShipHealth(float maxHealth)
        {
            _currentHealth = maxHealth;
        }
        

        public void GetDamage(float damage)
        {
            _currentHealth -= damage;

            if (_currentHealth <= 0)
            {
                OnDestroy?.Invoke();
            }
        }
    }
}
