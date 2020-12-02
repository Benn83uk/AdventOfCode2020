namespace AdventOfCode2020.App
{
    public class PasswordPolicy
    {
        private readonly char _character;
        private readonly int _minAppearances;
        private readonly int _maxAppearances;
        
        public PasswordPolicy(char character, int minAppearances, int maxAppearances)
        {
            _character = character;
            _minAppearances = minAppearances;
            _maxAppearances = maxAppearances;
        }

        public bool IsValid(string password)
        {
            var characterCount = CountCharacters(password);
            return characterCount >= _minAppearances && characterCount <= _maxAppearances;
        }

        private int CountCharacters(string password)
        {
            var characterCount = 0;
            for (var i = 0; i < password.Length && characterCount < _maxAppearances + 1; i++)
            {
                if (password[i].Equals(_character)) characterCount++;
            }

            return characterCount;
        }
    }
}