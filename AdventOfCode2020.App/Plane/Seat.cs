using System;

namespace AdventOfCode2020.App.Plane
{
    public class Seat
    {
        private readonly string _row;
        private readonly string _column;

        public Seat(string reference)
        {
            _row = ExtractRow(reference);
            _column = ExtractColumn(reference);
        }

        private string ExtractRow(string reference)
        {
            return reference.Replace("L", "").Replace("R", "");
        }

        private string ExtractColumn(string reference)
        {
            return reference.Replace("F", "").Replace("B", "");
        }

        public int Row()
        {
            return FromStringWithBinary(_row, "F", "B");
        }

        public int Column()
        {
            return FromStringWithBinary(_column, "L", "R");
        }

        private static int FromStringWithBinary(in string input, in string zero, in string one)
        {
            var inputAsBinaryString = input
                .Replace(zero, "0")
                .Replace(one, "1");
            return Convert.ToInt32(inputAsBinaryString, 2);
        }

        public int Id()
        {
            return (Row() * 8) + Column();
        }
    }
}