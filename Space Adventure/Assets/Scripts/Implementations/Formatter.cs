using System;


namespace Asteroids
{
    public class Formatter : IFormatter
    {
        public string FormatValue(int value)
        {
            int units = value;
            int degrees = 0;
            while (units >= 1000)
            {
                units = units / 1000;
                degrees++;
            }
            string degreReduciton = GetDegreReduction(degrees);
            return $"{units}{degreReduciton}";
        }

        private string GetDegreReduction(int degrees)
        {
            if (degrees <= 0)
                return string.Empty;

            switch (degrees)
            {
                case 1: return "K";
                case 2: return "M";
                case 3: return "B";
                default:
                    return "Holy shit!";
            }
        }
    }
}
