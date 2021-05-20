using System.Collections.Generic;
using UnityEngine;


namespace Asteroids
{
    public sealed class ObjectPool
    {
        private readonly Stack<GameObject> _stack = new Stack<GameObject>();
        private readonly GameObject _prefab;

        public ObjectPool(GameObject prefab)
        {
            _prefab = prefab;
        }

        public void Push(GameObject gameObject)
        {
            _stack.Push(gameObject);
            gameObject.SetActive(false);
        }

        public GameObject Pop()
        {
            GameObject gameObject;
            if (_stack.Count == 0)
            {
                gameObject = GameObject.Instantiate(_prefab);
            }
            else
            {
                gameObject = _stack.Pop();
            }
            gameObject.SetActive(true);

            return gameObject;
        }
    }
}
