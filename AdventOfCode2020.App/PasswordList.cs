using System.IO;
using System.Linq;

namespace AdventOfCode2020.App
{
    public class PasswordList
    {
        private readonly Password[] _passwords;
        public PasswordList(params Password[] passwords)
        {
            _passwords = passwords;
        }

        public PasswordList(string filePath, IPasswordPolicyFactory policyFactory)
        {
            var lines = File.ReadAllLines(filePath);
            _passwords = lines.Select(line => new Password(line, policyFactory)).ToArray();
        }

        public int NumValid()
        {
            return _passwords.Count(p => p.IsValid());
        }
    }
}