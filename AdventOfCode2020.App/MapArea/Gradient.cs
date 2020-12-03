namespace AdventOfCode2020.App.MapArea
{
    public readonly struct Gradient
    {
        public readonly int Right;
        public readonly int Down;

        public Gradient(int right, int down)
        {
            Right = right;
            Down = down;
        }
    }
}