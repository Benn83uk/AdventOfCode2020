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
        
        public Timetable(string busIds)
        {
            _busIds = busIds.Split(',').Where(a => !a.Equals("x")).Select(int.Parse).OrderBy(a => a).ToArray();
        }

        public int FirstBusAfter(int timeAtStop)
        {
            var currentTimeToWait = int.MaxValue;
            var currentWinner = _busIds[0];
            foreach (var busId in _busIds)
            {
                var timeToWait = TimeToWaitForBus(timeAtStop, busId);
                if (timeToWait < currentTimeToWait)
                {
                    currentWinner = busId;
                    currentTimeToWait = timeToWait;
                }
            }

            return currentWinner;
        }
        
        public int TimeToWaitForBus(int timeAtStop, int busId) {
            var timeSinceLastBus = timeAtStop % busId;
            return busId - timeSinceLastBus;
        }

        public int Checksum(int timeAtStop)
        {
            var busId = FirstBusAfter(timeAtStop);
            var timeToWaitForBus = TimeToWaitForBus(timeAtStop, busId);
            return timeToWaitForBus * busId;
        }
    }
}