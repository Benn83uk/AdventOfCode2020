using System.Linq;

namespace AdventOfCode2020.App.Baggage
{
    public class BagRule
    {
        private readonly string _color;
        private readonly string[] _containsColors;

        public BagRule(string color, params string[] containsColors)
        {
            _color = color;
            _containsColors = containsColors;
        }

        public bool CanContain(string color)
        {
            return _containsColors.Contains(color);
        }
    }
}