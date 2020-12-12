using AdventOfCode2020.App.Ferry;
using NUnit.Framework;

namespace AdventOfCode2020.Test.Ferry
{
    [TestFixture]
    public class CompassTest
    {
        [Test]
        public void TurnsRight()
        {
            Assert.That(Compass.North.Right(), Is.EqualTo(Compass.East));
            Assert.That(Compass.East.Right(), Is.EqualTo(Compass.South));
            Assert.That(Compass.South.Right(), Is.EqualTo(Compass.West));
            Assert.That(Compass.West.Right(), Is.EqualTo(Compass.North));
        }
        
        [Test]
        public void TurnsLeft()
        {
            Assert.That(Compass.North.Left(), Is.EqualTo(Compass.West));
            Assert.That(Compass.West.Left(), Is.EqualTo(Compass.South));
            Assert.That(Compass.South.Left(), Is.EqualTo(Compass.East));
            Assert.That(Compass.East.Left(), Is.EqualTo(Compass.North));
        }
    }
}