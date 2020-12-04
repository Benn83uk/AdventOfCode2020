using System;

namespace AdventOfCode2020.App.PassportControl
{
    public class Passport : StrictNorthPoleCredentials
    {
        private readonly string _countryId;

        public Passport(int birthYear, int issueYear, int expirationYear, string height, string hairColor, string eyeColor, string passportId, string countryId)
        : base(birthYear, issueYear, expirationYear, height, hairColor, eyeColor, passportId)
        {
            _countryId = countryId;
        }

        protected bool Equals(Passport other)
        {
            return base.Equals(other) &&
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
            return HashCode.Combine(base.GetHashCode(), _countryId);
        }

        public override string ToString()
        {
            return base.ToString() + " " +
                   $"cid:{_countryId}";
        }
    }
}