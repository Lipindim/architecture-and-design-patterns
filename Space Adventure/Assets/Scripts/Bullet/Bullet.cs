using UnityEngine;


namespace Asteroids
{
    public class Bullet : Unit, IBullet
    {
        public float Damage { get; private set; }

        public AttackType AttackType { get; private set; }

        public Bullet(float damage, AttackType attackType, GameObject gameObject)
        {
            AttackType = attackType;
            Damage = damage;
            GameObject = gameObject;
        }
    }
}
