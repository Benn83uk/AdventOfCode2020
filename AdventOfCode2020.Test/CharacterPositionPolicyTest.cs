using AdventOfCode2020.App;
using NUnit.Framework;

namespace AdventOfCode2020.Test
{
    [TestFixture]
    public class CharacterPositionPolicyTest
    {
        [Test]
        public void PasswordMeetsPolicy()
        {
            var policy = new CharacterPositionPolicy('a', 1, 3);
            Assert.That(policy.IsValid("abcde"), Is.True);
        }
    }
}