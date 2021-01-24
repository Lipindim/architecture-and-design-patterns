using System.Collections.Generic;
using UnityEngine;


namespace Asteroids
{
    internal sealed class PoolServices
    {
        private readonly Dictionary<string, ObjectPool> _poolCache = new Dictionary<string, ObjectPool>();

        public GameObject Create(GameObject gameObject)
        {
            if (!_poolCache.TryGetValue(gameObject.tag, out ObjectPool viewPool))
            {
                viewPool = new ObjectPool(gameObject);
                _poolCache[gameObject.tag] = viewPool;
            }

            return viewPool.Pop();
        }

        public void Destroy(GameObject gameObject)
        {
            if (!_poolCache.TryGetValue(gameObject.tag, out ObjectPool viewPool))
            {
                viewPool = new ObjectPool(gameObject);
                _poolCache[gameObject.tag] = viewPool;
            }

            viewPool.Push(gameObject);
        }
    }

}
