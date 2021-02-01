namespace UnitParsing
{
    public class Mag : IUnit
    {
        private int _health;
        public int Health => _health;

        public Mag(int health)
        {
            _health = health;
        }
    }
}
