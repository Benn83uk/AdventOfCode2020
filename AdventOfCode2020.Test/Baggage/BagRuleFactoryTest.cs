using AdventOfCode2020.App.Baggage;
using NUnit.Framework;

namespace AdventOfCode2020.Test.Baggage
{
    [TestFixture]
    public class BagRuleFactoryTest
    {
        [Test]
        public void CanCreateSimpleRuleFromSentence()
        {
            var expected = new BagRule[]
            {
                new BagRule("dotted black"),
            };
            var bagRules = BagRuleFactory.Create("dotted black bags contain no other bags.");
            Assert.That(bagRules, Is.EquivalentTo(expected));
        }
    }
}