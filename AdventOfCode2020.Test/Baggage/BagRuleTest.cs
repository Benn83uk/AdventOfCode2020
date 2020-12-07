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
            var bag = new BagRule("Bright White");
            bag.AddRule(new BagRule("Faded Blue"));
            Assert.That(bag.CanContain("Faded Blue"), Is.True);
        }
        
        [Test]
        public void BagCanNotContainMutedYellowBag()
        {
            var bag = new BagRule("Bright White");
            bag.AddRule(new BagRule("Faded Blue"));
            Assert.That(bag.CanContain("Muted Yellow"), Is.False);
        }
        
        [Test]
        public void BagContainsNoOtherBags()
        {
            var bag = new BagRule("White");
            Assert.That(bag.CanContain("Dotted Black"), Is.False);
        }
        
        [Test]
        public void BagContainsBagViaOtherBag()
        {
            var whiteBag = new BagRule("Bright White");
            var blueBag = new BagRule("Faded Blue");
            whiteBag.AddRule(blueBag);
            var yellowBag = new BagRule("Muted Yellow");
            blueBag.AddRule(yellowBag);
            Assert.That(whiteBag.CanContain("Muted Yellow"), Is.True);
        }
        
        [Test]
        public void BagContainsBagViaOtherBagCircular()
        {
            var whiteBag = new BagRule("Bright White");
            var blueBag = new BagRule("Faded Blue");
            whiteBag.AddRule(blueBag);
            var yellowBag = new BagRule("Muted Yellow");
            blueBag.AddRule(yellowBag);
            yellowBag.AddRule(whiteBag);
            Assert.That(whiteBag.CanContain("Muted Yellow"), Is.True);
        }
        
        [Test]
        public void BagDoesNotContainBagViaOtherBagCircular()
        {
            var whiteBag = new BagRule("Bright White");
            var blueBag = new BagRule("Faded Blue");
            whiteBag.AddRule(blueBag);
            var yellowBag = new BagRule("Muted Yellow");
            blueBag.AddRule(yellowBag);
            yellowBag.AddRule(whiteBag);
            Assert.That(whiteBag.CanContain("Dotted Black"), Is.False);
        }
    }
}