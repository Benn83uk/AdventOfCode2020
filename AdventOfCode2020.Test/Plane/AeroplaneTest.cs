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
        
        [Test]
        public void DayFiveTaskOneExampleFromFile()
        {
            var plane = new Aeroplane("TestFiles/DayFiveExample.txt");
            Assert.That(plane.HighestSeatId(), Is.EqualTo(820));
        }
        
        [Test]
        public void DayFiveTaskOneAnswer()
        {
            var plane = new Aeroplane("TestFiles/DayFiveInput.txt");
            Assert.That(plane.HighestSeatId(), Is.EqualTo(989));
        }

        [Test]
        public void FindMissingSeat()
        {
            var plane = new Aeroplane(
                new Seat("FFFL"), //Very front row
                //new Seat("FFFR"), //Very front row, missing
                new Seat("FFBL"), //Row 1
                new Seat("FFBR"),
                new Seat("FBFL"),  //Row 2
                new Seat("FBFR"),
                new Seat("FBBL"),  //Row 3
                new Seat("FBBR"),
                new Seat("BFFL"),  //Row 4
                //new Seat("BFFR"), //Our missing seat, Row 4, Column 1, Id 4*8+1 = 33
                new Seat("BFBL"),  //Row 5
                new Seat("BFBR"),
                new Seat("BBFL"),
                new Seat("BBFR"),
                //new Seat("BBBL"), // Very back row, missing
                new Seat("BBBR")
            );
            Assert.That(plane.MissingSeatId(), Is.EqualTo(33));
        }
    }
}