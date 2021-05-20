using UnityEngine;


namespace Asteroids
{
    [CreateAssetMenu(fileName = "EnemySettings", menuName = "Data/EnemySettings")]
    public class EnemySettings : ScriptableObject
    {
        public EnemyType EnemyType;
        public GameObject Prefab;
        public float Speed;
        public float SpawnIntervalTime;
        public float SpawnPositionY;
        public float SpawnStartPoisitionX;
        public float SpawnEntPositionX;
        public float Health;
        public int Score;
        public ShotSettings ShotSettings;
    }
}
