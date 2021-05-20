using UnityEngine;


namespace Asteroids
{
    public interface IEnemySpawner
    {
        EnemyType EnemyType { get; }
        Enemy SpawnEnemyInRandomPosition();
        Enemy SpawnEnemyInPosition(Vector3 position);
    }
}
