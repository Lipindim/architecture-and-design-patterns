using System;
using UnityEngine;


namespace Asteroids
{
    internal interface IShoting
    {
        event Action OnShot;
        bool TryShot(out Bullet bullet);
    }
}
