using System;


namespace Asteroids
{
    internal interface ICollision
    {
        event Action<Unit> OnCollision;
        void Collision(Unit unit);
    }
}
