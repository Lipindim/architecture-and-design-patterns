using UnityEngine;
using UnityEngine.UI;


namespace Asteroids
{
    internal class ScoreController
    {
        private readonly IFormatter _formatter;
        private readonly Text _scoreText;
        private readonly IUnitCache<Enemy> _enemiesCache;
        private int _totalScore = 0;

        public ScoreController(IUnitCache<Enemy> enemiesCache, Text scoreText, IFormatter formatter)
        {
            _formatter = formatter;
            _scoreText = scoreText;
            _enemiesCache = enemiesCache;
            _enemiesCache.OnAdd += EnemiesCacheOnAdd;
            _enemiesCache.OnRemove += EnemiesCacheOnRemove;
        }

        ~ScoreController()
        {
            _enemiesCache.OnAdd -= EnemiesCacheOnAdd;
            _enemiesCache.OnRemove -= EnemiesCacheOnRemove;
        }

        private void EnemiesCacheOnAdd(Enemy enemy)
        {
            if (enemy is IHealthing healthing)
                healthing.OnDestroy += HealthingOnDestroy;
        }

        private void HealthingOnDestroy(IHealthing healthing)
        {
            if (healthing is Enemy enemy)
            {
                _totalScore += enemy.Score;
                _scoreText.text = $"Score: {_formatter.FormatValue(_totalScore)}";
            }
        }

        private void EnemiesCacheOnRemove(Enemy enemy)
        {
            if (enemy is IHealthing healthing)
                healthing.OnDestroy -= HealthingOnDestroy;
        }
    }
}
