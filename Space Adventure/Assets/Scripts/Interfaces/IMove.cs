using UnityEngine;

namespace Asteroids
{
    public interface IMove : ILocation
    {
        float Speed { get; }
        void Move(float horizontal, float vertical, float deltaTime);

    }
}
