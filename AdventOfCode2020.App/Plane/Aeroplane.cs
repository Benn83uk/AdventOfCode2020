using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2020.App.Plane
{
    public class Aeroplane
    {
        private readonly Seat[] _seats;

        public Aeroplane(params Seat[] seats)
        {
            _seats = seats;
        }

        public Aeroplane(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            _seats = lines.Select(l => new Seat(l.Trim())).ToArray();
        }

        public int HighestSeatId()
        {
            return _seats.Max(s => s.Id());
        }

        public int MissingSeatId()
        {
            var seatIds = SeatIdsWithoutFrontRow();
            var maxRow = _seats.Max(s => s.Row());
            var maxCol = _seats.Max(s => s.Column());
            for (var row = 1; row < maxRow; row++)
            {
                for (var col = 0; col <= maxCol; col++)
                {
                    Console.WriteLine($"Checking row: {row}, column: {col}");
                    var expectedSeatId = (row * 8) + col;
                    if (
                        !seatIds.Contains(expectedSeatId) &&
                        seatIds.Contains(expectedSeatId-1) &&
                        seatIds.Contains(expectedSeatId+1)
                    ) return expectedSeatId;
                }
            }

            return -1;
        }

        private int[] SeatIdsWithoutFrontRow()
        {
            return _seats
                .Where(s => s.Row() > 0)
                .Select(s => s.Id())
                .OrderBy(i => i)
                .ToArray();
        }
    }
}