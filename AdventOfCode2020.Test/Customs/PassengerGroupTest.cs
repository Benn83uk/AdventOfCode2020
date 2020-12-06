using AdventOfCode2020.App.Customs;
using NUnit.Framework;

namespace AdventOfCode2020.Test.Customs
{
    [TestFixture]
    public class PassengerGroupTest
    {
        [Test]
        public void OnePersonOneAnswer()
        {
            var list = new PassengerGroup("a");
            Assert.That(list.CountUniqueAnswers(), Is.EqualTo(1));
        }
        
        [Test]
        public void OnePersonTwoAnswers()
        {
            var list = new PassengerGroup("ab");
            Assert.That(list.CountUniqueAnswers(), Is.EqualTo(2));
        }
    }
}