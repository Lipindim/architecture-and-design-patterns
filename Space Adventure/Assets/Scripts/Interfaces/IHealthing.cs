using System;


namespace Asteroids
{
    internal interface IHealthing
    {
        event Action<IHealthing> OnDestroy;
        float Health { get; }
        void GetDamage(float damage);
    }

}
