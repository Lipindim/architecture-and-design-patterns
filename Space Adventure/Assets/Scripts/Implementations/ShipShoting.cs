using UnityEngine;


namespace Asteroids
{
    internal class ShipShoting : IShoting
    {
        private readonly PoolServices _poolServices;
        private readonly GameObject _bullet;
        private readonly Transform _barrel;

        private readonly float _force;

        internal ShipShoting(GameObject bullet, Transform barrel, float force, PoolServices poolServices)
        {
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
            bullet = new Bullet(1, bulletObject, bulletObject.transform);

            return true;
        }
    }
}
