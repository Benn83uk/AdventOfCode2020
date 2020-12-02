using AdventOfCode2020.App;
using NUnit.Framework;

namespace AdventOfCode2020.Test
{
    [TestFixture]
    public class CharacterCountPolicyTest
    {
        [Test]
        public void PasswordMeetsPolicy()
        {
            var policy = new CharacterCountPolicy('a', 1, 3);
            Assert.That(policy.IsValid("ababab"), Is.True);
        }
        
        [Test]
        public void PasswordTooFewCharacters()
        {
            var policy = new CharacterCountPolicy('c', 1, 3);
            Assert.That(policy.IsValid("ababab"), Is.False);
        }
        
        [Test]
        public void PasswordTooManyCharacters()
        {
            var policy = new CharacterCountPolicy('c', 1, 3);
            Assert.That(policy.IsValid("abababa"), Is.False);
        }
        
        [Test]
        public void PolicyCreatedFromString()
        {
            var expectedPolicy = new CharacterCountPolicy('a', 1, 3);
            var policy = new CharacterCountPolicy("1-3 a");
            Assert.That(policy, Is.EqualTo(expectedPolicy));
        }
    }
}