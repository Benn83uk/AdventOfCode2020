using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.App.Dock
{
    public class MemoryDecoder
    {
        private const int MaskSize = 36;
        private readonly Memory _memory;
        private IEnumerable<(char, int)> _mask;

        public MemoryDecoder(string mask)
        {
            _memory = new Memory();
            SetMask(mask);
        }

        private IEnumerable<(char, int)> DecodeMask(string mask)
        {
            return mask.Select((item, index) => (item, index)).Where(m => !m.item.Equals('0'));
        }

        public void Add(in int initialAddress, in long value)
        {
            var addressMask = AddressMask(initialAddress);
            Console.WriteLine($"Mask: {addressMask}");

            var addressesToAlter = AddressesFromMask(addressMask);

            foreach (var address in addressesToAlter)
            {
                Console.WriteLine($"Address: {address}");
                _memory.Add(address, value);
            }
        }

        private List<long> AddressesFromMask(string addressMask)
        {
            if (!addressMask.Contains("X")) return new List<long>(){FromBinaryString(addressMask)};

            var result = new List<long>();
            var i = addressMask.IndexOf('X');
            
            var addressWith0 = AddressReplaceMask(addressMask, i, '0');
            result.AddRange(AddressesFromMask(addressWith0));
            var addressWith1 = AddressReplaceMask(addressMask, i, '1');
            result.AddRange(AddressesFromMask(addressWith1));

            return result;
        }

        private static long FromBinaryString(string binary)
        {
            return Convert.ToInt64(binary, 2);
        }

        private static string AddressReplaceMask(string addressMask, int i, char replacement)
        {
            var addressWith0Builder = new StringBuilder(addressMask);
            addressWith0Builder[i] = replacement;
            return addressWith0Builder.ToString();
        }

        private string AddressMask(int address)
        {
            var addressAsBinary = new StringBuilder(Convert.ToString(address, 2).PadLeft(MaskSize, '0'));
            foreach (var bit in _mask)
            {
                var index = bit.Item2;
                addressAsBinary[index] = bit.Item1;
            }

            var addressMask = addressAsBinary.ToString();
            return addressMask;
        }

        public long Sum()
        {
            return _memory.Sum();
        }

        public void Add(string[] instructions)
        {
            foreach (var instruction in instructions)
            {
                if (instruction.StartsWith("mask"))
                {
                    SetMask(instruction.Replace("mask = ", ""));
                }
                else
                {
                    var match = Regex.Match(instruction, "mem\\[(?<memAddress>[0-9]+)\\] = (?<value>[0-9]+)\\Z");
                    var memAddress = int.Parse(match.Groups["memAddress"].Value);
                    var value = long.Parse(match.Groups["value"].Value);
                    Add(memAddress, value);
                }
            }
        }

        public void SetMask(string mask)
        {
            _mask = DecodeMask(mask);
        }
    }
}