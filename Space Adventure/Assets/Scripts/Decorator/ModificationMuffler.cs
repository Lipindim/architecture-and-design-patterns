using UnityEngine;

namespace Asteroids.Decorator
{
    internal sealed class ModificationMuffler : ModificationWeapon
    {
        private readonly AudioSource _audioSource;
        private readonly IMuffler _muffler;
        private readonly Vector3 _mufflerPosition;
        private GameObject _mufflerObject;
        private AudioClip _initialAudioClip;
        private Transform _initialBarrelPosition;

        public ModificationMuffler(AudioSource audioSource, IMuffler muffler, Vector3 mufflerPosition)
        {
            _audioSource = audioSource;
            _muffler = muffler;
            _mufflerPosition = mufflerPosition;
        }
        
        protected override Weapon AddModification(Weapon weapon)
        {
            _mufflerObject = Object.Instantiate(_muffler.MufflerInstance, _mufflerPosition, Quaternion.identity);
            _audioSource.volume = _muffler.VolumeFireOnMuffler;
            _initialAudioClip = weapon.AudioClip;
            _initialBarrelPosition = weapon.BarrelPosition;
            weapon.SetAudioClip(_muffler.AudioClipMuffler);
            weapon.SetBarrelPosition(_muffler.BarrelPositionMuffler);
            return weapon;
        }

        protected override Weapon DeleteModification(Weapon weapon)
        {
            weapon.SetAudioClip(_initialAudioClip);
            weapon.SetBarrelPosition(_initialBarrelPosition);
            Object.Destroy(_mufflerObject);
            return weapon;
        }
    }
}
