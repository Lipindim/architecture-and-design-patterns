using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Asteroids
{
    public class GameController : MonoBehaviour
    {

        [SerializeField] private PlayerSettings _playerSettings;
        [SerializeField] private ShotSettings _shotSettings;
        [SerializeField] private EnemySettings _asteroidSettings;
        [SerializeField] private EnemySettings _fighterSettings;
        [SerializeField] private ShotSettings _fighterShotSettings;
        [SerializeField] private Text _scoreText;

        private IEnumerable<IUpdateble> _updatebles;

        private void Start()
        {
            GameInitializer gameInitializer = new GameInitializer();
            _updatebles = gameInitializer.Initialize(_playerSettings, 
                _shotSettings, 
                _asteroidSettings, 
                _fighterSettings, 
                _fighterShotSettings,
                _scoreText);
        }

        private void Update()
        {
            foreach (var updateble in _updatebles)
            {
                updateble.Update(Time.deltaTime);
            }
        }

    }
}
