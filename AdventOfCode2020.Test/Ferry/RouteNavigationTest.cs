using System.IO;
using AdventOfCode2020.App.Ferry;
using NUnit.Framework;

namespace AdventOfCode2020.Test.Ferry
{
    
    [TestFixture]
    public class RouteNavigationTest
    {
        [Test]
        public void MovesNorthEastSouthWestFinalDistance()
        {
            var route = new RouteNavigation("N5", "E5", "W2", "S1");
            Assert.That(route.DistanceFromStart(), Is.EqualTo(7));
        }
        
        [Test]
        public void MovesNorthEastSouthWestFinalDistance2()
        {
            var route = new RouteNavigation("L90", "F5", "R90", "F5", "L180", "F2", "L90", "F1");
            Assert.That(route.DistanceFromStart(), Is.EqualTo(7));
        }

        [Test]
        public void DayTwelveExample()
        {
            var lines = File.ReadAllLines("TestFiles/DayTwelveExample.txt");
            var route = new RouteNavigation(lines);
            Assert.That(route.DistanceFromStart(), Is.EqualTo(25));
        }
    }
}