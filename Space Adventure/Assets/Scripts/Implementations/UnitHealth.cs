using System;
using UnityEngine;

namespace Asteroids
{
    public class UnitHealth : IHealthing
    {
        public event Action<IHealthing> OnDestroy;
        public event Action<IHealthing> OnGetDamage;

        public float Health => _currentHealth;

        public float MaxHealth { get; private set; }

        private float _currentHealth;

        public UnitHealth(float maxHealth)
        {
            _currentHealth = maxHealth;
            MaxHealth = maxHealth;
        }
        

        public void GetDamage(float damage)
        {
            _currentHealth -= damage;
            OnGetDamage?.Invoke(this);

            if (_currentHealth <= 0)
            {
                OnDestroy?.Invoke(this);
            }
        }
    }
}
