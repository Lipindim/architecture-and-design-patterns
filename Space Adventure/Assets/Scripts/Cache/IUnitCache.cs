using System;
using System.Collections;


namespace Asteroids
{
    public interface IUnitCache<T> : IEnumerable where T: Unit
    {
        event Action<T> OnAdd;
        event Action<T> OnRemove;
        void AddUnit(T unit);
        void AddToRemoveUnit(T unit);
        void Clear();
    }
}
