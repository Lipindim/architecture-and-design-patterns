using System;


namespace Asteroids
{
    public interface IHealthing
    {
        event Action<IHealthing> OnDestroy;
        float Health { get; }
        void GetDamage(float damage);
    }

}
