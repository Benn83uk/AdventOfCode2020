using System;

namespace AdventOfCode2020.App.Plane
{
    public class Seat
    {
        private readonly string _reference;

        public Seat(string reference)
        {
            _reference = reference;
        }

        public int Row()
        {
            var refAsBinaryString = _reference
                .Replace("F", "0")
                .Replace("B", "1");
            return Convert.ToInt32(refAsBinaryString, 2);
        }
    }
}