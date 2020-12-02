namespace AdventOfCode2020.App
{
    public interface IPasswordPolicyFactory
    {
        IPasswordPolicy CreateFromString(string input);
    }
}