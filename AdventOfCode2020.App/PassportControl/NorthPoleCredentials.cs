using System;
using System.ComponentModel.DataAnnotations;

namespace AdventOfCode2020.App.PassportControl
{
    public class NorthPoleCredentials : IIdentityCredential
    {
        protected readonly int _birthYear;
        protected readonly int _issueYear;
        protected readonly int _expirationYear;
        protected readonly string _height;
        protected readonly string _hairColor;
        protected readonly string _eyeColor;
        protected readonly string _passportId;

        public NorthPoleCredentials(int birthYear, int issueYear, int expirationYear, string height, string hairColor,
            string eyeColor, string passportId)
        {
            _birthYear = birthYear;
            _issueYear = issueYear;
            _expirationYear = expirationYear;
            _height = height;
            _hairColor = hairColor;
            _eyeColor = eyeColor;
            _passportId = passportId;
        }

        protected bool Equals(NorthPoleCredentials other)
        {
            return _birthYear == other._birthYear && 
                   _issueYear == other._issueYear && 
                   _expirationYear == other._expirationYear && 
                   _height == other._height && 
                   _hairColor == other._hairColor && 
                   _eyeColor == other._eyeColor && 
                   _passportId == other._passportId;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NorthPoleCredentials) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_birthYear, _issueYear, _expirationYear, _height, _hairColor, _eyeColor, _passportId);
        }

        public override string ToString()
        {
            return $"byr:{_birthYear} " +
                   $"iyr:{_issueYear} " +
                   $"eyr:{_expirationYear} " +
                   $"hgt:{_height} " +
                   $"hcl:{_hairColor} " +
                   $"ecl:{_eyeColor} " +
                   $"pid:{_passportId} ";
        }
    }
}