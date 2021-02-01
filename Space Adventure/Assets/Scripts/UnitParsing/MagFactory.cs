using System;


namespace UnitParsing
{
    public class MagFactory : IUnitFactory
    {
        public bool CanCreateUnit(UnitData unitData)
        {
            return unitData.type == UnitTypes.mag.ToString();
        }

        public IUnit CreateUnit(UnitData unitData)
        {
            if (unitData.type != UnitTypes.mag.ToString())
                throw new ArgumentException($"Can't create unit type of {unitData.type}.");

            Mag mag = new Mag(unitData.health);
            return mag;
        }
    }
}
