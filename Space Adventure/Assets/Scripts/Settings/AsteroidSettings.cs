using UnityEngine;


namespace Asteroids
{
    [CreateAssetMenu(fileName = "AsteroidSettings", menuName = "Data/AsteroidSettings")]
    public class AsteroidSettings : ScriptableObject
    {
        public GameObject Prefab;
        public float Speed;
        public float SpawnIntervalTime;
        public float SpawnPositionY;
        public float SpawnStartPoisitionX;
        public float SpawnEntPositionX;

    }
}
