using System;
using UnityEngine;


namespace Asteroids
{
    public interface IShoting
    {
        event Action OnShot;
        bool TryShot(out Bullet bullet);
    }
}
