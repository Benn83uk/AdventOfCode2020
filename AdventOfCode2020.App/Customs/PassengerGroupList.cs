using System.Linq;

namespace AdventOfCode2020.App.Customs
{
    public class PassengerGroupList
    {
        private readonly PassengerGroup[] _passengerGroups;
        public PassengerGroupList(params PassengerGroup[] passengerGroups)
        {
            _passengerGroups = passengerGroups;
        }

        public int SumUniqueAnswers()
        {
            return _passengerGroups.Sum(g => g.CountUniqueAnswers());
        }
    }
}