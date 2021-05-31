namespace Asteroids
{
    public interface IBullet
    {
        AttackType AttackType { get; }
        float Damage { get; }
    }
}
