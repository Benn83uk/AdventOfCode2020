using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.App.Baggage
{
    public class BagRule
    {
        private readonly string _color;
        private readonly BagRule[] _children;

        public BagRule(string color, params string[] containsColors)
        {
            _color = color;
            var children = new List<BagRule>();
            foreach (var childColor in containsColors)
            {
                var bagRule = children.FirstOrDefault(br => br._color.Equals(childColor)) ?? new BagRule(childColor);
                children.Add(bagRule);
            }

            _children = children.ToArray();
        }

        public bool CanContain(string color)
        {
            return _children.Where(child => child._color.Equals(color)).Count() > 0;
        }
    }
}