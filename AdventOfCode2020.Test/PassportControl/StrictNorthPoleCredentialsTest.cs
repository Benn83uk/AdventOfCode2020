using AdventOfCode2020.App.PassportControl;
using NUnit.Framework;

namespace AdventOfCode2020.Test.PassportControl
{
    [TestFixture]
    public class StrictNorthPoleCredentialsTest
    {
        [Test]
        public void BirthYearAfter2002()
        {
            Assert.Throws<InvalidCredentialFieldException>(
                () => new StrictNorthPoleCredentials(2003, 2010, 2020, "150cm", "#ffffff", "amb", "012345678"));
        }
        
        [Test]
        public void BirthYearBefore1920()
        {
            Assert.Throws<InvalidCredentialFieldException>(
                () => new StrictNorthPoleCredentials(1919, 2010, 2020, "150cm", "#ffffff", "amb", "012345678"));
        }
        
        [Test]
        public void IssueYearAfter2020()
        {
            Assert.Throws<InvalidCredentialFieldException>(
                () => new StrictNorthPoleCredentials(1920, 2021, 2020, "150cm", "#ffffff", "amb", "012345678"));
        }
        
        [Test]
        public void IssueYearBefore2010()
        {
            Assert.Throws<InvalidCredentialFieldException>(
                () => new StrictNorthPoleCredentials(1920, 2009, 2020, "150cm", "#ffffff", "amb", "012345678"));
        }
    }
}