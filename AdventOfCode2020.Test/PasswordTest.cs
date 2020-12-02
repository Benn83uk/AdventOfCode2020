using AdventOfCode2020.App;
using NUnit.Framework;

namespace AdventOfCode2020.Test
{
    [TestFixture]
    public class PasswordTest
    {
        [Test]
        public void PasswordIsValid()
        {
            var policy = new CharacterCountPolicy('a', 1, 3);
            var password = new Password("aaa", policy);
            Assert.That(password.IsValid(), Is.True);
        }
        
        [Test]
        public void PasswordIsNotValid()
        {
            var policy = new CharacterCountPolicy('a', 1, 3);
            var password = new Password("aaaa", policy);
            Assert.That(password.IsValid(), Is.False);
        }
        
        [Test]
        public void PasswordCreatedFromString()
        {
            var policy = new CharacterCountPolicy('a', 1, 3);
            var expectedPassword = new Password("abcde", policy);
            
            var password = new Password("1-3 a: abcde", new CharacterCountPolicyFactory());
            Assert.That(password, Is.EqualTo(expectedPassword));
        }
    }
}