using System;


namespace UnitParsing
{
    public class InfantryFactory : IUnitFactory
    {
        public bool CanCreateUnit(UnitData unitData)
        {
            return unitData.type == UnitTypes.infantry.ToString();
        }

        public IUnit CreateUnit(UnitData unitData)
        {
            if (unitData.type != UnitTypes.infantry.ToString())
                throw new ArgumentException($"Can't create unit type of {unitData.type}.");

            Infantry infantry = new Infantry(unitData.health);
            return infantry;
        }
    }
}
