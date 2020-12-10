using System.IO;
using System.Linq;
using AdventOfCode2020.App.Joltage;
using NUnit.Framework;

namespace AdventOfCode2020.Test.Joltage
{
    [TestFixture]
    public class AdapterListTest
    {
        [Test]
        public void CountOneDifferenceOf3()
        {
            var expected = new AdapterDifferences(0, 0, 1);
            var adapters = new AdapterList(0);
            var result = adapters.Chain();
            Assert.That(result, Is.EqualTo(expected));
        }
        
        [Test]
        public void CountOneDifferenceOfOneEach()
        {
            var expected = new AdapterDifferences(1, 1, 1);
            var adapters = new AdapterList(1,3);
            var result = adapters.Chain();
            Assert.That(result, Is.EqualTo(expected));
        }
        
        [Test]
        public void DayTenTaskOneExample()
        {
            var expected = new AdapterDifferences(7, 0, 5);
            var adapters = new AdapterList(16, 10, 15, 5, 1, 11, 7, 19, 6, 12, 4);
            var result = adapters.Chain();
            Assert.That(result, Is.EqualTo(expected));
        }
        
        [Test]
        public void DayTenTaskOneExampleFromFile()
        {
            var lines = File.ReadAllLines("TestFiles/DayTenExample.txt");
            var numbers = lines.Select(int.Parse).ToArray();
            var adapters = new AdapterList(numbers);
            var result = adapters.Chain();
            
            var expected = new AdapterDifferences(22, 0, 10);
            Assert.That(result, Is.EqualTo(expected));
            Assert.That(result.Checksum(), Is.EqualTo(220));
        }
        
        [Test]
        public void DayTenTaskOneAnswer()
        {
            var lines = File.ReadAllLines("TestFiles/DayTenInput.txt");
            var numbers = lines.Select(int.Parse).ToArray();
            var adapters = new AdapterList(numbers);
            var result = adapters.Chain();
            
            Assert.That(result.Checksum(), Is.EqualTo(2775));
        }
    }
}