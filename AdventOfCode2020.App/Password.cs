namespace AdventOfCode2020.App
{
    public class Password
    {
        private readonly PasswordPolicy _policy;
        private readonly string _password;
        public Password(string password, PasswordPolicy policy)
        {
            _policy = policy;
            _password = password;
        }

        public bool IsValid()
        {
            return _policy.IsValid(_password);
        }
    }
}