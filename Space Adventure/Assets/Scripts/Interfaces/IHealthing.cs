using System;


namespace Asteroids
{
    internal interface IHealthing
    {
        event Action OnDestroy;
        float Health { get; }
        void GetDamage(float damage);
    }

}
