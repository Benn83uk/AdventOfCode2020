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
        
        [Test]
        public void CountColoursWhichCanContainBlack()
        {
            var whiteBag = new BagRule("Bright White");
            var blueBag = new BagRule("Faded Blue");
            whiteBag.AddRule(blueBag);
            var yellowBag = new BagRule("Muted Yellow");
            blueBag.AddRule(yellowBag);
            yellowBag.AddRule(whiteBag);
            Assert.That(whiteBag.NumBagsFor("Dotted Black"), Is.EqualTo(0));
        }
        
        [Test]
        public void CountColoursWhichCanContainYellow()
        {
            var whiteBag = new BagRule("Bright White");
            var blueBag = new BagRule("Faded Blue");
            whiteBag.AddRule(blueBag);
            var yellowBag = new BagRule("Muted Yellow");
            blueBag.AddRule(yellowBag);
            yellowBag.AddRule(whiteBag);
            Assert.That(whiteBag.NumBagsFor("Muted Yellow"), Is.EqualTo(2));
        }

        [Test]
        public void DaySevenExample()
        {
            //light red bags contain 1 bright white bag, 2 muted yellow bags.
            var lightRedBag = new BagRule("light red");
            var brightWhiteBag = new BagRule("bright white");
            lightRedBag.AddRule(brightWhiteBag);
            var mutedYellowBag = new BagRule("muted yellow");
            lightRedBag.AddRule(mutedYellowBag);
            //dark orange bags contain 3 bright white bags, 4 muted yellow bags.
            var darkOrangeBag = new BagRule("dark orange");
            darkOrangeBag.AddRule(brightWhiteBag);
            darkOrangeBag.AddRule(mutedYellowBag);
            //bright white bags contain 1 shiny gold bag.
            var shinyGoldBag = new BagRule("shiny gold");
            brightWhiteBag.AddRule(shinyGoldBag);
            //muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.
            mutedYellowBag.AddRule(shinyGoldBag);
            var fadedBlueBag = new BagRule("faded blue");
            mutedYellowBag.AddRule(fadedBlueBag);
            //shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.
            var darkOliveBag = new BagRule("dark olive");
            var vibrantPlumBag = new BagRule("vibrant plum");
            shinyGoldBag.AddRule(darkOliveBag);
            shinyGoldBag.AddRule(vibrantPlumBag);
            //dark olive bags contain 3 faded blue bags, 4 dotted black bags.
            darkOliveBag.AddRule(fadedBlueBag);
            var dottedBlackBag = new BagRule("dotted black");
            darkOliveBag.AddRule(dottedBlackBag);
            //vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.
            vibrantPlumBag.AddRule(fadedBlueBag);
            vibrantPlumBag.AddRule(dottedBlackBag);
            //faded blue bags contain no other bags.
            //dotted black bags contain no other bags.
            var root = new BagRule("ROOT");
            root.AddRule(lightRedBag);
            root.AddRule(brightWhiteBag);
            root.AddRule(mutedYellowBag);
            root.AddRule(shinyGoldBag);
            root.AddRule(darkOliveBag);
            root.AddRule(darkOrangeBag);
            root.AddRule(dottedBlackBag);
            root.AddRule(fadedBlueBag);
            root.AddRule(vibrantPlumBag);
            Assert.That(root.NumBagsFor("shiny gold")-1, Is.EqualTo(4));
        }
    }
}