using AdventOfCode2020.App.Customs;
using NUnit.Framework;

namespace AdventOfCode2020.Test.Customs
{
    [TestFixture]
    public class PassengerGroupTest
    {
        [Test]
        public void OnePersonOneGroupOneAnswer()
        {
            var list = new PassengerGroup("a");
            Assert.That(list.CountUniqueAnswers(), Is.EqualTo(1));
        }
    }
}