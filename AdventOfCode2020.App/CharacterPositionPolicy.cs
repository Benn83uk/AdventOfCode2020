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
    }
}