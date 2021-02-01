using System;
using System.Collections.Generic;


namespace UnitParsing
{
    public class CompositeFactory : IUnitFactory
    {
        private readonly IEnumerable<IUnitFactory> _factories;

        public CompositeFactory(IEnumerable<IUnitFactory> factories)
        {
            _factories = factories;
        }
        public bool CanCreateUnit(UnitData unitData)
        {
            foreach (IUnitFactory unitFactory in _factories)
            {
                if (unitFactory.CanCreateUnit(unitData))
                {
                    return true;
                }
            }

            return false;
        }

        public IUnit CreateUnit(UnitData unitData)
        {
            foreach (IUnitFactory unitFactory in _factories)
            {
                if (unitFactory.CanCreateUnit(unitData))
                {
                    return unitFactory.CreateUnit(unitData);
                }
            }

            throw new ArgumentException($"Can't create unit type of  {unitData.type}");
        }
    }
}
