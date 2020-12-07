using AdventOfCode2020.App.Baggage;
using NUnit.Framework;

namespace AdventOfCode2020.Test.Baggage
{
    [TestFixture]
    public class BagRuleTest
    {
        [Test]
        public void BagCanContainFadedBlueBag()
        {
            var bag = new BagRule("Bright White", "Faded Blue");
            Assert.That(bag.CanContain("Faded Blue"), Is.True);
        }
        
        [Test]
        public void BagCanNotContainMutedYellowBag()
        {
            var bag = new BagRule("White", "Blue");
            Assert.That(bag.CanContain("Muted Yellow"), Is.False);
        }
        
        [Test]
        public void BagContainsNoOtherBags()
        {
            var bag = new BagRule("White");
            Assert.That(bag.CanContain("Dotted Black"), Is.False);
        }
    }
}