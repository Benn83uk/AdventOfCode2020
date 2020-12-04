using System;

namespace AdventOfCode2020.App.PassportControl
{
    public class Passport : IIdentityCredential
    {
        private readonly int _birthYear;
        private readonly int _issueYear;
        private readonly int _expirationYear;
        private readonly string _height;
        private readonly string _hairColor;
        private readonly string _eyeColor;
        private readonly string _id;
        private readonly int _countryId;


        public Passport()
        {
        }

        public Passport(int birthYear, int issueYear, int expirationYear, string height, string hairColor, string eyeColor, string id, int countryId)
        {
            _birthYear = birthYear;
            _issueYear = issueYear;
            _expirationYear = expirationYear;
            _height = height;
            _hairColor = hairColor;
            _eyeColor = eyeColor;
            _id = id;
            _countryId = countryId;
        }

        protected bool Equals(Passport other)
        {
            return _birthYear == other._birthYear && 
                   _issueYear == other._issueYear && 
                   _expirationYear == other._expirationYear && 
                   _height == other._height && 
                   _hairColor == other._hairColor && 
                   _eyeColor == other._eyeColor && 
                   _id == other._id && 
                   _countryId == other._countryId;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Passport) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_birthYear, _issueYear, _expirationYear, _height, _hairColor, _eyeColor, _id, _countryId);
        }

        public override string ToString()
        {
            return $"byr:{_birthYear} " +
                   $"iyr:{_issueYear} " +
                   $"eyr:{_expirationYear} " +
                   $"hgt:{_height} " +
                   $"hcl:{_hairColor} " +
                   $"ecl:{_eyeColor} " +
                   $"pid:{_id} " +
                   $"cid:{_countryId}";
        }
    }
}