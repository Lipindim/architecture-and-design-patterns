using UnityEngine;


namespace Asteroids
{
    public class ShipShootingWithReloadAndRange : ShipShotingWithReload, IShoting
    {
        private readonly ILocation _target;
        private readonly Transform _transform;
        private float _attackRangeSqr;

        public ShipShootingWithReloadAndRange(ShipShoting shipShoting, float reloadSeconds, float attackRange, ILocation target, Transform transform) : base(shipShoting, reloadSeconds)
        {
            _target = target;
            _transform = transform;
            _attackRangeSqr = attackRange * attackRange;
        }


        public new bool TryShot(out Bullet bullet)
        {
            float sqrToTarget = (_transform.position - _target.CurrentPosition).sqrMagnitude;
            Debug.Log(sqrToTarget);
            if (_attackRangeSqr > sqrToTarget)
            {
                return base.TryShot(out bullet);
            }
            else
            {
                bullet = null;
                return false;
            }

        }
    }
}
