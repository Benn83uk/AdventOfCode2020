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
            var group = new PassengerGroup("a");
            Assert.That(group.CountUniqueAnswers(), Is.EqualTo(1));
        }
        
        [Test]
        public void OnePersonTwoAnswers()
        {
            var group = new PassengerGroup("ab");
            Assert.That(group.CountUniqueAnswers(), Is.EqualTo(2));
        }
        
        [Test]
        public void TwoPeopleSameAnswers()
        {
            var group = new PassengerGroup("abc", "abc");
            Assert.That(group.CountUniqueAnswers(), Is.EqualTo(3));
        }
        
        [Test]
        public void TwoPeopleDifferentAnswers()
        {
            var group = new PassengerGroup("abcx", "abcy");
            Assert.That(group.CountUniqueAnswers(), Is.EqualTo(5));
        }
        
        [Test]
        public void ThreePeopleDifferentAnswers()
        {
            var group = new PassengerGroup("abcx", "abcy", "abcz");
            Assert.That(group.CountUniqueAnswers(), Is.EqualTo(6));
        }
    }
}