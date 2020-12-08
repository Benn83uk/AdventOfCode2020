using System;
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
                _ => new NoOp(input)
            };
        }

        public int Run()
        {
            var state = Run(_instructions);
            return state.Accumulator;
        }

        private static ProgramState Run(IInstruction[] instructions)
        {
            var pointerHistory = new List<int>();
            var state = new ProgramState(0, 0);
            while (state.Pointer < instructions.Length)
            {
                if (pointerHistory.Contains(state.Pointer))
                {
                    state.Looped = true;
                    break;
                }
                pointerHistory.Add(state.Pointer);
                state = instructions[state.Pointer].Execute(state);
            }

            return state;
        }

        public int HealAndRun()
        {
            var modifiedPointer = 0;
            var oldInstruction = _instructions[0];
            var state = Run(_instructions);
            while (state.Looped && modifiedPointer < _instructions.Length)
            {
                _instructions[modifiedPointer] = oldInstruction;
                modifiedPointer++;
                for (; modifiedPointer < _instructions.Length; modifiedPointer++)
                {
                    var instruction = _instructions[modifiedPointer];
                    if (instruction is Jmp)
                    {
                        Console.WriteLine($"Modifying line {modifiedPointer} to be NoOp");
                        oldInstruction = _instructions[modifiedPointer];
                        _instructions[modifiedPointer] = new NoOp(0);
                        break;
                    } else if (instruction is NoOp)
                    {
                        Console.WriteLine($"Modifying line {modifiedPointer} to be Jmp");
                        oldInstruction = _instructions[modifiedPointer];
                        _instructions[modifiedPointer] = (instruction as NoOp).ToJmp();
                        break;
                    }
                }
                state = Run(_instructions);
            }

            return state.Accumulator;
        }
    }
}