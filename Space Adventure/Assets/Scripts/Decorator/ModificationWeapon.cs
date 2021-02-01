namespace Asteroids.Decorator
{
    internal abstract class ModificationWeapon : IFire
    {
        private Weapon _weapon;
        
        protected abstract Weapon AddModification(Weapon weapon);
        protected abstract Weapon DeleteModification(Weapon weapon);
        
        public void ApplyModification(Weapon weapon)
        {
            _weapon = AddModification(weapon);
        }

        public void RemoveModification(Weapon weapon)
        {
            _weapon = DeleteModification(weapon);
        }

        public void Fire()
        {
            _weapon.Fire();
        }
    }
}
