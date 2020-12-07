using System;
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
        
        protected bool Equals(BagRule other)
        {
            return _color == other._color && _children.SequenceEqual(other._children);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BagRule) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_color, _children);
        }

        public override string ToString()
        {
            return $"{_color} with {_children.Count} childen";
        }

        public int NumBagsFor(string color)
        {
            return BagsFor(color, new List<BagRule>(), new List<BagRule>()).Count();
        }
        
        private List<BagRule> BagsFor(string color, List<BagRule> visitedRules, List<BagRule> currentValid)
        {
            if (visitedRules.Contains(this)) return new List<BagRule>();
            visitedRules.Add(this);
            if (CanContain(color) && !_color.Equals(color)) currentValid.Add(this);
            foreach (var child in _children)
            {
                child.BagsFor(color, visitedRules, currentValid);
            }

            return currentValid;
        }
    }
}