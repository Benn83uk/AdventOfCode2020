using AdventOfCode2020.App.Plane;
using NUnit.Framework;

namespace AdventOfCode2020.Test.Plane
{
    [TestFixture]
    public class SeatTest
    {
        [Test]
        public void FrontSeatHasRow0()
        {
            var seat = new Seat("F");
            Assert.That(seat.Row(), Is.EqualTo(0));
        }
        
        [Test]
        public void BackSeatOnTwoRowPlaneHasRow1()
        {
            var seat = new Seat("B");
            Assert.That(seat.Row(), Is.EqualTo(1));
        }
    }
}