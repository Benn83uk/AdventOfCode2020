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
            var adapters = new AdapterList(1, 3);
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
        public void DayTenTaskOneBigExampleFromFile()
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

        [Test]
        public void OnlyOneWayToArrangeOneNumber()
        {
            var adapters = new AdapterList(1);
            var result = adapters.NumArrangements();
            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void TwoWays()
        {
            var adapters = new AdapterList(1, 2);
            var result = adapters.NumArrangements();
            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void OneWayLongChain()
        {
            var adapters = new AdapterList(2, 5, 8);
            var result = adapters.NumArrangements();
            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void SevenWays()
        {
            var adapters = new AdapterList(1, 2, 3, 4);
            // (0) -> 1 -> 2 -> 3 -> 4 -> (7)
            // (0) -> 1 -> 3 -> 4 -> (7)
            // (0) -> 1 -> 2 -> 4 -> (7)
            // (0) -> 1 -> 4 -> (7)
            // (0) -> 2 -> 3 -> 4 -> (7)
            // (0) -> 2 -> 4 -> (7)
            // (0) -> 3 -> 4 -> (7)
            var result = adapters.NumArrangements();
            Assert.That(result, Is.EqualTo(7));
        }

        [Test]
        public void DayTenTaskTwoExample()
        {
            var adapters = new AdapterList(16, 10, 15, 5, 1, 11, 7, 19, 6, 12, 4);
            var result = adapters.NumArrangements();
            Assert.That(result, Is.EqualTo(8));
        }

        [Test]
        public void DayTenTaskTwoBigExampleFromFile()
        {
            var lines = File.ReadAllLines("TestFiles/DayTenExample.txt");
            var numbers = lines.Select(int.Parse).ToArray();
            var adapters = new AdapterList(numbers);
            var result = adapters.NumArrangements();

            Assert.That(result, Is.EqualTo(19208));
        }


        
        [Test]
        public void DayTenTaskTwoAnswer()
        {
            var lines = File.ReadAllLines("TestFiles/DayTenInput.txt");
            var numbers = lines.Select(int.Parse).ToArray();
            var adapters = new AdapterList(numbers);
            var result = adapters.NumArrangements();

            Assert.That(result, Is.EqualTo(518344341716992));
        }

        [Test]
        public void LongChainOneSections()
        {
            var adapters = new AdapterList(1, 4, 5, 6);
            var result = adapters.NumArrangements();
            Assert.That(result, Is.EqualTo(2));
            //(0),1,4,5,6,(9)
            //(0),1,4,  6,(9)
        }

        [Test]
        public void LongChainTwoSections()
        {
            var adapters = new AdapterList(1, 4, 5, 6, 9, 10, 11);
            var result = adapters.NumArrangements();
            Assert.That(result, Is.EqualTo(4));
            //  1  3 1 1 3 1  1  3  [1,2,2]
            //(0),1,4,5,6,9,10,11,(14)
            //(0),1,4,6,9,10,11,(14)
            //(0),1,4,5,6,9,11,(14)
            //(0),1,4,6,9,11,(14)
        }

        [Test]
        public void LongerChainOneSections()
        {
            var adapters = new AdapterList(1, 4, 5, 6, 7);
            var result = adapters.NumArrangements();
            Assert.That(result, Is.EqualTo(4));
            //(0),1,4,5,6,7,(10)
            //(0),1,4,  6,7,(10)
            //(0),1,4,5, ,7,(10)
            //(0),1,4, , ,7,(10)
        }

        [Test]
        public void EvenLongerChainOneSections()
        {
            var adapters = new AdapterList(1, 4, 5, 6, 7, 8);
            var result = adapters.NumArrangements();
            Assert.That(result, Is.EqualTo(7));
            //(0),1,4,5,6,7,8,(11)
            //(0),1,4,  6,7,8,(11)
            //(0),1,4,5, ,7,8,(11)
            //(0),1,4, , ,7,8,(11)
            //(0),1,4,5,6, ,8,(11)
            //(0),1,4, ,6, ,8,(11)
            //(0),1,4,5, , ,8,(11)
        }

        [Test]
        public void EvenEvenLongerChainOneSections()
        {
            var adapters = new AdapterList(1, 4, 5, 6, 7, 8, 9);
            var result = adapters.NumArrangements();
            Assert.That(result, Is.EqualTo(13));
        }

        [Test]
        public void LongChainTwoSectionsOneLonger()
        {
            var adapters = new AdapterList(1, 4, 5, 6, 7, 10, 11, 12);
            var result = adapters.NumArrangements();
            Assert.That(result, Is.EqualTo(8));
            //(0), 1, 4, 5, 6, 7, 10, 11, 12, (15)
            //   1   3  1  1  1  3   1   1    3
            //(0),1,4,5,6,7   ,X
            //(0),1,4, ,6,7   ,X
            //(0),1,4,5, ,7   ,X
            //(0),1,4, , ,7   ,X
            // A,             10,11,12,(15)
            // A,             10,  ,12,(15)
        }

        [Test]
        public void LongChainTwoSectionsBothLonger()
        {
            var adapters = new AdapterList(1, 4, 5, 6, 7, 10, 11, 12, 13);
            var result = adapters.NumArrangements();
            Assert.That(result, Is.EqualTo(16));
            //(0), 1, 4, 5, 6, 7, 10, 11, 12, 13, (16)
            //    1  3  1  1  1  3   1  1    1   3
            //(0),1,4,5,6,7   ,X
            //(0),1,4, ,6,7   ,X
            //(0),1,4,5, ,7   ,X
            //(0),1,4, , ,7   ,X
            // A,             10,11,12,13,(16)
            // A,             10,  ,12,13,(16)
            // A,             10,11,  ,13,(16)
            // A,             10,  ,  ,13,(16) 
        }
    }
}