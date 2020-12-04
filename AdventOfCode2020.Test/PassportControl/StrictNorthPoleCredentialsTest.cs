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
        
        [Test]
        public void ErrorWhenHeightInInchesMoreThan76()
        {
            Assert.Throws<InvalidCredentialFieldException>(
                () => new StrictNorthPoleCredentials(1920, 2010, 2030, "77in", "#ffffff", "amb", "012345678"));
        }
        
        [Test]
        public void ErrorWhenHeightInInchesLessThan59()
        {
            Assert.Throws<InvalidCredentialFieldException>(
                () => new StrictNorthPoleCredentials(1920, 2010, 2030, "58in", "#ffffff", "amb", "012345678"));
        }
        
        [Test]
        public void ErrorWhenHeightNotCMOrInches()
        {
            Assert.Throws<InvalidCredentialFieldException>(
                () => new StrictNorthPoleCredentials(1920, 2010, 2030, "120na", "#ffffff", "amb", "012345678"));
        }

        [Test]
        public void ErrorWhenHairColorDoesNotStartWithHash()
        {
            Assert.Throws<InvalidCredentialFieldException>(
                () => new StrictNorthPoleCredentials(1920, 2010, 2030, "150cm", "ffffff", "amb", "012345678"));
        }
        
        [Test]
        public void ErrorWhenHairColorDoesNotStartWithHashButDoesContainOne()
        {
            Assert.Throws<InvalidCredentialFieldException>(
                () => new StrictNorthPoleCredentials(1920, 2010, 2030, "150cm", "f#ffffff", "amb", "012345678"));
        }
        
        [Test]
        public void ErrorWhenHairColorTooShort()
        {
            Assert.Throws<InvalidCredentialFieldException>(
                () => new StrictNorthPoleCredentials(1920, 2010, 2030, "150cm", "#fffff", "amb", "012345678"));
        }
        
        [Test]
        public void ErrorWhenHairColorTooLong()
        {
            Assert.Throws<InvalidCredentialFieldException>(
                () => new StrictNorthPoleCredentials(1920, 2010, 2030, "150cm", "#fffffff", "amb", "012345678"));
        }
        
        [Test]
        public void ErrorWhenHairColorDoesNotCorrectFormat()
        {
            Assert.Throws<InvalidCredentialFieldException>(
                () => new StrictNorthPoleCredentials(1920, 2010, 2030, "150cm", "#00fffg", "amb", "012345678"));
        }
        
        [Test]
        public void ErrorWhenEyeColorDoesNotAnOption()
        {
            Assert.Throws<InvalidCredentialFieldException>(
                () => new StrictNorthPoleCredentials(1920, 2010, 2030, "150cm", "#00ffff", "zzz", "012345678"));
        }
        
        [Test]
        public void ErrorWhenPassportIdIsNotANumber()
        {
            Assert.Throws<InvalidCredentialFieldException>(
                () => new StrictNorthPoleCredentials(1920, 2010, 2030, "150cm", "#00ffff", "brn", "abcabcabc"));
        }
        
        [Test]
        public void ErrorWhenPassportIdLessThan9Chars()
        {
            Assert.Throws<InvalidCredentialFieldException>(
                () => new StrictNorthPoleCredentials(1920, 2010, 2030, "150cm", "#00ffff", "brn", "01234567"));
        }
        
        [Test]
        public void ErrorWhenPassportIdGreaterThan9Chars()
        {
            Assert.Throws<InvalidCredentialFieldException>(
                () => new StrictNorthPoleCredentials(1920, 2010, 2030, "150cm", "#00ffff", "brn", "0123456789"));
        }
        
        [Test]
        public void ErrorWhenUsingDayFourTaskTwoExample()
        {
            Assert.Throws<InvalidCredentialFieldException>(
                () => new StrictNorthPoleCredentials(1946, 2019, 1967, "170cm", "#602927", "grn", "012533040"));
        }
    }
}