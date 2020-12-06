using AdventOfCode2020.App.Customs;
using NUnit.Framework;

namespace AdventOfCode2020.Test.Customs
{
    [TestFixture]
    public class PassengerGroupListTest
    {
        [Test]
        public void OneGroupSumIsCount()
        {
            var list = new PassengerGroupList(new PassengerGroup("abcx", "abcy"));
            Assert.That(list.SumUniqueAnswers(), Is.EqualTo(5));
        }
        
        [Test]
        public void TwoGroupSumCorrectly()
        {
            var list = new PassengerGroupList(
                new PassengerGroup("abcx", "abcy"),
                    new PassengerGroup("abcx", "abcy")
                );
            Assert.That(list.SumUniqueAnswers(), Is.EqualTo(10));
        }
        
        [Test]
        public void DaySixExample()
        {
            var list = new PassengerGroupList(
                new PassengerGroup("abc"),
                new PassengerGroup("a", "b", "c"),
                new PassengerGroup("ab", "ac"),
                new PassengerGroup("a", "a", "a", "a"),
                new PassengerGroup("b")
            );
            Assert.That(list.SumUniqueAnswers(), Is.EqualTo(11));
        }
        
        [Test]
        public void DaySixExampleFromFile()
        {
            var list = new PassengerGroupList("TestFiles/DaySixExample.txt");
            Assert.That(list.SumUniqueAnswers(), Is.EqualTo(11));
        }
        
        [Test]
        public void DaySixTaskOneAnswer()
        {
            var list = new PassengerGroupList("TestFiles/DaySixInput.txt");
            Assert.That(list.SumUniqueAnswers(), Is.EqualTo(6662));
        }
    }
}