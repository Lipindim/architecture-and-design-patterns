using System;
using UnityEngine;


namespace Asteroids
{
    public class ShipShoting : IShoting
    {
        private readonly AttackType _attackType;
        private readonly int _damage;
        private readonly PoolServices _poolServices;
        private readonly GameObject _bullet;
        private readonly Transform _barrel;
        public event Action OnShot;

        private readonly float _force;

        public ShipShoting(GameObject bullet, Transform barrel, float force, PoolServices poolServices, AttackType attackType, int damage)
        {
            _attackType = attackType;
            _damage = damage;
            _poolServices = poolServices;
            _bullet = bullet;
            _barrel = barrel;
            _force = force;
        }


        public bool TryShot(out Bullet bullet)
        {
            GameObject bulletObject = _poolServices.Create(_bullet);
            bulletObject.transform.position = _barrel.position;
            bulletObject.transform.rotation = _barrel.rotation;
            var bulletRigidBody = bulletObject.GetComponent<Rigidbody2D>();
            bulletRigidBody.AddForce(_barrel.right * _force);
            bullet = new Bullet(_damage, _attackType, bulletObject, bulletObject.transform);

            OnShot?.Invoke();

            return true;
        }
    }
}
