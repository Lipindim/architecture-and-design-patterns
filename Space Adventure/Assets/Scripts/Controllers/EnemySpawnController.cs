using System;
using System.Collections.Generic;
using System.Linq;


namespace Asteroids
{
    public class EnemySpawnController : IUpdateble
    {
        public event Action OnSpawnCompleted;

        private readonly IEnumerable<IEnemySpawner> _enemySpawners;
        private readonly IUnitCache<Enemy> _enemyCache;
        private Dictionary<EnemyType, int> _enemies;
        private readonly Random _random = new Random();
        private UnityTimer _unityTimer;

        private bool _spawnCompleted;
        private float _spawnInterval;

        public EnemySpawnController(IEnumerable<IEnemySpawner> enemySpawners, IUnitCache<Enemy> enemyCache)
        {
            _enemySpawners = enemySpawners;
            _enemyCache = enemyCache;
        }

        public void SetSpawnEnemies(EnemyCountSettings[] enemiesCountSettings, float duration)
        {
            _enemies = new Dictionary<EnemyType, int>();
            foreach (var enemy in enemiesCountSettings)
                _enemies.Add(enemy.Type, enemy.Count);

            _spawnCompleted = false;
            _spawnInterval = duration / _enemies.Sum(x => x.Value);
            _unityTimer = new UnityTimer(_spawnInterval, 0);
        }

        public void Update(float deltaTime)
        {
            if (_unityTimer != null)
                _unityTimer.Tick(deltaTime);

            if (_enemies != null)
            {
                if (IsSpawnReady())
                {
                    if (_enemies.Sum(x => x.Value) == 0)
                    {
                        _spawnCompleted = true;
                        OnSpawnCompleted?.Invoke();
                    }
                    else
                    {

                        var enemyType = ChoosEnemy();
                        var enemySpawner = _enemySpawners.FirstOrDefault(x => x.EnemyType == enemyType);
                        if (enemySpawner == null)
                            throw new ArgumentException($"Can't find spawner for enemy type: {enemyType}");
                        var enemy = enemySpawner.SpawnEnemyInRandomPosition();
                        _enemyCache.AddUnit(enemy);
                        _enemies[enemyType]--;

                        foreach (var en in _enemies)
                        {
                            UnityEngine.Debug.Log($"{en.Key}:{en.Value}");
                        }
                    }
                }
            }
        }

        private EnemyType ChoosEnemy()
        {
            int totalEnemiesCount = _enemies.Sum(x => x.Value);
            int randomIndex = _random.Next(totalEnemiesCount);

            int currentCount = 0;

            foreach (var enemy in _enemies)
            {
                currentCount += enemy.Value;
                if (currentCount > randomIndex)
                    return enemy.Key;
            }

            return EnemyType.None;
        }

        private bool IsSpawnReady()
        {
            if (_spawnCompleted)
                return false;

            if (_unityTimer.IsTimeUp)
            {
                _unityTimer.Reset();
                return true;
            }

            return false;
        }
    }
}
