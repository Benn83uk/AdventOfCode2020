using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.App.Ferry
{
    public class RouteNavigation
    {
        private List<Coordinate> _coordsPassedThrough;

        public RouteNavigation(params string[] path)
        {
            _coordsPassedThrough = new List<Coordinate>();
            var currentCoordinate = new Coordinate(0,0);
            foreach (var instruction in path)
            {
                var distance = int.Parse(instruction.Substring(1));
                for (var d = 0; d < distance; d++)
                {
                    currentCoordinate = instruction[0] switch
                    {
                        'N' => currentCoordinate.Up(),
                        'S' => currentCoordinate.Down(),
                        'W' => currentCoordinate.Left(),
                        'E' => currentCoordinate.Right(),
                        _ => currentCoordinate
                    };
                    _coordsPassedThrough.Add(currentCoordinate);
                }
            }
        }

        public int DistanceFromStart()
        {
            return _coordsPassedThrough.Last().DistanceFromOrigin();
        }
    }
}