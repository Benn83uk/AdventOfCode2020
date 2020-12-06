using System.Collections.Generic;
using System.Linq;

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

        public int CountSameAnswers()
        {
            var answerCount = new Dictionary<char, int>();
            foreach (var personAnswers in _groupAnswers)
            {
                foreach (var answer in personAnswers)
                {
                    if (answerCount.ContainsKey(answer)) answerCount[answer]++;
                    else answerCount.Add(answer, 1);
                }
            }

            var numPeople = _groupAnswers.Length;
            return answerCount.Count(kvp => kvp.Value == numPeople);
        }
    }
}