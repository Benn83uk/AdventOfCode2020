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
            var currentTimeToWait = long.MaxValue;
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
        
        public long TimeToWaitForBus(long timeAtStop, int busId) {
            var timeSinceLastBus = timeAtStop % busId;
            return timeSinceLastBus == 0 ? 0 : busId - timeSinceLastBus;
        }

        public long Checksum(int timeAtStop)
        {
            var busId = FirstBusAfter(timeAtStop);
            var timeToWaitForBus = TimeToWaitForBus(timeAtStop, busId);
            return timeToWaitForBus * busId;
        }

        public long EarliestTimeStampForPattern()
        {
            long time = 0;
            var firstBusId = int.Parse(_busIds[0]);
            for (; time < int.MaxValue - 1; time += firstBusId)
            {
                int i = 0; 
                for (;i < _busIds.Length; i++)
                {
                    if (_busIds[i].Equals("x")) continue;
                    var busId = int.Parse(_busIds[i]);
                    var timeBusMustArrive = time + i;
                    if (TimeToWaitForBus(timeBusMustArrive, busId) != 0) break;
                }

                if (i == _busIds.Length) break;
            }

            return time;
        }
    }
}