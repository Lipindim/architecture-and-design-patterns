namespace Asteroids
{
    public class UnityTimer
    {
        private float _timeUntilNextSpawn;
        private float _interval;

        public bool IsTimeUp
        {
            get
            {
                return _timeUntilNextSpawn <= 0;
            }
        }

        public UnityTimer(float interval, float startToFirst)
        {
            _interval = interval;
            _timeUntilNextSpawn = startToFirst;
        }

        public void Tick(float deltaTime)
        {
            _timeUntilNextSpawn -= deltaTime;
        }

        public void Reset()
        {
            _timeUntilNextSpawn = _interval;
        }
    }
}
