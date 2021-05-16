using UnityEngine;


namespace Asteroids
{
    public class Bullet : Unit, IBullet
    {
        private readonly Transform _transform;

        public int Damage { get; private set; }

        public AttackType AttackType { get; private set; }

        public Bullet(int damage, AttackType attackType, GameObject gameObject, Transform transform)
        {
            AttackType = attackType;
            Damage = damage;
            GameObject = gameObject;
            _transform = transform;
        }
    }
}
