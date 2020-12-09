using System;
using System.IO;
using System.Linq;
using AdventOfCode2020.App.Encryption;
using NUnit.Framework;

namespace AdventOfCode2020.Test.Encryption
{
    [TestFixture]
    public class XmasTest
    {
        [Test]
        public void ValidForPreeambleOfTwo()
        {
            var xmas = new Xmas(2, new int[] {1, 2, 3});
            Assert.Throws<XmasException>(() => xmas.FirstInvalidNumber());
        }
        
        [Test]
        public void InvalidForPreeambleOfTwo()
        {
            var xmas = new Xmas(2, new int[] {1, 2, 4});
            Assert.That(xmas.FirstInvalidNumber(), Is.EqualTo(4));
        }
        
        [Test]
        public void InvalidForPreeambleOfTwoLongerString()
        {
            var xmas = new Xmas(2, new int[] {1, 2, 3, 4, 8, 12});
            Assert.That(xmas.FirstInvalidNumber(), Is.EqualTo(4));
        }
        
        [Test]
        public void InvalidForPreeambleOfThreeLongerString()
        {
            var xmas = new Xmas(3, new int[] {1, 2, 3, 4, 8, 12});
            Assert.That(xmas.FirstInvalidNumber(), Is.EqualTo(8));
        }
        
        [Test]
        public void DayNineTaskOneExample()
        {
            var sequence = new[] {35, 20, 15, 25, 47, 40, 62, 55, 65, 95, 102, 117, 150, 182, 127, 219, 299, 277, 309, 576};
            var xmas = new Xmas(5, sequence);
            Assert.That(xmas.FirstInvalidNumber(), Is.EqualTo(127));
        }

        [Test]
        public void DayNineTaskOneExampleFromFile()
        {
            var lines = File.ReadAllLines("TestFiles/DayNineExample.txt");
            var sequence = lines.Select(l => int.Parse(l)).ToArray();
            var xmas = new Xmas(5, sequence);
            Assert.That(xmas.FirstInvalidNumber(), Is.EqualTo(127));
        }
    }
}