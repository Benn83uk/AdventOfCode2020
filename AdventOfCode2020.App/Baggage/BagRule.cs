using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.App.Baggage
{
    public class BagRule
    {
        private readonly string _color;
        private readonly List<BagRule> _children;

        public BagRule(string color)
        {
            _color = color;
            _children = new List<BagRule>();
        }

        public void AddRule(BagRule rule)
        {
            _children.Add(rule);
        }

        public bool CanContain(string color)
        {
            return CanContain(color, new List<BagRule>());
        }
        
        private bool CanContain(string color, List<BagRule> visitedRules)
        {
            if (visitedRules.Contains(this)) return false;
            visitedRules.Add(this);
            if (_color.Equals(color)) return true;
            return _children.Exists(child => child.CanContain(color, visitedRules));
        }
    }
}