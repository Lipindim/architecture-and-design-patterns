namespace Asteroids
{
    public interface IEnemyFactory
    {
        EnemyType EnemyType { get; }
        Enemy Create();
    }
}
