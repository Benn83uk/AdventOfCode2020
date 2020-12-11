using System;
using System.IO;
using AdventOfCode2020.App.Ferry;
using NUnit.Framework;

namespace AdventOfCode2020.Test.Ferry
{
    [TestFixture]
    public class SeatLayoutTest
    {
        [Test]
        public void NumOccupiedSeatsIsZero()
        {
            var layout = new SeatLayout("L.L", "LLL", "..L");
            Assert.That(layout.NumOccupiedSeats(), Is.EqualTo(0));
        }

        [Test]
        public void SingleSeatNoAdjacentBecomesOccupied()
        {
            var layout = new SeatLayout("...", ".L.", "...");

            var result = layout.ApplyRules();
            Console.WriteLine(result);
            Assert.That(result.NumOccupiedSeats(), Is.EqualTo(1));
        }        
        
        [Test]
        public void SingleSeatOccupiedToRightRemainsEmpty()
        {
            var layout = new SeatLayout("L#", "..");

            var result = layout.ApplyRules();
            Console.WriteLine(result);
            Assert.That(result.NumOccupiedSeats(), Is.EqualTo(1));
        }
        
        [Test]
        public void SingleSeatOccupiedToLeftRemainsEmpty()
        {
            var layout = new SeatLayout("#L", "..");

            var result = layout.ApplyRules();
            Console.WriteLine(result);
            Assert.That(result.NumOccupiedSeats(), Is.EqualTo(1));
        }
        
        [Test]
        public void SingleSeatOccupiedToBottomRemainsEmpty()
        {
            var layout = new SeatLayout("L.", "#.");

            var result = layout.ApplyRules();
            Console.WriteLine(result);
            Assert.That(result.NumOccupiedSeats(), Is.EqualTo(1));
        }
        
        [Test]
        public void SingleSeatOccupiedToTopRemainsEmpty()
        {
            var layout = new SeatLayout("#.", "L.");

            var result = layout.ApplyRules();
            Console.WriteLine(result);
            Assert.That(result.NumOccupiedSeats(), Is.EqualTo(1));
        }
        
        [Test]
        public void SingleSeatOccupiedToTopLeftRemainsEmpty()
        {
            var layout = new SeatLayout("#.", ".L");

            var result = layout.ApplyRules();
            Console.WriteLine(result);
            Assert.That(result.NumOccupiedSeats(), Is.EqualTo(1));
        }
        
        [Test]
        public void OccupiedSeatWithFourOccupiedAdjacentSeatsBecomeEmpty()
        {
            var layout = new SeatLayout("###", ".#.", "..#");

            var result = layout.ApplyRules();
            Console.WriteLine(result);
            Assert.That(result.NumOccupiedSeats(), Is.EqualTo(4));
        }

        [Test]
        public void DayElevenExampleStepOne()
        {
            var lines = File.ReadAllLines("TestFiles/DayElevenExample.txt");
            var layout = new SeatLayout(lines);

            var result = layout.ApplyRules();
            Console.WriteLine(result);
            Assert.That(result.NumOccupiedSeats(), Is.EqualTo(71));
        }
        
        [Test]
        public void DayElevenExampleStepTwo()
        {
            var lines = File.ReadAllLines("TestFiles/DayElevenExample.txt");
            var layout = new SeatLayout(lines);

            var result = layout.ApplyRules().ApplyRules();
            Console.WriteLine(result);
            Assert.That(result.NumOccupiedSeats(), Is.EqualTo(20));
        }
        
        [Test]
        public void DayElevenExample()
        {
            var lines = File.ReadAllLines("TestFiles/DayElevenExample.txt");
            var layout = new SeatLayout(lines);

            var result = layout.ApplyRulesUntilStable();
            Console.WriteLine(result);
            Assert.That(result.NumOccupiedSeats(), Is.EqualTo(37));
        }

        [Test]
        public void TestEquals()
        {
            var layout1 = new SeatLayout("###", ".#.", "..#");
            var layout2 = new SeatLayout("###", ".#.", "..#");
            Assert.That(layout1, Is.EqualTo(layout2));
        }
    }
}