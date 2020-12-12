using System;

namespace AdventOfCode2020.App.Ferry
{
    public struct Coordinate
    {
        private readonly int _x;
        private readonly int _y;

        public Coordinate(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public Coordinate Move(Compass direction)
        {
            if (direction.Equals(Compass.North)) return Up();
            else if (direction.Equals(Compass.South)) return Down();
            else if (direction.Equals(Compass.West)) return Left();
            else if (direction.Equals(Compass.East)) return Right();
            return this;
        }

        public Coordinate Up()
        {
            return new Coordinate(_x, _y+1);
        }
            
        public Coordinate Down()
        {
            return new Coordinate(_x, _y-1);
        }
            
        public Coordinate Left()
        {
            return new Coordinate(_x-1, _y);
        }
            
        public Coordinate Right()
        {
            return new Coordinate(_x+1, _y);
        }

        public int DistanceFromOrigin()
        {
            return _x + _y;
        }
            
        public bool Equals(Coordinate other)
        {
            return _x == other._x && _y == other._y;
        }

        public override bool Equals(object obj)
        {
            return obj is Coordinate other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_x, _y);
        }
    }
}