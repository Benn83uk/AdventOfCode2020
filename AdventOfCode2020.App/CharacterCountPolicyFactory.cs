namespace AdventOfCode2020.App
{
    public class CharacterCountPolicyFactory : IPasswordPolicyFactory
    {
        public IPasswordPolicy CreateFromString(string input)
        {
            return new CharacterCountPolicy(input);
        }
    }
}