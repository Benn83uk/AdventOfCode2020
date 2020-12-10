using System;

namespace AdventOfCode2020.App.Joltage
{
    public readonly struct AdapterDifferences
    {
        private readonly int[] _differences;
        public readonly int One => _differences[0];

        public readonly int Two => _differences[1];

        public readonly int Three => _differences[2];

        public AdapterDifferences(int one, int two, int three)
        {
            _differences = new[] {one, two, three};
        }

        public void AddDifference(int diff)
        {
            _differences[diff-1]++;
        }

        public int Checksum()
        {
            return One * Three;
        }

        public bool Equals(AdapterDifferences other)
        {
            return One == other.One && Two == other.Two && Three == other.Three;
        }

        public override bool Equals(object obj)
        {
            return obj is AdapterDifferences other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(One, Two, Three);
        }

        public override string ToString()
        {
            return $"Differences: {One}, {Two}, {Three}";
        }
    }
}