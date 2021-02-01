using System.Collections.Generic;
using UnityEngine;

namespace UnitParsing
{
    public class ParsingStartController : MonoBehaviour
    {
        [SerializeField] private string _dataFilePath;

        private void Start()
        {
            MagFactory magFactory = new MagFactory();
            InfantryFactory infantryFactory = new InfantryFactory();
            IUnitFactory[] factories = new IUnitFactory[] { magFactory, infantryFactory };
            CompositeFactory compositeFactory = new CompositeFactory(factories);

            UnitParser unitParser = new UnitParser();
            IEnumerable<UnitContainer> unitContainers = unitParser.GetUnitContainersFromFile(_dataFilePath);

            List<IUnit> units = new List<IUnit>();
            foreach (var unitContainer in unitContainers)
            {
                IUnit unit = compositeFactory.CreateUnit(unitContainer.unit);
                units.Add(unit);
                Debug.Log(unit.GetType());
            }
        }

    }
}
