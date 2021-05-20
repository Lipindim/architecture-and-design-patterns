using System;


namespace Asteroids
{
    public class ShipShotingWithReload : IShoting
    {
        private readonly ShipShoting _shipShoting;
        private readonly float _reloadTime;
        private DateTime? _lastShotTime;

        public ShipShotingWithReload(ShipShoting shipShoting, float reloadSeconds)
        {
            _shipShoting = shipShoting;
            _reloadTime = reloadSeconds;
        }

        public event Action OnShot
        {
            add
            {
                _shipShoting.OnShot += value;
            }
            remove
            {
                _shipShoting.OnShot -= value;
            }
        }

        public bool TryShot(out Bullet bullet)
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
