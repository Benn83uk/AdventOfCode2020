using System;
using System.Collections.Generic;
using System.IO;
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
                .Trim()
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

            if (!input.ContainsKey("cid"))
            {
                try
                {
                    return new StrictNorthPoleCredentials(birthYear, issueYear, expirationYear, height, hairColor,
                        eyeColor,
                        passportId);
                }
                catch (InvalidCredentialFieldException)
                {
                    return INVALID_CREDENTIALS;
                }
            }

            var countryId = input["cid"];
            try
            {
                return new Passport(birthYear, issueYear, expirationYear, height, hairColor, eyeColor, passportId,
                    countryId);
            }
            catch (InvalidCredentialFieldException)
            {
                return INVALID_CREDENTIALS;
            }
        }

        public static IIdentityCredential[] CreateFromFile(string filePath)
        {
            var result = new List<IIdentityCredential>();
            var lines = File.ReadAllLines(filePath);
            var currentInput = lines[0];
            for (var  i = 1;  i < lines.Length;  i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i]))
                {
                    result.Add(Create(currentInput));
                    currentInput = "";
                }
                else
                {
                    currentInput = currentInput + " " + lines[i];
                }
            }
            
            if (!string.IsNullOrWhiteSpace(currentInput)) result.Add(Create(currentInput));

            return result.ToArray();
        }

        public static int CountValidPassportsInFile(string filePath)
        {
            return CreateFromFile(filePath)
                .Count(cred => cred is Passport || cred is StrictNorthPoleCredentials);
        }
    }
}