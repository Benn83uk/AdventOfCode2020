using AdventOfCode2020.App.Ferry;
using NUnit.Framework;

namespace AdventOfCode2020.Test.Ferry
{
    [TestFixture]
    public class CoordinateTest
    {
        [Test]
        public void RotateCoordinateLeftOnce()
        {
            var coord = new Coordinate(1,1);
            var result = coord.RotateLeft(90);
            var expected = new Coordinate(-1,1);
            Assert.That(result, Is.EqualTo(expected));
        }
        
        
        [Test]
        public void RotateCoordinateLeftTwice()
        {
            var coord = new Coordinate(1,1);
            var result = coord.RotateLeft(180);
            var expected = new Coordinate(-1,-1);
            Assert.That(result, Is.EqualTo(expected));
        }
        
        [Test]
        public void RotateCoordinateRightOnce()
        {
            var coord = new Coordinate(1,1);
            var result = coord.RotateRight(90);
            var expected = new Coordinate(1,-1);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}