using AdventOfCode2020.App.BusTerminal;
using NUnit.Framework;

namespace AdventOfCode2020.Test.BusTerminal
{
    [TestFixture]
    public class TimetableTest
    {
        [Test]
        public void BusToCatch()
        {
            var timetable = new Timetable(7, 13, 59, 31, 19);
            Assert.That(timetable.FirstBusAfter(939), Is.EqualTo(59));
        }

        [Test]
        public void MathCheck()
        {
            var timeToWait = 939 % 59;
            Assert.That(timeToWait, Is.EqualTo(54));
        }
    }
}