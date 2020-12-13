using System.IO;
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
        
        [Test]
        public void DayThirteenTaskOneExample()
        {
            var lines = File.ReadAllLines("TestFiles/DayThirteenExample.txt");
            var arriveAtTime = int.Parse(lines[0]);
            var timetable = new Timetable(lines[1]);
            
            Assert.That(timetable.FirstBusAfter(arriveAtTime), Is.EqualTo(59));
            Assert.That(timetable.Checksum(arriveAtTime), Is.EqualTo(295));
        }
        
        [Test]
        public void DayThirteenTaskOneAnswer()
        {
            var lines = File.ReadAllLines("TestFiles/DayThirteenInput.txt");
            var arriveAtTime = int.Parse(lines[0]);
            var timetable = new Timetable(lines[1]);
            Assert.That(timetable.Checksum(arriveAtTime), Is.EqualTo(4808));
        }

        [Test]
        public void EarliestTimeForBusPattern()
        {
            var timetable = new Timetable(2,3,5);
            Assert.That(timetable.EarliestTimeStampForPattern(), Is.EqualTo(8));
        }
        
        [Test]
        public void DayThirteenTaskTwoExample()
        {
            var lines = File.ReadAllLines("TestFiles/DayThirteenExample.txt");
            var arriveAtTime = int.Parse(lines[0]);
            var timetable = new Timetable(lines[1]);
            
            Assert.That(timetable.EarliestTimeStampForPattern(), Is.EqualTo(1068781));
        }
        
        [Test]
        [Ignore("Takes too long")]
        public void DayThirteenTaskTwoAnswer()
        {
            var lines = File.ReadAllLines("TestFiles/DayThirteenInput.txt");
            var arriveAtTime = int.Parse(lines[0]);
            var timetable = new Timetable(lines[1]);
            
            Assert.That(timetable.EarliestTimeStampForPattern(), Is.EqualTo(0));
        }
    }
}