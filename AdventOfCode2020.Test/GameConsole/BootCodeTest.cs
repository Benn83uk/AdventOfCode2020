using System.IO;
using System.Reflection.Metadata.Ecma335;
using AdventOfCode2020.App.GameConsole;
using Microsoft.AspNetCore.Routing.Matching;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace AdventOfCode2020.Test.GameConsole
{
    [TestFixture]
    public class BootCodeTest
    {
        [Test]
        public void RunNop()
        {
            var code = new BootCode(
                new NoOp()
            );
            Assert.That(code.Run(), Is.EqualTo(0));
        }
        
        [Test]
        public void RunAcc()
        {
            var code = new BootCode(
                new NoOp(),
                new Acc(3)
            );
            Assert.That(code.Run(), Is.EqualTo(3));
        }
        
        [Test]
        public void RunTwoAcc()
        {
            var code = new BootCode(
                new NoOp(),
                new Acc(3),
                new Acc(4)
            );
            Assert.That(code.Run(), Is.EqualTo(7));
        }        
        
        [Test]
        public void RunJmp()
        {
            var code = new BootCode(
                new NoOp(),
                new Jmp(2),
                new Acc(3),
                new Acc(4)
            );
            Assert.That(code.Run(), Is.EqualTo(4));
        }
        
        [Test]
        public void RunJmpStopWhenLoop()
        {
            var code = new BootCode(
                new NoOp(),
                new Jmp(2),
                new Acc(3),
                new Acc(4),
                new Jmp(-2),
                new Acc(10)
            );
            Assert.That(code.Run(), Is.EqualTo(7));
        }

        [Test]
        public void LoadFromStringArray()
        {
            var code = new BootCode(
                "nop +0",
                "jmp +2",
                "acc +4",
                "acc +5",
                "jmp -2",
                "acc -10"
            );
            Assert.That(code.Run(), Is.EqualTo(9));
        }

        [Test]
        public void DayEightExample()
        {
            var input = File.ReadAllLines("TestFiles/DayEightExample.txt");
            var code = new BootCode(input);
            Assert.That(code.Run(), Is.EqualTo(5));
        }
        
        [Test]
        public void DayEightTaskOneAnswer()
        {
            var input = File.ReadAllLines("TestFiles/DayEightInput.txt");
            var code = new BootCode(input);
            Assert.That(code.Run(), Is.EqualTo(1949));
        }
    }
}