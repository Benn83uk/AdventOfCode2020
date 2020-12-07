using System.Text.RegularExpressions;

namespace AdventOfCode2020.App.Baggage
{
    public class BagRuleFactory
    {
        public static BagRule[] Create(string ruleStr)
        {
            var match = Regex.Match(ruleStr, "(?<color>.*?) bags contain");
            var color = match.Groups["color"].Value;
            return new BagRule[]
            {
                new BagRule(color), 
            };
        }
    }
}