using System.Collections.Generic;
using UnityEngine;


namespace Asteroids
{
    internal class FightersController : IUpdateble
    {
        private readonly IScreen _screen;
        private readonly IEnemySpawner _enemySpawner;
        private readonly IMove _playerMove;
        private readonly UnityTimer _timer;
        private readonly PoolServices _poolServices;
        private readonly List<Enemy> _fighters;

        internal FightersController(EnemySettings fighterSettings, IEnemySpawner enemySpawner, PoolServices poolServices, IMove playerMove, IScreen screen)
        {
            _screen = screen;
            _poolServices = poolServices;
            _enemySpawner = enemySpawner;
            _playerMove = playerMove;

            _fighters = new List<Enemy>();
            _timer = new UnityTimer(fighterSettings.SpawnIntervalTime, 0);
        }

        private void Spawn(float deltaTime)
        {
            _timer.Tick(deltaTime);
            if (_timer.IsTimeUp)
            {
                var fighter = _enemySpawner.SpawnEnemyInRandomPosition();
                _fighters.Add(fighter);
                _timer.Reset();
            }
        }

        public void Update(float deltaTime)
        {
            Spawn(deltaTime);

            for (int i = 0; i < _fighters.Count; i++)
            {
                IMove move = _fighters[i] as IMove;
                move.Move(0, 0, deltaTime);

                IRotation rotation = _fighters[i] as IRotation;
                Vector3 directionToRotate = _playerMove.CurrentPosition - move.CurrentPosition;
                rotation.Rotation(directionToRotate);

                if (_screen.IsPositionOutOfScreen(move.CurrentPosition))
                {
                    _poolServices.Destroy(_fighters[i].GameObject);
                    _fighters.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}
