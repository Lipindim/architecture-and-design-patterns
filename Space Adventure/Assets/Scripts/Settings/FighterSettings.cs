using UnityEngine;


namespace Asteroids
{

    [CreateAssetMenu(fileName = "FighterSettings", menuName = "Data/FighterSettings")]
    public class FighterSettings : ScriptableObject
    {
        public GameObject Prefab;
        public float Speed;
        public float SpawnIntervalTime;
        public float SpawnPositionY;
        public float SpawnStartPoisitionX;
        public float SpawnEntPositionX;
    }
}
