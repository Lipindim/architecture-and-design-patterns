using System;
using UnityEngine;


namespace Asteroids
{
    internal class ShipShotingWithLock : IShoting
    {
        private readonly ShipShoting _shipShoting;
        private DateTime? _lockTime;
        private float _lockDuration;

        internal ShipShotingWithLock(ShipShoting shipShoting)
        {
            _shipShoting = shipShoting;
        }

        public void Lock(float duration)
        {
            _lockDuration = duration;
            _lockTime = DateTime.UtcNow;
        }

        public bool TryShot(out GameObject bullet)
        {
            if (IsNotLock())
                return _shipShoting.TryShot(out bullet);

            bullet = null;
            return false;
        }

        private bool IsNotLock()
        {
            if (_lockTime == null)
                return true;

            double spendSecondsFromLock = (DateTime.UtcNow - _lockTime.Value).TotalSeconds;
            if (_lockDuration < spendSecondsFromLock)
                return true;
            else
                return false;
        }
    }
}
