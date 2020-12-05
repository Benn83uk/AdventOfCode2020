using AdventOfCode2020.App.Plane;
using NUnit.Framework;

namespace AdventOfCode2020.Test.Plane
{
    [TestFixture]
    public class AeroplaneTest
    {
        [Test]
        public void HighestSeatId()
        {
            var plane = new Aeroplane(
                new Seat("FFLL"), // Row 0, Column 0, Seat Id 0
                new Seat("FBRR"), // Row 1, Column 3, Seat Id 3 
                new Seat("BFLR"), // Row 2, Column 1, Seat Id 17 (2*8+1)
                new Seat("BFRL")  // Row 2, Column 2, Seat Is 18 (2*8+2)
                );
            Assert.That(plane.HighestSeatId(), Is.EqualTo(18));
        }
    }
}