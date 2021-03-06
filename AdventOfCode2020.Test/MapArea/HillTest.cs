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
            Assert.That(hill.CountTreesOnSlope(new Gradient(0, 1)), Is.EqualTo(0));
        }
        
        [Test]
        public void OneTreeInFirstColumn()
        {
            var hill = new Hill(
                new Slope("..#"),
                new Slope(".#."),
                new Slope("#.#")
            );
            Assert.That(hill.CountTreesOnSlope(new Gradient(0, 1)), Is.EqualTo(1));
        }

        [Test]
        public void TwoTreesInDiagonal()
        {
            var hill = new Hill(
                new Slope("..#"),
                new Slope(".#."),
                new Slope("..#")
            );
            Assert.That(hill.CountTreesOnSlope(new Gradient(1, 1)), Is.EqualTo(2));
        }

        [Test]
        public void DayThreeExample()
        {
            var hill = new Hill("TestFiles/DayThreeExample.txt");
            Assert.That(hill.CountTreesOnSlope(new Gradient(3, 1)), Is.EqualTo(7));
        }
        
        [Test]
        public void DayThreeTaskOne()
        {
            var hill = new Hill("TestFiles/DayThreeInput.txt");
            Assert.That(hill.CountTreesOnSlope(new Gradient(3, 1)), Is.EqualTo(191));
        }

        [Test]
        public void ProductOfTreesOnSlopes()
        {
            var hill = new Hill(
                new Slope("..#"),
                new Slope("##."),
                new Slope("#.#")
            );
            var straightDown = new Gradient(0, 1);
            var diagonal = new Gradient(1, 1);
            Assert.That(hill.ProductOfTreesOnSlopes(straightDown, diagonal), Is.EqualTo(4));
        }
        
        [Test]
        public void DayThreeTaskTwo()
        {
            var hill = new Hill("TestFiles/DayThreeInput.txt");
            Assert.That(hill.ProductOfTreesOnSlopes(
                new Gradient(1, 1),
                new Gradient(3, 1),
                new Gradient(5, 1),
                new Gradient(7, 1),
                new Gradient(1, 2)
                ), Is.EqualTo(1478615040));
        }
    }
}