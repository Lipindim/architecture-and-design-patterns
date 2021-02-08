using UnityEngine;


namespace Asteroids
{
    public interface IBullet
    {
        int Damage { get; }
        Vector3 Position { get; }
        GameObject GameObject { get; }
    }
}
