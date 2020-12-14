using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.App.Dock
{
    public class Memory
    {
        private const int MaskSize = 36;
        private readonly Dictionary<int, long> _addressSpace;
        private IEnumerable<(char, int)> _mask;

        public Memory() : this("") { }

        public Memory(string mask)
        {
            _addressSpace = new Dictionary<int, long>();
            _mask = DecodeMask(mask);
        }

        private IEnumerable<(char, int)> DecodeMask(string mask)
        {
            return mask.Select((item, index) => (item, index)).Where(m => !m.item.Equals('X'));
        }

        public void Add(int address, long value)
        {
            var valueAsBinary = new StringBuilder(Convert.ToString(value, 2).PadLeft(MaskSize, '0'));
            foreach (var bit in _mask)
            {
                var index = bit.Item2;
                valueAsBinary[index] = bit.Item1;
            }

            _addressSpace[address] = Convert.ToInt64(valueAsBinary.ToString(),2);
        }

        public long Sum()
        {
            return _addressSpace.Values.Sum();
        }

        public void Add(string[] instructions)
        {
            foreach (var instruction in instructions)
            {
                if (instruction.StartsWith("mask"))
                {
                    _mask = DecodeMask(instruction.Replace("mask = ", ""));
                }
                else
                {
                    var match = Regex.Match(instruction, "mem\\[(?<memAddress>[0-9]+)\\] = (?<value>[0-9]+)\\Z");
                    var memAddress = int.Parse(match.Groups["memAddress"].Value);
                    var value = long.Parse(match.Groups["value"].Value);
                    Console.WriteLine($"Address: {memAddress} setting value to: {value}");
                    Add(memAddress, value);
                }
            }
        }
    }
}