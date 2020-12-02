namespace AdventOfCode2020.App.Password
{
    public interface IPasswordPolicy
    {
        bool IsValid(string password);
    }
}