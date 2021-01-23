using UnityEngine;


namespace Asteroids
{
    internal class ShotController : IUpdateble
    {
        private Rigidbody2D _bullet;
        private Transform _barrel;
        private float _force;

        internal ShotController(Rigidbody2D bullet, Transform barrel, float force)
        {
            _bullet = bullet;
            _barrel = barrel;
            _force = force;
        }

        public void Update(float deltaTime)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                var temAmmunition = GameObject.Instantiate(_bullet, _barrel.position, _barrel.rotation);
                temAmmunition.AddForce(_barrel.up * _force);
            }
        }
    }
}
