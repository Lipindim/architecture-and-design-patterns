using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Asteroids
{
    public class GameController : MonoBehaviour
    {

        [SerializeField] private PlayerSettings _playerSettings;
        [SerializeField] private ShotSettings _shotSettings;
        [SerializeField] private EnemySettings[] _enemiesSettings;
        [SerializeField] private SoundSettings _soundSettings;

        [SerializeField] private Text _scoreText;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioSource _backgroundAudioSource;
        [SerializeField] private RoundSettings[] _roundsSettings;
        [SerializeField] private GameObject _background;

        private IEnumerable<IUpdateble> _updatebles;
        private RoundsController _roundsController;

        private void Start()
        {
            GameInitializer gameInitializer = new GameInitializer();
            (_updatebles, _roundsController) = gameInitializer.Initialize(_playerSettings, 
                _shotSettings, 
                _enemiesSettings, 
                _scoreText,
                _audioSource,
                _soundSettings,
                _backgroundAudioSource,
                _roundsSettings,
                _background);

            _roundsController.Start();
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
