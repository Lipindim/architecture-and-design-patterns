using UnityEngine;


namespace Asteroids
{
    internal interface IScreen
    {
        bool IsPositionOutOfScreen(Vector3 position);
        Vector3 WorldToScreenPoint(Vector3 position);
    }
}
