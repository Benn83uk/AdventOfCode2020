namespace AdventOfCode2020.App.Password
{
    public interface IPasswordPolicyFactory
    {
        IPasswordPolicy CreateFromString(string input);
    }
}