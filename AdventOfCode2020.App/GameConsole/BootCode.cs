using System.Collections.Generic;

namespace AdventOfCode2020.App.GameConsole
{
    public class BootCode
    {
        private readonly IInstruction[] _instructions;
        

        public BootCode(params IInstruction[] instructions)
        {
            _instructions = instructions;
        }

        public int Run()
        {
            var pointerHistory = new List<int>();
            var state = new ProgramState(0,0);
            while (state.Pointer < _instructions.Length)
            {
                if (pointerHistory.Contains(state.Pointer)) break;
                pointerHistory.Add(state.Pointer);
                state = _instructions[state.Pointer].Execute(state);
            }
            return state.Accumulator;
        }
    }
}