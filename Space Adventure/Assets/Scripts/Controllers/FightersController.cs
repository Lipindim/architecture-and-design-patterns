using System.Collections.Generic;
using UnityEngine;


namespace Asteroids
{
    internal class FightersController : IUpdateble
    {
        private readonly FighterSettings _fighterSettings;
        private readonly PoolServices _poolServices;
        private readonly IEnemyFactory _fighterFactory;
        private readonly IMove _playerMove;
        private List<Enemy> _fighters;

        private float _timeUntilNextSpawn;

        internal FightersController(FighterSettings fighterSettings, IEnemyFactory fighterFactory, PoolServices poolServices, IMove playerMove)
        {
            _fighterSettings = fighterSettings;
            _poolServices = poolServices;
            _fighterFactory = fighterFactory;
            _playerMove = playerMove;

            _fighters = new List<Enemy>();
        }

        private void Spawn(float deltaTime)
        {
            _timeUntilNextSpawn -= deltaTime;
            if (_timeUntilNextSpawn <= 0)
            {
                var asteroid = _fighterFactory.Create();
                _fighters.Add(asteroid);
                _timeUntilNextSpawn = _fighterSettings.SpawnIntervalTime;
                asteroid.GameObject.transform.position = GetNewPosition();
            }
        }

        private Vector3 GetNewPosition()
        {
            float x = Random.Range(_fighterSettings.SpawnStartPoisitionX, _fighterSettings.SpawnEntPositionX);
            return new Vector3(x, _fighterSettings.SpawnPositionY);
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

                if (move.CurrentPosition.y < 0)
                {
                    _poolServices.Destroy(_fighters[i].GameObject);
                    _fighters.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}
