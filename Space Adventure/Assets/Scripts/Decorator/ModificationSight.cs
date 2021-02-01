using System;
using UnityEngine;


namespace Asteroids.Decorator
{
    internal class ModificationSight : ModificationWeapon
    {
        private readonly ISight _sight;
        private readonly Vector3 _sightPosition;
        private GameObject _sightObject;

        public ModificationSight(ISight sight, Vector3 sightPosition)
        {
            _sight = sight;
            _sightPosition = sightPosition;
        }

        protected override Weapon AddModification(Weapon weapon)
        {
            _sightObject = UnityEngine.Object.Instantiate(_sight.SightInstance, _sightPosition, Quaternion.identity);
            return weapon;
        }

        protected override Weapon DeleteModification(Weapon weapon)
        {
            GameObject.Destroy(_sightObject);
            return weapon;
        }
    }
}
