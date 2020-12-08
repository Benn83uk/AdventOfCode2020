namespace AdventOfCode2020.App.GameConsole
{
    public class ProgramState
    {
        private readonly int _accumulator;
        private readonly int _pointer;
        
        public ProgramState(int accumulator, int pointer)
        {
            _accumulator = accumulator;
            _pointer = pointer;
        }

        public int AccumulatorValue()
        {
            return _accumulator;
        }
    }
}