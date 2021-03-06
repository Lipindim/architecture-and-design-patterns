﻿using System;
using UnityEngine;


namespace Asteroids
{
    public class ShipShotingWithLock : IShoting
    {
        private readonly ShipShoting _shipShoting;
        private DateTime? _lockTime;
        private float _lockDuration;

        public ShipShotingWithLock(ShipShoting shipShoting)
        {
            _shipShoting = shipShoting;
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

        public void Lock(float duration)
        {
            _lockDuration = duration;
            _lockTime = DateTime.UtcNow;
        }

        public bool TryShot(out Bullet bullet)
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
