using System.Collections.Generic;
using System.IO;
using UnityEngine;


namespace UnitParsing
{
    public class UnitParser
    {
        public IEnumerable<UnitContainer> GetUnitContainers(string json)
        {
            json = FixJson(json);
            UnitsContainer unitsContainer = JsonUtility.FromJson<UnitsContainer>(json);
            return unitsContainer.Items;
        }

        public IEnumerable<UnitContainer> GetUnitContainersFromFile(string filePath)
        {
            string fileData = File.ReadAllText(filePath);
            Debug.Log(fileData);
            return GetUnitContainers(fileData);
        }

        private string FixJson(string value)
        {
            value = "{\"Items\":" + value + "}";
            return value;
        }
    }
}
