﻿using System;
using System.IO;
using AdventOfCode2020.App;
using NUnit.Framework;

namespace AdventOfCode2020.Test
{
    [TestFixture]
    public class ExpenseReportTest
    {
        [Test]
        public void FindEntriesWhichAddTo2020AndReturnEntriesMultipled()
        {
            var report = new ExpenseReport(1721, 979, 366, 299, 675, 1456);
            var result = report.EntriesWhichAddTo2020Multiplied();
            Assert.That(result, Is.EqualTo(514579));
        }
        
        [Test]
        public void CanNotFindEntriesWhichAddTo2020SoReturnInvalid()
        {
            var report = new ExpenseReport(1,2,3,4,5);
            var result = report.EntriesWhichAddTo2020Multiplied();
            Assert.That(result, Is.EqualTo(ExpenseReport.INVALID_RESULT));
        }
        
        [Test]
        public void FindEntriesWhichAddTo2020AndReturnEntriesMultipledFromFile()
        {
            var report = new ExpenseReport("TestFiles/DayOneExample.txt");
            var result = report.EntriesWhichAddTo2020Multiplied();
            Assert.That(result, Is.EqualTo(514579));
        }
        
        [Test]
        public void DayOneAnswer()
        {
            var report = new ExpenseReport("TestFiles/DayOneInput.txt");
            var result = report.EntriesWhichAddTo2020Multiplied();
            //No assert (don't want to give away the answer)
        }
    }
}