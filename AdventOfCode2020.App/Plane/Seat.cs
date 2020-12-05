using System;

namespace AdventOfCode2020.App.Plane
{
    public class Seat
    {
        private readonly string _row;

        public Seat(string reference)
        {
            _row = reference;
        }

        public int Row()
        {
            var rowAsBinaryString = _row
                .Replace("F", "0")
                .Replace("B", "1");
            return Convert.ToInt32(rowAsBinaryString, 2);
        }
    }
}