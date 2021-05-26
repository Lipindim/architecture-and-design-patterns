using UnityEngine;


namespace Asteroids
{
    public interface IScreen
    {
        bool IsPositionOutOfScreen(Vector3 position);
        Vector3 WorldToScreenPoint(Vector3 position);
        float GetPixelHeight();
    }
}
