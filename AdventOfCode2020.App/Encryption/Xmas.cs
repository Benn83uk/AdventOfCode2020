using System;

namespace AdventOfCode2020.App.Encryption
{
    public class Xmas
    {
        private readonly int _preambleLength;
        private readonly long[] _numbers;

        public Xmas(int preambleLength, long[] numbers)
        {
            _preambleLength = preambleLength;
            _numbers = numbers;
        }

        public long FirstInvalidNumber()
        {
            for (var i = _preambleLength; i < _numbers.Length; i++)
            {
                var numToCheck = _numbers[i];
                var isValid = false;
                for (var x = 0; x < _preambleLength; x++)
                {
                    var firstNumIndex = i - _preambleLength + x;
                    var firstNum = _numbers[firstNumIndex];
                    for (var y = x+1; y < _preambleLength; y++)
                    {
                        var secondNumIndex = i - _preambleLength + y;
                        var secondNum = _numbers[secondNumIndex];
                        Console.WriteLine($"Checking {numToCheck} == {firstNum} + {secondNum}");
                        isValid = (numToCheck == firstNum + secondNum);
                        if (isValid) break;
                    }
                    if (isValid) break;
                }
                if (!isValid) return numToCheck;
            }
            throw new XmasException("No invalid numbers");
        }
    }
}