using AdventOfCode2020.App;
using NUnit.Framework;

namespace AdventOfCode2020.Test
{
    [TestFixture]
    public class PasswordPolicyTest
    {
        [Test]
        public void PasswordMeetsPolicy()
        {
            var policy = new PasswordPolicy('a', 1, 3);
            Assert.That(policy.IsValid("ababab"), Is.True);
        }
        
        [Test]
        public void PasswordTooFewCharacters()
        {
            var policy = new PasswordPolicy('c', 1, 3);
            Assert.That(policy.IsValid("ababab"), Is.False);
        }
        
        [Test]
        public void PasswordTooManyCharacters()
        {
            var policy = new PasswordPolicy('c', 1, 3);
            Assert.That(policy.IsValid("abababa"), Is.False);
        }
        
        [Test]
        public void PolicyCreatedFromString()
        {
            var expectedPolicy = new PasswordPolicy('a', 1, 3);
            var policy = new PasswordPolicy("1-3 a");
            Assert.That(policy, Is.EqualTo(expectedPolicy));
        }
    }
}