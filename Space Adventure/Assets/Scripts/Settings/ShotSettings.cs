using UnityEngine;


namespace Asteroids
{
    [CreateAssetMenu(fileName = "ShotSettings", menuName = "Data/ShotSettings")]
    public class ShotSettings : ScriptableObject
    {
        public float Force;
        public float ReloadTimeSec;
        public GameObject Bullet;
        public GameObject Barrel;
        public Vector2 BarrelPositon;
        public float Damage;
    }
}
