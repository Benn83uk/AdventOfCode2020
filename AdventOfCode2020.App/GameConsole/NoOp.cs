namespace AdventOfCode2020.App.GameConsole
{
    public class NoOp : IInstruction
    {
        public ProgramState Execute(in ProgramState state, in int input)
        {
            return state;
        }
    }
}