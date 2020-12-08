using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.App.GameConsole
{
    public class BootCode
    {
        private readonly IInstruction[] _instructions;
        
        public BootCode(params IInstruction[] instructions)
        {
            _instructions = instructions;
        }
        
        public BootCode(params string[] instructions)
        {
            _instructions = instructions.Select(CreateInstruction).ToArray();
        }

        private static IInstruction CreateInstruction(string instruction)
        {
            var splitBySpace = instruction.Split(' ');
            var op = splitBySpace[0];
            var input = int.Parse(splitBySpace[1]);
            return op switch
            {
                "acc" => new Acc(input),
                "jmp" => new Jmp(input),
                _ => new NoOp()
            };
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