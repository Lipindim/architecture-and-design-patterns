using System.Collections.Generic;
using UnityEngine;


namespace Asteroids
{
    public class GameController : MonoBehaviour
    {

        [SerializeField] private PlayerSettings _playerSettings;
        [SerializeField] private ShotSettings _shotSettings;
        [SerializeField] private AsteroidSettings _asteroidSettings;
        [SerializeField] private FighterSettings _fighterSettings;

        private List<IUpdateble> _updatebles;

        private void Start()
        {
            var poolServices = new PoolServices();
            var playerFactory = new PlayerShipFactory(_playerSettings, _shotSettings, poolServices);
            var playerShip = playerFactory.CreateShip();

            MoveController moveController = new MoveController(playerShip, playerShip, Camera.main);
            ShotController shotController = new ShotController(playerShip, Camera.main, poolServices);

            var asteroidFactory = new AsteroidFactory(_asteroidSettings, poolServices);
            AsteroidsController asteroidsController = new AsteroidsController(_asteroidSettings, asteroidFactory, poolServices);
            var fighterFactory = new FighterFactory(_fighterSettings, poolServices);
            FightersController fightersController = new FightersController(_fighterSettings, fighterFactory, poolServices, playerShip);

            _updatebles = new List<IUpdateble>();
            _updatebles.Add(moveController);
            _updatebles.Add(shotController);
            _updatebles.Add(asteroidsController);
            _updatebles.Add(fightersController);
            //_updatebles.Add(shotController);

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
