namespace AdventOfCode2020.App
{
    public class CharacterPositionPolicyFactory : IPasswordPolicyFactory
    {
        public IPasswordPolicy CreateFromString(string input)
        {
            return new CharacterPositionPolicy(input);
        }
    }
}