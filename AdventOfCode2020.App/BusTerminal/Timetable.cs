using System.Linq;

namespace AdventOfCode2020.App.BusTerminal
{
    public class Timetable
    {
        private readonly string[] _busIds;

        public Timetable(params int[] busIds)
        {
            _busIds = busIds.Select(b => b.ToString()).ToArray();
        }
        
        public Timetable(string busIds)
        {
            _busIds = busIds.Split(',');
        }

        public int FirstBusAfter(int timeAtStop)
        {
            var currentTimeToWait = int.MaxValue;
            var currentWinner = -1;
            foreach (var busIdStr in _busIds)
            {
                if (busIdStr.Equals("x")) continue;

                var busId = int.Parse(busIdStr);
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