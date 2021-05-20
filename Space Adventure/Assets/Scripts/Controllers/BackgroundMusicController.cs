using UnityEngine;


namespace Asteroids
{
    public class BackgroundMusicController
    {
        private readonly AudioSource _audioSource;

        public BackgroundMusicController(AudioSource audioSource)
        {
            _audioSource = audioSource;
        }

        public void StartMusic(AudioClip audioClip)
        {
            _audioSource.PlayOneShot(audioClip);
        }

        public void StopMusic()
        {
            _audioSource.Stop();
        }
    }
}
