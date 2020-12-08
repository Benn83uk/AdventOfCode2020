namespace AdventOfCode2020.App.GameConsole
{
    public class Jmp : IInstruction
    {
        private int _value;

        public Jmp(int value)
        {
            _value = value;
        }

        public ProgramState Execute(in ProgramState state)
        {
            return state.Jump(_value);
        }
    }
}