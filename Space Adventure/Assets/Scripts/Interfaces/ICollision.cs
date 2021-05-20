using System;


namespace Asteroids
{
    public interface ICollision
    {
        event Action<Unit> OnCollision;
        void Collision(Unit unit);
    }
}
