using System;


namespace Asteroids
{
    public static class Randomizer
    {
        private static Random random = new Random();
        public static bool GetBool()
        {
            int randomInt = random.Next(2);
            if (randomInt == 0)
                return false;
            else
                return true;
        }
    }
}
