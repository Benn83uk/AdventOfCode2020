using AdventOfCode2020.App.Password;
using NUnit.Framework;

namespace AdventOfCode2020.Test.Password
{
    [TestFixture]
    public class PasswordTest
    {
        [Test]
        public void PasswordIsValid()
        {
            var policy = new CharacterCountPolicy('a', 1, 3);
            var password = new App.Password.Password("aaa", policy);
            Assert.That(password.IsValid(), Is.True);
        }
        
        [Test]
        public void PasswordIsNotValid()
        {
            var policy = new CharacterCountPolicy('a', 1, 3);
            var password = new App.Password.Password("aaaa", policy);
            Assert.That(password.IsValid(), Is.False);
        }
        
        [Test]
        public void PasswordCreatedFromString()
        {
            var policy = new CharacterCountPolicy('a', 1, 3);
            var expectedPassword = new App.Password.Password("abcde", policy);
            
            var password = new App.Password.Password("1-3 a: abcde", new CharacterCountPolicyFactory());
            Assert.That(password, Is.EqualTo(expectedPassword));
        }
    }
}