namespace AdventOfCode2020.App.PassportControl
{
    public class StrictNorthPoleCredentials : NorthPoleCredentials
    {
        public StrictNorthPoleCredentials(int birthYear, int issueYear, int expirationYear, string height, string hairColor, string eyeColor, string id) 
            : base(birthYear, issueYear, expirationYear, height, hairColor, eyeColor, id)
        {
            Validate();
        }

        private void Validate()
        {
            ValidateBirthYear();
            ValidateIssueYear();
            ValidateExpirationYear();
            ValidateHeight();
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
            if (heightInInches > 59 || heightInInches < 76) throw new InvalidCredentialFieldException();
        }
    }
}