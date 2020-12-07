using System.IO;
using AdventOfCode2020.App.Baggage;
using Castle.DynamicProxy.Generators;
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
            Assert.That(root.NumBagsFor("shiny gold"), Is.EqualTo(4));
        }
        
        [Test]
        public void CanCreateSimpleRuleFromSentence()
        {
            var expected = new BagRule("ROOT");
            var blackBag = new BagRule("dotted black");
            expected.AddRule(blackBag);
            
            var bagRules = BagRule.Create("dotted black bags contain no other bags.");
            Assert.That(bagRules, Is.EqualTo(expected));
        }
        
        [Test]
        public void CanCreateSimpleRuleFromMultipleSentences()
        {
            var expected = new BagRule("ROOT");
            var blueBag = new BagRule("blue");
            expected.AddRule(blueBag);
            var blackBag = new BagRule("dotted black");
            expected.AddRule(blackBag);

            var bagRules = BagRule.Create(
                "blue bags contain no other bags",
                "dotted black bags contain no other bags.");
            Assert.That(bagRules, Is.EqualTo(expected));
        }

        [Test]
        public void DaySevenExampleFromFile()
        {
            var lines = File.ReadAllLines("TestFiles/DaySevenExample.txt");
            var root = BagRule.Create(lines);
            Assert.That(root.NumBagsFor("shiny gold"), Is.EqualTo(4));
        }
        
        [Test]
        public void CanCreateSimpleRulesMultipleSentencesColorExists()
        {
            var root = BagRule.Create(
                "blue bags contain 1 dotted black bag",
                "dotted black bags contain no other bags.");
            Assert.That(root.NumBagsFor("dotted black"), Is.EqualTo(1));
        }
        
        [Test]
        public void CanCreateSimpleRulesMultipleSentencesColorDoesNotExist()
        {
            var root = BagRule.Create(
                "blue bags contain 1 dotted black bag",
                "dotted black bags contain no other bags.");
            Assert.That(root.NumBagsFor("shiny gold"), Is.EqualTo(0));
        }
        
        [Test]
        public void CanCreateMoreComplexRulesMultipleSentences()
        {
            var root = BagRule.Create(
                "blue bags contain 1 dotted black bag, 3 faded blue bags.",
                "dotted black bags contain 2 faded blue bag",
                "faded blue bags contain no other bags.");
            Assert.That(root.NumBagsFor("faded blue"), Is.EqualTo(2));
        }
        
        [Test]
        public void DaySevenTaskOne()
        {
            var lines = File.ReadAllLines("TestFiles/DaySevenInput.txt");
            var root = BagRule.Create(lines);
            Assert.That(root.NumBagsFor("shiny gold"), Is.EqualTo(164));
        }
        
        [Test]
        public void NumBagsRequiredSimple()
        {
            var whiteBag = new BagRule("Bright White");
            var blueBag = new BagRule("Faded Blue");
            whiteBag.AddRule(blueBag, 2);
            var yellowBag = new BagRule("Muted Yellow");
            blueBag.AddRule(yellowBag, 3);
            Assert.That(whiteBag.BagsRequired(), Is.EqualTo(8)); // 2 blue + 2 * 3 yellow
        }
        
        [Test]
        public void DaySevenExampleCountBags()
        {
            var lines = File.ReadAllLines("TestFiles/DaySevenExample.txt");
            var root = BagRule.Create(lines);
            Assert.That(root.BagsRequiredFor("shiny gold"), Is.EqualTo(32));
        }
        
        [Test]
        public void DaySevenExample2CountBags()
        {
            var lines = File.ReadAllLines("TestFiles/DaySevenExample2.txt");
            var root = BagRule.Create(lines);
            Assert.That(root.BagsRequiredFor("shiny gold"), Is.EqualTo(126));
        }
        
        [Test]
        public void DaySevenTaskTwoAnswer()
        {
            var lines = File.ReadAllLines("TestFiles/DaySevenInput.txt");
            var root = BagRule.Create(lines);
            Assert.That(root.BagsRequiredFor("shiny gold"), Is.EqualTo(7872));
        }
    }
}