using AdventOfCode2020.App;
using NUnit.Framework;

namespace AdventOfCode2020.Test
{
    [TestFixture]
    public class PasswordListTest
    {
        [Test]
        public void CountMultipleCorrectPasswords()
        {
            var password1 = new Password("abcde", new PasswordPolicy('a', 1, 3));
            var password2 = new Password("cdefg", new PasswordPolicy('b', 1, 3));
            var password3 = new Password("ccccccccc", new PasswordPolicy('c', 1, 9));
            var list = new PasswordList(password1, password2, password3);
            Assert.That(list.NumValid(), Is.EqualTo(2));
        }

        [Test]
        public void CountValidPasswordsInFile()
        {
            var list = new PasswordList("TestFiles/DayTwoExample.txt");
            Assert.That(list.NumValid(), Is.EqualTo(2));
        }
        
        [Test]
        public void DayTwoPartOne()
        {
            var list = new PasswordList("TestFiles/DayTwoInput.txt");
            Assert.That(list.NumValid(), Is.EqualTo(439));
        }
    }
}