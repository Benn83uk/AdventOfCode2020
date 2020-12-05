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
            return _reference.Equals("F") ? 0 : 1;
        }
    }
}