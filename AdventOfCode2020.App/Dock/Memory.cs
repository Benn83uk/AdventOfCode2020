using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.App.Dock
{
    public class Memory
    {
        private const int AddressSpaceSize = 36;
        private readonly int[] _addressSpace;
        private readonly IEnumerable<(char, int)> _mask;

        public Memory() : this("") { }

        public Memory(string mask)
        {
            _addressSpace = new int[AddressSpaceSize];
            _mask = mask.Select((item, index) => (item, index)).Where(m => !m.item.Equals('X'));
        }

        public void Add(int address, int value)
        {
            var valueAsBinary = new StringBuilder(Convert.ToString(value, 2).PadLeft(AddressSpaceSize, '0'));
            foreach (var bit in _mask)
            {
                var index = bit.Item2;
                valueAsBinary[index] = bit.Item1;
            }

            _addressSpace[address] = Convert.ToInt32(valueAsBinary.ToString(),2);
        }

        public int Sum()
        {
            return _addressSpace.Sum();
        }
    }
}