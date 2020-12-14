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
    }
}