using System;

namespace AdventOfCode2020.App
{
    public class CharacterCountPolicy : IPasswordPolicy
    {
        private readonly char _character;
        private readonly int _minAppearances;
        private readonly int _maxAppearances;
        
        public CharacterCountPolicy(char character, int minAppearances, int maxAppearances)
        {
            _character = character;
            _minAppearances = minAppearances;
            _maxAppearances = maxAppearances;
        }

        public CharacterCountPolicy(string policy)
        {
            var splitBySpace = policy.Split(' ');
            var range = splitBySpace[0];
            _character = splitBySpace[1][0];
            var rangeSplitByDash = range.Split("-");
            _minAppearances = int.Parse(rangeSplitByDash[0]);
            _maxAppearances = int.Parse(rangeSplitByDash[1]);
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
        
        protected bool Equals(CharacterCountPolicy other)
        {
            return _character == other._character && _minAppearances == other._minAppearances && _maxAppearances == other._maxAppearances;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CharacterCountPolicy) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_character, _minAppearances, _maxAppearances);
        }

        public override string ToString()
        {
            return $"{_minAppearances}-{_maxAppearances} {_character}";
        }
    }
}