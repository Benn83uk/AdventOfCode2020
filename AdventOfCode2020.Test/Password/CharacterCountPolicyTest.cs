using AdventOfCode2020.App.Password;
using NUnit.Framework;

namespace AdventOfCode2020.Test.Password
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
    }
}