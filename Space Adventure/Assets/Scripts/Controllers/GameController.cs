using System.Collections.Generic;
using UnityEngine;


namespace Asteroids
{
    public class GameController : MonoBehaviour
    {

        [SerializeField] private PlayerSettings _playerSettings;
        [SerializeField] private ShotSettings _shotSettings;
        [SerializeField] private EnemySettings _asteroidSettings;
        [SerializeField] private EnemySettings _fighterSettings;

        private List<IUpdateble> _updatebles;

        private void Start()
        {
            var poolServices = new PoolServices();
            var playerFactory = new PlayerShipFactory(_playerSettings, _shotSettings, poolServices);
            Ship playerShip = playerFactory.CreateShip();
            IScreen screen = new Screen(Camera.main);

            MoveController moveController = new MoveController(playerShip, playerShip, screen);
            ShotController shotController = new ShotController(playerShip, screen, poolServices);

            var asteroidFactory = new AsteroidFactory(_asteroidSettings, poolServices);
            var asteroidSpawner = new EnemySpawner(_asteroidSettings, asteroidFactory);
            AsteroidsController asteroidsController = new AsteroidsController(_asteroidSettings, asteroidSpawner, poolServices, screen);

            var fighterFactory = new FighterFactory(_fighterSettings, poolServices);
            var fighterSpawner = new EnemySpawner(_fighterSettings, fighterFactory);
            FightersController fightersController = new FightersController(_fighterSettings, fighterSpawner, poolServices, playerShip, screen);

            _updatebles = new List<IUpdateble>();
            _updatebles.Add(moveController);
            _updatebles.Add(shotController);
            _updatebles.Add(asteroidsController);
            _updatebles.Add(fightersController);

        }

        private void Update()
        {
            foreach (var updateble in _updatebles)
            {
                updateble.Update(Time.deltaTime);
            }
        }

    }
}
