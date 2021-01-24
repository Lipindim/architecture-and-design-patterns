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

        public GameObject Shot()
        {
            var bullet = _poolServices.Create(_bullet);
            bullet.transform.position = _barrel.position;
            bullet.transform.rotation = _barrel.rotation;
            var bulletRigidBody = bullet.GetComponent<Rigidbody2D>();
            bulletRigidBody.AddForce(_barrel.right * _force);
            return bullet;
        }
    }
}
