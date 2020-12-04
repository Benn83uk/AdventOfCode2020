using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.App.PassportControl
{
    public class StrictNorthPoleCredentials : NorthPoleCredentials
    {
        private static readonly string[] EyeColors = new[]
        {
            "amb", "blu", "brn", "gry", "grn", "hzl", "oth"
        };
        public StrictNorthPoleCredentials(int birthYear, int issueYear, int expirationYear, string height, string hairColor, string eyeColor, string passportId) 
            : base(birthYear, issueYear, expirationYear, height, hairColor, eyeColor, passportId)
        {
            Validate();
        }

        private void Validate()
        {
            ValidateBirthYear();
            ValidateIssueYear();
            ValidateExpirationYear();
            ValidateHeight();
            ValidateHairColor();
            ValidateEyeColor();
            ValidatePassportId();
        }

        private void ValidateBirthYear()
        {
            if (_birthYear > 2002 || _birthYear < 1920) throw new InvalidCredentialFieldException();
        }
        
        private void ValidateIssueYear()
        {
            if (_issueYear > 2020 || _issueYear < 2010) throw new InvalidCredentialFieldException();
        }
        
        private void ValidateExpirationYear()
        {
            if (_expirationYear > 2030 || _expirationYear < 2020) throw new InvalidCredentialFieldException();
        }

        private void ValidateHeight()
        {
            if (_height.EndsWith("cm")) ValidateHeightInCM();
            else if (_height.EndsWith("in")) ValidateHeightInInches();
            else throw new InvalidCredentialFieldException();
        }

        private void ValidateHeightInCM()
        {
            var heightInCm = int.Parse(_height.Replace("cm", ""));
            if (heightInCm > 193 || heightInCm < 150) throw new InvalidCredentialFieldException();
        }
        
        private void ValidateHeightInInches()
        {
            var heightInInches = int.Parse(_height.Replace("in", ""));
            if (heightInInches > 76 || heightInInches < 59) throw new InvalidCredentialFieldException();
        }

        private void ValidateHairColor()
        {
            if (!Regex.IsMatch(_hairColor, "\\A#[a-f0-9]{6}\\Z")) throw new InvalidCredentialFieldException();
        }

        private void ValidateEyeColor()
        {
            if (!EyeColors.Contains(_eyeColor)) throw new InvalidCredentialFieldException();
        }

        private void ValidatePassportId()
        {
            if (!Regex.IsMatch(_passportId, "\\A[0-9]{9}\\Z")) throw new InvalidCredentialFieldException();
        }
    }
}