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
    }
}