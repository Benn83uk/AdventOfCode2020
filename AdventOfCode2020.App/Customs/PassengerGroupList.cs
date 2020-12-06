using System.Collections.Generic;
using System.IO;
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

        public PassengerGroupList(string filePath)
        {
            var result = new List<PassengerGroup>();
            var lines = File.ReadAllLines(filePath);
            var currentInput = new List<string>();
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    result.Add(CreatePassengerGroup(currentInput));
                    currentInput.Clear();
                }
                else
                {
                    currentInput.Add(line);
                }
            }
            
            if (currentInput.Count > 0) result.Add(CreatePassengerGroup(currentInput));

            _passengerGroups = result.ToArray();
        }

        private PassengerGroup CreatePassengerGroup(List<string> currentInput)
        {
            return new PassengerGroup(currentInput.ToArray());
        }

        public int SumUniqueAnswers()
        {
            return _passengerGroups.Sum(g => g.CountUniqueAnswers());
        }
    }
}