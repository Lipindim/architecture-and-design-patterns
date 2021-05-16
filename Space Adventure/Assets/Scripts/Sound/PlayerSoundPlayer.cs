using UnityEngine;

namespace Asteroids
{
    internal class PlayerAudioPlayer
    {
        private readonly SoundSettings _soundSettings;
        private readonly AudioSource _audioSource;
        private readonly IShoting _playerShoting;

        public PlayerAudioPlayer(IShoting playerShoting, SoundSettings soundSettings, AudioSource audioSource)
        {
            _soundSettings = soundSettings;
            _audioSource = audioSource;

            playerShoting.OnShot += PlayPlayerShotSound;
            _playerShoting = playerShoting;
        }

        ~ PlayerAudioPlayer()
        {
            _playerShoting.OnShot -= PlayPlayerShotSound;
        }

        private void PlayPlayerShotSound()
        {
            _audioSource.PlayOneShot(_soundSettings.PlayerShotSound);
        }
    }
}
