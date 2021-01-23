using UnityEngine;


namespace Asteroids
{
    [CreateAssetMenu(fileName = "PlayerSettings", menuName = "Data/PlayerSettings")]
    public class PlayerSettings : ScriptableObject
    {
        public float StartPositoinX;
        public float StartPositionY;
        public float Speed;
        public float Acceleration;
        public float Hp;
        public GameObject PlayerPrefab;
    }
}
