using System.Collections.Generic;

namespace AdventOfCode2020.App.Customs
{
    public class PassengerGroup
    {
        private readonly string[] _groupAnswers;
        public PassengerGroup(params string[] groupAnswers)
        {
            _groupAnswers = groupAnswers;
        }

        public int CountUniqueAnswers()
        {
            var uniqueAnswers = new List<char>();
            foreach (var personAnswers in _groupAnswers)
            {
                foreach (var answer in personAnswers)
                {
                    if (!uniqueAnswers.Contains(answer)) uniqueAnswers.Add(answer);
                }
            }
            return uniqueAnswers.Count;
        }
    }
}