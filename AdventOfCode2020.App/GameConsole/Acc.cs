namespace AdventOfCode2020.App.GameConsole
{
    public class Acc : IInstruction
    {
        private readonly int _value;

        public Acc(int value)
        {
            _value = value;
        }

        public ProgramState Execute(in ProgramState state)
        {
            return state.IncreaseAccumulator(_value);
        }
    }
}