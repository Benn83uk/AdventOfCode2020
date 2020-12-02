using AdventOfCode2020.App;
using NUnit.Framework;

namespace AdventOfCode2020.Test
{
    [TestFixture]
    public class CharacterCountPolicyFactoryTest
    {
        public void CanCreateFromString()
        {
            var expectedPolicy = new CharacterCountPolicy('a', 1, 3);
            var factory = new CharacterCountPolicyFactory();
            Assert.That(factory.CreateFromString("1-3 a"), Is.EqualTo(expectedPolicy));
        }
    }
}