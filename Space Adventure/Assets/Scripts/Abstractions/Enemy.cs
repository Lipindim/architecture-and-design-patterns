using UnityEngine;


namespace Asteroids
{
    public abstract class Enemy : Unit
    {
        public int Score { get; protected set; }
    }
}
