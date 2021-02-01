using System.Collections;


namespace Asteroids
{
    public interface IEnemyCache : IEnumerable
    {
        void AddEnemy(Enemy enemy);
        void AddToRemoveEnemy(Enemy enemy);
        void Clear();
    }
}
