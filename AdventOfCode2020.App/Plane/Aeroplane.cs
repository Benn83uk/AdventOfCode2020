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

        public int HighestSeatId()
        {
            return _seats.Max(s => s.Id());
        }
    }
}