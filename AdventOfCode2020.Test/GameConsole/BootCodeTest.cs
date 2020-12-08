using System.Reflection.Metadata.Ecma335;
using AdventOfCode2020.App.GameConsole;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace AdventOfCode2020.Test.GameConsole
{
    [TestFixture]
    public class BootCodeTest
    {
        [Test]
        public void RunNop()
        {
            var code = new BootCode(
                new NoOp()
            );
            Assert.That(code.AccumulatorValue(), Is.EqualTo(0));
        }
    }
}