namespace UnitParsing
{
    public class Infantry : IUnit
    {
        private int _health;
        public int Health => _health;

        public Infantry(int health)
        {
            _health = health;
        }
    }
}
