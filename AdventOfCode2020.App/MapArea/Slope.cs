namespace AdventOfCode2020.App.MapArea
{
    //Represents a single line of trees on a Hill.
    public class Slope
    {
        private const char TREE = '#';
        private readonly string _treeLine;
        public Slope(string treeLine)
        {
            _treeLine = treeLine;
        }

        public bool HasTreeAt(int position)
        {
            var i = position % _treeLine.Length;
            return (_treeLine[i].Equals(TREE));
        }
    }
}