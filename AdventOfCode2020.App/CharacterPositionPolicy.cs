using System;

namespace AdventOfCode2020.App
{
    public class CharacterPositionPolicy : IPasswordPolicy
    {
        private readonly char _character;
        private readonly int[] _positions;
        
        public CharacterPositionPolicy(char character, params int[] positions)
        {
            _character = character;
            _positions = positions;
        }

        public bool IsValid(string password)
        {
            var count = 0;
            foreach (var position in _positions)
            {
                if (password[position - 1] == _character) count++;
                if (count > 1) return false;
            }

            return count == 1;
        }
        
        protected bool Equals(CharacterPositionPolicy other)
        {
            return _character == other._character && Equals(_positions, other._positions);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CharacterPositionPolicy) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_character, _positions);
        }

        public override string ToString()
        {
            return $"{_positions[0]}-{_positions[1]} {_character}";
        }
    }
}