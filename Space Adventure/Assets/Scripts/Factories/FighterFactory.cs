namespace Asteroids
{
    internal class FighterFactory : IEnemyFactory
    {
        private readonly FighterSettings _fighterSettings;
        private readonly PoolServices _poolServices;

        internal FighterFactory(FighterSettings fighterSettings, PoolServices poolServices)
        {
            _fighterSettings = fighterSettings;
            _poolServices = poolServices;
        }

        public Enemy Create()
        {
            var fighterObject = _poolServices.Create(_fighterSettings.Prefab);
            var move = new LinearDownMove(fighterObject.transform, _fighterSettings.Speed);
            var rotarion = new RotationShip(fighterObject.transform);
            var fighter = new Fighter(fighterObject, move, rotarion);
            return fighter;
        }
    }
}
