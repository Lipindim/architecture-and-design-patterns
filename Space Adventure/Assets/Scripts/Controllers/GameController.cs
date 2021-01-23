using System.Collections.Generic;
using UnityEngine;


namespace Asteroids
{
    public class GameController : MonoBehaviour
    {

        [SerializeField] private PlayerSettings _playerSettings;
        [SerializeField] private ShotSettings _shotSettings;

        private List<IUpdateble> _updatebles;

        private void Start()
        {
            var player = PlayerInitializer.Initialize(_playerSettings);
            MoveController moveController = MoveControllerInitializer.Initialize(player.transform, _playerSettings, Camera.main);
            ShotController shotController = ShotControllerInitializer.Initialize(_shotSettings, player.transform);
            _updatebles.Add(moveController);
            _updatebles.Add(shotController);

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
