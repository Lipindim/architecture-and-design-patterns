using UnityEngine;

namespace Asteroids
{
    public class RoundsController
    {
        private readonly BackgroundMover _backgroundMover;
        private readonly BackgroundMusicController _backgroundMusicController;
        private readonly EnemySpawnController _enemySpawnController;
        private readonly RoundSettings[] _roundsSettings;

        private int _currentRound;

        public RoundsController(RoundSettings[] roundsSettings, BackgroundMusicController backgroundMusicController, EnemySpawnController enemySpawnController, BackgroundMover backgroundMover)
        {
            _backgroundMusicController = backgroundMusicController;
            _enemySpawnController = enemySpawnController;
            _roundsSettings = roundsSettings;
            _backgroundMover = backgroundMover;

            _enemySpawnController.OnSpawnCompleted += EnemySpawnControllerOnSpawnCompleted;
        }

        private void EnemySpawnControllerOnSpawnCompleted()
        {
            Debug.Log("Раунд завершен");
            _currentRound++;
            if (_currentRound < _roundsSettings.Length)
                StartRound(_roundsSettings[_currentRound]);
        }

        public void Start()
        {
            _currentRound = 0;
            StartRound(_roundsSettings[_currentRound]);
        }

        private void StartRound(RoundSettings roundSettings)
        {
            _enemySpawnController.SetSpawnEnemies(roundSettings.Enemies, roundSettings.Duration);
            _backgroundMusicController.StopMusic();
            _backgroundMusicController.StartMusic(roundSettings.BackgroundMusic);
            _backgroundMover.SetBackgroundImage(roundSettings.Background, roundSettings.Duration);
        }

        ~RoundsController()
        {
            _enemySpawnController.OnSpawnCompleted -= EnemySpawnControllerOnSpawnCompleted;
        }

    }
}
