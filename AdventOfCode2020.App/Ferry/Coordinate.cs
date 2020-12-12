using System;
using System.Collections;

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
        
        public Coordinate Move(Compass direction, int distance)
        {
            var result = this;
            for (var i = 0; i < distance; i++)
            {
                result = result.Move(direction);
            }

            return result;
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
            return Math.Abs(_x) + Math.Abs(_y);
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

        public override string ToString()
        {
            return $"({_x}, {_y})";
        }

        public Coordinate RotateLeft(int degrees)
        {
            var timesToRotate = degrees / 90;
            var result = this;
            for (var i = 0; i < timesToRotate; i++)
            {
                result = result.RotateLeft();
            }

            return result;
        }

        private Coordinate RotateLeft()
        {
            return new Coordinate(0 - _y, _x);
        }

        public Coordinate RotateRight(int degrees)
        {
            var timesToRotate = degrees / 90;
            var result = this;
            for (var i = 0; i < timesToRotate; i++)
            {
                result = result.RotateRight();
            }

            return result;
        }
        
        private Coordinate RotateRight()
        {
            return new Coordinate(_y, 0 - _x);
        }

        public Coordinate MoveTo(Coordinate waypoint)
        {
            return new Coordinate(_x + waypoint._x, _y + waypoint._y);
        }
    }
}