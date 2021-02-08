using UnityEngine;


namespace Asteroids
{
    public abstract class Unit
    {
        public GameObject GameObject { get; protected set; }
        public Vector3 Position
        {
            get
            {
                return GameObject.transform.position;
            }
        }
    }
}
