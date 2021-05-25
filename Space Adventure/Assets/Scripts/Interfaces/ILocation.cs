using UnityEngine;


namespace Asteroids
{
    public interface ILocation
    {
        Vector3 CurrentPosition { get; }
    }
}
