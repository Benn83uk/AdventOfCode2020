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
            return 1;
        }
    }
}