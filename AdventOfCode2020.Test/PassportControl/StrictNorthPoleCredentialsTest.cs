using AdventOfCode2020.App.PassportControl;
using NUnit.Framework;

namespace AdventOfCode2020.Test.PassportControl
{
    [TestFixture]
    public class StrictNorthPoleCredentialsTest
    {
        [Test]
        public void ErrorWhenBirthYearAfter2002()
        {
            Assert.Throws<InvalidCredentialFieldException>(
                () => new StrictNorthPoleCredentials(2003, 2010, 2020, "150cm", "#ffffff", "amb", "012345678"));
        }
        
        [Test]
        public void ErrorWhenBirthYearBefore1920()
        {
            Assert.Throws<InvalidCredentialFieldException>(
                () => new StrictNorthPoleCredentials(1919, 2010, 2020, "150cm", "#ffffff", "amb", "012345678"));
        }
        
        [Test]
        public void ErrorWhenIssueYearAfter2020()
        {
            Assert.Throws<InvalidCredentialFieldException>(
                () => new StrictNorthPoleCredentials(1920, 2021, 2020, "150cm", "#ffffff", "amb", "012345678"));
        }
        
        [Test]
        public void ErrorWhenIssueYearBefore2010()
        {
            Assert.Throws<InvalidCredentialFieldException>(
                () => new StrictNorthPoleCredentials(1920, 2009, 2020, "150cm", "#ffffff", "amb", "012345678"));
        }

        [Test]
        public void ErrorWhenExpirationYearBefore2020()
        {
            Assert.Throws<InvalidCredentialFieldException>(
                () => new StrictNorthPoleCredentials(1920, 2010, 2019, "150cm", "#ffffff", "amb", "012345678"));
        }
        
        [Test]
        public void ErrorWhenExpirationYearAfter2030()
        {
            Assert.Throws<InvalidCredentialFieldException>(
                () => new StrictNorthPoleCredentials(1920, 2010, 2031, "150cm", "#ffffff", "amb", "012345678"));
        }

        [Test]
        public void ErrorWhenHeightInCMMoreThan193()
        {
            Assert.Throws<InvalidCredentialFieldException>(
                () => new StrictNorthPoleCredentials(1920, 2010, 2030, "194cm", "#ffffff", "amb", "012345678"));
        }
        
        [Test]
        public void ErrorWhenHeightInCMLessThan150()
        {
            Assert.Throws<InvalidCredentialFieldException>(
                () => new StrictNorthPoleCredentials(1920, 2010, 2030, "149cm", "#ffffff", "amb", "012345678"));
        }
    }
}