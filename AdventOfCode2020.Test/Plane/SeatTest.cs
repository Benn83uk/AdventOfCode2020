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

        [Test]
        public void BackSeatOnFourRowPlaneHasRow3()
        {
            var seat = new Seat("BB");
            Assert.That(seat.Row(), Is.EqualTo(3));
        }
        
        [Test]
        public void FrontSeatOnFourRowPlaneHasRow0()
        {
            var seat = new Seat("FF");
            Assert.That(seat.Row(), Is.EqualTo(0));
        }
        
        [Test]
        public void FrontBackSeatOnFourRowPlaneHasRow1()
        {
            var seat = new Seat("FB");
            Assert.That(seat.Row(), Is.EqualTo(1));
        }
        
        [Test]
        public void FrontSeatOnEightRowPlaneHasRow0()
        {
            var seat = new Seat("FFF");
            Assert.That(seat.Row(), Is.EqualTo(0));
        }
        
        [Test]
        public void BackSeatOnEightRowPlaneHasRow7()
        {
            var seat = new Seat("BBB");
            Assert.That(seat.Row(), Is.EqualTo(7));
        }
        
        [Test]
        public void BackBackFrontSeatOnEightRowPlaneHasRow6()
        {
            var seat = new Seat("BBF");
            Assert.That(seat.Row(), Is.EqualTo(6));
        }
        
        [Test]
        public void FrontBackBackSeatOnEightRowPlaneHasRow3()
        {
            var seat = new Seat("FBB");
            Assert.That(seat.Row(), Is.EqualTo(3));
        }
        
        [Test]
        public void DayFiveTaskOneExampleRow()
        {
            var seat = new Seat("FBFBBFF");
            Assert.That(seat.Row(), Is.EqualTo(44));
        }
    }
}