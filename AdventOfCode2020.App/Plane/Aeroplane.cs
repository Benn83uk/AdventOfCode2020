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
    }
}