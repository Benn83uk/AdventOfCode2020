using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020.App.Ferry
{
    public class WaypointNavigation
    {
        private Coordinate _currentCoordinate = new Coordinate(0,0);
        private Coordinate _waypoint = new Coordinate(10,1);

        public WaypointNavigation(params string[] path)
        {
            foreach (var instruction in path)
            {
                var input = int.Parse(instruction.Substring(1));
                if (instruction[0].Equals('L'))
                {
                    _waypoint = _waypoint.RotateLeft(input);
                }
                else if (instruction[0].Equals('R'))
                {
                    _waypoint = _waypoint.RotateRight(input);
                }
                else if (instruction[0].Equals('F'))
                {
                    Move(input);
                }
                else
                {
                    if (Compass.TryParse(instruction[0], out var direction))
                    {
                        _waypoint = _waypoint.Move(direction, input);
                    }
                }
                Console.WriteLine($"Waypoint is now at : {_waypoint}");
            }
        }

        private void Move(int distance)
        {
            for (var d = 0; d < distance; d++)
            {
                _currentCoordinate = _currentCoordinate.MoveTo(_waypoint);
                Console.WriteLine($"Moved to: {_currentCoordinate}");
                 //_waypoint = _waypoint.MoveRelativeTo(_currentCoordinate);
            }
        }

        public int DistanceFromStart()
        {
            return _currentCoordinate.DistanceFromOrigin();
        }
    }
}