using UnityEngine;


namespace Asteroids
{
    [CreateAssetMenu(fileName = "SoundSettings", menuName = "Data/SoundSettings")]
    public class SoundSettings : ScriptableObject
    {
        public AudioClip PlayerShotSound;
    }
}
