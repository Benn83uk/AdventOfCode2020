using System.IO;
using System.Linq;
using AdventOfCode2020.App.Dock;
using NUnit.Framework;

namespace AdventOfCode2020.Test.Dock
{
    [TestFixture]
    public class MemoryTest
    {
        [Test]
        public void AddElevenToAddressEightNoMask()
        {
            var memory = new Memory();
            memory.Add(8, 11);
            Assert.That(memory.Sum(), Is.EqualTo(11));
        }
        
        [Test]
        public void AddElevenToAddressEightWithMask()
        {
            var memory = new Memory("XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X");
            memory.Add(8, 11);
            Assert.That(memory.Sum(), Is.EqualTo(73));
        }
        
        [Test]
        public void DayFourteenTaskOneExample()
        {
            var memory = new Memory("XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X");
            memory.Add(8, 11);
            memory.Add(7, 101);
            memory.Add(8, 0);
            Assert.That(memory.Sum(), Is.EqualTo(165));
        }
        
        [Test]
        public void DayFourteenTaskOneExampleFromFile()
        {
            var lines = File.ReadAllLines("TestFiles/DayFourteenExample.txt");
            var memory = new Memory(lines[0].Replace("mask = ", ""));
            memory.Add(lines.Skip(1).ToArray());
            Assert.That(memory.Sum(), Is.EqualTo(165));
        }
        
        [Test]
        public void DayFourteenTaskOneAnswer()
        {
            var lines = File.ReadAllLines("TestFiles/DayFourteenInput.txt");
            var memory = new Memory(lines[0].Replace("mask = ", ""));
            memory.Add(lines.Skip(1).ToArray());
            Assert.That(memory.Sum(), Is.EqualTo(9879607673316));
        }
    }
}