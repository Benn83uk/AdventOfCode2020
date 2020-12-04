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
            var expected = new Passport(1937, 2017, 2020, "183cm", "#fffffd", "gry", "860033327", 147);
                
            var result = IdentityCredentialFactory.Create(inputString);
            Assert.That(result, Is.TypeOf<Passport>());
            //Assert.That(result, Is.EqualTo(expected));
        }
        
        [Test]
        public void IsValidNorthPoleCredentials()
        {
            var inputString = "ecl:gry pid:860033327 eyr:2020 hcl:#fffffd" + Environment.NewLine +
                              "byr:1937 iyr:2017 hgt:183cm";

            var result = IdentityCredentialFactory.Create(inputString);
            Assert.That(result, Is.TypeOf<NorthPoleCredentials>());
        }
    }
}