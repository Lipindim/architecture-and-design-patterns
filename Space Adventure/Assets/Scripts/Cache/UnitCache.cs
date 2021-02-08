using System;
using System.Collections;
using System.Collections.Generic;


namespace Asteroids
{
    internal class UnitCache<T> : IUnitCache<T> where T : Unit
    {
        private readonly PoolServices _poolServices;
        private IList<T> _units;
        private IList<T> _unitsToRemove;

        public event Action<T> OnAdd;
        public event Action<T> OnRemove;

        internal UnitCache(PoolServices poolServices)
        {
            _poolServices = poolServices;
            _units = new List<T>();
            _unitsToRemove = new List<T>();
        }

        public void AddUnit(T unit)
        {
            if (unit == null)
                throw new ArgumentNullException(nameof(unit));

            _units.Add(unit);
            OnAdd?.Invoke(unit);
        }

        public void AddToRemoveUnit(T unit)
        {
            if (_units.Contains(unit))
            {
                _unitsToRemove.Add(unit);
                OnRemove?.Invoke(unit);
            }
        }

        public void Clear()
        {
            foreach (T unitToRemove in _unitsToRemove)
            {
                _units.Remove(unitToRemove);
                _poolServices.Destroy(unitToRemove.GameObject);
            }

            _unitsToRemove.Clear();
        }

        public IEnumerator GetEnumerator()
        {
            return _units.GetEnumerator();
        }
    }
}
