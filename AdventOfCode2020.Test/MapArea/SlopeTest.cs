using AdventOfCode2020.App.MapArea;
using Microsoft.AspNetCore.Server.Kestrel.Transport.Sockets.Internal;
using NUnit.Framework;

namespace AdventOfCode2020.Test.MapArea
{
    [TestFixture]
    public class SlopeTest
    {
        [Test]
        public void HasTreeAtThirdColumn()
        {
            var slope = new Slope("..#");
            Assert.That(slope.HasTreeAt(2), Is.True);
        }
        
        [Test]
        public void DoesNotHaveTreeAtStartingPoint()
        {
            var slope = new Slope("..#");
            Assert.That(slope.HasTreeAt(0), Is.False);
        }
        
        [Test]
        public void HasTreeAtSixthColumn()
        {
            var slope = new Slope("..#");
            Assert.That(slope.HasTreeAt(5), Is.True);
        }
        
        [Test]
        public void DoesNotHaveTreeAtSeventhColumn()
        {
            var slope = new Slope("..#");
            Assert.That(slope.HasTreeAt(6), Is.False);
        }
    }
}