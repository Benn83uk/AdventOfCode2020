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
            var rowAsBinaryString = _row
                .Replace("F", "0")
                .Replace("B", "1");
            return Convert.ToInt32(rowAsBinaryString, 2);
        }

        public int Column()
        {
            var columnAsBinaryString = _column
                .Replace("L", "0")
                .Replace("R", "1");
            return Convert.ToInt32(columnAsBinaryString, 2);
        }

        public int Id()
        {
            return (Row() * 8) + Column();
        }
    }
}