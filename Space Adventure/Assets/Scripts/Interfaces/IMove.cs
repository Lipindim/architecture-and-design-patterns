using UnityEngine;

namespace Asteroids
{
    public interface IMove
    {
        Vector3 CurrentPosition { get; }
        float Speed { get; }
        void Move(float horizontal, float vertical, float deltaTime);

    }
}
