using UnityEngine;


namespace Asteroids
{
    internal interface IEnemySpawner
    {
        Enemy SpawnEnemyInRandomPosition();
        Enemy SpawnEnemyInPosition(Vector3 position);
        bool IsReadyToSpawn();
    }
}
