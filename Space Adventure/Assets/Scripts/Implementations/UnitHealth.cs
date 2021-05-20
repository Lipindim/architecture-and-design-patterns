using System;
using UnityEngine;

namespace Asteroids
{
    public class UnitHealth : IHealthing
    {
        public event Action<IHealthing> OnDestroy;

        public float Health => _currentHealth;

        private float _currentHealth;

        public UnitHealth(float maxHealth)
        {
            _currentHealth = maxHealth;
        }
        

        public void GetDamage(float damage)
        {
            _currentHealth -= damage;

            if (_currentHealth <= 0)
            {
                OnDestroy?.Invoke(this);
            }
        }
    }
}
