using AdventOfCode2020.App.MapArea;
using NUnit.Framework;

namespace AdventOfCode2020.Test.MapArea
{
    [TestFixture]
    public class HillTest
    {
        [Test]
        public void NoTreesInFirstColumn()
        {
            var hill = new Hill(
                new Slope("..#"),
                new Slope(".#."),
                new Slope("..#")
            );
            Assert.That(hill.CountTreesOnSlope(0, 1), Is.EqualTo(0));
        }
        
        [Test]
        public void OneTreeInFirstColumn()
        {
            var hill = new Hill(
                new Slope("..#"),
                new Slope(".#."),
                new Slope("#.#")
            );
            Assert.That(hill.CountTreesOnSlope(0, 1), Is.EqualTo(1));
        }

        [Test]
        public void TwoTreesInDiagonal()
        {
            var hill = new Hill(
                new Slope("..#"),
                new Slope(".#."),
                new Slope("..#")
            );
            Assert.That(hill.CountTreesOnSlope(1, 1), Is.EqualTo(2));
        }
    }
}