using System.Linq;

namespace AdventOfCode2020.App.BusTerminal
{
    public class Timetable
    {
        private readonly int[] _busIds;

        public Timetable(params int[] busIds)
        {
            _busIds = busIds.OrderBy(a => a).ToArray();
        }

        public int FirstBusAfter(int timeAtStop)
        {
            var currentTimeToWait = int.MaxValue;
            var currentWinner = _busIds[0];
            foreach (var busId in _busIds)
            {
                var timeSinceLastBus = timeAtStop % busId;
                var timeToWait = busId - timeSinceLastBus;
                if (timeToWait < currentTimeToWait)
                {
                    currentWinner = busId;
                    currentTimeToWait = timeToWait;
                }
            }

            return currentWinner;
        }
    }
}