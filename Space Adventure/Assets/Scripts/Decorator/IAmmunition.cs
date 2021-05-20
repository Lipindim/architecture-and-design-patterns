using UnityEngine;

namespace Asteroids.Decorator
{
    public interface IAmmunition
    {
        Rigidbody BulletInstance { get; }
        float TimeToDestroy { get; }
    }
}
