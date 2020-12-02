namespace AdventOfCode2020.App
{
    public interface IPasswordPolicy
    {
        bool IsValid(string password);
    }
}