using UnityEngine;


namespace Asteroids
{
    internal static class PlayerInitializer
    {
        internal static GameObject Initialize(PlayerSettings playerSettings)
        {
            Vector3 startPosition = new Vector3(playerSettings.StartPositoinX, playerSettings.StartPositionY);
            var player = GameObject.Instantiate(playerSettings.PlayerPrefab, startPosition, Quaternion.identity);
            return player;
        }
    }
}
