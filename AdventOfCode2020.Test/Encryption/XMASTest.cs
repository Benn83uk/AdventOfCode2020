using System;
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
    }
}