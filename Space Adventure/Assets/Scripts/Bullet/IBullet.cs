using UnityEngine;


namespace Asteroids
{
    public interface IBullet
    {
        AttackType AttackType { get; }
        int Damage { get; }
    }
}
