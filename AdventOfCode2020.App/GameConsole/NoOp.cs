namespace AdventOfCode2020.App.GameConsole
{
    public class NoOp : IInstruction
    {
        private readonly int _value;

        public NoOp(int value)
        {
            _value = value;
        }

        public ProgramState Execute(in ProgramState state)
        {
            return state.NoOp();
        }

        public Jmp ToJmp()
        {
            return new Jmp(_value);
        }
    }
}