using UnityEngine;


namespace Asteroids
{
    internal interface IShoting
    {
         bool TryShot(out GameObject bullet);
    }
}
