using AdventOfCode2020.App.Password;
using NUnit.Framework;

namespace AdventOfCode2020.Test.Password
{
    [TestFixture]
    public class PasswordListTest
    {
        [Test]
        public void CountMultipleCorrectPasswords()
        {
            var password1 = new App.Password.Password("abcde", new CharacterCountPolicy('a', 1, 3));
            var password2 = new App.Password.Password("cdefg", new CharacterCountPolicy('b', 1, 3));
            var password3 = new App.Password.Password("ccccccccc", new CharacterCountPolicy('c', 1, 9));
            var password4 = new App.Password.Password("abcde", new CharacterPositionPolicy('a', 1, 3));
            var password5 = new App.Password.Password("cdefg", new CharacterPositionPolicy('b', 1, 3));
            var password6 = new App.Password.Password("ccccccccc", new CharacterPositionPolicy('c', 1, 9));
            var list = new PasswordList(password1, password2, password3, password4, password5, password6);
            Assert.That(list.NumValid(), Is.EqualTo(3));
        }

        [Test]
        public void CountValidPasswordsInFile()
        {
            var list = new PasswordList("TestFiles/DayTwoExample.txt", new CharacterCountPolicyFactory());
            Assert.That(list.NumValid(), Is.EqualTo(2));
        }
        
        [Test]
        public void DayTwoPartOne()
        {
            var list = new PasswordList("TestFiles/DayTwoInput.txt", new CharacterCountPolicyFactory());
            Assert.That(list.NumValid(), Is.EqualTo(439));
        }
        
        [Test]
        public void DayTwoPartTwo()
        {
            var list = new PasswordList("TestFiles/DayTwoInput.txt", new CharacterPositionPolicyFactory());
            Assert.That(list.NumValid(), Is.EqualTo(584));
        }
    }
}