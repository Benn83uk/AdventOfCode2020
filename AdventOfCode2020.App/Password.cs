using System;

namespace AdventOfCode2020.App
{
    public class Password
    {
        private readonly IPasswordPolicy _policy;
        private readonly string _password;
        public Password(string password, IPasswordPolicy policy)
        {
            _policy = policy;
            _password = password;
        }

        public Password(string passwordString)
        {
            var splitByColon = passwordString.Split(": ");
            _policy = new PasswordPolicy(splitByColon[0]);
            _password = splitByColon[1];
        }

        public bool IsValid()
        {
            return _policy.IsValid(_password);
        }
        
        protected bool Equals(Password other)
        {
            return Equals(_policy, other._policy) && _password == other._password;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Password) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_policy, _password);
        }
        
        public override string ToString()
        {
            return $"{_policy}: {_password}";
        }
    }
}