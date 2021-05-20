using UnityEngine;


namespace Asteroids
{
    [CreateAssetMenu(fileName = "RoundSettings", menuName = "Data/RoundSettings")]
    public class RoundSettings : ScriptableObject
    {
        public float Duration;
        public AudioClip BackgroundMusic;
        public EnemyCountSettings[] Enemies;
        public BossType Boss;
    }
}
