using AdventOfCode2020.App.Password;
using NUnit.Framework;

namespace AdventOfCode2020.Test.Password
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
        
        [Test]
        public void PasswordDoesNotMeetPolicyIfLetterInBothPositions()
        {
            var policy = new CharacterPositionPolicy('a', 1, 3);
            Assert.That(policy.IsValid("abade"), Is.False);
        }
        
        [Test]
        public void PasswordDoesNotMeetPolicyIfLetterInNeitherPosition()
        {
            var policy = new CharacterPositionPolicy('a', 1, 3);
            Assert.That(policy.IsValid("badae"), Is.False);
        }
    }
}