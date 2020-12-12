using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020.App.Ferry
{
    public class RouteNavigation
    {
        private readonly List<Coordinate> _coordsPassedThrough;
        private Compass _heading = Compass.East;

        public RouteNavigation(params string[] path)
        {
            _coordsPassedThrough = new List<Coordinate>();
            var currentCoordinate = new Coordinate(0,0);
            foreach (var instruction in path)
            {
                var input = int.Parse(instruction.Substring(1));
                if (instruction[0].Equals('L'))
                {
                    _heading = _heading.Left(input);
                }
                else if (instruction[0].Equals('R'))
                {
                    _heading = _heading.Right(input);
                }
                else
                {
                    if (!Compass.TryParse(instruction[0], out var direction))
                    {
                        direction = _heading;
                    }
                    currentCoordinate = Move(currentCoordinate, direction, input);
                }
            }
        }

        private Coordinate Move(Coordinate fromCoordinate, Compass direction, int distance)
        {
            for (var d = 0; d < distance; d++)
            {
                fromCoordinate = fromCoordinate.Move(direction);
                _coordsPassedThrough.Add(fromCoordinate);
            }

            return fromCoordinate;
        }

        public int DistanceFromStart()
        {
            return _coordsPassedThrough.Last().DistanceFromOrigin();
        }
    }
}