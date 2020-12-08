namespace AdventOfCode2020.App.GameConsole
{
    public interface IInstruction
    {
        public ProgramState Execute(in ProgramState state);
    }
}