using UnityEngine;


namespace Asteroids
{
    public class Bullet : Unit
    {
        private readonly Transform _transform;

        public int Damage { get; private set; }

        public Bullet(int damage, GameObject gameObject, Transform transform)
        {
            Damage = damage;
            GameObject = gameObject;
            _transform = transform;
        }
    }
}
