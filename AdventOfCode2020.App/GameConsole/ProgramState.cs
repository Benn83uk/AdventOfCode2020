namespace AdventOfCode2020.App.GameConsole
{
    public class ProgramState
    {
        public readonly int Accumulator;
        public readonly int Pointer;
        public bool Looped = false;
        
        public ProgramState(int accumulator, int pointer)
        {
            Accumulator = accumulator;
            Pointer = pointer;
        }

        public ProgramState NoOp()
        {
            return new ProgramState(Accumulator, Pointer + 1);
        }

        public ProgramState IncreaseAccumulator(in int value)
        {
            return new ProgramState(Accumulator + value, Pointer+1);
        }

        public ProgramState Jump(int value)
        {
            return new ProgramState(Accumulator, Pointer + value);
        }
    }
}