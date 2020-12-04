using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.App.PassportControl
{
    public static class IdentityCredentialFactory
    {
        public static readonly IIdentityCredential INVALID_CREDENTIALS = new InvalidIdentityCredential();

        public static IIdentityCredential Create(in string input)
        {
            var dictionary = CreateDictionary(input);

            return Create(dictionary);
        }

        private static Dictionary<string, string> CreateDictionary(in string input)
        {
            return input
                .Replace(Environment.NewLine, " ")
                .Split(' ')
                .Select(str => str.Split(':'))
                .ToDictionary(
                    splitByColon => splitByColon[0].Trim(), 
                    splitByColon => splitByColon[1].Trim()
                );
        }

        private static IIdentityCredential Create(in Dictionary<string, string> input)
        {
            string height;
            int issueYear;
            int birthYear;
            int expirationYear;
            string eyeColor;
            string hairColor;
            string passportId;
            try
            {
                height = input["hgt"];
                issueYear = int.Parse(input["iyr"]);
                birthYear = int.Parse(input["byr"]);
                expirationYear = int.Parse(input["eyr"]);
                eyeColor = input["ecl"];
                hairColor = input["hcl"];
                passportId = input["pid"];
            }
            catch (KeyNotFoundException)
            {
                return INVALID_CREDENTIALS;
            }

            if (input.ContainsKey("cid"))
            {
                var countryId = input["cid"];
                return new Passport(birthYear, issueYear, expirationYear, height, hairColor, eyeColor, passportId,
                    countryId);
            }

            return new NorthPoleCredentials();
        }
    }
}