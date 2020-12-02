using AdventOfCode2020.App;
using NUnit.Framework;

namespace AdventOfCode2020.Test
{
    [TestFixture]
    public class CharacterPositionPolicyFactoryTest
    {
        public void CanCreateFromString()
        {
            var expectedPolicy = new CharacterPositionPolicy('a', 1, 3);
            var factory = new CharacterPositionPolicyFactory();
            Assert.That(factory.CreateFromString("1-3 a"), Is.EqualTo(expectedPolicy));
        }
    }
}