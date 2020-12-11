using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace AdventOfCode2020.App.Ferry
{
    public class SeatLayout
    {
        public const char Occupied = '#';
        public const char Floor = '.';
        public const char Free = 'L';
        
        private readonly char[][] _seats;

        public SeatLayout(params string[] seatRows)
        {
            var height = seatRows.Length;
            _seats = new char[height][];
            for (var i = 0; i < _seats.Length; i++)
            {
                _seats[i] = seatRows[i].ToCharArray();
            }
        }

        private SeatLayout(char[][] seats)
        {
            _seats = seats;
        }

        public int NumOccupiedSeats()
        {
            var occupiedCount = 0;
            for (var y = 0; y < _seats.Length; y++)
            {
                for (var x = 0; x < _seats[y].Length; x++)
                {
                    if (_seats[y][x] == Occupied) occupiedCount++;
                }
            }

            return occupiedCount;
        }

        public SeatLayout ApplyRules()
        {
            var height = _seats.Length;
            var width = _seats[0].Length;
            var newSeats = new char[height][];
            for (var y = 0; y < height; y++)
            {
                newSeats[y] = new char[width];
                for (var x = 0; x < width; x++)
                {
                    newSeats[y][x] = _seats[y][x];
                    
                    if (_seats[y][x] == Free)
                    {
                        if (NumOccupiedSeatsNextToSeatAt(x,y) == 0)
                        {
                            newSeats[y][x] = Occupied;
                        }
                    } else if (_seats[y][x] == Occupied)
                    {
                        if (NumOccupiedSeatsNextToSeatAt(x,y) >= 4)
                        {
                            newSeats[y][x] = Free;
                        }
                    }
                }
            }

            return new SeatLayout(newSeats);
        }

        private int NumOccupiedSeatsNextToSeatAt(in int x, in int y)
        {
            var occupiedCount = 0;
            for (var xDiff = -1; xDiff <= 1; xDiff++)
            {
                for (var yDiff = -1; yDiff <= 1; yDiff++)
                {
                    if (xDiff == 0 && yDiff == 0) continue;
                    Console.WriteLine($"Checking {xDiff},{yDiff}");
                    if (IsSeatOccupiedAt(x + xDiff, y + yDiff)) occupiedCount++;
                }
            }
            Console.WriteLine($"Occupied Count: {occupiedCount}");
            return occupiedCount;
        }

        private bool IsSeatOccupiedAt(in int x, in int y)
        {
            if (y >= _seats.Length || y < 0) return false;
            if (x >= _seats[y].Length || x < 0) return false;
            return _seats[y][x] == Occupied;
        }

        public override string ToString()
        {
            return _seats.Select(r => new string(r)).Aggregate((a, b) => $"{a}{Environment.NewLine}{b}");
        }
    }
}