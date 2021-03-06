using System;
using AdventOfCode2020.App.PassportControl;
using NUnit.Framework;

namespace AdventOfCode2020.Test.PassportControl
{
    [TestFixture]
    public class IdentityCredentialFactoryTest
    {
        [Test]
        public void IsValidPassport()
        {
            var inputString = "ecl:gry pid:860033327 eyr:2020 hcl:#fffffd" + Environment.NewLine +
                              "byr:1937 iyr:2017 cid:147 hgt:183cm";
            var expected = new Passport(1937, 2017, 2020, "183cm", "#fffffd", "gry", "860033327", "147");
                
            var result = IdentityCredentialFactory.Create(inputString);
            Assert.That(result, Is.EqualTo(expected));
        }
        
        [Test]
        public void IsValidStrictPassport()
        {
            var inputString = "ecl:gry pid:860033327 eyr:2020 hcl:#fffffd" + Environment.NewLine +
                              "byr:1937 iyr:2017 cid:147 hgt:183cm";
            var expected = new Passport(1937, 2017, 2020, "183cm", "#fffffd", "gry", "860033327", "147");
                
            var result = IdentityCredentialFactory.Create(inputString);
            Assert.That(result, Is.EqualTo(expected));
        }
        
        [Test]
        public void IsValidNorthPoleCredentials()
        {
            var inputString = "ecl:gry pid:860033327 eyr:2020 hcl:#fffffd" + Environment.NewLine +
                              "byr:1937 iyr:2017 hgt:183cm";
            var expected = new StrictNorthPoleCredentials(1937, 2017, 2020, "183cm", "#fffffd", "gry", "860033327");
            var result = IdentityCredentialFactory.Create(inputString);
            Assert.That(result, Is.EqualTo(expected));
        }
        
        [Test]
        public void CredentialsMissingHeight()
        {
            var inputString = "ecl:gry pid:860033327 eyr:2020 hcl:#fffffd byr:1937 iyr:2017";
            var result = IdentityCredentialFactory.Create(inputString);
            Assert.That(result, Is.EqualTo(IdentityCredentialFactory.INVALID_CREDENTIALS));
        }
        
        [Test]
        public void CredentialsMissingIssueYear()
        {
            var inputString = "ecl:gry pid:860033327 eyr:2020 hcl:#ffffff byr:1937 hgt:183cm";
            var result = IdentityCredentialFactory.Create(inputString);
            Assert.That(result, Is.EqualTo(IdentityCredentialFactory.INVALID_CREDENTIALS));
        }
        
        [Test]
        public void CredentialsMissingBirthYear()
        {
            var inputString = "ecl:gry pid:860033327 eyr:2020 hcl:#fffffd iyr:2017 hgt:183cm";
            var result = IdentityCredentialFactory.Create(inputString);
            Assert.That(result, Is.EqualTo(IdentityCredentialFactory.INVALID_CREDENTIALS));
        }
        
        [Test]
        public void CredentialsMissingHairColor()
        {
            var inputString = "ecl:gry pid:860033327 eyr:2020 byr:1937 iyr:2017 hgt:183cm";
            var result = IdentityCredentialFactory.Create(inputString);
            Assert.That(result, Is.EqualTo(IdentityCredentialFactory.INVALID_CREDENTIALS));
        }
        
        [Test]
        public void CredentialsMissingExpirationYear()
        {
            var inputString = "ecl:gry pid:860033327 hcl:#fffffd byr:1937 iyr:2017 hgt:183cm";
            var result = IdentityCredentialFactory.Create(inputString);
            Assert.That(result, Is.EqualTo(IdentityCredentialFactory.INVALID_CREDENTIALS));
        }
        
        [Test]
        public void CredentialsMissingPassportId()
        {
            var inputString = "ecl:gry eyr:2020 hcl:#fffffd byr:1937 iyr:2017 hgt:183cm";
            var result = IdentityCredentialFactory.Create(inputString);
            Assert.That(result, Is.EqualTo(IdentityCredentialFactory.INVALID_CREDENTIALS));
        }
        
        [Test]
        public void CredentialsMissingEyeColor()
        {
            var inputString = "pid:860033327 eyr:2020 hcl:#fffffd byr:1937 iyr:2017 hgt:183cm";
            var result = IdentityCredentialFactory.Create(inputString);
            Assert.That(result, Is.EqualTo(IdentityCredentialFactory.INVALID_CREDENTIALS));
        }

        [Test]
        public void CanCreateCredentialsFromFile()
        {
            var expected = new IIdentityCredential[]
            {
                new Passport(1937, 2017, 2020, "183cm", "#fffffd", "gry", "860033327", "147"),
                IdentityCredentialFactory.INVALID_CREDENTIALS, 
                new StrictNorthPoleCredentials(1931, 2013, 2024, "179cm", "#ae17e1", "brn", "760753108"),
                IdentityCredentialFactory.INVALID_CREDENTIALS
            };
            var result = IdentityCredentialFactory.CreateFromFile("TestFiles/DayFourExample.txt");
            Assert.That(result, Is.EquivalentTo(expected));
        }
        
        [Test]
        public void DayFourTaskOneExample()
        {
            var result = IdentityCredentialFactory.CountValidPassportsInFile("TestFiles/DayFourExample.txt");
            Assert.That(result, Is.EqualTo(2));
        }
        
        [Test]
        [Ignore("Invalid for Task two")]
        public void DayFourTaskOneAnswer()
        {
            var result = IdentityCredentialFactory.CountValidPassportsInFile("TestFiles/DayFourInput.txt");
            Assert.That(result, Is.EqualTo(235));
        }
        
        [Test]
        public void DayFourTaskTwoInvalidExamples()
        {
            var expected = new IIdentityCredential[]
            {
                IdentityCredentialFactory.INVALID_CREDENTIALS,
                IdentityCredentialFactory.INVALID_CREDENTIALS, 
                IdentityCredentialFactory.INVALID_CREDENTIALS,
                IdentityCredentialFactory.INVALID_CREDENTIALS
            };
            var result = IdentityCredentialFactory.CreateFromFile("TestFiles/DayFourTaskTwoInvalidExamples.txt");
            Assert.That(result, Is.EquivalentTo(expected));
        }

        [Test]
        public void InvalidCredentialExampleFromDayFour()
        {
            var str = "byr:1946 iyr:2019 eyr:1967 hgt:170cm hcl:#602927 ecl:grn pid:012533040";
            var result = IdentityCredentialFactory.Create(str);
            Assert.That(result, Is.EqualTo(IdentityCredentialFactory.INVALID_CREDENTIALS));
        }

        [Test]
        public void DayFourTaskTwoExamples()
        {
            var result = IdentityCredentialFactory.CountValidPassportsInFile("TestFiles/DayFourTaskTwoExamples.txt");
            Assert.That(result, Is.EqualTo(4)); 
        }
        
        [Test]
        public void DayOneTaskTwoAnswer()
        {
            var result = IdentityCredentialFactory.CountValidPassportsInFile("TestFiles/DayFourInput.txt");
            Assert.That(result, Is.EqualTo(194));
        }
    }
}