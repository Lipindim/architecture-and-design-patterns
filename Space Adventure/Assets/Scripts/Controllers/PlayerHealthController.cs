namespace Asteroids
{
    public class PlayerHealthController
    {
        private readonly IHealthing _playerHealth;
        private readonly HealthView _healthView;

        public PlayerHealthController(IHealthing playerHealth, HealthView healthView)
        {
            _playerHealth = playerHealth;
            _playerHealth.OnGetDamage += PlayerHealthOnGetDamage;
            _healthView = healthView;
        }

        private void PlayerHealthOnGetDamage(IHealthing playerHealth)
        {
            float healthValue = playerHealth.Health / playerHealth.MaxHealth;
            _healthView.SetHealthValue(healthValue);
        }

        ~PlayerHealthController()
        {
            _playerHealth.OnGetDamage -= PlayerHealthOnGetDamage;
        }
    }
}
