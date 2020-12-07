using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.App.Baggage
{
    public class BagRule
    {
        private readonly string _color;
        private readonly Dictionary<BagRule, int> _children;

        public BagRule(string color)
        {
            _color = color;
            _children = new Dictionary<BagRule, int>();
        }

        public void AddRule(BagRule rule)
        {
            AddRule(rule, 0);
        }

        public void AddRule(BagRule rule, int numBags)
        {
            _children.Add(rule, 0);
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
            return _children.Keys.Count(child => child.CanContain(color, visitedRules)) > 0;
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
            var bags = BagsFor(color, new List<BagRule>(), new List<BagRule>());
            if (this._color.Equals("ROOT"))
            {
                bags.Remove(this);
            }

            return bags.Count();
        }
        
        private List<BagRule> BagsFor(string color, List<BagRule> visitedRules, List<BagRule> currentValid)
        {
            if (visitedRules.Contains(this)) return new List<BagRule>();
            visitedRules.Add(this);
            if (CanContain(color) && !_color.Equals(color)) currentValid.Add(this);
            foreach (var child in _children)
            {
                child.Key.BagsFor(color, visitedRules, currentValid);
            }

            return currentValid;
        }
        
        public static BagRule Create(params string[] ruleStr)
        {
            var rulesList = new List<BagRule>();
            
            foreach(var rule in ruleStr)
            {
                var matchColor = Regex.Match(rule, "(?<color>.*?) bags contain");
                var color = matchColor.Groups["color"].Value;
                var currentBag = new BagRule(color);
                rulesList.Add(currentBag);
            }
            
            foreach(var rule in ruleStr)
            {
                var matchNoChildren = Regex.Match(rule, "bags contain no other bags");
                if (matchNoChildren.Success)
                {
                    continue;
                }
                
                var matchColor = Regex.Match(rule, "(?<color>.+?) bags contain");
                var color = matchColor.Groups["color"].Value;
                var currentBag = rulesList.First(b => b._color == color);

                var ruleChildren = rule.Replace(matchColor.Value, "");

                var matchChildren = Regex.Matches(ruleChildren, "(?<number>[0-9]+?) (?<color>[a-z\\s]+?) bag");
                foreach (Match matchChild in matchChildren)
                {
                    var childColor = matchChild.Groups["color"].Value;
                    var childBag = rulesList.First(b => b._color == childColor);
                    currentBag.AddRule(childBag);
                }
            }
            
            var root = new BagRule("ROOT");
            foreach (var rule in rulesList)
            {
                root.AddRule(rule);
            }

            return root;
        }
    }
}