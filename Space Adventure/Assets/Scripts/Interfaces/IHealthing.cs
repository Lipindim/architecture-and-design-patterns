using System;


namespace Asteroids
{
    public interface IHealthing
    {
        event Action<IHealthing> OnDestroy;
        event Action<IHealthing> OnGetDamage;
        float Health { get; }
        float MaxHealth { get; }
        void GetDamage(float damage);
    }

}
