using System;
using UnityEngine;


namespace Asteroids
{
    internal class ShipShotingWithReload : IShoting
    {
        private readonly ShipShoting _shipShoting;
        private readonly float _reloadTime;
        private DateTime? _lastShotTime;

        public ShipShotingWithReload(ShipShoting shipShoting, float reloadSeconds)
        {
            _shipShoting = shipShoting;
            _reloadTime = reloadSeconds;
        }
        public bool TryShot(out GameObject bullet)
        {
            if (IReload())
            {
                bullet = null;
                return false;
            }


            if (_shipShoting.TryShot(out bullet))
            {
                _lastShotTime = DateTime.UtcNow;
                return true;
            }
            else
            {
                return false;
            }
            
        }

        private bool IReload()
        {
            if (_lastShotTime == null)
                return false;

            double spendSecondsFromShot = (DateTime.UtcNow - _lastShotTime.Value).TotalSeconds;
            if (spendSecondsFromShot <_reloadTime)
                return true;
            else
                return false;
        }
    }
}
