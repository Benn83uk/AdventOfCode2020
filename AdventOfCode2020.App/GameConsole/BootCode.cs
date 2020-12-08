namespace AdventOfCode2020.App.GameConsole
{
    public class BootCode
    {
        private readonly IInstruction[] _instructions;
        private ProgramState _state;

        public BootCode(params IInstruction[] instructions)
        {
            _state = new ProgramState(0,0);
            _instructions = instructions;
        }

        public int AccumulatorValue()
        {
            return _state.AccumulatorValue();
        }
    }
}