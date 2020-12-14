using System.IO;
using System.Linq;
using AdventOfCode2020.App.Dock;
using NUnit.Framework;

namespace AdventOfCode2020.Test.Dock
{
    [TestFixture]
    public class MemoryDecoderTest
    {
        [Test]
        public void MemoryAddressDecode()
        {
            var memory = new MemoryDecoder("000000000000000000000000000000X1001X");
            memory.Add(42, 100);
            Assert.That(memory.Sum(), Is.EqualTo(400));
        }
        
        [Test]
        public void DayFourteenTaskTwoExample()
        {
            var memory = new MemoryDecoder("000000000000000000000000000000X1001X");
            memory.Add(42, 100);
            memory.SetMask("00000000000000000000000000000000X0XX");
            memory.Add(26, 1);
            Assert.That(memory.Sum(), Is.EqualTo(208));
        }
        
        [Test]
        public void DayFourteenTaskTwoAnswer()
        {
            var lines = File.ReadAllLines("TestFiles/DayFourteenInput.txt");
            var memory = new MemoryDecoder(lines[0].Replace("mask = ", ""));
            memory.Add(lines.Skip(1).ToArray());
            Assert.That(memory.Sum(), Is.EqualTo(3435342392262));
        }
    }
}