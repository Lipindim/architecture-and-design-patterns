using UnityEngine;


namespace Asteroids.Decorator
{
    public class Sight : ISight
    {
        public GameObject SightInstance { get; }

        public Sight(GameObject sightInstanse)
        {
            SightInstance = sightInstanse;
        }
    }
}
