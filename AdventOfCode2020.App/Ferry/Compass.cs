using System;

namespace AdventOfCode2020.App.Ferry
{
    public class Compass
    {
        private readonly string _value;
        public static readonly Compass North = new Compass("North");
        public static readonly Compass East = new Compass("East");
        public static readonly Compass South = new Compass("South");
        public static readonly Compass West = new Compass("West");

        private static readonly Compass[] Directions = new[] {North, East, South, West};

        private Compass(string value)
        {
            _value = value;
        }

        public Compass Right()
        {
            var myIndex = IndexOf(this);
            return myIndex + 1 < Directions.Length ? Directions[myIndex + 1] : Directions[0];
        }
        
        public Compass Left()
        {
            var myIndex = IndexOf(this);
            return myIndex - 1 >= 0 ? Directions[myIndex - 1] : Directions[^1];
        }

        public Compass Left(int degrees)
        {
            var heading = this;
            var numTurns = degrees / 90;
            for (var turns = 0; turns < numTurns; turns++)
            {
                heading = heading.Left();
            }

            return heading;
        }
        
        public Compass Right(int degrees)
        {
            var heading = this;
            var numTurns = degrees / 90;
            for (var turns = 0; turns < numTurns; turns++)
            {
                heading = heading.Right();
            }

            return heading;
        }

        private static int IndexOf(Compass direction)
        {
            for (var i = 0; i < Directions.Length; i++)
            {
                if (Directions[i].Equals(direction)) return i;
            }
            throw new IndexOutOfRangeException("Direction not found");
        }

        public override string ToString()
        {
            return _value;    
        }

        public static bool TryParse(char c, out Compass direction)
        {
            direction = null;
            foreach (var compassPoint in Directions)
            {
                if (compassPoint._value.StartsWith(c)) direction = compassPoint;
            }
            return (direction is not null);
        }
    }
}