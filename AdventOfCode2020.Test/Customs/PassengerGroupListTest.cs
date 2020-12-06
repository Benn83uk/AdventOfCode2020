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
    }
}