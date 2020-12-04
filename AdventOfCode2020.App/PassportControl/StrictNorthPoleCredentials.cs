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
        }

        private void ValidateBirthYear()
        {
            if (_birthYear > 2002 || _birthYear < 1920) throw new InvalidCredentialFieldException();
        }
        
        private void ValidateIssueYear()
        {
            if (_issueYear > 2020 || _issueYear < 2010) throw new InvalidCredentialFieldException();
        }
    }
}