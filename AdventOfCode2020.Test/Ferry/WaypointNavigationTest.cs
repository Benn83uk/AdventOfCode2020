using System.IO;
using AdventOfCode2020.App.Ferry;
using NUnit.Framework;

namespace AdventOfCode2020.Test.Ferry
{
    [TestFixture]
    public class WaypointNavigationTest
    {
        [Test]
        public void MoveToWaypoint()
        {
            //Waypoint starts at 10,1
            // 10+5-1, 1+5-2 = (14,4) * 2 = (28,8) = distance 36
            var route = new WaypointNavigation("N5", "E5", "W2", "S1", "F2");
            Assert.That(route.DistanceFromStart(), Is.EqualTo(36));
        }
        
        [Test]
        public void MoveToWaypointTenTimes()
        {
            //Waypoint starts at 10,1
            var route = new WaypointNavigation("F10");
            Assert.That(route.DistanceFromStart(), Is.EqualTo(110));
        }
        
        [Test]
        public void DayTwelveTaskTwoExample()
        {
            var lines = File.ReadAllLines("TestFiles/DayTwelveExample.txt");
            var route = new WaypointNavigation(lines);
            Assert.That(route.DistanceFromStart(), Is.EqualTo(286));
        }
        
        [Test]
        public void DayTwelveTaskTwoInput()
        {
            var lines = File.ReadAllLines("TestFiles/DayTwelveInput.txt");
            var route = new WaypointNavigation(lines);
            Assert.That(route.DistanceFromStart(), Is.EqualTo(63843));
        }
    }
}