namespace UnitParsing
{
    public interface IUnitFactory
    {
        IUnit CreateUnit(UnitData unitData);
        bool CanCreateUnit(UnitData unitData);
    }
}
