using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.App.PassportControl
{
    public static class IdentityCredentialFactory
    {
        public static IIdentityCredential Create(in string input)
        {
            var dictionary = CreateDictionary(input);

            return Create(dictionary);
        }

        private static Dictionary<string, string> CreateDictionary(in string input)
        {
            return input.Split(' ')
                .Select(str => str.Split(':'))
                .ToDictionary(
                    splitByColon => splitByColon[0].Trim(), 
                    splitByColon => splitByColon[1].Trim()
                );
        }

        private static IIdentityCredential Create(in Dictionary<string, string> input)
        {
            if (input.ContainsKey("cid"))
            {
                return new Passport();
            }

            return new NorthPoleCredentials();
        }
    }
}